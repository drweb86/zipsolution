using System;
using System.Windows.Forms;
using ZipSolution.UI;

namespace ZipSolution
{
    /// <summary>
    /// Main class of program.
    /// </summary>
	internal sealed class Program
    {
        [STAThread]
		private static void Main(string[] args)
		{
            // fixes form showing at first program start
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var controller = new Controller())
            {
                bool isSettingsValid;
                var processingContext = controller.PreprocessArguments(args, out isSettingsValid);
                if (!isSettingsValid)
                {
                    Environment.ExitCode = -1;
                    return;
                }
                try
                {
                    Application.Run(new MainForm(controller, processingContext));
                }
                catch(Exception unhandledException)
                {
                    controller.ProcessErrors(unhandledException.ToString());
                    throw;
                }
            }
		}
    }
}
