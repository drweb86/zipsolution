using System.IO;
using BULocalization;
using ZipSolution.Core.Configuration;
using ZipSolution.Core.Controller;

namespace ZipSolution.Core.Commands
{
    /// <summary>
    /// Saves options.
    /// </summary>
    class SaveOptionsCommand
    {
        #region Public Methods

        public void SaveOptions(CommonController context)
        {
            try
            {
                context.Model.Settings.Language =context.Model.LocalsManager.CurrentLanguage;
                XmlSettingsRepresentation.SaveUserSpecificSettings(context.Model.Settings, context.Model.SettingsXmlFile);
            }
            catch (IOException e)
            {
                context.ShowErrorBox(Translation.Current[1], e.Message);
            }
        }

        #endregion
    }
}
