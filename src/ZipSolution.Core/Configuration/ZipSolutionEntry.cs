using System;
using System.Collections.ObjectModel;
using ZipSolution.Core.DataSources;
using SevenZip;

namespace ZipSolution.Core.Configuration
{
    /// <summary>
    /// Contains project.
    /// </summary>
	public sealed class ZipSolutionEntry
    {
        #region Fields

		readonly Collection<string> _targetFolders = new Collection<string>();
		string _previousVersion = string.Empty;

        #endregion

        #region Properties

        public string Header { get; private set; }

        public OutArchiveFormat OutArchiveFormat { get; set; }
        public CompressionMethod CompressionMethod { get; set; }
        public CompressionLevel CompressionLevel { get; set; }

        /// <summary>
        /// Increment of a zipping operation
        /// </summary>
        public int Increment { get; private set; }

		public IDataSource DataSource { get; private set; }

        public string PreviousVersion
		{
			get { return _previousVersion; }
			set { _previousVersion = value; }
		}
		
		public ZipFileFormatStrings ZipFileNameTemplateStrings { get; private set; }
		
		public ReadOnlyCollection<string> TargetFolders
		{
			get { return new ReadOnlyCollection<string>(_targetFolders); }
		}
		
		public int ProduceNewIncrement()
		{
		    Increment++;
		    return Increment;
		}

        #endregion

        #region Constructors

        public ZipSolutionEntry(
			string header, 

            OutArchiveFormat outArchiveFormat,
            CompressionMethod compressionMethod,
            CompressionLevel compressionLevel,

			ZipFileFormatStrings zipFileNameTemplateStrings, 
			Collection<string> targetFolders,
			IDataSource dataSource,
            int increment)
		{
            if (dataSource == null)
			{
				throw new ArgumentNullException("dataSource");
			}
			
			if (string.IsNullOrEmpty(header))
			{
				throw new ArgumentNullException("header");
			}
			
			if (zipFileNameTemplateStrings == null)
			{
				throw new ArgumentNullException("zipFileNameTemplateStrings");
			}
			
			if (targetFolders == null)
			{
				throw new ArgumentNullException("targetFolders");
			}
			
			if (targetFolders.Count == 0 &&
                header != "Template")
			{
				throw new ArgumentNullException("targetFolders");
			}

            Header = header;
            OutArchiveFormat = outArchiveFormat;
            CompressionMethod = compressionMethod;
            CompressionLevel = compressionLevel;
            ZipFileNameTemplateStrings = zipFileNameTemplateStrings;
			_targetFolders = targetFolders;
            DataSource = dataSource;
            Increment = increment;
        }

        #endregion
    }
}
