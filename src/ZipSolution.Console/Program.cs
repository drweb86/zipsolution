using System;
using BULocalization;
using HDE.Platform.Logging;
using ZipSolution.Core.Misc;

namespace ZipSolution.Console
{
    /// <summary>
    /// Console tool.
    /// </summary>
    class Program
    {
        #region Fields

        static ILog _log;

        #endregion

        #region Private Methods

        static void Main(string[] args)
        {
            Successfull loadSettingsSuccessfull;
            using (var controller = new Controller(out loadSettingsSuccessfull))
            {
                if (loadSettingsSuccessfull != Successfull.Yes)
                {
                    return;
                }

                _log = controller.Log;
                try
                {
                    bool argumentsAreValid;
                    var filterContext = controller.PreprocessArguments(args, out argumentsAreValid);
                    if (argumentsAreValid)
                    {
                        var successfull = controller.Go(filterContext, reportProgress);
                        switch (successfull)
                        {
                            case Successfull.Yes:
                                controller.SaveOptions(); // solution might contain alatered items
                                break;
                            case Successfull.No:
                                failed();
                                break;
                            default:
                                throw new NotSupportedException(successfull.ToString());
                        }
                    }
                }
                catch(Exception e)
                {
                    controller.ProcessErrors(e.ToString());
                    failed();
                }
            }
        }

        static void failed()
        {
            _log.Warning(Translation.Current[88]);
            Environment.ExitCode = -1;
        }

        static void reportProgress(long progress)
        {
            System.Console.Title = string.Format(Translation.Current[89], progress);
        }

        #endregion
    }
}
