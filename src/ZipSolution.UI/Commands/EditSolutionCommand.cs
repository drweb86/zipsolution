using ZipSolution.Core.Configuration;
using ZipSolution.UI;

namespace ZipSolution.Commands
{
    /// <summary>
    /// Edits selected solution.
    /// Returns edited solution. Null if all is cancelled.
    /// </summary>
    class EditSolutionCommand
    {
        #region Public Methods

        public ZipSolutionEntry EditSolution(Controller controller, string solutionName)
        {
            var solution = controller.Model.GetSolution(solutionName);
            using (var form = controller.CreateView<ISolutionPropertiesView>())
            {
                form.Init(solution);
                controller.Model.Settings.DeleteSolution(solutionName);

                if (form.Process())
                {
                    var changedSolution = form.GetSolution();
                    controller.Model.Settings.AddSolution(changedSolution);
                    return changedSolution;
                }
                else
                {
                    controller.Model.Settings.AddSolution(solution);
                }
            }
            return null;
        }

        public void EditSolutionFromFile(Controller controller, string solutionFile)
        {
            var solution = controller.LoadSolutionFromFile(solutionFile);
            if (solution == null) // failed to load
            {
                return;
            }

            var propView = controller.CreateView<ISolutionPropertiesView>();
            propView.SkipUniqueNameCheck = true;
            propView.Init(solution);

            if (propView.Process())
            {
                controller.SaveSolutionToFile(propView.GetSolution(), solutionFile);
            }
        }

        #endregion
    }
}
