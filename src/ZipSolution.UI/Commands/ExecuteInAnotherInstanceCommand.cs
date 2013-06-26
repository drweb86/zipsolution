using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using ZipSolution.Core.Commands;

namespace ZipSolution.Commands
{
    /// <summary>
    /// Executes solution in other instance.
    /// </summary>
    class ExecuteInAnotherInstanceCommand
    {
        #region Constants

        private const string _ExecuteXmlTask = "\"{2}{0}\" {1}";

        #endregion

        public void ExecuteInAnotherInstance(Controller controller, string taskFile)
        {
            Process.Start(Application.ExecutablePath,
                string.Format(CultureInfo.CurrentCulture, _ExecuteXmlTask, taskFile,
                CommandLineArguments.OpenArchiveAfterPacking,
                CommandLineArguments.SolutionFile));
        }
    }
}
