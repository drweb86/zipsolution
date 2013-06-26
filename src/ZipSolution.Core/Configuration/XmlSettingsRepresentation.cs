using System;
using System.Text;
using System.Xml;
using System.IO;
using System.Collections.ObjectModel;
using HDE.Platform.FileIO;
using HDE.Platform.Logging;
using SevenZip;
using ZipSolution.Core.DataSources;
using ZipSolution.Core.Filters;
using ZipSolution.Core.Misc;

namespace ZipSolution.Core.Configuration
{
    /// <summary>
    /// Produces xml representation and loads from it user specific settings 
    /// </summary>
    public static class XmlSettingsRepresentation
    {
        /// <summary>
        /// Stores user specific settings in xml format
        /// </summary>
        /// <param name="settings">Settings instance</param>
        /// <param name="file">Target file</param>
        /// <exception cref="ArgumentNullException">settings or file is null or empty</exception>
        public static void SaveUserSpecificSettings(Settings settings, string file)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            if (string.IsNullOrEmpty(file))
            {
                throw new ArgumentNullException("file");
            }

            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;
            xmlSettings.Encoding = Encoding.Unicode;
            xmlSettings.IndentChars = ("    ");
            XmlWriter writer = XmlWriter.Create(file, xmlSettings);

            writer.WriteStartElement("XML");

            writer.WriteStartElement("General");
            writer.WriteElementString("Language", settings.Language);
            writer.WriteElementString("LastZippedSolutionHeader", settings.LastZippedSolutionHeader);
            SaveSolution(writer, settings.TemplateSolutionSettings, false, string.Empty); 

            writer.WriteEndElement(); // General

            writer.WriteStartElement("Solutions");

            foreach (var solution in settings.Solutions)
            {
                SaveSolution(writer, solution, false, string.Empty); 
            }

            writer.WriteEndElement();//Solutions

            writer.WriteEndElement();//xml
            // language
            writer.Flush();
            writer.Close();
        }

        /// <summary>
        /// Saves the solution to specified file
        /// </summary>
        /// <param name="file">target xml file</param>
        /// <param name="solution">target solution</param>
        public static void SaveSolution(string file, ZipSolutionEntry solution)
        {
            if (solution == null)
            {
                throw new ArgumentNullException("solution");
            }

            if (string.IsNullOrEmpty(file))
            {
                throw new ArgumentNullException("file");
            }

            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;
            xmlSettings.Encoding = Encoding.Unicode;
            xmlSettings.IndentChars = ("    ");
            XmlWriter writer = XmlWriter.Create(file, xmlSettings);

            writer.WriteStartElement("XML");

            SaveSolution(writer, solution, true, Directory.GetParent(file).FullName);

            writer.WriteEndElement();//xml
            writer.Flush();
            writer.Close();
        }

        static void SaveSolution(XmlWriter writer, ZipSolutionEntry solution, bool useRelativePathes, string basePath)
        {
            writer.WriteStartElement("Solution");

            writer.WriteAttributeString("name", solution.Header);

            writer.WriteElementString("OutArchiveFormat", solution.OutArchiveFormat.ToString());
            writer.WriteElementString("CompressionMethod", solution.CompressionMethod.ToString());
            writer.WriteElementString("CompressionLevel", solution.CompressionLevel.ToString());

            writer.WriteElementString("PreviousVersion", solution.PreviousVersion);
            writer.WriteElementString("Increment", solution.Increment.ToString());
            writer.WriteStartElement("ZipFileNameTemplateStrings");

            writer.WriteElementString("InternalPurpose", solution.ZipFileNameTemplateStrings.Debug);
            writer.WriteElementString("Release", solution.ZipFileNameTemplateStrings.Release);

            writer.WriteEndElement();//ZipFileNameTemplateStrings

            writer.WriteStartElement("TargetFolders");

            foreach (var targetFolder in solution.TargetFolders)
            {
                writer.WriteElementString("TargetFolder", useRelativePathes ? RelativePathDiscovery.ProduceRelativePath(basePath, targetFolder) : targetFolder);
            }

            writer.WriteEndElement();// TargetFolders
            
            writer.WriteStartElement("DataSource");
            writer.WriteAttributeString("Type", solution.DataSource.GetType().Name);
            
            solution.DataSource.Save(writer, useRelativePathes, basePath);

            writer.WriteEndElement();// TargetFolders

            writer.WriteEndElement();// Solution
        }

        public static ZipSolutionEntry LoadSolution(ILog log, string file)
        {
            var readersettings = new XmlReaderSettings();
            readersettings.ConformanceLevel = ConformanceLevel.Fragment;
            readersettings.IgnoreWhitespace = true;
            readersettings.IgnoreComments = true;

            XmlReader reader = XmlReader.Create(file, readersettings);
            XmlDocument document = new XmlDocument();
            document.Load(reader);
            reader.Close();

            return LoadSolution(log, document.SelectSingleNode("/XML/Solution"), Path.GetDirectoryName(file));
        }

