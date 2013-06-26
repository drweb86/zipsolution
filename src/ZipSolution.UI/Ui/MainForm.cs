using System;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using BULocalization;
using ZipSolution.Core.Configuration;
using ZipSolution.Core.Filters;
using ZipSolution.Core.Misc;

namespace ZipSolution.UI
{
    /// <summary>
    /// Main UI application form.
    /// </summary>
	internal partial class MainForm : Form
	{
		#region Fields
		
		//Please, confirm deletion of '{0}'
		string _pleaseConfirmDeletion;
		//Zip Solution
		string _caption;
		//Zip Solution - Zipping solution...
		string _inProgressCaption;
		Thread _workThread;
		readonly Controller _controller;
        readonly object _syncObj = new object();
		
		#endregion

        #region Constructors

        /// <summary>
        /// The default form contructor
        /// </summary>
        /// <param name="controller">the application controller</param>
		public MainForm(Controller controller, ProcessingContext processingContext)
		{
			_controller = controller;
			
			InitializeComponent();

            if (Settings.ShowTextInToolbars)
            {
                foreach (ToolStripItem control in mainToolBar.Items)
                {
                    if (control.Image != null)
                    {
                        control.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    }
                }
            }

            if (processingContext != null)
            {
                releaseCheckBox.Checked = processingContext.UseReleaseConfiguration;
            }
            _controller.Model.LocalsManager.OnApplyLanguage += applyLanguage;
			
			solutionListComboBox.Items.AddRange(_controller.Model.GetSolutionHeaders());
			
			int lastSelectedSolutionIndex = solutionListComboBox.Items.IndexOf(_controller.Model.LastZippedSolutionHeader);
			if (lastSelectedSolutionIndex > -1)
			{
				if (solutionListComboBox.Items.Count > lastSelectedSolutionIndex)
				{
					solutionListComboBox.SelectedIndex = lastSelectedSolutionIndex;
				}
			}
			
			Text = _caption;
			
			if (processingContext != null && 
                !string.IsNullOrEmpty(processingContext.PredefinedProjectToProcess))
			{
                ZipSolutionEntry solution = _controller.Model.GetSolution(processingContext.PredefinedProjectToProcess);
                if (solution != null)
                {
                    start(solution, processingContext, canceledProcessing, progressChanged);
                }
			}
            else if (
                processingContext != null &&
                !string.IsNullOrEmpty(processingContext.PredefinedSolutionFileToProcess))
            {
                ZipSolutionEntry solution = _controller.LoadSolutionFromFile(processingContext.PredefinedSolutionFileToProcess);
                if (solution != null)
                {
                    start(solution, processingContext, canceledProcessing, progressChanged);
                }
            }
		
			refreshSolutionHeaders();
            applyLanguage(Translation.Current);
		}

        #endregion

        #region Private Methods

        void progressChanged(long progress)
		{
			if (InvokeRequired)
			{
                Invoke(new Action<long>(progressChanged), progress);
			}
			else
			{
				progressBar.Value = Convert.ToInt32(progress);
			}
		}
		
		void applyLanguage(Translation translation)
		{
			_pleaseConfirmDeletion = translation[5];
			_caption = translation[6];
			_inProgressCaption = translation[7];
			releaseCheckBox.Text = translation[8];
			zipSolutionLabel.Text = translation[9];

            addToolStripButton.Text = translation[39];
            editToolStripButton.Text = translation[40];
            removeToolStripButton.Text = translation[41];
			Text = _caption;
            templateToolStripButton.Text = translation[75];
            loadSolutionFromFileToolStripButton.Text = translation[76];
		}

        void start(ZipSolutionEntry solution, ProcessingContext cmdLineProcessingContext, Action onCancel, Action<long> onProgress)
        {
            Text = _inProgressCaption;
            zipButton.Image = Resource.Stop;

            _workThread = new Thread(threadWork)
                              {
                                  IsBackground = true
                              };
            _workThread.SetApartmentState(ApartmentState.STA);

            _workThread.Start(new object[]
                                  {
                                      solution, 
                                      cmdLineProcessingContext ?? new ProcessingContext { UseReleaseConfiguration = releaseCheckBox.Checked }, 
                                      onCancel, 
                                      onProgress
                                  });
        }

        void startStopProcessing()
        { 
            progressBar.Value = 0;
			if (_workThread != null)
			{
				try
				{
					_workThread.Abort();
				}
				finally 
				{
					_workThread = null;
				}
				this.Text = _caption;
				zipButton.Image = Resource.Start;
			}
			else
			{
				if (solutionListComboBox.SelectedIndex > -1)
				{
                    start(
                        _controller.Model.GetSolution((string)solutionListComboBox.SelectedItem), 
                        null,
                        canceledProcessing, 
                        progressChanged);
				}
			}
        }

		void zipButtonClick(object sender, EventArgs e)
		{
            lock (_syncObj)
            {
                startStopProcessing();
            }
		}
		
		void addNewSolutionClick(object sender, EventArgs e)
		{
			addNewSolutionUI(string.Empty);
		}
		
