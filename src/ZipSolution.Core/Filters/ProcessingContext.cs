using System;

namespace ZipSolution.Core.Filters
{
    /// <summary>
    /// Filter context used for accessing different operations by filters.
    /// </summary>
    public class ProcessingContext
    {
        /// <summary>
        /// Uses the release template string during packing of solution
        /// </summary>
        public bool UseReleaseConfiguration { get; set; }

        /// <summary>
        /// Predefines version extraction from .net assembly file. Extracted version set to PredefinedAnswerForVersionRequestDialog
        /// </summary>
        public string ExtractVersionFromAssemblyFile { get; set; }

        /// <summary>
        /// Predefines version
        /// </summary>
        public string PredefinedAnswerForVersionRequestDialog { get; set; }

        public DateTime? PredefinedDateTimeForDateFilterStartTimeRequestDialog { get; set; }

        /// <summary>
        /// Allows to specify by command line arguments the target project name.
        /// Predefined which project to process
        /// </summary>
        public string PredefinedProjectToProcess { get; set; }

        /// <summary>
        /// Password for archives encryption. When setted all archives contents will be encrypted
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Wait msec
        /// </summary>
        public int WaitMsec { get; set; }

        /// <summary>
        /// Predefines version extraction from AssemblyInfo.cs file. Extracted version set to PredefinedAnswerForVersionRequestDialog
        /// </summary>
        public string ExtractVersionFromAssemblyInfoCsFile { get; set; }

        /// <summary>
        /// Last write or create time will be used for filter by time dialog
        /// </summary>
        public DateTime LastChangeTime { get; set; }

        /// <summary>
        /// Predefined task file to process
        /// </summary>
        public string PredefinedSolutionFileToProcess { get; set; }
    }
}