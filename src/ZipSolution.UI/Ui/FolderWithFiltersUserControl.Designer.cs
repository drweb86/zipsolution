
namespace ZipSolution.UI
{
	partial class FolderWithFiltersUserControl
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FolderWithFiltersUserControl));
            this.browseSolutionFolderButton = new System.Windows.Forms.Button();
            this.solutionFolderTextBox = new System.Windows.Forms.TextBox();
            this.solutionFolderLabel = new System.Windows.Forms.Label();
            this.filtersListView = new System.Windows.Forms.ListView();
            this.actionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.affectedColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.parameterColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.filtersContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFilterButton = new System.Windows.Forms.Button();
            this.addFilterButton = new System.Windows.Forms.Button();
            this.filtersLabel = new System.Windows.Forms.Label();
            this.filtersContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // browseSolutionFolderButton
            // 
            this.browseSolutionFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseSolutionFolderButton.Location = new System.Drawing.Point(407, 1);
            this.browseSolutionFolderButton.Name = "browseSolutionFolderButton";
            this.browseSolutionFolderButton.Size = new System.Drawing.Size(32, 23);
            this.browseSolutionFolderButton.TabIndex = 5;
            this.browseSolutionFolderButton.Text = "...";
            this.browseSolutionFolderButton.UseVisualStyleBackColor = true;
            this.browseSolutionFolderButton.Click += new System.EventHandler(this.browseRootFolderButtonClick);
            // 
            // solutionFolderTextBox
            // 
            this.solutionFolderTextBox.AllowDrop = true;
            this.solutionFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.solutionFolderTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.solutionFolderTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.solutionFolderTextBox.Location = new System.Drawing.Point(113, 3);
            this.solutionFolderTextBox.Name = "solutionFolderTextBox";
            this.solutionFolderTextBox.Size = new System.Drawing.Size(288, 20);
            this.solutionFolderTextBox.TabIndex = 4;
            this.solutionFolderTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.solutionFolderTextBoxDragDrop);
            this.solutionFolderTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.solutionFolderTextBoxDragEnter);
            // 
            // solutionFolderLabel
            // 
            this.solutionFolderLabel.Location = new System.Drawing.Point(7, 6);
            this.solutionFolderLabel.Name = "solutionFolderLabel";
            this.solutionFolderLabel.Size = new System.Drawing.Size(100, 23);
            this.solutionFolderLabel.TabIndex = 3;
            this.solutionFolderLabel.Text = "Solution folder:";
            // 
            // filtersListView
            // 
            this.filtersListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.filtersListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.filtersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.actionColumnHeader,
            this.affectedColumnHeader,
            this.parameterColumnHeader});
            this.filtersListView.ContextMenuStrip = this.filtersContextMenuStrip;
            this.filtersListView.FullRowSelect = true;
            this.filtersListView.Location = new System.Drawing.Point(6, 61);
            this.filtersListView.Name = "filtersListView";
            this.filtersListView.Size = new System.Drawing.Size(395, 123);
            this.filtersListView.TabIndex = 12;
            this.filtersListView.UseCompatibleStateImageBehavior = false;
            this.filtersListView.View = System.Windows.Forms.View.Details;
            this.filtersListView.SelectedIndexChanged += new System.EventHandler(this.filtersListViewSelectedIndexChanged);
            this.filtersListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.filtersListViewKeyDown);
            // 
            // actionColumnHeader
            // 
            this.actionColumnHeader.Text = "Action";
            this.actionColumnHeader.Width = 150;
            // 
            // affectedColumnHeader
            // 
            this.affectedColumnHeader.Text = "Affected";
            this.affectedColumnHeader.Width = 130;
            // 
            // parameterColumnHeader
            // 
            this.parameterColumnHeader.Text = "Parameter";
            this.parameterColumnHeader.Width = 75;
            // 
            // filtersContextMenuStrip
            // 
            this.filtersContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem1,
            this.removeToolStripMenuItem1});
            this.filtersContextMenuStrip.Name = "filtersContextMenuStrip";
            this.filtersContextMenuStrip.Size = new System.Drawing.Size(130, 48);
            // 
            // addToolStripMenuItem1
            // 
            this.addToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("addToolStripMenuItem1.Image")));
            this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            this.addToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.addToolStripMenuItem1.Text = "Add...";
            this.addToolStripMenuItem1.Click += new System.EventHandler(this.addFilterButtonClick);
            // 
            // removeToolStripMenuItem1
            // 
            this.removeToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("removeToolStripMenuItem1.Image")));
            this.removeToolStripMenuItem1.Name = "removeToolStripMenuItem1";
            this.removeToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.removeToolStripMenuItem1.Text = "Remove";
            this.removeToolStripMenuItem1.Click += new System.EventHandler(this.removeFiltersButtonClick);
            // 
            // removeFilterButton
            // 
            this.removeFilterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeFilterButton.Enabled = false;
            this.removeFilterButton.Image = ((System.Drawing.Image)(resources.GetObject("removeFilterButton.Image")));
            this.removeFilterButton.Location = new System.Drawing.Point(407, 99);
            this.removeFilterButton.Name = "removeFilterButton";
            this.removeFilterButton.Size = new System.Drawing.Size(32, 32);
            this.removeFilterButton.TabIndex = 15;
            this.removeFilterButton.UseVisualStyleBackColor = true;
            this.removeFilterButton.Click += new System.EventHandler(this.removeFiltersButtonClick);
            // 
            // addFilterButton
            // 
            this.addFilterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addFilterButton.Image = ((System.Drawing.Image)(resources.GetObject("addFilterButton.Image")));
            this.addFilterButton.Location = new System.Drawing.Point(407, 61);
            this.addFilterButton.Name = "addFilterButton";
            this.addFilterButton.Size = new System.Drawing.Size(32, 32);
            this.addFilterButton.TabIndex = 13;
            this.addFilterButton.UseVisualStyleBackColor = true;
            this.addFilterButton.Click += new System.EventHandler(this.addFilterButtonClick);
            // 
            // filtersLabel
            // 
            this.filtersLabel.Location = new System.Drawing.Point(8, 35);
            this.filtersLabel.Name = "filtersLabel";
            this.filtersLabel.Size = new System.Drawing.Size(412, 23);
            this.filtersLabel.TabIndex = 14;
            this.filtersLabel.Text = "Exclude filters for subdirectories and files in solution folder:";
            // 
            // FolderWithFiltersUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.filtersListView);
            this.Controls.Add(this.addFilterButton);
            this.Controls.Add(this.removeFilterButton);
            this.Controls.Add(this.filtersLabel);
            this.Controls.Add(this.browseSolutionFolderButton);
            this.Controls.Add(this.solutionFolderTextBox);
            this.Controls.Add(this.solutionFolderLabel);
            this.Name = "FolderWithFiltersUserControl";
            this.Size = new System.Drawing.Size(442, 187);
            this.filtersContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem1;
		private System.Windows.Forms.ContextMenuStrip filtersContextMenuStrip;
		private System.Windows.Forms.Label filtersLabel;
		private System.Windows.Forms.Button addFilterButton;
		private System.Windows.Forms.Button removeFilterButton;
		private System.Windows.Forms.ColumnHeader parameterColumnHeader;
		private System.Windows.Forms.ColumnHeader affectedColumnHeader;
		private System.Windows.Forms.ColumnHeader actionColumnHeader;
        private System.Windows.Forms.ListView filtersListView;
		private System.Windows.Forms.Label solutionFolderLabel;
		private System.Windows.Forms.TextBox solutionFolderTextBox;
		private System.Windows.Forms.Button browseSolutionFolderButton;
	}
}
