namespace ZipSolution.Commands
{
    /// <summary>
    /// Deletes solution from model.
    /// </summary>
    class RemoveSolutionFromModelCommand
    {
        public void RemoveSolutionFromModel(Controller controller, string solutionName)
        {
            controller.Model.Settings.DeleteSolution(solutionName);
        }
    }
}
