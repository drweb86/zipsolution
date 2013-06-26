namespace ZipSolution.UI
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.zipButton = new System.Windows.Forms.Button();
            this.zipSolutionLabel = new System.Windows.Forms.Label();
            this.solutionListComboBox = new System.Windows.Forms.ComboBox();
            this.releaseCheckBox = new System.Windows.Forms.CheckBox();
            this.dropFolderBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mainToolBar = new System.Windows.Forms.ToolStrip();
            this.addToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.loadSolutionFromFileToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.templateToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.languageToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.mainToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // zipButton
            // 
            this.zipButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zipButton.Image = ((System.Drawing.Image)(resources.GetObject("zipButton.Image")));
            this.zipButton.Location = new System.Drawing.Point(312, 69);
            this.zipButton.Name = "zipButton";
            this.zipButton.Size = new System.Drawing.Size(75, 23);
            this.zipButton.TabIndex = 0;
            this.zipButton.UseVisualStyleBackColor = false;
            this.zipButton.Click += new System.EventHandler(this.zipButtonClick);
            this.zipButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            // 
            // zipSolutionLabel
            // 
            this.zipSolutionLabel.Location = new System.Drawing.Point(9, 42);
            this.zipSolutionLabel.Name = "zipSolutionLabel";
            this.zipSolutionLabel.Size = new System.Drawing.Size(107, 23);
            this.zipSolutionLabel.TabIndex = 1;
            this.zipSolutionLabel.Text = "Zip solution:";
            // 
            // solutionListComboBox
            // 
            this.solutionListComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.solutionListComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.solutionListComboBox.FormattingEnabled = true;
            this.solutionListComboBox.Location = new System.Drawing.Point(122, 39);
            this.solutionListComboBox.Name = "solutionListComboBox";
            this.solutionListComboBox.Size = new System.Drawing.Size(265, 21);
            this.solutionListComboBox.TabIndex = 2;
            this.solutionListComboBox.SelectedIndexChanged += new System.EventHandler(this.solutionListComboBoxSelectedIndexChanged);
            this.solutionListComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            // 
            // releaseCheckBox
            // 
            this.releaseCheckBox.AutoSize = true;
            this.releaseCheckBox.Location = new System.Drawing.Point(8, 73);
            this.releaseCheckBox.Name = "releaseCheckBox";
            this.releaseCheckBox.Size = new System.Drawing.Size(65, 17);
            this.releaseCheckBox.TabIndex = 6;
            this.releaseCheckBox.Text = "Release";
            this.releaseCheckBox.UseVisualStyleBackColor = true;
            this.releaseCheckBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            // 
            // dropFolderBackgroundWorker
            // 
            this.dropFolderBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.dropFolderBackgroundWorkerDoWork);
            this.dropFolderBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.dropFolderBackgroundWorkerRunWorkerCompleted);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 97);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(399, 15);
            this.progressBar.TabIndex = 7;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Xml|*.xml";
            // 
            // mainToolBar
            // 
            this.mainToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripButton,
            this.editToolStripButton,
            this.removeToolStripButton,
            this.toolStripSeparator1,
            this.loadSolutionFromFileToolStripButton,
            this.toolStripSeparator3,
            this.templateToolStripButton,
            this.toolStripSeparator2,
            this.languageToolStripButton,
            this.helpToolStripButton});
            this.mainToolBar.Location = new System.Drawing.Point(0, 0);
            this.mainToolBar.Name = "mainToolBar";
            this.mainToolBar.Size = new System.Drawing.Size(399, 25);
            this.mainToolBar.TabIndex = 8;
            this.mainToolBar.Text = "mainToolBar";
            // 
            // addToolStripButton
            // 
            this.addToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addToolStripButton.Image")));
            this.addToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addToolStripButton.Name = "addToolStripButton";
            this.addToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addToolStripButton.Text = "Add...";
            this.addToolStripButton.Click += new System.EventHandler(this.addNewSolutionClick);
            // 
            // editToolStripButton
            // 
            this.editToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripButton.Image")));
            this.editToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editToolStripButton.Name = "editToolStripButton";
            this.editToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.editToolStripButton.Text = "Edit...";
            this.editToolStripButton.Click += new System.EventHandler(this.editSolutionClick);
            // 
            // removeToolStripButton
            // 
            this.removeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("removeToolStripButton.Image")));
            this.removeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeToolStripButton.Name = "removeToolStripButton";
            this.removeToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.removeToolStripButton.Text = "Remove";
            this.removeToolStripButton.Click += new System.EventHandler(this.removeSolutionClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // loadSolutionFromFileToolStripButton
            // 
            this.loadSolutionFromFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loadSolutionFromFileToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("loadSolutionFromFileToolStripButton.Image")));
            this.loadSolutionFromFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadSolutionFromFileToolStripButton.Name = "loadSolutionFromFileToolStripButton";
            this.loadSolutionFromFileToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.loadSolutionFromFileToolStripButton.Text = "Load Solution from File...";
            this.loadSolutionFromFileToolStripButton.Click += new System.EventHandler(this.loadSolutionFromFileClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // templateToolStripButton
            // 
            this.templateToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.templateToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.templateToolStripButton.Name = "templateToolStripButton";
            this.templateToolStripButton.Size = new System.Drawing.Size(70, 22);
            this.templateToolStripButton.Text = "Template...";
            this.templateToolStripButton.Click += new System.EventHandler(this.templateEditClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // languageToolStripButton
            // 
            this.languageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.languageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.languageToolStripButton.Name = "languageToolStripButton";
            this.languageToolStripButton.Size = new System.Drawing.Size(72, 22);
            this.languageToolStripButton.Text = "Language...";
            this.languageToolStripButton.Click += new System.EventHandler(this.languageSelectClick);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "?";
            this.helpToolStripButton.Click += new System.EventHandler(this.helpClick);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 112);
            this.Controls.Add(this.mainToolBar);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.zipSolutionLabel);
            this.Controls.Add(this.solutionListComboBox);
            this.Controls.Add(this.zipButton);
            this.Controls.Add(this.releaseCheckBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 150);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(402, 150);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zip Solution";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainFormFormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.mainFormDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.mainFormDragEnter);
            this.DoubleClick += new System.EventHandler(this.mainFormDoubleClick);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            this.mainToolBar.ResumeLayout(false);
            this.mainToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.ProgressBar progressBar;
		private System.ComponentModel.BackgroundWorker dropFolderBackgroundWorker;
        private System.Windows.Forms.Label zipSolutionLabel;
        private System.Windows.Forms.CheckBox releaseCheckBox;
		private System.Windows.Forms.ComboBox solutionListComboBox;
        private System.Windows.Forms.Button zipButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStrip mainToolBar;
        private System.Windows.Forms.ToolStripButton addToolStripButton;
        private System.Windows.Forms.ToolStripButton editToolStripButton;
        private System.Windows.Forms.ToolStripButton removeToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton loadSolutionFromFileToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton templateToolStripButton;
        private System.Windows.Forms.ToolStripButton languageToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
	}
}
