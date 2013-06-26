using System;
using System.IO;
using System.Security;
using BULocalization;
using ZipSolution.Core.Configuration;

namespace ZipSolution.Commands
{
    /// <summary>
    /// Saves solution to separate file with relative paths.
    /// </summary>
    class SaveSolutionToFileCommand
    {
        public void SaveSolutionToFile(Controller controller, ZipSolutionEntry solution, string file)
        {
            try
            {
                XmlSettingsRepresentation.SaveSolution(file, solution);
            }
            catch (NullReferenceException e)
            {
                controller.ShowErrorBox(Translation.Current[79], e.Message);
            }
            catch (SecurityException e)
            {
                controller.ShowErrorBox(Translation.Current[79], e.Message);
            }
            catch (IOException e)
            {
                controller.ShowErrorBox(Translation.Current[79], e.Message);
            }
        }
    }
}
