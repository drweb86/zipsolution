using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ZipSolution.Commands
{
    /// <summary>
    /// Shows help file.
    /// </summary>
    class HelpCommand
    {
        public void Help(Controller controller)
        {
            Process.Start(
                Path.Combine(
                    Path.Combine(
                        Application.StartupPath, 
                        "Docs"), 
                    "Documentation.doc"));
        }
    }
}
