using System;
using System.Windows.Forms;
using HDE.Platform.Logging;
using ZipSolution.Console.Commands;
using ZipSolution.Console.View;
using ZipSolution.Core.Controller;
using ZipSolution.Core.Filters;
using ZipSolution.Core.Misc;
using ZipSolution.Core.Model;
using ZipSolution.Core.View;

namespace ZipSolution.Console
{
    class Controller : CommonController
    {
        #region Public Methods

        public override DialogResult  ShowMessageBoxInternal(string message, string caption, MessageBoxIcon icon, MessageBoxButtons buttons)
        {
            Log.Debug(message);
            if (buttons == MessageBoxButtons.OKCancel)
            {
                Log.Debug("OK/Cancel [O/C]");
                return System.Console.ReadKey().Key == ConsoleKey.O ? DialogResult.OK : DialogResult.Cancel;
            }

            if (buttons == MessageBoxButtons.OKCancel)
            {
                Log.Debug( "Yes/No [Y/N]");
                return System.Console.ReadKey().Key == ConsoleKey.Y ? DialogResult.Yes : DialogResult.No;
            }

            return DialogResult.OK;
        }

        #endregion

        #region Constructors

        public Controller(out Successfull successfull)
        {
            UiFactory.Register<IGetLastModificationsView, GetLastModificationsView>();
            UiFactory.Register<IRegisterErrorsView, RegisteredErrorsView>();
            UiFactory.Register<IRequestVersionView, RequestVersionView>();
            
            successfull = LoadOptions(false);
            if (successfull == Successfull.No)
            {
                Log.Error ("Failed to load settings!");
                Environment.ExitCode = -1;
            }
        }

        #endregion

        #region Commands

        public Successfull Go(
            ProcessingContext processingContext, 
            Action<long> progressChanged)
        {
            return new GoCommand()
                .Go(this, processingContext, progressChanged);
        }

        #endregion

        protected override ILog CreateOpenLog()
        {
            var log = new QueueLog(
                new ConsoleLog(),
                new ZipSolutionFileLog());

            log.Open();
            return log;
        }
    }
}
