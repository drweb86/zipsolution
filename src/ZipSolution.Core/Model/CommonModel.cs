using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using BULocalization;
using ZipSolution.Core.Configuration;
using ZipSolution.Core.Filters;

namespace ZipSolution.Core.Model
{
    /// <summary>
    /// Common Model.
    /// </summary>
    public class CommonModel
    {
#if DEBUG
        public const string SettingsFileName = "dev-settings.xml";
#else
        public const string SettingsFileName = "settings.xml";
#endif

        #region Properties

        public KeyValueConfigurationCollection Configuration { get; internal set; }
        public string GetAppConfigSetting(string key)
        {
            foreach (KeyValueConfigurationElement pair in Configuration)
            {
                if (string.Compare(pair.Key,key, StringComparison.OrdinalIgnoreCase)==0)
                {
                    return pair.Value;
                }
            }
            throw new ConfigurationErrorsException(string.Format("Key {0} not found", key));
        }

        public Settings Settings { get; set;}
        public string SettingsXmlFile { get; internal set;}
        public LanguagesManager LocalsManager { get; set; }

        public string LastZippedSolutionHeader
        {
            get { return Settings.LastZippedSolutionHeader; }
        }

        /// <summary>
        /// The source for default settings such as default strings for
        /// debug and release strings, filters list
        /// </summary>
        public ZipSolutionEntry TemplateSolutionSettings
        {
            get { return Settings.TemplateSolutionSettings; }
            set { Settings.TemplateSolutionSettings = value; }
        }

        /// <summary>
        /// Default filters chain for filtered data source
        /// </summary>
        public IEnumerable<FilterConfiguration> DefaultFiltersList
        {
            get { return Settings.DefaultFiltersList; }
        }

        public string DefaultInternalPurposeFormatString
        {
            get { return Settings.DefaultInternalPurposeFormatString; }
        }

        public string DefaultReleaseFormatString
        {
            get { return Settings.DefaultReleaseFormatString; }
        }

        public string LastModificationsDialogTimeFormatString { get; set; }
        
        #endregion

        #region Public Methods

        public ZipSolutionEntry GetSolution(string header)
        {
            return Settings.GetSolution(header);
        }

        public string[] GetSolutionHeaders()
        {
            return Settings.Solutions
                .Select(solution=>solution.Header)
                .ToArray();
        }

        #endregion
    }
}
