using ZipSolution.UI;

namespace ZipSolution.Commands
{
    /// <summary>
    /// Adds solution to model.
    /// </summary>
    class EditTemplateCommand
    {
        public void EditTemplate(Controller controller)
        {
            var propView = controller.CreateView<ISolutionPropertiesView>();
            propView.Init(controller.Model.TemplateSolutionSettings);
            propView.IAmEditingTemplate();

            if (propView.Process())
            {
                controller.Model.TemplateSolutionSettings = propView.GetSolution();
            }
        }
    }
}
