using System;
using System.Windows.Forms;
using BULocalization;
using HDE.Platform.AspectOrientedFramework;
using ZipSolution.Core.Controller;
using ZipSolution.Core.Filters;
using ZipSolution.Core.Localization;
using ZipSolution.Core.Model;
using ZipSolution.Core.Tree.Nodes;

namespace ZipSolution
{
    /// <summary>
    /// Solution properties form.
    /// </summary>
    interface INewFilterView : IBaseView<BaseController<CommonModel>>
    {
        FilterConfiguration GetFilterConfiguration();
    }

    internal partial class NewFilterForm : Form, INewFilterView
    {
        #region Fields

		private CommonController _controller;

        #endregion

        #region Constructors

        public NewFilterForm()
		{
			InitializeComponent();
			
			okButton.Enabled = false;
		}

        #endregion

        void applyLocals()
        {
            actionComboBox.DataSource = FilterActionConverter.GetAllActions();
            affectedItemsComboBox.DataSource = KindConverter.GetAllKinds();

            Text = Translation.Current[12];
            filterPropertiesGroupBox.Text = Translation.Current[13];
            actionLabel.Text = Translation.Current[14];
            affectedLabel.Text = Translation.Current[15];
            maskLabel.Text = Translation.Current[16];
            cancelButton.Text = Translation.Current[17];
        }

        void okButtonClick(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(parameterTextBox.Text))
			{
                _controller.ShowErrorBox(Translation.Current[10]);
				return;
			}
			
			DialogResult = DialogResult.OK;
		}
		
		void helpButtonClick(object sender, EventArgs e)
		{
            _controller.ShowHelp(Translation.Current[11]);
		}
		
		void parameterTextBoxTextChanged(object sender, EventArgs e)
		{
			okButton.Enabled = !string.IsNullOrEmpty(parameterTextBox.Text);
		}
		
		void actionComboBoxSelectedIndexChanged(object sender, EventArgs e)
		{
			if (FilterActionConverter.FromString((string)actionComboBox.SelectedItem)
                == FilterAction.ExcludeByTime)
			{
				affectedItemsComboBox.SelectedItem = KindConverter.ToString(Kind.File);
				affectedItemsComboBox.Enabled = false;
				parameterTextBox.Text = " ";
				parameterTextBox.Enabled = false;
				maskLabel.Enabled = false;
			}
			else
			{
				affectedItemsComboBox.Enabled = true;
				parameterTextBox.Enabled = true;
				parameterTextBox.Text = string.Empty;
				maskLabel.Enabled = true;
			}			
		}

        #region Public Methods

        public FilterConfiguration GetFilterConfiguration()
        {
            return new FilterConfiguration(
                    KindConverter.FromString((string)affectedItemsComboBox.SelectedItem),
                    FilterActionConverter.FromString((string)actionComboBox.SelectedItem),
                    parameterTextBox.Text);
        }

        public void SetContext(BaseController<CommonModel> context)
        {
            _controller = (CommonController)context;
            applyLocals();
        }

        public bool Process()
        {
            return ShowDialog() == DialogResult.OK;
        }

        #endregion
	}
}