		void addNewSolutionUI(string filterFolder)
		{
		    ZipSolutionEntry addedSolution;
			if (!string.IsNullOrEmpty(filterFolder))
			{
			    addedSolution = _controller.CreateSolution(filterFolder);
			}
			else
			{
                addedSolution = _controller.CreateSolution();
			}

            if (addedSolution != null)
            {
                solutionListComboBox.Items.Add(addedSolution.Header);
                solutionListComboBox.SelectedItem = addedSolution.Header;
                refreshSolutionHeaders();
            }
		}
		
		void mainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			_controller.SaveOptions();
		}
		
		void removeSolutionClick(object sender, EventArgs e)
		{
			if (solutionListComboBox.SelectedIndex > -1)
			{
				if (_controller.ShowYesNoBox(_pleaseConfirmDeletion, solutionListComboBox.SelectedItem))
				{
					_controller.RemoveSolutionFromModel((string)solutionListComboBox.SelectedItem);
					solutionListComboBox.Items.Remove(solutionListComboBox.SelectedItem);
				}
			}
			
			refreshSolutionHeaders();
		}
		
		void editSelectedSolution()
		{
			if (solutionListComboBox.SelectedIndex > -1)
			{
			    var editedItem = _controller.EditSolution((string) solutionListComboBox.SelectedItem);
                if (editedItem != null)
                {
                    solutionListComboBox.Items.Remove(solutionListComboBox.SelectedItem);
                    solutionListComboBox.Items.Add(editedItem.Header);
                    solutionListComboBox.SelectedItem = editedItem.Header;
                }
			}
			
			refreshSolutionHeaders();
		}
		
		void editSolutionClick(object sender, EventArgs e)
		{
			editSelectedSolution();
		}
		
		void solutionListComboBoxSelectedIndexChanged(object sender, EventArgs e)
		{
			refreshSolutionHeaders();
		}
		
		void refreshSolutionHeaders()
		{
			if (solutionListComboBox.Items.Count > 0)
			{
				if (solutionListComboBox.SelectedIndex < 0)
				{
					solutionListComboBox.SelectedItem = solutionListComboBox.Items[0];
				}
			}
			
			bool enabled = (solutionListComboBox.SelectedIndex > -1);
			
			zipButton.Enabled = enabled;
			releaseCheckBox.Enabled = enabled;
            editToolStripButton.Enabled = enabled;
            removeToolStripButton.Enabled = enabled;
		}
		
        /// <summary>
        /// Processes the solution
        /// </summary>
        /// <param name="argument">solution entry</param>
		void threadWork(object argument)
		{
			var arguments = (object[])argument;
            var result = _controller.Compress(
                (ZipSolutionEntry)arguments[0],
                (ProcessingContext)arguments[1], 
                //(Action)arguments[2], 
                (Action<long>)arguments[3]);

            switch (result)
            {
                case Successfull.Yes:
                    _controller.SaveOptions();
                    Application.Exit();
                    break;
                case Successfull.No:
                    ((Action) arguments[2])();
                    break;
                default:
                    throw new NotSupportedException(result.ToString());
            }
#warning: exit is broken. replaced to application.exit.
		}
		
		void canceledProcessing()
		{
			if (InvokeRequired)
			{
				Invoke(new Action(canceledProcessing));
			}
			else
			{
				zipButton.Image = Resource.Start;
				Text = _caption;
				_workThread = null;
			}
		}
		
		void mainFormDoubleClick(object sender, EventArgs e)
		{
			editSelectedSolution();
		}

		#region Drop Folder
		
		void mainFormDragDrop(object sender, DragEventArgs e)
		{
			dropFolderBackgroundWorker.RunWorkerAsync(e.Data);
		}
		
		void mainFormDragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.All;
		}
		
		void dropFolderBackgroundWorkerDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			IDataObject data = (IDataObject)e.Argument;
			e.Result = null;
			
			if( data.GetDataPresent(DataFormats.FileDrop, false) )
			{
				string[] newitems = (string[])data.GetData(DataFormats.FileDrop);
				
				if (newitems.Length > 0)
				{
					string folder = newitems[0];
					
					if (Directory.Exists(folder))
					{
						e.Result = folder;
					}
				}
			}
		}
		
		void dropFolderBackgroundWorkerRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			string folder = (string)e.Result;
			
			if (!string.IsNullOrEmpty(folder))
			{
				addNewSolutionUI(folder);
			}
		}
		
		#endregion
		
		void keyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F1)
			{
                helpClick(sender, e);
				e.SuppressKeyPress = true;
			    e.Handled = true;
			}
            else if (e.KeyCode == Keys.F3)
            { 
                loadSolutionFromFileClick(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.O && e.Control)
            {
                loadSolutionFromFileClick(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F5 && zipButton.Enabled)
            {
                zipButtonClick(this, e);
                e.Handled = true;
            }
            else if (
                (e.KeyCode == Keys.A && e.Control) ||
                (e.KeyCode == Keys.Add) ||
                (e.KeyCode == Keys.N && e.Control))
            {
                addNewSolutionClick(sender, e);
                e.Handled = true;
            }
		}

        void templateEditClick(object sender, EventArgs e)
        {
            _controller.EditTemplate();
        }

        void loadSolutionFromFileClick(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _controller.EditSolutionFromFile(openFileDialog.FileName);
            }
        }

        void languageSelectClick(object sender, EventArgs e)
        {
            _controller.ChangeAppLanguage();
        }

        void helpClick(object sender, EventArgs e)
        {
            _controller.ShowHelp();
        }

        #endregion
    }
}
