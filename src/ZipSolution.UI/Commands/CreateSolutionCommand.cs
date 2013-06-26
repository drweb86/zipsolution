using ZipSolution.Core.Configuration;
using ZipSolution.Core.DataSources;
using ZipSolution.UI;

namespace ZipSolution.Commands
{
    /// <summary>
    /// Adds solution to model.
    /// </summary>
    class CreateSolutionCommand
    {
        public ZipSolutionEntry CreateSolution(Controller controller, string filterFolder)
        {
            DataSourceEnum sourceType = DataSourceEnum.FiltersChainToTargetFolder;

            if (string.IsNullOrEmpty(filterFolder))
            {
                var view = controller.CreateView<IChooseDataSourceTypeView>();
                if (view.Process() && view.DataSourceType != DataSourceEnum.Cancelled)
                {
                    sourceType = view.DataSourceType;
                }
                else
                {
                    return null;
                }
            }

            var propView = controller.CreateView<ISolutionPropertiesView>();
            propView.Init(sourceType);
            propView.SetSolutionFolder(filterFolder);
            
            if (propView.Process())
            {
                ZipSolutionEntry entry = propView.GetSolution();
                controller.AddSolutionToModel(entry);
                return entry;
            }
            return null;
        }

        public ZipSolutionEntry CreateSolution(Controller controller)
        {
            return CreateSolution(controller, null);
        }
    }
}
