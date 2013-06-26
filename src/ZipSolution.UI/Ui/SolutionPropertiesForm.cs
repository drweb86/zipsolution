#region Usings
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using BULocalization;
using HDE.Platform.AspectOrientedFramework;
using Ionic.Utils;
using SevenZip;
using ZipSolution.Commands;
using ZipSolution.Core.Configuration;
using ZipSolution.Core.Controller;
using ZipSolution.Core.DataSources;
using ZipSolution.Core.Misc;
using ZipSolution.Core.Model;
using ZipSolution.Core.View;
#endregion

namespace ZipSolution.UI
{
    /// <summary>
    /// Solution properties form.
    /// </summary>
    interface ISolutionPropertiesView: IBaseView<BaseController<CommonModel>>
    {
        //TODO: interface must be redesigned.

        ZipSolutionEntry GetSolution();
        
        void Init(DataSourceEnum newSolutionDataSourceType);
        void Init(ZipSolutionEntry solution);

        void SetSolutionFolder(string folder);
        void IAmEditingTemplate();
        bool SkipUniqueNameCheck { get; set; }
    }

    /// <summary>
    /// Changes solution properties.
    /// </summary>
	sealed partial class SolutionPropertiesForm : Form, ISolutionPropertiesView
	{
		#region Fields

        bool _isEditingTemplate;
		Controller _controller;
		IDataSourceConfig _sourceConfigControl;
		
		#endregion

        #region Properties

        OutArchiveFormat? OutArchiveFormat 
        { 
            get
            {
                var selectedItem = outArchiveTypeToolStripComboBox_.SelectedItem;
                if (selectedItem == null)
                {
                    return null;
                }
                else
                {
                    return (OutArchiveFormat) selectedItem;
                }
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                outArchiveTypeToolStripComboBox_.SelectedItem = value.Value;
            }
        }

        CompressionLevel? CompressionLevel
        {
            get
            {
                var selectedItem = compressionLevelToolStripComboBox_.SelectedItem;
                if (selectedItem == null)
                {
                    return null;
                }
                else
                {
                    return (CompressionLevel)selectedItem;
                }
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                compressionLevelToolStripComboBox_.SelectedItem = value.Value;
            }
        }

        CompressionMethod? CompressionMethod
        {
            get
            {
                var selectedItem = compressionMethodToolStripComboBox_.SelectedItem;
                if (selectedItem == null)
                {
                    return null;
                }
                else
                {
                    return (CompressionMethod)selectedItem;
                }
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                compressionMethodToolStripComboBox_.SelectedItem = value.Value;
            }
        }

        /// <summary>
        /// Skips check uniquty of solution caption
        /// </summary>
        public bool SkipUniqueNameCheck { get; set; }

        #endregion

        #region Constructors

		public SolutionPropertiesForm()
		{
			InitializeComponent();
		}

        #endregion
		
		#region Public Methods

		/// <summary>
		/// Creates the new solution of the specified type
		/// </summary>
		/// <param name="newSolutionDataSourceType">The new solution type</param>
		public void Init(DataSourceEnum newSolutionDataSourceType)
		{
			genericInit();
            Text = Translation.Current[25];

		    var template = _controller.Model.Settings.TemplateSolutionSettings;

            foldersListBox.Items.AddRange(template.TargetFolders.ToArray());
			createAndSetupDataSourceControl(newSolutionDataSourceType);
		    OutArchiveFormat = template.OutArchiveFormat;
		    CompressionMethod = template.CompressionMethod;
		    CompressionLevel = template.CompressionLevel;
            if (newSolutionDataSourceType == DataSourceEnum.FiltersChainToTargetFolder)
            {
                ((FolderWithFiltersUserControl)_sourceConfigControl).AddDefaultFilters(((FolderAndFiltersDataSource)template.DataSource).Filters);
            }
		}

