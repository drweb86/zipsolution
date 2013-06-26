using System;
using BULocalization;
using ZipSolution.Core.Configuration;
using ZipSolution.Core.Controller;
using ZipSolution.Core.Filters;
using ZipSolution.Core.Misc;

namespace ZipSolution.Console.Commands
{
    /// <summary>
    /// Executes the task.
    /// </summary>
    class GoCommand
    {
        #region Public Methods

        public Successfull Go(CommonController context, 
            ProcessingContext processingContext, 
            Action<long> progressChanged)
        {
            if (!string.IsNullOrEmpty(processingContext.PredefinedProjectToProcess))
            {
                ZipSolutionEntry solution = context.Model.GetSolution(processingContext.PredefinedProjectToProcess);
                if (solution != null)
                {
                    return start(context, solution, processingContext, progressChanged);
                }
                else
                {
                    context.ProcessErrors(Translation.Current[81]);
                    return Successfull.No;
                }
            }
            else if (!string.IsNullOrEmpty(processingContext.PredefinedSolutionFileToProcess))
            {
                ZipSolutionEntry solution = context.LoadSolutionFromFile(processingContext.PredefinedSolutionFileToProcess);
                if (solution != null)
                {
                    return start(context, solution, processingContext, progressChanged);
                }
                else
                {
                    return Successfull.No;
                }
            }
            else
            {
                context.ShowErrorBox(Translation.Current[82]);
                return Successfull.No;
            }
        }

        #endregion

        #region Private Methods

        static Successfull start(
            CommonController context, 
            ZipSolutionEntry solution, 
            ProcessingContext processingContext, 
            Action<long> onProgress)
        {
            return context.Compress(solution, processingContext, onProgress);
        }

        #endregion
    }
}
