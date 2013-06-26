using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using BULocalization;
using SevenZip;
using ZipSolution.Core.Controller;
using ZipSolution.Core.DataSources;
using ZipSolution.Core.Filters;
using ZipSolution.Core.Misc;
using ZipSolution.Core.Tree.Nodes;

namespace ZipSolution.Core.Configuration
{
#warning: remove static props!

	public sealed class Settings
	{
		#region Command Line Arguments Settings

        private static string _settingsFolder = string.Empty;

        /// <summary>
        /// Allows to specify by command line arguments the target project name.
        /// Predefined which project to process
        /// </summary>
        public static string SettingsFolder 
        { 
            get { return _settingsFolder; }
            set { _settingsFolder = value; }
        }

        /// <summary>
        /// Opens an archive after packing (this is for testing of project only)
        /// </summary>
        public static bool OpenArchiveAfterPacking { get; set; }

		#endregion
		
		#region Application Configuration Settings (app.config)

		private const string _ReplaceTimeFormatStringConfig = "ReplaceTimeFormat";
		private const string _LastModificationsTimeFormatStringConfig = "LastModificationsTimeFormatString";
		private const string _ProgramCultureConfig = "ProgramCulture";
        private const string _ShowTextInToolbarsConfig = "ShowTextInToolbars";
		
		private string _lastModificationsDialogTimeFormatString;
        private static bool _showTextInToolbars;
		
		private string _replaceTimeFormatString;

        public static bool ShowTextInToolbars
        {
            get { return _showTextInToolbars; }
            private set { _showTextInToolbars = value; }
        }
		
        /// <summary>
        /// Gets the default filters for solution filters
        /// </summary>
		public IEnumerable<FilterConfiguration> DefaultFiltersList
		{
			get { return ((FolderAndFiltersDataSource)TemplateSolutionSettings.DataSource).Filters; }
		}
		
		public string DefaultInternalPurposeFormatString
		{
			get { return TemplateSolutionSettings.ZipFileNameTemplateStrings.Debug; }
		}
		
		public string DefaultReleaseFormatString
		{
            get { return TemplateSolutionSettings.ZipFileNameTemplateStrings.Release; }
		}
		
		public string LastModificationsDialogTimeFormatString
		{
			get { return _lastModificationsDialogTimeFormatString; }
		}
		
		public string ReplaceTimeFormatString
		{
			get { return _replaceTimeFormatString; }
		}
		
		#endregion
		
		#region Autodetecion Settings

        private static string _localsPath;
		
