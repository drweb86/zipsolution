using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using BULocalization;
using HDE.Platform.FileIO;
using HDE.Platform.Logging;
using Ionic.Zip;
using SevenZip;
using ZipSolution.Core.Commands.Hg;
using ZipSolution.Core.Configuration;
using ZipSolution.Core.Controller;
using ZipSolution.Core.DataSources;
using ZipSolution.Core.Filters;
using ZipSolution.Core.Misc;
using ZipSolution.Core.Model;
using ZipSolution.Core.View;
using CompressionMode = SevenZip.CompressionMode;

namespace ZipSolution.Core.Commands
{
    /// <summary>
    /// Compresses the contents using the desired filters.
    /// </summary>
    class CompressCommand
    {
        #region Public Methods

        public Successfull Compress(
            CommonController context, 
            ZipSolutionEntry solution, 
            ProcessingContext processingContext,
            Action<long> progressChanged)
        {
            context.Model.Settings.LastZippedSolutionHeader = solution.Header;

            string archiveFileName;

            try
            {
                archiveFileName = generateArchiveName(context, processingContext, solution);
            }
            catch (InvalidOperationException e)
            {
                context.ProcessErrors(e.Message);
                return Successfull.No;
            }

            if (string.IsNullOrEmpty(archiveFileName))
            {
                return Successfull.No;
            }
            else
            {
                context.SaveOptions();
                Thread.Sleep(processingContext.WaitMsec);
                // initing filters
                if (!solution.DataSource.BeforeProcessing(processingContext))
                {
                    return Successfull.No;
                }

                // this call is to save filter values
                context.SaveOptions();

                try
                {
                    string tempFile = createArchive(context, processingContext, solution, progressChanged);
                    if (Settings.OpenArchiveAfterPacking)
                    {
                        string zippedFile = tempFile + ".zip";
                        File.Copy(tempFile, zippedFile);
                        Process.Start(zippedFile);
                    }
                    copyArchiveToStorages(context.Log, tempFile, archiveFileName, solution.TargetFolders.ToArray());
                }
                catch (ThreadAbortException) { throw; }
                catch (CompressionFailedException e) { context.ProcessErrors(e.Message); return Successfull.No; }
                catch (DirectoryNotFoundException e) { context.ProcessErrors(e.Message); return Successfull.No; }
                catch (UnauthorizedAccessException e) { context.ProcessErrors(e.Message); return Successfull.No; }
                catch (IOException e) { context.ProcessErrors(e.Message); return Successfull.No; }
                catch (InvalidOperationException e) { context.ProcessErrors(e.Message); return Successfull.No; }
                catch (ArgumentException e) { context.ProcessErrors(e.Message); return Successfull.No; }
                catch (Exception e) { context.Log.Error(e.ToString()); throw; }

                // support for saving settings for opened solutions from file
                // checking if solution currently processed is not from our old file(case it failed and user chose another file)
                if (!string.IsNullOrEmpty(processingContext.PredefinedSolutionFileToProcess) && !context.Model.Settings.Solutions.Contains(solution))
                {
                    try
                    {
                        XmlSettingsRepresentation.SaveSolution(processingContext.PredefinedSolutionFileToProcess, solution);
                    }
                    catch (DirectoryNotFoundException e) { context.ProcessErrors(e.Message); return Successfull.No; }
                    catch (UnauthorizedAccessException e) { context.ProcessErrors(e.Message); return Successfull.No; }
                    catch (IOException e) { context.ProcessErrors(e.Message); return Successfull.No; }
                    catch (InvalidOperationException e) { context.ProcessErrors(e.Message); return Successfull.No; }
                }

                return Successfull.Yes;
            }
        }

        #endregion

        #region Private Methods

