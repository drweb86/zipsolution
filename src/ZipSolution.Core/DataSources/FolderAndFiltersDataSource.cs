using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;
using HDE.Platform.FileIO;
using HDE.Platform.Logging;
using ZipSolution.Core.Controller;
using ZipSolution.Core.Filters;
using ZipSolution.Core.Tree;
using ZipSolution.Core.Tree.Nodes;
using System.Linq;

namespace ZipSolution.Core.DataSources
{
	/// <summary>
	/// Provides ability to configure and use the filter with applying custom filters
	/// </summary>
	public sealed class FolderAndFiltersDataSource: IDataSource
    {
        #region Fields

        readonly string _solutionFolder;
		readonly Collection<FilterConfiguration> _filtersChain = new Collection<FilterConfiguration>();
        [NonSerializedAttribute]
        List<IFilter> _filterInstances;

        #endregion

        #region Public Properties

        /// <summary>
        /// The root path to which filters will be applied used to create zip archive
        /// </summary>
		public string SolutionFolder
		{
			get { return _solutionFolder; }
		}

        /// <summary>
        /// Filters configuration chain
        /// </summary>
		public IEnumerable<FilterConfiguration> Filters
		{
			get { return new ReadOnlyCollection<FilterConfiguration>(_filtersChain); }
		}

        public IEnumerable<IFilter> FilterInstances
        {
            get { return _filterInstances; }
        }

        #endregion

        #region Contructors

        public FolderAndFiltersDataSource(
            string solutionFolder, 
			Collection<FilterConfiguration> filters)
		{
			if (string.IsNullOrEmpty(solutionFolder))
			{
				throw new ArgumentNullException("solutionFolder");
			}
			
			if (filters == null)
			{
				throw new ArgumentNullException("filters");
			}

			_solutionFolder = solutionFolder;
			_filtersChain = filters;
		}
		
        /// <summary>
        /// Loads internal structure from xml reader
        /// </summary>
        /// <param name="node">The opened reader</param>
        /// <param name="basePath">Base path for resolving relative pathes</param>
        public FolderAndFiltersDataSource(XmlNode node, string basePath)
        {
            var relativeSolutionFolder = node.Attributes["SolutionFolder"].InnerText;
            if (string.IsNullOrEmpty(relativeSolutionFolder))
            {
                relativeSolutionFolder = " ";
            }

            _solutionFolder = RelativePathDiscovery.ResolveRelativePath(relativeSolutionFolder, basePath);

            foreach (XmlNode element in node["Filters"])
            {
                _filtersChain.Add(
                    new FilterConfiguration(
                        (Kind)Enum.Parse(typeof(Kind),
                        element.Attributes["Affected"].Value),
                        (FilterAction)Enum.Parse(typeof(FilterAction),
                        element.Attributes["Action"].Value),
                        element.Attributes["Parameter"].Value));
            }
        }

        #endregion

        #region IDataSource implementation

        /// <summary>
		/// Occurs before the second saving of options,
		/// in this place all information f.e. from user should be set
		/// </summary>
		/// <param name="context">Filter context.</param>
		/// <returns>True if packing can continue, otherwise user cancelled operation</returns>
        bool IDataSource.BeforeProcessing(ProcessingContext context)
		{
			_filterInstances = new List<IFilter>();
			foreach (FilterConfiguration filterEntry in _filtersChain)
			{
				IFilter filter = filterEntry.CreateFilter();
				_filterInstances.Add(filter);

                if (!filter.Init(context))
				{
					return false;
				}
			}
			return true;
		}
		
		/// <summary>
		/// Starts the processing and returnes the dictonary with zip task
		/// </summary>
		/// <returns>Key is file, value is folder</returns>
		List<PlainTreeRepresentation> IDataSource.PrepareZipEntries(ILog log)
		{
			var solutionManager = new TreeManager(SolutionFolder, log);
		    var filters = FilterInstances
		        .OrderByDescending(filter=> filter.IsElementNameFilter )
		        .ToArray();
		    var root = solutionManager.Load(filters);
            return TreeManager.ProduceZipTasks(root);
		}

        /// <summary>
        /// Saves internal state to supplied xml writer
        /// </summary>
        /// <param name="writer">opened xml writer</param>
        /// <param name="useRelativePathes">flag indicates that relative pathes must be used</param>
        /// <param name="basePath">base path for producing relative pathes</param>
        void IDataSource.Save(XmlWriter writer, bool useRelativePathes, string basePath)
        {
            writer.WriteAttributeString("SolutionFolder", useRelativePathes ? RelativePathDiscovery.ProduceRelativePath(basePath, SolutionFolder) : SolutionFolder);

            writer.WriteStartElement("Filters");
            foreach (FilterConfiguration filter in Filters)
            { 
                writer.WriteStartElement("Filter");

                writer.WriteAttributeString("Action", filter.FilterAction.ToString());
                writer.WriteAttributeString("Affected", filter.Affected.ToString());
                writer.WriteAttributeString("Parameter", filter.Parameter);

                writer.WriteEndElement(); // Filter
            }
            writer.WriteEndElement(); // Filters
        }

        #endregion
    }
}
