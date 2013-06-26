using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using HDE.Platform.Logging;
using Ionic.Utils;
using ZipSolution.Core.DataSources;
using ZipSolution.Core.Filters;
using ZipSolution.Core.Localization;
using BULocalization;

namespace ZipSolution.UI
{
    #region Delegates

    delegate void SetSolutionName(string name);

    #endregion

    /// <summary>
	/// Provides availability to use folder with list of filters.
	/// </summary>
	sealed partial class FolderWithFiltersUserControl : UserControl, IDataSourceConfig
	{
		#region Fields

		Action<string> _showError;
        Func<FilterConfiguration> _addFilter;

		#endregion
		
		#region Events
		
		[Description("Allowes to automatically set the solution name on a base of folder")]
		public event SetSolutionName OnSetSolutionName;
		
		#endregion
		
		#region Properties

		/// <summary>
		/// The data source
		/// </summary>
		[DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]// workaround of SD designer issue
		public IDataSource DataSource
		{
			get 
			{ 
				if (!ValidStorageState())
				{
					throw new InvalidOperationException("State is invalid!");
				}

				return new FolderAndFiltersDataSource(solutionFolderTextBox.Text, getFilters());
			}
			set 
			{
				FolderAndFiltersDataSource dataSource = value as FolderAndFiltersDataSource;
				if (dataSource == null)
				{
					throw new InvalidOperationException("Cannot configure such datasource type");
				}
			
				solutionFolderTextBox.Text = dataSource.SolutionFolder;
				IEnumerable<FilterConfiguration> filters = dataSource.Filters;
				
				foreach (FilterConfiguration filter in filters)
				{
					addFilter(filter);
				}
			}
		}	

		#endregion
		
		#region Contructors
		
		/// <summary>
		/// The default contructor
		/// Don't forget to call Init
		/// </summary>
		public FolderWithFiltersUserControl()
		{
			InitializeComponent();
		}
	
		#endregion
		
		#region Public Methods

        /// <summary>
        /// Here localization and data set.
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="showError">Allows to show errors.</param>
        /// <param name="addFilter">Adds filter configuration.</param>
        public void Init(ILog log, 
            Action<string> showError,
            Func<FilterConfiguration> addFilter)
        {
            _showError = showError;
            _addFilter = addFilter;

            applyLocals();
        }

        /// <summary>
        /// Disables check for project folder existence 
        /// and disables controls
        /// </summary>
        public void TurnOffChoosingSolutionFolderFunctionality()
        {
            solutionFolderLabel.Enabled = false;
            solutionFolderTextBox.Text = " ";
            solutionFolderTextBox.Enabled = false;
            browseSolutionFolderButton.Enabled = false;
        }

		/// <summary>
		/// Adds default filters
		/// </summary>
        /// <param name="filters">List of default filters to add</param>
        /// <exception cref="ArgumentNullException">List of filters is null</exception>
		public void AddDefaultFilters(IEnumerable<FilterConfiguration> filters)
		{
            if (filters == null)
            {
                throw new ArgumentNullException("filters");
            }
            foreach (FilterConfiguration filterConfig in filters)
            {
                addFilter(filterConfig);
            }
		}
		
		/// <summary>
		/// Sets the solution folder and raises OnSetSolutionName event
		/// </summary>
		/// <param name="folder">The folder to set</param>
		public void SetSolutionFolder(string folder)
		{
			solutionFolderTextBox.Text = folder;
			if (OnSetSolutionName != null)
			{
				OnSetSolutionName(Path.GetFileName(folder));
			}
		}
		
		/// <summary>
		/// Checks the data and shows the message to the user if it is not valid
		/// </summary>
		/// <returns>True if all's OK </returns>
		public bool ValidStorageState()
		{
            // we've disabled editing solution folder
            if (!solutionFolderTextBox.Enabled)
            {
                return true;
            }
			if (string.IsNullOrEmpty(solutionFolderTextBox.Text))
			{
                _showError(Translation.Current[19]);
				return false;
			}
			
			if (!Directory.Exists(solutionFolderTextBox.Text))
			{
                _showError(Translation.Current[56]);
				return false;
			}

			return true;
		}

