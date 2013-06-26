using System.Collections.Generic;
using System.Xml;
using HDE.Platform.Logging;
using ZipSolution.Core.Filters;
using ZipSolution.Core.Tree;

namespace ZipSolution.Core.DataSources
{
	/// <summary>
	/// Provides abilities for getting the zip source.
	/// </summary>
	public interface IDataSource
	{
		/// <summary>
		/// Occurs before the second saving of options,
		/// in this place all information f.e. from user should be set
		/// </summary>
		/// <param name="context">Filter context.</param>
		/// <returns>True if packing can continue, otherwise user cancelled operation</returns>
        bool BeforeProcessing(ProcessingContext context);
		
		/// <summary>
		/// Starts the processing and returnes the dictonary with zip task
		/// </summary>
		/// <param name="log">The log</param>
		/// <returns>Key is file, value is path in an archive</returns>
        List<PlainTreeRepresentation> PrepareZipEntries(ILog log);

        /// <summary>
        /// Saves internal state to supplied xml writer
        /// </summary>
        /// <param name="writer">opened xml writer</param>
        /// <param name="useRelativePathes">flag indicates that relative pathes must be used</param>
        /// <param name="basePath">base path for producing relative pathes</param>
        void Save(XmlWriter writer, bool useRelativePathes, string basePath);
	}
}
