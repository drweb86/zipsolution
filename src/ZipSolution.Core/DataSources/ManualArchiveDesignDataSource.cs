using System;
using System.Collections.Generic;
using System.Xml;
using HDE.Platform.FileIO;
using HDE.Platform.Logging;
using ZipSolution.Core.Filters;
using ZipSolution.Core.Tree;

namespace ZipSolution.Core.DataSources
{
	/// <summary>
	/// Provides ability to create manual designed archives
	/// </summary>
	public sealed class ManualArchiveDesignDataSource: IDataSource
	{
		#region Fields

        readonly List<PlainTreeRepresentation> _contents;
		
		#endregion
		
		#region Contructors
		
		/// <summary>
		/// The default constructor
		/// </summary>
        /// <exception cref="ArgumentNullException">contents is null</exception>
        public ManualArchiveDesignDataSource(List<PlainTreeRepresentation> contents)
		{
            if (contents == null)
			{
                throw new ArgumentNullException("contents");
			}

            _contents = contents;
		}

        /// <summary>
        /// Loads internal structure from xml reader
        /// </summary>
        /// <param name="basePath">Base path for resolving relative pathes</param>
        /// <param name="node">The opened reader</param>
        public ManualArchiveDesignDataSource(XmlNode node, string basePath)
        {
            _contents = new List<PlainTreeRepresentation>();

            foreach (XmlNode content in node["Contents"])
            {
                string target = RelativePathDiscovery.ResolveRelativePath(content.Attributes["Target"].Value, basePath);
                string locationInArchive = content.Attributes["LocationInArchive"].Value;
                _contents.Add(new PlainTreeRepresentation { Target = target, RelativeFolderInArchive = locationInArchive });
            }
        }
		
		#endregion
		
		#region Public Methods
		
		/// <summary>
		/// Occurs before the second saving of options,
		/// in this place all information f.e. from user should be set
		/// </summary>
		/// <param name="context">Filter context.</param>
		/// <returns>True if packing can continue, otherwise user cancelled operation</returns>
		public bool BeforeProcessing(ProcessingContext context)
		{
			return true;
		}
		
        public List<PlainTreeRepresentation> PrepareZipEntries(ILog log)
		{
            foreach (var item in _contents)
            {
                log.Debug ( 
                    "[+]: {0} <-- {1}", 
                    item.RelativeFolderInArchive, 
                    item.Target);
            }

            return _contents;
		}

        /// <summary>
        /// Saves internal state to supplied xml writer
        /// </summary>
        /// <param name="writer">opened xml writer</param>
        /// <param name="useRelativePathes">flag indicates that relative pathes must be used</param>
        /// <param name="basePath">base path for producing relative pathes</param>
        public void Save(XmlWriter writer, bool useRelativePathes, string basePath)
        {
            writer.WriteStartElement("Contents");

            foreach(var item in _contents)
            {
                writer.WriteStartElement("Element");

                writer.WriteAttributeString("Target", useRelativePathes ? RelativePathDiscovery.ProduceRelativePath(basePath, item.Target) : item.Target);
                writer.WriteAttributeString("LocationInArchive", item.RelativeFolderInArchive);

                writer.WriteEndElement();
            }
            writer.WriteEndElement(); // Contents
        }

		#endregion
	}
}
