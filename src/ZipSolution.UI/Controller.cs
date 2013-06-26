using HDE.Platform.Logging;
using ZipSolution.Commands;
using ZipSolution.Core.Configuration;
using ZipSolution.Core.Controller;
using ZipSolution.Core.Filters;
using ZipSolution.Core.Misc;
using ZipSolution.Core.Model;
using ZipSolution.Core.View;
using ZipSolution.Ui;
using ZipSolution.UI;

namespace ZipSolution
{
    /// <summary>
    /// Controls application.
    /// </summary>
	sealed class Controller: CommonController
	{
		public Controller()
		{
            UiFactory.Register<IGetLastModificationsView, GetLastModificationsTimeForm>();
            UiFactory.Register<IRegisterErrorsView, RegisteredErrors>();
            UiFactory.Register<IRequestVersionView, RequestVersionForm>();
		    UiFactory.Register<IChooseDataSourceTypeView, ChooseDataSourceTypeForm>();
		    UiFactory.Register<ISolutionPropertiesView, SolutionPropertiesForm>();
            UiFactory.Register<INewFilterView, NewFilterForm>();

            LoadOptions(true);
		}

        #region Public Methods

        /// <summary>
        /// Loads the solution from file
        /// </summary>
        /// <param name="file">The target file</param>
        /// <param name="solution">The solution</param>
        public void SaveSolutionToFile(ZipSolutionEntry solution, string file)
        {
            new SaveSolutionToFileCommand().SaveSolutionToFile(this, solution, file);
        }

		#region Managing solutions
		
        public ZipSolutionEntry EditSolution(string solutionName)
        {
            return new EditSolutionCommand().EditSolution(this, solutionName);
        }

        public void EditSolutionFromFile(string solutionFile)
        {
            new EditSolutionCommand().EditSolutionFromFile(this, solutionFile);
        }

        public bool AddSolutionToModel(ZipSolutionEntry newSolution)
		{
            return new AddSolutionToModelCommand().AddSolutionToModel(this, newSolution);
		}

        public ZipSolutionEntry CreateSolution(string filterFolder)
        {
            return new CreateSolutionCommand().CreateSolution(this, filterFolder);
        }

        public ZipSolutionEntry CreateSolution()
        {
            return new CreateSolutionCommand().CreateSolution(this);
        }

        public void RemoveSolutionFromModel(string header)
		{
            new RemoveSolutionFromModelCommand().RemoveSolutionFromModel(this, header);
		}

        public void EditTemplate()
        {
            new EditTemplateCommand().EditTemplate(this);
        }

        public FilterConfiguration AddFilterConfiguration()
        {
            return new AddFilterConfigurationCommand().Add(this);
        }

        #endregion

        /// <summary>
        /// Shows the select app language dialog
        /// </summary>
        public void ChangeAppLanguage()
        {
            new ChangeAppLanguageCommand().ChangeAppLanguage(this);
        }

        public void OpenFolderInShell(string folder)
		{
            new OpenFolderInShellCommand().OpenFolderInShell(this, folder);
		}
		
		public void ExecuteInAnotherInstance(string taskFile)
        {
            new ExecuteInAnotherInstanceCommand().ExecuteInAnotherInstance(this, taskFile);
        }

        public void CopyScript(ScriptType type, string solutionHeader)
		{
			new CopyScriptCommand().CopyScript(this, type, solutionHeader);
        }

        public void ShowHelp()
        {
            new HelpCommand().Help(this);
        }

        #endregion

        protected override ILog CreateOpenLog()
        {
            var log = new ZipSolutionFileLog();
            log.Open();
            return log;
        }
	}
}
