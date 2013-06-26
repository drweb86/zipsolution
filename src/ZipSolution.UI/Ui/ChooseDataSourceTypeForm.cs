using System;
using System.Windows.Forms;
using BULocalization;
using HDE.Platform.AspectOrientedFramework;
using ZipSolution.Core.DataSources;
using ZipSolution.Core.Model;

namespace ZipSolution.UI
{
    /// <summary>
	/// Provides ability to choose the sources getting way.
	/// </summary>
    sealed partial class ChooseDataSourceTypeForm : Form, IChooseDataSourceTypeView
    {
        #region Properties

        public DataSourceEnum DataSourceType { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
		/// The default constructor
		/// </summary>
		public ChooseDataSourceTypeForm()
		{
			InitializeComponent();
            DataSourceType = DataSourceEnum.Cancelled;

			applyLocals();
		}

        #endregion
		
        #region Private Methods

        private void applyLocals()
        {
            cancelButton.Text = Translation.Current[17];
            Text = Translation.Current[70];
            _useFilterChainButton.Text = Translation.Current[71];
            _manualDesignButton.Text = Translation.Current[72];
        }

        private void onUseFilterChainButtonClick(object sender, EventArgs e)
        {
            DataSourceType = DataSourceEnum.FiltersChainToTargetFolder;
            DialogResult = DialogResult.OK;
        }

        private void onManualDesignButtonClick(object sender, EventArgs e)
        {
            DataSourceType = DataSourceEnum.ManualDesignOfArchive;
            DialogResult = DialogResult.OK;
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

        #endregion
    }
}
