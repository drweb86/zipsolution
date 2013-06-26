namespace ZipSolution.Commands
{
    /// <summary>
    /// Changes the language.
    /// </summary>
    class ChangeAppLanguageCommand
    {
        public void ChangeAppLanguage(Controller controller)
        {
            controller.Model.LocalsManager.ShowSelectLanguageDialog(true, true);
        }
    }
}
