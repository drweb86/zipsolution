#region Usings
using System;
using System.Diagnostics;
using System.Windows.Forms;
using HDE.Platform.Logging;
using Microsoft.Build.Utilities;
using ZipSolution.Console.Commands;
using ZipSolution.Console.View;
using ZipSolution.Core.Controller;
using ZipSolution.Core.Filters;
using ZipSolution.Core.Misc;
using ZipSolution.Core.View;
#endregion

namespace ZipSolution.Console.MsBuild
{
    static class MsBuildSettings
    {
        public static TaskLoggingHelper MsBuildLog { get; set; }
    }

    class MsBuildController : CommonController
    {
        #region Constructor

        public MsBuildController()
        {
            UiFactory.Register<IRegisterErrorsView, RegisteredErrorsView>();

            //Ui factory is empty, because all options must be set in properties and no input is supported

            if (LoadOptions(false) == Successfull.No)
            {
                Log.Error("Failed to load settings!");
                throw new InvalidOperationException("Settings are invalid!");
            }
        }

        #endregion

        #region Message Engine

        public override DialogResult ShowMessageBoxInternal(string message, string caption, MessageBoxIcon icon, MessageBoxButtons buttons)
        {
            Log.Write(icon == MessageBoxIcon.Error ? LoggingEvent.Error : LoggingEvent.Debug, message);
            return DialogResult.Cancel;
        }

        #endregion

        #region Commands

        public Successfull Go(ProcessingContext processingContext, Action<long> progressChanged)
        {
            return new GoCommand().Go(this, processingContext, progressChanged);
        }

        protected override ILog CreateOpenLog()
        {
            if (MsBuildSettings.MsBuildLog == null)
            {
                throw new ArgumentNullException("MsBuildLog is not initialized.", "MsBuildSettings.MsBuildLog");
            }
            var log = new MsBuildLog(MsBuildSettings.MsBuildLog);

            log.Open();
            return log;
        }

        #endregion
    }
}