		public static string PathToLocals
		{
			get 
            { 
                if (string.IsNullOrEmpty(_localsPath))
                {
                    _localsPath = Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), "locals");		
                }
                return _localsPath; 
            }

		}

		#endregion
		
		#region User specific settings

        const string _DefaultDebugTemplateString = "-i$INCREMENT-DotNet2-$DATE-src.zip";
        const string _DefaultReleaseTemplateString = "-$VERSION-DotNet2-$DATE-src.zip";

		private readonly Collection<ZipSolutionEntry> _entries = new Collection<ZipSolutionEntry>();
        private ZipSolutionEntry _templateSolutionSettings;
        
        
        private string _lastUsedSolution = string.Empty;
        
        private string _language = string.Empty;
		
		public string Language
		{
			get { return _language; }
			set { _language = value; }
		}

        /// <summary>
        /// The source for default settings such as default strings for
        /// debug and release strings, filters list
        /// </summary>
        public ZipSolutionEntry TemplateSolutionSettings
        {
            get 
            {
                _templateSolutionSettings = _templateSolutionSettings ?? getTemplateDefault();

                return _templateSolutionSettings; 
            }
            set { _templateSolutionSettings = value; }
        }

        private ZipSolutionEntry getTemplateDefault()
        {
            var method = CompressionHelper.GetCompressionMethodGoodDefault(OutArchiveFormat.Zip);
            return new ZipSolutionEntry(" ",
                                 OutArchiveFormat.Zip,
                                 method,
                                 CompressionHelper.GetCompressionLevelGoodDefault(OutArchiveFormat.Zip, method),
                                 new ZipFileFormatStrings(_DefaultDebugTemplateString, _DefaultReleaseTemplateString),
                                 new Collection<string> {Environment.GetFolderPath(Environment.SpecialFolder.Desktop)},
                                 new FolderAndFiltersDataSource(" ", getDefaultFilters()), 0);
        }

	    /// <summary>
        /// Adds C# default filters
        /// </summary>
        Collection<FilterConfiguration> getDefaultFilters()
        {
            var result = new Collection<FilterConfiguration>();
            result.Add(new FilterConfiguration(Kind.Folder, FilterAction.ExcludeByMask, "bin"));
            result.Add(new FilterConfiguration(Kind.Folder, FilterAction.ExcludeByMask, ".svn"));
            result.Add(new FilterConfiguration(Kind.Folder, FilterAction.ExcludeByMask, "BIN"));
            result.Add(new FilterConfiguration(Kind.Folder, FilterAction.ExcludeByMask, "_ReSharper.*"));
            result.Add(new FilterConfiguration(Kind.Folder, FilterAction.ExcludeByMask, "obj"));
            result.Add(new FilterConfiguration(Kind.File, FilterAction.ExcludeByMask, "*.tmp"));
            result.Add(new FilterConfiguration(Kind.File, FilterAction.ExcludeByMask, "*.TMP"));
            result.Add(new FilterConfiguration(Kind.File, FilterAction.ExcludeByMask, "*.suo"));
            result.Add(new FilterConfiguration(Kind.File, FilterAction.ExcludeByMask, "*resharper*"));
            result.Add(new FilterConfiguration(Kind.File, FilterAction.ExcludeByMask, "*.user"));
            result.Add(new FilterConfiguration(Kind.File, FilterAction.ExcludeByMask, "Ankh.*"));
            result.Add(new FilterConfiguration(Kind.File, FilterAction.ExcludeByMask, "Thumbs.db"));
            return result;
        }

		public ReadOnlyCollection<ZipSolutionEntry> Solutions
		{
			get { return new ReadOnlyCollection<ZipSolutionEntry>(_entries); }
		}
		
		/// <summary>
		/// This is not safe. It should be checked in the place where used
		/// </summary>		
		public string LastZippedSolutionHeader
		{
			get { return _lastUsedSolution; }
			set { _lastUsedSolution = value; }
		}
		
		#endregion
		
		#region Managing solutions
		
		public bool AddSolution(ZipSolutionEntry newSolution)
		{
			if (newSolution == null)
				throw new ArgumentNullException("newSolution");
			
			if (GetSolution(newSolution.Header) == null)
			{
				_entries.Add(newSolution);
				return true;
			}
			else
			{
				return false;
			}
		}
		
		public void DeleteSolution(string header)
		{
			if (string.IsNullOrEmpty(header))
				throw new ArgumentNullException("header");

            _entries.Remove(
                GetSolution(header));
		}
		
		public ZipSolutionEntry GetSolution(string header)
		{
			if (string.IsNullOrEmpty(header))
				throw new ArgumentNullException("header");
			
			ZipSolutionEntry result = null;
			foreach (ZipSolutionEntry entry in _entries)
			{
				if (entry.Header == header)
				{
					result = entry;
					break;
				}
			}
			
			return result;
		}
		
		#endregion
		
		public static void Init()
		{
#warning: use localappdata path, paste code from .net
			if (!Directory.Exists(Application.UserAppDataPath))
			{
				Directory.CreateDirectory(Application.UserAppDataPath);
			}
		}
		
		/// <param name="formatString"></param>
		/// <returns>true - if formatString is OK</returns>
		private static bool checkDateTimeFormatString(string formatString, bool isFile)
		{
			if (string.IsNullOrEmpty(formatString))
			{
				return false;
			}
			
			try
			{
				string result = DateTime.Now.ToString(formatString, CultureInfo.CurrentCulture);
				
				if (isFile)
				{
					int index = result.IndexOfAny(Path.GetInvalidFileNameChars());

					if (index > 0)
					{
						throw new FormatException();
					}
				}
			}
			catch(FormatException)
			{
				return false;
			}
			
			return true;
		}

        public void LoadAppConfigSettings(CommonController controller, out Successfull successfull)
		{
			string culture = string.Empty;

			try
            {
                _lastModificationsDialogTimeFormatString = controller.Model.GetAppConfigSetting(_LastModificationsTimeFormatStringConfig);
				_replaceTimeFormatString = controller.Model.GetAppConfigSetting(_ReplaceTimeFormatStringConfig);
				culture = controller.Model.GetAppConfigSetting(_ProgramCultureConfig);
                ShowTextInToolbars = bool.Parse(controller.Model.GetAppConfigSetting(_ShowTextInToolbarsConfig));
			}
			catch (ConfigurationErrorsException e)
			{
                controller.ShowErrorBox(Translation.Current[51], e.Message);
                successfull = Successfull.No;
			    return;
			}
			
			if (!checkDateTimeFormatString(_lastModificationsDialogTimeFormatString, false))
			{
                controller.ShowErrorBox(Translation.Current[52], _LastModificationsTimeFormatStringConfig);
                successfull = Successfull.No;
			    return;
			}
			
			
			if (!checkDateTimeFormatString(_replaceTimeFormatString, true))
			{
                controller.ShowErrorBox(Translation.Current[52], _ReplaceTimeFormatStringConfig);
                successfull = Successfull.No;
                return;
			}
			
			if (!string.IsNullOrEmpty(culture))
			{
				try
				{
					Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(culture);
				}
				catch (NotSupportedException)
				{
                    controller.ShowErrorBox(Translation.Current[53]);
                    successfull = Successfull.No;
                    return;
				}
				catch (ArgumentException)
				{
                    controller.ShowErrorBox(Translation.Current[53]);
                    successfull = Successfull.No;
                    return;
				}
			}
            successfull = Successfull.Yes;
		}
	}
}
