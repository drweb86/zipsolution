using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Security;
using System.Windows.Forms;
using BULocalization;
using HDE.Platform.FileIO;
using ZipSolution.Core.Configuration;
using ZipSolution.Core.Controller;
using ZipSolution.Core.Misc;
using ZipSolution.Core.Model;

namespace ZipSolution.Core.Commands
{
    /// <summary>
    /// Loads options.
    /// </summary>
    class LoadOptionsCommand
    {
        #region Constants

        private const string _SettingsFolderConfig = "SettingsFolder";
        private const string _CouldNotLoadlocalization = "Could not init localization.\n\nPlease reinstall application";
        private const string _CouldNotLoadSettings = "Could not load settings, they will be reseted!\n\nReason: {0}";

        #endregion

        #region Public Methods

        public Successfull LoadOptions(CommonController context, bool interactive)
        {
            LoadAppSettings(context);

            LoadSettingsFileLocation(context);
            if (File.Exists(context.Model.SettingsXmlFile))
            {
                try
                {
                    context.Model.Settings = new Settings();
                    XmlSettingsRepresentation.LoadUserSpecificSettings(context.Log, context.Model.Settings, context.Model.SettingsXmlFile);
                }
                catch (SecurityException e)
                {
                    context.ShowErrorBox(_CouldNotLoadSettings, e.Message);
                    context.Model.Settings = new Settings();
                }
                catch (IOException e)
                {
                    context.ShowErrorBox(_CouldNotLoadSettings, e.Message);
                    context.Model.Settings = new Settings();
                }
            }
            else
            {
                context.Model.Settings = new Settings();
            }

            if (!interactive &&
                string.IsNullOrEmpty(context.Model.Settings.Language))
            {
                context.Model.Settings.Language = "default";
            }

            try
            {
                context.Model.LocalsManager.Init(context.Model.Settings.Language);
            }
            catch (LocalizationGenericException)
            {
                context.ShowErrorBox(_CouldNotLoadlocalization);
                return Successfull.No;
            }

            // Loading zipsolution.config
            Successfull isValidSettings;
            context.Model.Settings.LoadAppConfigSettings(context, out isValidSettings);
            if (isValidSettings == Successfull.No)
            {
                return Successfull.No;
            }

            context.Model.LastModificationsDialogTimeFormatString = context.Model.Settings.LastModificationsDialogTimeFormatString;
            return Successfull.Yes;
        }

        /// <summary>
        /// Loads configuration file independently from application usage (from exe or config)
        /// </summary>
        private static void LoadAppSettings(CommonController context)
        {
            var configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "ZipSolution.config");
            context.Model.Configuration = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None).AppSettings.Settings;
        }

        private static void LoadSettingsFileLocation(CommonController context)
        {
            context.Log.Debug(Application.ExecutablePath);
            string predefinedSettingsFolder = context.Model.GetAppConfigSetting(_SettingsFolderConfig);
            if (!string.IsNullOrEmpty(predefinedSettingsFolder))
            {
                context.Model.SettingsXmlFile = Path.Combine(predefinedSettingsFolder, CommonModel.SettingsFileName);
            }
            else if (!string.IsNullOrEmpty(Application.UserAppDataPath) &&
                !string.IsNullOrEmpty(Application.ExecutablePath) &&
                !Application.ExecutablePath.ToLowerInvariant().Contains("msbuild.exe"))
            {
                var dir = RelativePathDiscovery.ResolveRelativePath("..", Application.UserAppDataPath);
                context.Model.SettingsXmlFile = Path.Combine(dir, CommonModel.SettingsFileName);
            }
            else
            {
                context.Log.Error("Please, set the 'SettingsFolder' in ZipSolution.config!\n\nRefer to Documentation to Visual Studio and SharpDevelop interop issue");
                throw new Exception("Please, set the 'SettingsFolder' in ZipSolution.config!\n\nRefer to Documentation to Visual Studio and SharpDevelop interop issue");
            }
        }

        #endregion
    }
}
