using System;
using System.Windows.Forms;
using BULocalization;
using HDE.Platform.AspectOrientedFramework;
using ZipSolution.Core.Model;
using ZipSolution.Core.View;

namespace ZipSolution.Ui
{
    /// <summary>
    /// Requests version label from user.
    /// </summary>
    internal partial class RequestVersionForm : Form, IRequestVersionView
    {
        #region Properties

        public string Version
		{
			get { return versionTextBox.Text; }
		}

        #endregion

        #region Constructors

        public RequestVersionForm()
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
            return ShowDialog() == DialogResult.OK;
        }

        public void Init(string oldVersion)
        {
            versionTextBox.Text = oldVersion.Trim();
            refreshOkButton();
            applyLocals();
        }

        #endregion

        #region Private Methods

        private void applyLocals()
        {
            Text = Translation.Current[36];
            versionLabel.Text = Translation.Current[37];
            cancelButton.Text = Translation.Current[17];
        }

        void refreshOkButton()
		{
			char errorCharacter;

            if (!ViewHelper.CheckFilenameForIllegalCharacters(versionTextBox.Text, out errorCharacter))
			{
				okButton.Enabled = (!string.IsNullOrEmpty(versionTextBox.Text));
			}
			else
			{
				okButton.Enabled = false;
			}
			
			errorLabel.Text = errorCharacter.ToString();
		}

		void okButtonClick(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}
		
		void versionTextBoxTextChanged(object sender, EventArgs e)
		{
			refreshOkButton();
		}
		
		void requestVersionFormLoad(object sender, EventArgs e)
		{
			Activate();
        }

        #endregion
    }
}
