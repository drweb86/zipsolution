#region Usings
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Forms;
using BULocalization;
using HDE.Platform.Logging;
using HDE.Platform.AspectOrientedFramework;
using ZipSolution.Core.Commands;
using ZipSolution.Core.Configuration;
using ZipSolution.Core.Filters;
using ZipSolution.Core.Misc;
using ZipSolution.Core.Model;
#endregion

namespace ZipSolution.Core.Controller
{
    /// <summary>
    /// Contains common functional.
    /// </summary>
    public abstract class CommonController : BaseController<CommonModel>
    {
        #region Properties

#warning: hack. forms must use platform pattern
        [Obsolete]
        public static CommonController Instance { get; private set; }

        #endregion

        #region Constructors

        protected CommonController()
        {
            Instance = this;
#warning!
            Settings.Init();

            var settings = new ManagerBehaviorSettings();
            settings.RequestLanguageIfNotSpecified = true;
            settings.UseToolGeneratedConfigFile = false;

            Model.LocalsManager = new LanguagesManager(
                new ReadOnlyCollection<string>(new [] { "program" }),
                Settings.PathToLocals,
                "ZipSolution",
                settings);
        }

        #endregion

        #region Public Methods

        public ProcessingContext PreprocessArguments(string[] args, out bool isValid)
        {
            return new PreprocessArgumentsCommand()
                .PreprocessArgument(this, args, out isValid);
        }

        public Successfull LoadOptions(bool interactive)
        {
            return new LoadOptionsCommand().LoadOptions(this, interactive);
        }

        public string LoadVersionFromAssembly(string assemblyRelativePath)
        {
            return new LoadVersionFromAssemblyCommand().LoadVersionFromAssembly(this, assemblyRelativePath);
        }

        public string LoadVersionFromAssemblyInfoCs(string assemblyInfoCsRelativePath)
        {
            return new LoadVersionFromAssemblyInfoCsCommand().LoadVersionFromAssemblyInfoCs(this, assemblyInfoCsRelativePath);
        }

        public ZipSolutionEntry LoadSolutionFromFile(string file)
        {
            return new LoadSolutionFromFileCommand().LoadSolutionFromFile(this, file);
        }

        public void SaveOptions()
        {
            new SaveOptionsCommand().SaveOptions(this);
        }

        public void ProcessErrors(string errorFormat, params string[] args)
        {
            new ProcessErrorsCommand().ProcessErrors(this, errorFormat, args);
        }

        public Successfull Compress(ZipSolutionEntry solution,
            ProcessingContext processingContext,
            Action<long> progressChanged)
        {
            return new CompressCommand().Compress(this, solution, processingContext, progressChanged);
        }

        public void ShowHelp(string message)
        {
            ShowMessageBox(message, Translation.Current[4],
                MessageBoxIcon.Information,            
                MessageBoxButtons.OK);
        }

        #endregion

        #region Messaging

        public virtual DialogResult ShowMessageBoxInternal(string message, string caption, MessageBoxIcon icon, MessageBoxButtons buttons)
        {
            return MessageBox.Show(message, caption, buttons, icon);
        }

        public DialogResult ShowMessageBox(string message, string caption, MessageBoxIcon icon, MessageBoxButtons buttons)
        {
            return ShowMessageBoxInternal(message, caption, icon, buttons);
        }

        public void ShowMessageBox(string messageFormat, params object[] args)
        {
            ShowMessageBoxInternal(string.Format(CultureInfo.CurrentCulture, messageFormat, args), "",
                                   MessageBoxIcon.Information,
                                   MessageBoxButtons.OK);
        }

        public void ShowErrorBox(string messageFormat, params object[] args)
        {
            ShowMessageBoxInternal(string.Format(CultureInfo.CurrentCulture, messageFormat, args), Translation.Current[2],
                                   MessageBoxIcon.Error,
                                   MessageBoxButtons.OK);
        }

        public bool ShowOkCancelBox(string messageFormat, params object[] args)
        {
            return ShowMessageBoxInternal(string.Format(CultureInfo.CurrentCulture, messageFormat, args), Translation.Current[3],
                                          MessageBoxIcon.Question, MessageBoxButtons.OKCancel) == DialogResult.OK;
        }

        public bool ShowYesNoBox(string messageFormat, params object[] args)
        {
            return ShowMessageBoxInternal(string.Format(CultureInfo.CurrentCulture, messageFormat, args), Translation.Current[3],
                                          MessageBoxIcon.Question, MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        #endregion
    }
}
