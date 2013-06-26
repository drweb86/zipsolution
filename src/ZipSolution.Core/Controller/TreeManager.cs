using System;
using System.Collections.Generic;
using System.IO;
using System.Collections.ObjectModel;
using HDE.Platform.Logging;
using ZipSolution.Core.Filters;
using ZipSolution.Core.Tree;
using ZipSolution.Core.Tree.Nodes;

namespace ZipSolution.Core.Controller
{
    /// <summary>
    /// Manages tree.
    /// </summary>
	public sealed class TreeManager
    {
        #region Fields

        private readonly DirectoryElement _rootFolder;
	    private readonly ILog _log;

        #endregion

        #region Constructors

        public TreeManager(string rootFolder, ILog log)
        {
            if (string.IsNullOrEmpty(rootFolder))
            {
                throw new ArgumentNullException("rootFolder");
            }

            if (rootFolder.EndsWith(@"\", StringComparison.Ordinal))
            {
                rootFolder = rootFolder.Substring(0, rootFolder.Length - 1);
            }
            _log = log;
            _rootFolder = new DirectoryElement(rootFolder);
        }

        #endregion

        #region Public Methods

        public static List<PlainTreeRepresentation> ProduceZipTasks(Element rootElement)
		{
			if (rootElement == null)
			{
				throw new ArgumentNullException("rootElement");
			}

            List<PlainTreeRepresentation> files = new List<PlainTreeRepresentation>();
            produceZipTasks(rootElement, files, string.Empty, rootElement.Name);

            return files;
		}
        
        public DirectoryElement Load(IFilter[] nameFilters)
        {
            _rootFolder.DeleteChilds();

            gatherFolder(_rootFolder, nameFilters);

            return _rootFolder;
        }

        #endregion

        #region Private Methods

        private static void produceZipTasks(Element element, List<PlainTreeRepresentation> dictionary, string relativePath, string excludeRelativePath)
		{
			if (element.Kind == Kind.File)
			{
			    var acrhiveRelPath = !string.IsNullOrEmpty(excludeRelativePath)
			                             ? relativePath
                                            .Substring(excludeRelativePath.Length)
                                            .TrimStart('\\')
			                             : relativePath;
                dictionary.Add(new PlainTreeRepresentation 
                { 
                    Target = element.FullName,
                    RelativeFolderInArchive = acrhiveRelPath
                });
			}
			else
			{
				ReadOnlyCollection<Element> nodes = element.ChildNodes;
                string currentRelativePath = Path.Combine(relativePath, element.Name);
                if (nodes.Count == 0) // empty folder
                {
                    dictionary.Add(new PlainTreeRepresentation
                    {
                        Target = element.FullName,
                        RelativeFolderInArchive = currentRelativePath
                    });
                }
                else
                {
                    foreach (Element node in nodes)
                    {
                        produceZipTasks(node, dictionary, currentRelativePath, excludeRelativePath);
                    }
                }
			}
		}
		
		private void gatherFolder(DirectoryElement folderElement, IFilter[] nameFilters)
		{
			string[] folders = Directory.GetDirectories(folderElement.FullName);
			string[] files = Directory.GetFiles(folderElement.FullName);
			
			foreach (string file in files)
			{
			    var fileElement = new FileElement(file);

                if (!passFilter(fileElement, nameFilters))
                {
                    _log.Debug ("[-]: {0}", file);
                    continue;
                }
                _log.Debug ("[+]: {0}", file);
				folderElement.AppendChild(fileElement);
			}
			
			foreach (string folder in folders)
			{
			    var dirElement = new DirectoryElement(folder);

                if (!passFilter(dirElement, nameFilters))
                {
                    _log.Debug ("[-]: {0}", folder);
                    continue;
                }
                _log.Debug("[+]: {0}", folder);

				gatherFolder((DirectoryElement)folderElement.AppendChild(dirElement), nameFilters);
			}
		}

	    private static bool passFilter(Element element, IEnumerable<IFilter> filters)
	    {
            foreach (var filter in filters)
	        {
                filter.Apply(element);
	            if (element.CheckStatus == ElementStatus.Exclude)
	            {
	                return false;
	            }
	        }
	        return true;
        }

        #endregion
    }
}