		/// <summary>
		/// Here form localization setted and data loades. This is not in constructor to workaround sharpdevelop ide issues with designer
		/// </summary>
		/// <param name="solution">The solution</param>
		/// <exception cref="ArgumentNullException">solution is null</exception>
		public void Init(ZipSolutionEntry solution)
		{
			genericInit();
			
			if (solution==null)
			{
				throw new ArgumentNullException("solution");
			}

            Text = Translation.Current[24];
			captionTextBox.Text = solution.Header;
            OutArchiveFormat = solution.OutArchiveFormat;
            CompressionMethod = solution.CompressionMethod;
            CompressionLevel = solution.CompressionLevel;
			if (solution.DataSource is FolderAndFiltersDataSource)
			{
				createAndSetupDataSourceControl(DataSourceEnum.FiltersChainToTargetFolder);
			}
			else if (solution.DataSource is ManualArchiveDesignDataSource)
			{
				createAndSetupDataSourceControl(DataSourceEnum.ManualDesignOfArchive);
			}
			else
			{
				throw new NotImplementedException(solution.DataSource.GetType().ToString());
			}
			_sourceConfigControl.DataSource = solution.DataSource;
			internalPurposeZipArchiveNameFormatTextBox.Text = solution.ZipFileNameTemplateStrings.Debug;
			releaseTextBox.Text = solution.ZipFileNameTemplateStrings.Release;
				
			ReadOnlyCollection<string> folders = solution.TargetFolders;
			foreach (string folder in folders)
			{
				foldersListBox.Items.Add(folder);
			}
		}

        public void SetContext(BaseController<CommonModel> context)
        {
            _controller = (Controller)context;
        }

        public bool Process()
        {
            return ShowDialog() == DialogResult.OK;
        }

        /// <summary>
        /// Turns off folder check for filters folder
        /// </summary>
        public void IAmEditingTemplate()
        {
            _isEditingTemplate = true;
            var control = _sourceConfigControl as FolderWithFiltersUserControl;
            if (control == null)
            {
                throw new InvalidOperationException("Try to turn off solution folder check for non filter control");
            }
            
            control.TurnOffChoosingSolutionFolderFunctionality();
            _captionLabel.Enabled = false;
            captionTextBox.Text = "Template";
            captionTextBox.Enabled = false;
            propertiesToolStrip_.Enabled = false;
        }

		/// <summary>
		/// Sets the solution folder(for folder with filters kind of compression)
		/// </summary>
		/// <param name="folder">The folder to set</param>
		public void SetSolutionFolder(string folder)
		{
			var control = _sourceConfigControl as FolderWithFiltersUserControl;
			if (control != null)
			{
				control.SetSolutionFolder(folder);
			}
		}
		
		/// <summary>
		/// Gets the solution
		/// </summary>
		/// <returns>Returnes the new solution object</returns>
		public ZipSolutionEntry GetSolution()
		{
			var folders = new Collection<string>();
				
			foreach (object obj in foldersListBox.Items)
			{
				folders.Add((string)obj);
			}
			
			return new ZipSolutionEntry(
				captionTextBox.Text,
                OutArchiveFormat.Value,
                CompressionMethod.Value,
                CompressionLevel.Value,
				new ZipFileFormatStrings(
					internalPurposeZipArchiveNameFormatTextBox.Text,
					releaseTextBox.Text),
				folders,
				_sourceConfigControl.DataSource,
                0);
		}
		
		#endregion
		
		#region Private Methods
		
        void fillOutArchiveTypes()
        {
            outArchiveTypeToolStripComboBox_.Items.Clear();
            Array.ForEach(CompressionHelper.GetAllowedOutArchiveFormats(), item=>outArchiveTypeToolStripComboBox_.Items.Add(item));
        }

        void genericInit()
		{
            internalPurposeZipArchiveNameFormatTextBox.Text = _controller.Model.DefaultInternalPurposeFormatString;
            releaseTextBox.Text = _controller.Model.DefaultReleaseFormatString;
            fillOutArchiveTypes();

			applyLocals();
		}

