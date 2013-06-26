using System;
using HDE.Platform.Logging;
using ZipSolution.Core.DataSources;
using ZipSolution.Core.Filters;

namespace ZipSolution.UI
{
	/// <summary>
	/// Common interface for configuring controls.
	/// </summary>
	interface IDataSourceConfig
	{
		/// <summary>
		/// Checks the data and shows the message to the user if it is not valid.
		/// </summary>
		/// <returns>True if all's OK.</returns>
		bool ValidStorageState();
		
		/// <summary>
		/// Data source.
		/// </summary>
		IDataSource DataSource { get; set; }
		
		/// <summary>
		/// Inits the control state.
		/// </summary>
		/// <param name="log">The opened log</param>
        /// <param name="showError">Shows error.</param>
        /// <param name="addFilter">Adds filter to filter control.</param>
        void Init(ILog log, 
            Action<string> showError,
            Func<FilterConfiguration> addFilter);
	}
}