		#endregion
		
		#region Private Methods

        void applyLocals()
        {
            solutionFolderLabel.Text = Translation.Current[27];
            filtersLabel.Text = Translation.Current[32];
            filtersListView.Columns[0].Text = Translation.Current[33];
            filtersListView.Columns[1].Text = Translation.Current[34];
            filtersListView.Columns[2].Text = Translation.Current[35];
            addToolStripMenuItem1.Text = Translation.Current[39];
            removeToolStripMenuItem1.Text = Translation.Current[41];
        }

		void solutionFolderTextBoxDragDrop(object sender, DragEventArgs e)
		{
			if( e.Data.GetDataPresent(DataFormats.FileDrop, false) )
			{
				string[] newitems = (string[])e.Data.GetData(DataFormats.FileDrop);
				
				foreach (string folder in newitems)
				{
					if (Directory.Exists(folder))
					{
						SetSolutionFolder(folder);
					}
				}
			}
		}
		
		void solutionFolderTextBoxDragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.All;
		}

		void browseRootFolderButtonClick(object sender, EventArgs e)
		{
		    FolderBrowserDialogEx.LastSelectedPath = solutionFolderTextBox.Text;
            if (FolderBrowserDialogEx.Execute())
			{
                SetSolutionFolder(FolderBrowserDialogEx.LastSelectedPath);
			}
		}
		
		void filtersListViewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Delete)
			{
				removeSelectedFilters();
			}
			// 'Ctrl + A' support
			else if (e.Control)
			{
				if (e.KeyCode == Keys.A)
				{
					foreach (ListViewItem item in filtersListView.Items)
					{
						item.Selected = true;
					}
				}
			}
		}
		
		void filtersListViewSelectedIndexChanged(object sender, EventArgs e)
		{
			removeToolStripMenuItem1.Enabled = removeFilterButton.Enabled = filtersListView.SelectedItems.Count > 0;
    	}
		
		void addFilter(FilterConfiguration filter)
		{
			ListViewItem item = new ListViewItem(
				new string[] {
					FilterActionConverter.ToString(filter.FilterAction), 
					KindConverter.ToString(filter.Affected), 
					filter.Parameter});
			item.Tag = filter;
			filtersListView.Items.Add(item);
		}
		
		void removeSelectedFilters()
		{
            filtersListView.BeginUpdate();

			ListView.SelectedListViewItemCollection filters = filtersListView.SelectedItems;
			
			if (filters.Count > 0)
			{
				int indexToSetAfterDeleting = filters[0].Index;
				
				foreach (ListViewItem filter in filters)
				{
					filtersListView.Items.Remove(filter);
				}
				
				if (filtersListView.Items.Count > indexToSetAfterDeleting)
				{
					filtersListView.SelectedIndices.Add(indexToSetAfterDeleting);
				}
				else
				{
					if (filtersListView.Items.Count > 0)
					{
						filtersListView.SelectedIndices.Add(filtersListView.Items.Count - 1);
					}
				}
				
				filtersListView.Focus();
			}

            filtersListView.EndUpdate();
		}
		
		Collection<FilterConfiguration> getFilters()
		{
			Collection<FilterConfiguration> filters = new Collection<FilterConfiguration>();
			
			foreach (ListViewItem item in filtersListView.Items)
			{
				filters.Add((FilterConfiguration)item.Tag);
			}
			
			return filters;
		}

        void addFilterButtonClick(object sender, EventArgs e)
        {
            var filter = _addFilter();

            if (filter != null)
            {
                addFilter(filter);
            }
        }

        void removeFiltersButtonClick(object sender, EventArgs e)
		{
			removeSelectedFilters();
		}

		#endregion
	}
}
