using System;
using System.Windows.Forms;
using BULocalization;
using HDE.Platform.AspectOrientedFramework;
using ZipSolution.Core.Model;
using ZipSolution.Core.View;

namespace ZipSolution.Ui
{
    /// <summary>
    /// Shows errors.
    /// </summary>
    public partial class RegisteredErrors : Form, IRegisterErrorsView
    {
        #region Constructors

        public RegisteredErrors()
		{
			InitializeComponent();
		}

        #endregion

        #region Public Methods

        public void SetContext(BaseController<CommonModel> context)
        {
        }

        public bool Process()
        {
            ShowDialog();
            return true;
        }

        public void Init(string errorMessage)
        {
            string[] error = errorMessage.Split(
                    new[] { Environment.NewLine },
                    StringSplitOptions.RemoveEmptyEntries);

            errorMessageTextBox.Lines = error;
        }

        #endregion

        #region Private Methods

        void registeredErrorsLoad(object sender, EventArgs e)
		{
            Text = Translation.Current[38];
			Activate();
        }

        #endregion
    }
}
