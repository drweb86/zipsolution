using ZipSolution.Core.Configuration;

namespace ZipSolution.Commands
{
    /// <summary>
    /// Adds solution to model.
    /// </summary>
    class AddSolutionToModelCommand
    {
        public bool AddSolutionToModel(Controller controller, ZipSolutionEntry newSolution)
        {
            return controller.Model.Settings.AddSolution(newSolution);
        }
    }
}
