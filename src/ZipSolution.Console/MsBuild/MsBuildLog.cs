using System;
using HDE.Platform.Logging;
using Microsoft.Build.Utilities;

namespace ZipSolution.Console.MsBuild
{
    class MsBuildLog : LogBase
    {
        #region Fields

        private readonly TaskLoggingHelper _logInternal;

        #endregion

        #region Constructors

        public MsBuildLog(TaskLoggingHelper logInternal)
        {
            _logInternal = logInternal;
        }

        #endregion

        protected override void OpenInternal()
        {
        }

        protected override void CloseInternal()
        {
        }

        protected override void WriteInternal(LoggingEvent loggingEvent, string message)
        {
            switch (loggingEvent)
            {
                case LoggingEvent.Debug:
                    _logInternal.LogMessage(message);
                    break;
                case LoggingEvent.Error:
                    _logInternal.LogError(message);
                    break;
                case LoggingEvent.Warning:
                    _logInternal.LogWarning(message);
                    break;
                default:
                    throw new NotSupportedException(loggingEvent.ToString());
            }
        }
    }
}