        private static string createArchive(
            CommonController context,
            ProcessingContext processingContext,
            ZipSolutionEntry solutionEntry,
            Action<long> progressChanged
            )
        {
            string tempFile = Path.GetTempFileName();

            var entriesToPack = solutionEntry.DataSource.PrepareZipEntries(context.Log);

            var compressor = new SevenZipCompressor
                                 {
                                     CompressionMode = CompressionMode.Create,
                                     ArchiveFormat = solutionEntry.OutArchiveFormat,
                                     CompressionMethod = solutionEntry.CompressionMethod,
                                     CompressionLevel = solutionEntry.CompressionLevel,
                                 };
            compressor.Compressing += (s, e) => progressChanged(e.PercentDone);

            // custom packing with support of empty folders
            if (solutionEntry.DataSource is FolderAndFiltersDataSource)
            {
                var typedSource = (FolderAndFiltersDataSource) solutionEntry.DataSource;
                var items = new List<string>();
                foreach (var item in entriesToPack)
                {
                    if (File.Exists(item.Target))
                    {
                        notifyAddItemToArchive(context.Log, item.Target, item.RelativeFolderInArchive);
                        items.Add(item.Target);
                    }
                    else if (Directory.Exists(item.Target)) // empty dir
                    {
                        items.Add(item.Target);
                    }
                }

                compressor.IncludeEmptyDirectories = true;
                compressor.EncryptHeaders = true;
                compressor.ZipEncryptionMethod = ZipEncryptionMethod.Aes256;
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
                using (var stream = File.OpenWrite(tempFile))
                {
                    compressor.CompressDirItems(
                        typedSource.SolutionFolder,
                        stream,
                        items.ToArray(),
                        processingContext.Password);
                }
            }
            else
            {
                var archiveContents = new Dictionary<string, string>();
                var keys = new List<string>();

                foreach (var item in entriesToPack)
                {
                    if (File.Exists(item.Target))
                    {
                        addItemToArchive(
                            context.Log,

                            archiveContents,
                            keys,

                            Path.Combine(item.RelativeFolderInArchive, Path.GetFileName(item.Target)),
                            item.Target);
                    }
                    else
                    {
                        // Directory.
                        var filesInDir = Directory.GetFiles(item.Target, "*.*", SearchOption.AllDirectories);
                        foreach (var fileInDir in filesInDir)
                        {
                            context.Log.Debug(Translation.Current[90], fileInDir, item.RelativeFolderInArchive);

                            var pathFileNameInArchive = RelativePathDiscovery.ProduceRelativePath(item.Target, fileInDir);
                            if (!string.IsNullOrEmpty(item.RelativeFolderInArchive))
                            {
                                pathFileNameInArchive = Path.Combine(item.RelativeFolderInArchive, pathFileNameInArchive);
                            }

                            addItemToArchive(
                                context.Log,

                                archiveContents,
                                keys,

                                pathFileNameInArchive,
                                fileInDir);
                        }
                    }
                }

                if (!string.IsNullOrEmpty(processingContext.Password))
                {
                    compressor.EncryptHeaders = true;
                    compressor.ZipEncryptionMethod = ZipEncryptionMethod.Aes256;
                    compressor.CompressFileDictionary(archiveContents, tempFile, processingContext.Password);
                }
                else
                {
                    compressor.CompressFileDictionary(archiveContents, tempFile);
                }
            }
            

            return tempFile;
        }

        private static void notifyAddItemToArchive(
            ILog log,
            string relativePath, 
            string file)
        {
            log.Debug(Translation.Current[90], file, relativePath);
        }

        private static void addItemToArchive(
            ILog log,

            Dictionary<string, string> archiveTask, 
            List<string> lowerCaseKeys,

            string relativePath, 
            string file)
        {
            var lowerCaseKey = relativePath.ToLowerInvariant();
            if (lowerCaseKeys.Contains(lowerCaseKey))
            {
                log.Warning(Translation.Current[101], relativePath, file);
            }
            else
            {
                log.Debug (Translation.Current[90], file, relativePath);
                lowerCaseKeys.Add(lowerCaseKey);
                archiveTask.Add(relativePath, file);
            }
        }

        private static void copyArchiveToStorages(ILog log, string file, string targetFilename, string[] storages)
        {
            log.Debug(Translation.Current[91], targetFilename);
            var builder = new StringBuilder();

            storages
                .AsParallel()
                .ForAll(folder => copyToStorage(log, folder, targetFilename, file, builder));

            File.Delete(file);

            if (builder.Length > 0)
            {
                log.Error(builder.ToString());
                throw new InvalidOperationException(builder.ToString());
            }
        }

