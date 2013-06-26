using ZipSolution.Core.Controller;
using ZipSolution.Core.View;

namespace ZipSolution.Core.Commands
{
    //TODO: consider global variable 
    //Environment.IsProcess IsInProcess and set return codes.

    /// <summary>
    /// Processes errors during processing errors.
    /// </summary>
    class ProcessErrorsCommand
    {
        #region Public Methods

        public void ProcessErrors(CommonController context, string errorFormat, string[] args)
        {
            context.Log.Error(errorFormat, args);
            string errorMessage = string.Format(errorFormat, args);

            using (var view = context.CreateView<IRegisterErrorsView>())
            {
                view.Init(errorMessage);
                view.Process();
           }
        }

        #endregion
    }
}