        void applyLocals()
        {
            _captionLabel.Text = Translation.Current[26];
            _releaseZipGroupBox.Text = Translation.Current[28];
            _fiuLabel.Text = Translation.Current[29];
            _releaseLabel.Text = Translation.Current[30];
            _putInLabel.Text = Translation.Current[31];
            _cancelButton.Text = Translation.Current[17];
            _addToolStripMenuItem.Text = Translation.Current[39];
            _removeToolStripMenuItem.Text = Translation.Current[41];
            _copyBatToBufferToolStripButton.ToolTipText = Translation.Current[54];
            _copyCmdToBufferToolStripButton.ToolTipText = Translation.Current[55];
            _copyPowerShellToolStripButton.ToolTipText = Translation.Current[93];
            _openToolStripMenuItem.Text = Translation.Current[57];
            _saveToFileToolStripButton.ToolTipText = Translation.Current[77];
            _saveToFileToolStripButton.Text = Translation.Current[77];
            _testToolStripButton.Text = Translation.Current[73];
            _viewToolStripLabel.Text = Translation.Current[94];
            _archiveBarLabel.Text = Translation.Current[95];
            _typeToolStripLabel.Text = Translation.Current[96];
            _methodToolStripLabel.Text = Translation.Current[97];
            _levelToolStripLabel.Text = Translation.Current[98];
            _testToolStripButton.Text = Translation.Current[100];
        }

        void createAndSetupDataSourceControl(DataSourceEnum controlKind)
		{
			Control control;
			switch (controlKind)
			{
				case DataSourceEnum.FiltersChainToTargetFolder:
					_sourceConfigControl = new FolderWithFiltersUserControl();
					control = (FolderWithFiltersUserControl)_sourceConfigControl;
					((FolderWithFiltersUserControl)_sourceConfigControl).OnSetSolutionName += setSolutionName;
					break;
				
				case DataSourceEnum.ManualDesignOfArchive:
					_sourceConfigControl = new DesignArchiveUserControl();
					control = (DesignArchiveUserControl)_sourceConfigControl;
					break;
					
				default:
					throw new NotImplementedException(controlKind.ToString());
			}
			_sourceConfigControl.Init(_controller.Log, 
                item=>_controller.ShowErrorBox(item),
                _controller.AddFilterConfiguration);
			control.Dock = DockStyle.Fill;
			holdDataSourceConfigureControlPanel.Controls.Add(control);		
		}

		void setSolutionName(string solutionName)
		{
			if (string.IsNullOrEmpty(captionTextBox.Text))
			{
				captionTextBox.Text = solutionName;
			}

            if (internalPurposeZipArchiveNameFormatTextBox.Text == _controller.Model.DefaultInternalPurposeFormatString)
            {
                internalPurposeZipArchiveNameFormatTextBox.Text = solutionName + internalPurposeZipArchiveNameFormatTextBox.Text;
            }

            if (releaseTextBox.Text == _controller.Model.DefaultReleaseFormatString)
            {
                releaseTextBox.Text = solutionName + releaseTextBox.Text;
            }
		}

        /// <summary>
        /// Performs solution checks
        /// </summary>
        /// <returns>True when all's fine</returns>
        bool performChecks()
        {
            captionTextBox.Text = captionTextBox.Text.Trim();

            if (string.IsNullOrEmpty(captionTextBox.Text))
            {
                _controller.ShowErrorBox(Translation.Current[18]);
                return false;
            }

            if (OutArchiveFormat == null ||
                CompressionLevel == null ||
                CompressionMethod == null)
            {
                _controller.ShowErrorBox(Translation.Current[99]);
            }

            if (!_sourceConfigControl.ValidStorageState())
            {
                return false;
            }

            if (string.IsNullOrEmpty(internalPurposeZipArchiveNameFormatTextBox.Text))
            {
                _controller.ShowErrorBox(Translation.Current[20]);
                return false;
            }

            if (string.IsNullOrEmpty(releaseTextBox.Text))
            {
                _controller.ShowErrorBox(Translation.Current[21]);
                return false;
            }

            if (!_isEditingTemplate && foldersListBox.Items.Count == 0)
            {
                _controller.ShowErrorBox(Translation.Current[22]);
                return false;
            }

            char invalidCharacter;
            if (ViewHelper.CheckFilenameForIllegalCharacters(internalPurposeZipArchiveNameFormatTextBox.Text, out invalidCharacter))
            {
                _controller.ShowErrorBox(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        Translation.Current[43],
                        invalidCharacter));

                return false;
            }