        private static void copyToStorage(ILog log, string folder, string targetFilename, string file, StringBuilder builder)
        {
            try
            {
                log.Debug(Translation.Current[92], folder);
                string resultFile = Path.Combine(folder, targetFilename);
                File.Delete(resultFile);
                File.Copy(file, resultFile);
            }
            catch (ArgumentException e)
            {
                processException(folder, builder, e);
            }
            catch (UnauthorizedAccessException e)
            {
                processException(folder, builder, e);
            }
            catch (DirectoryNotFoundException e)
            {
                processException(folder, builder, e);
            }
            catch (IOException e)
            {
                processException(folder, builder, e);
            }
        }

        private static void processException(string folder, StringBuilder builder, Exception e)
        {
            lock (builder)
            {
                builder.Append(folder);
                builder.Append(": ");
                builder.Append(e.Message);
                builder.Append(Environment.NewLine);
            }
        }

        private static string generateArchiveName(
            CommonController context,
            ProcessingContext processingContext,
            ZipSolutionEntry solution)
        {
            if (solution == null)
            {
                throw new ArgumentNullException("solution");
            }

            string archiveFileName;

            if (processingContext.UseReleaseConfiguration)
            {
                archiveFileName = solution.ZipFileNameTemplateStrings.Release;
            }
            else
            {
                archiveFileName = solution.ZipFileNameTemplateStrings.Debug;
            }

            int datePos = archiveFileName.IndexOf(SupportedReplacements.Date, StringComparison.OrdinalIgnoreCase);

            if (datePos > -1)
            {
                archiveFileName = archiveFileName.Remove(datePos, SupportedReplacements.Date.Length);
                archiveFileName = archiveFileName.Insert(datePos,
                                                         DateTime.Now.ToString(
                                                            context.Model.Settings.ReplaceTimeFormatString,
                                                            CultureInfo.CreateSpecificCulture("en-US")));
            }

            var filterSource = solution.DataSource as FolderAndFiltersDataSource;
            if (filterSource != null)
            {
                if (SupportedReplacements.HasTortoiseSvnIntegration(archiveFileName))
                {
                    archiveFileName = SupportedReplacements.ResolveTortoiseSvnIntegration(
                        archiveFileName,
                        TortoiseSvnInteropHelper.ExtractRevision(filterSource.SolutionFolder));
                }

                if (SupportedReplacements.HasHgIntegration(archiveFileName))
                {
                    archiveFileName = SupportedReplacements.ResolveHgIntegration(
                        archiveFileName,
                        HgHelper.GetHgInfo(HgHelper.FindHg(), filterSource.SolutionFolder));
                }
            }

            int versionPos = archiveFileName.IndexOf(SupportedReplacements.Version, StringComparison.OrdinalIgnoreCase);
            if (versionPos > -1)
            {
                archiveFileName = archiveFileName.Remove(versionPos, SupportedReplacements.Version.Length);

                string targetVersion;
                if (!string.IsNullOrEmpty(processingContext.ExtractVersionFromAssemblyInfoCsFile))
                {
                    targetVersion = context.LoadVersionFromAssemblyInfoCs(processingContext.ExtractVersionFromAssemblyInfoCsFile);
                }
                else if (!string.IsNullOrEmpty(processingContext.ExtractVersionFromAssemblyFile))
                {
                    targetVersion = context.LoadVersionFromAssembly(processingContext.ExtractVersionFromAssemblyFile);
                }
                else if (!string.IsNullOrEmpty(processingContext.PredefinedAnswerForVersionRequestDialog))
                {
                    targetVersion = processingContext.PredefinedAnswerForVersionRequestDialog;
                }
                else
                {
                    targetVersion = string.Empty;
                    using (var form = context.CreateView<IRequestVersionView>())
                    {
                        form.Init(solution.PreviousVersion);
                        if (form.Process())
                        {
                            targetVersion = form.Version;
                        }
                    }
                }

                solution.PreviousVersion = targetVersion;
                archiveFileName = archiveFileName.Insert(versionPos, targetVersion);
            }

            int incrementPos = archiveFileName.IndexOf(SupportedReplacements.Increment, StringComparison.OrdinalIgnoreCase);

            if (incrementPos > -1)
            {
                archiveFileName = archiveFileName.Remove(incrementPos, SupportedReplacements.Increment.Length);
                archiveFileName = archiveFileName.Insert(incrementPos, solution.ProduceNewIncrement().ToString(CultureInfo.CurrentCulture));
            }

            return archiveFileName;
        }

        #endregion
    }
}
