using ZipSolution.Core.Filters;

namespace ZipSolution.Commands
{
    /// <summary>
    /// Adds filter configuration.
    /// </summary>
    class AddFilterConfigurationCommand
    {
        public FilterConfiguration Add(Controller controller)
        {
            var view = controller.CreateView<INewFilterView>();
            if (view.Process())
            {
                return view.GetFilterConfiguration();
            }
            return null;
        }
    }
}