            if (ViewHelper.CheckFilenameForIllegalCharacters(releaseTextBox.Text, out invalidCharacter))
            {
                _controller.ShowErrorBox(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        Translation.Current[43],
                        invalidCharacter));

                return false;
            }

            if (!SkipUniqueNameCheck && _controller.Model.GetSolution(captionTextBox.Text) != null)
            {
                _controller.ShowErrorBox(Translation.Current[42]);
                return false;
            }

            return true;
        }

		void okButtonClick(object sender, EventArgs e)
		{
            if (performChecks())
            {
                DialogResult = DialogResult.OK;
            }
		}

		void addFolderButtonClick(object sender, EventArgs e)
		{
		    if (FolderBrowserDialogEx.Execute())
			{
                if (!foldersListBox.Items.Contains(FolderBrowserDialogEx.LastSelectedPath))
				{
                    foldersListBox.Items.Add(FolderBrowserDialogEx.LastSelectedPath);
				}
			}
		}
		
		void removeSelectedFolder()
		{
			if (foldersListBox.Items.Count > 0)
			{
				int selectedIndex = foldersListBox.SelectedIndex;
				
				if (selectedIndex > -1)
				{
					foldersListBox.Items.Remove(foldersListBox.SelectedItem);

					// selecting next folder
					if (foldersListBox.Items.Count > 0)
					{
						if (foldersListBox.Items.Count > selectedIndex)
						{
							foldersListBox.SelectedIndex = selectedIndex;
						}
						else
						{
							foldersListBox.SelectedIndex = foldersListBox.Items.Count - 1 ;
						}
					}
				}
			}
		}
		
		void removeFolderButtonClick(object sender, EventArgs e)
		{
			removeSelectedFolder();
		}
		
		void supportedFormatItemsHelpButtonClick(object sender, EventArgs e)
		{
            _controller.ShowHelp(Translation.Current[23]);
		}
		
		void foldersContextMenuStripOpening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			bool itemSelected = foldersListBox.SelectedIndex > -1;
			_removeToolStripMenuItem.Enabled = itemSelected;
			_openToolStripMenuItem.Enabled = itemSelected;
		}
		
		void foldersListBoxDragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.All;
		}
		
		void foldersListBoxDragDrop(object sender, DragEventArgs e)
		{
			if( e.Data.GetDataPresent(DataFormats.FileDrop, false) )
			{
				string[] newitems = (string[])e.Data.GetData(DataFormats.FileDrop);
				
				foreach (string folder in newitems)
				{
					if (Directory.Exists(folder))
					{
						if (!foldersListBox.Items.Contains(folder))
						{
							foldersListBox.Items.Add(folder);
						}
					}
				}
			}
		}
		
		void foldersListBoxMouseDown(object sender, MouseEventArgs e)
		{
			foldersListBox.SelectedIndex = foldersListBox.IndexFromPoint(e.Location);
		}
		
		void getbatScriptToolStripMenuItemClick(object sender, EventArgs e)
		{
            _controller.CopyScript(ScriptType.Batch, captionTextBox.Text);
		}
		
		void getcmdScriptToolStripMenuItemClick(object sender, EventArgs e)
		{
            _controller.CopyScript(ScriptType.Cmd, captionTextBox.Text);
		}
		
		void openToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (foldersListBox.SelectedItem != null)
			{
				_controller.OpenFolderInShell((string) foldersListBox.SelectedItem);
			}
		}
		
		void foldersListBoxDoubleClick(object sender, EventArgs e)
		{
			if (foldersListBox.SelectedItem != null) 
			{
				_controller.OpenFolderInShell((string) foldersListBox.SelectedItem);
			}
		}
		
		// to support drop
		void newItemFormShown(object sender, EventArgs e)
		{
			Activate();
		}
		
		void foldersListBoxKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Delete)
			{
				removeSelectedFolder();
			}
		}
		
		void foldersListBoxSelectedIndexChanged(object sender, EventArgs e)
		{
			removeFolderButton.Enabled = foldersListBox.SelectedIndex > -1;
		}

        void saveSolutionToFileClick(object sender, EventArgs e)
        {
            if (performChecks() && saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                saveSolutionToFile(saveFileDialog.FileName);
            }
        }	

        /// <summary>
        /// Saves solution to file
        /// </summary>
        /// <returns>true when file is saved</returns>
        bool saveSolutionToFile(string targetFile)
        {
            bool previousValue = SkipUniqueNameCheck;
            try
            {
                SkipUniqueNameCheck = true;
                if (performChecks())
                {
                    _controller.SaveSolutionToFile(GetSolution(), targetFile);
                    return true;
                }
            }
            finally
            {
                SkipUniqueNameCheck = previousValue;
            }

            return false;
        }

	    void onTestToolStripButtonClick(object sender, EventArgs e)
        {
	        string file = Path.GetTempFileName();
            if (saveSolutionToFile(file))
            {
                _controller.ExecuteInAnotherInstance(file);
            }
        }

        void onSolutionPropertiesFormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && propertiesToolStrip_.Enabled)
            {
                onTestToolStripButtonClick(sender, e);
                e.Handled = true;
            }
        }

        void onPowerShellCopyScriptToolStripButtonClick(object sender, EventArgs e)
        {
            _controller.CopyScript(ScriptType.PowerShell, captionTextBox.Text);
        }

        void outArchiveTypeChanged(object sender, EventArgs e)
        {
            updateArchiveExtensions();
            fillCompressionMethods();
            fillCompressionLevels();
        }

        private void updateArchiveExtensions()
        {
            if (OutArchiveFormat == null)
            {
                return;
            }

            internalPurposeZipArchiveNameFormatTextBox.Text = getNewArchiveFormat(
                internalPurposeZipArchiveNameFormatTextBox.Text,
                OutArchiveFormat.Value);

            releaseTextBox.Text = getNewArchiveFormat(
                releaseTextBox.Text,
                OutArchiveFormat.Value);
        }

        private static string getNewArchiveFormat(string text, OutArchiveFormat archiveFormat)
        {
            var newExt = CompressionHelper.GetArchiveExtension(archiveFormat);
            return Path.ChangeExtension(text, newExt);
        }

        void onCompressionMethodChanged(object sender, EventArgs e)
        {
            fillCompressionLevels();
        }

        void fillCompressionLevels()
        {
            if (OutArchiveFormat != null &&
                CompressionMethod != null)
            {
                compressionLevelToolStripComboBox_.Items.Clear();
                var allowedCompressionLevels = CompressionHelper.GetAllowedCompressionLevels(OutArchiveFormat.Value, CompressionMethod.Value);
                Array.ForEach(allowedCompressionLevels, item => compressionLevelToolStripComboBox_.Items.Add(item));

                compressionLevelToolStripComboBox_.SelectedItem = CompressionHelper.GetCompressionLevelGoodDefault(OutArchiveFormat.Value, CompressionMethod.Value);
            }
        }

        void fillCompressionMethods()
        {
            compressionMethodToolStripComboBox_.Items.Clear();
            if (OutArchiveFormat != null)
            {
                var allowedCompressionMethods = CompressionHelper.GetAllowedCompressionMethods(OutArchiveFormat.Value);
                Array.ForEach(allowedCompressionMethods, item => compressionMethodToolStripComboBox_.Items.Add(item));

                compressionMethodToolStripComboBox_.SelectedItem = CompressionHelper.GetCompressionMethodGoodDefault(OutArchiveFormat.Value);
            }
        }

        #endregion
	}
}
