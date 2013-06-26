using System;
using System.Windows.Forms;
using BULocalization;
using HDE.Platform.AspectOrientedFramework;
using ZipSolution.Core.Controller;
using ZipSolution.Core.Model;
using ZipSolution.Core.View;

namespace ZipSolution.Ui
{
    /// <summary>
    /// Gets last modifications time label from user.
    /// </summary>
    public partial class GetLastModificationsTimeForm : Form, IGetLastModificationsView
    {
        #region Fields

        private CommonController _context;

        #endregion

        #region Properties

        public GetLastModifications Result { get; private set; }

        public DateTime ChosenTime
		{
			get { return lastModificationsDateTimePicker.Value; }
		}

        #endregion

        #region Constructors

        public GetLastModificationsTimeForm()
        {
            InitializeComponent();
			
            applyLocals();
        }

        #endregion

        #region Public Methods

        public void Init(DateTime previousTime, string lastModificationsDialogTimeFormatString)
        {
            lastModificationsDateTimePicker.CustomFormat = lastModificationsDialogTimeFormatString;
            lastModificationsDateTimePicker.Value = previousTime;
        }

        public void SetContext(BaseController<CommonModel> context)
        {
            _context = (CommonController)context;
        }

        public bool Process()
        {
            var shResult = ShowDialog();
            switch (shResult)
            {
                case DialogResult.OK:
                    Result = GetLastModifications.Ok;
                    return true;

                case DialogResult.Cancel:
                    Result = GetLastModifications.Cancel;
                    return true;

                default:
                    Result = GetLastModifications.DoNotUse;
                    return true;
            }
        }

        #endregion

        #region Private Methods

        void helpButtonClick(object sender, EventArgs e)
		{
            _context.ShowHelp(Translation.Current[48]);
		}
		
		void getLastModificationsTimeFormLoad(object sender, EventArgs e)
		{
			Activate();
		}

        void applyLocals()
        {
            Text = Translation.Current[49];
            
            cancelButton.Text = Translation.Current[17];
            doNotApplyButton.Text = Translation.Current[50];
        }

        #endregion
    }
}