        static ZipSolutionEntry LoadSolution(ILog log, XmlNode node, string basePath)
        {
            string name = node.Attributes["name"].Value;
            string previousVersion = node["PreviousVersion"].InnerText;
            var incrementNode = node["Increment"];
            int increment = int.Parse((incrementNode == null) ? "0" : node["Increment"].InnerText);// '0' is for support of legacy configs of 5.x versions
            string innerPurposeTemplateString = node["ZipFileNameTemplateStrings"]["InternalPurpose"].InnerText;
            string releasePurposeTemplateString = node["ZipFileNameTemplateStrings"]["Release"].InnerText;
            Collection<string> targetFolders = new Collection<string>();
            foreach(XmlNode targetFolderNode in node["TargetFolders"])
            {
                targetFolders.Add(RelativePathDiscovery.ResolveRelativePath(targetFolderNode.InnerText, basePath));
            }

            IDataSource dataSource;
            string type = node["DataSource"].Attributes["Type"].Value;
            switch (type)
            {
                case "FolderAndFiltersDataSource":
                    dataSource = new FolderAndFiltersDataSource(node["DataSource"], basePath);
                    break;
                case "ManualArchiveDesignDataSource":
                    dataSource = new ManualArchiveDesignDataSource(node["DataSource"], basePath);
                    break;
                default:
                    throw new NotImplementedException(string.Format("Type of storage '{0}' is not supported!", type));
            }

            // new settings for 5.7+ (fail safe loading)
            var outArchiveFormat = ParseOutArchiveFormat(log, node);
            var compressionMethod = ParseCompressionMethod(log, node, outArchiveFormat);
            var compressionLevel = ParseCompressionLevel(log, node, outArchiveFormat, compressionMethod);
            // end new settings for 5.7

            return new ZipSolutionEntry(
                name, 
                outArchiveFormat, 
                compressionMethod, 
                compressionLevel, 
                new ZipFileFormatStrings(innerPurposeTemplateString, releasePurposeTemplateString), targetFolders, dataSource, increment)
                            {
                                PreviousVersion = previousVersion
                            };
        }

        /// <summary>
        /// Reads settings from file
        /// </summary>
        /// <param name="settings">Instance of settings</param>
        /// <param name="file">file with settings</param>
        public static void LoadUserSpecificSettings(ILog log, Settings settings, string file)
        {
            // reading xml options
			var readersettings = new XmlReaderSettings();
			readersettings.ConformanceLevel = ConformanceLevel.Fragment;
			readersettings.IgnoreWhitespace = true;
			readersettings.IgnoreComments = true;
            
            XmlReader reader = XmlReader.Create(file, readersettings);
            XmlDocument userSettings = new XmlDocument();
            userSettings.Load(reader);
            reader.Close();

            var langNode = userSettings.SelectSingleNode(@"/XML/General/Language");
            settings.Language = langNode != null ? langNode.InnerText : string.Empty;
            var lastZippedSolutionHeaderNode = userSettings.SelectSingleNode(@"/XML/General/LastZippedSolutionHeader");
            settings.LastZippedSolutionHeader = lastZippedSolutionHeaderNode != null ? lastZippedSolutionHeaderNode.InnerText : string.Empty;

            settings.TemplateSolutionSettings = LoadSolution(log, userSettings.SelectSingleNode(@"/XML/General/Solution"), Path.GetDirectoryName(file));
            
            var solutionsNodes = userSettings.SelectNodes(@"/XML/Solutions/Solution");
            foreach (XmlNode node in solutionsNodes)
            { 
                settings.AddSolution(LoadSolution(log, node, Path.GetDirectoryName(file)));
            }
            //FolderAndFiltersDataSource
        }

        #region Private Methods

        static CompressionLevel ParseCompressionLevel(
            ILog log, 
            XmlNode solutionNode, 
            OutArchiveFormat archiveFormat,
            CompressionMethod method)
        {
            var node = solutionNode["CompressionLevel"];
            CompressionLevel result;
            if (node != null &&
                Enum.TryParse(node.InnerText, out result))
            {
                if (CompressionHelper.IsAllowedCompressionLevel(archiveFormat, method, result))
                {
                    return result;
                }
                log.Error("Invalid compression level was supplied: method {0}; compression level {1}. Good default is taken.", archiveFormat, result);
            }

            return CompressionHelper.GetCompressionLevelGoodDefault(archiveFormat, method);
        }
        
        static CompressionMethod ParseCompressionMethod(ILog log, XmlNode solutionNode, OutArchiveFormat archiveFormat)
        {
            var node = solutionNode["CompressionMethod"];
            CompressionMethod result;
            if (node != null &&
                Enum.TryParse(node.InnerText, true, out result))
            {
                if (CompressionHelper.IsAllowedCompressionMethod(archiveFormat, result))
                {
                    return result;
                }
                log.Error("Invalid compression method was supplied: method {0}; compression level {1}. Good default is taken.", archiveFormat, result);
            }

            return CompressionHelper.GetCompressionMethodGoodDefault(archiveFormat);
        }

        static OutArchiveFormat ParseOutArchiveFormat(ILog log, XmlNode solutionNode)
        {
            var node = solutionNode["OutArchiveFormat"];
            OutArchiveFormat result;
            if (node != null &&
                Enum.TryParse(node.InnerText, true, out result))
            {
                if (CompressionHelper.IsSupportedOutArchiveFormat(result))
                {
                    return result;
                }
                log.Error("Invalid out archive type was specified: {0}. Good default is taken.", result);
            }

            return OutArchiveFormat.Zip;
        }

        #endregion
    }
}
