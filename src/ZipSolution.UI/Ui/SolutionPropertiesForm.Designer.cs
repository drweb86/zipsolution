
namespace ZipSolution.UI
{
	partial class SolutionPropertiesForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SolutionPropertiesForm));
            this._captionLabel = new System.Windows.Forms.Label();
            this.captionTextBox = new System.Windows.Forms.TextBox();
            this.internalPurposeZipArchiveNameFormatTextBox = new System.Windows.Forms.TextBox();
            this.foldersListBox = new System.Windows.Forms.ListBox();
            this.foldersContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._putInLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._fiuLabel = new System.Windows.Forms.Label();
            this._releaseLabel = new System.Windows.Forms.Label();
            this.releaseTextBox = new System.Windows.Forms.TextBox();
            this._releaseZipGroupBox = new System.Windows.Forms.GroupBox();
            this.holdDataSourceConfigureControlPanel = new System.Windows.Forms.Panel();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.propertiesToolStrip_ = new System.Windows.Forms.ToolStrip();
            this._viewToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this._copyBatToBufferToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._copyCmdToBufferToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._copyPowerShellToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this._saveToFileToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._testToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._archiveBarLabel = new System.Windows.Forms.ToolStripLabel();
            this._typeToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.outArchiveTypeToolStripComboBox_ = new System.Windows.Forms.ToolStripComboBox();
            this._methodToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.compressionMethodToolStripComboBox_ = new System.Windows.Forms.ToolStripComboBox();
            this._levelToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.compressionLevelToolStripComboBox_ = new System.Windows.Forms.ToolStripComboBox();
            this.addFolderButton = new System.Windows.Forms.Button();
            this.removeFolderButton = new System.Windows.Forms.Button();
            this.supportedFormatItemsButton = new System.Windows.Forms.Button();
            this.foldersContextMenuStrip.SuspendLayout();
            this._releaseZipGroupBox.SuspendLayout();
            this.propertiesToolStrip_.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _captionLabel
            // 
            this._captionLabel.AutoSize = true;
            this._captionLabel.Location = new System.Drawing.Point(12, 71);
            this._captionLabel.Name = "_captionLabel";
            this._captionLabel.Size = new System.Drawing.Size(46, 13);
            this._captionLabel.TabIndex = 3;
            this._captionLabel.Text = "Caption:";
            // 
            // captionTextBox
            // 
            this.captionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.captionTextBox.Location = new System.Drawing.Point(119, 68);
            this.captionTextBox.Name = "captionTextBox";
            this.captionTextBox.Size = new System.Drawing.Size(467, 20);
            this.captionTextBox.TabIndex = 0;
            // 
            // internalPurposeZipArchiveNameFormatTextBox
            // 
            this.internalPurposeZipArchiveNameFormatTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.internalPurposeZipArchiveNameFormatTextBox.Location = new System.Drawing.Point(6, 32);
            this.internalPurposeZipArchiveNameFormatTextBox.Name = "internalPurposeZipArchiveNameFormatTextBox";
            this.internalPurposeZipArchiveNameFormatTextBox.Size = new System.Drawing.Size(562, 20);
            this.internalPurposeZipArchiveNameFormatTextBox.TabIndex = 6;
            // 
            // foldersListBox
            // 
            this.foldersListBox.AllowDrop = true;
            this.foldersListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.foldersListBox.ContextMenuStrip = this.foldersContextMenuStrip;
            this.foldersListBox.FormattingEnabled = true;
            this.foldersListBox.Location = new System.Drawing.Point(12, 424);
            this.foldersListBox.Name = "foldersListBox";
            this.foldersListBox.Size = new System.Drawing.Size(574, 108);
            this.foldersListBox.TabIndex = 2;
            this.foldersListBox.SelectedIndexChanged += new System.EventHandler(this.foldersListBoxSelectedIndexChanged);
            this.foldersListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.foldersListBoxDragDrop);
            this.foldersListBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.foldersListBoxDragEnter);
            this.foldersListBox.DoubleClick += new System.EventHandler(this.foldersListBoxDoubleClick);
            this.foldersListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.foldersListBoxKeyDown);
            this.foldersListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.foldersListBoxMouseDown);
            // 
            // foldersContextMenuStrip
            // 
            this.foldersContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._addToolStripMenuItem,
            this._removeToolStripMenuItem,
            this._openToolStripMenuItem});
            this.foldersContextMenuStrip.Name = "foldersContextMenuStrip";
            this.foldersContextMenuStrip.Size = new System.Drawing.Size(118, 70);
            this.foldersContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.foldersContextMenuStripOpening);
            // 
            // _addToolStripMenuItem
            // 
            this._addToolStripMenuItem.Image = global::ZipSolution.Resource.Add;
            this._addToolStripMenuItem.Name = "_addToolStripMenuItem";
            this._addToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this._addToolStripMenuItem.Text = "Add...";
            this._addToolStripMenuItem.Click += new System.EventHandler(this.addFolderButtonClick);
            // 
            // _removeToolStripMenuItem
            // 
            this._removeToolStripMenuItem.Image = global::ZipSolution.Resource.Remove;
            this._removeToolStripMenuItem.Name = "_removeToolStripMenuItem";
            this._removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this._removeToolStripMenuItem.Text = "Remove";
            this._removeToolStripMenuItem.Click += new System.EventHandler(this.removeFolderButtonClick);
            // 
            // _openToolStripMenuItem
            // 
            this._openToolStripMenuItem.Name = "_openToolStripMenuItem";
            this._openToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this._openToolStripMenuItem.Text = "Open...";
            this._openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItemClick);
            // 
            // _putInLabel
            // 
            this._putInLabel.AutoSize = true;
            this._putInLabel.Location = new System.Drawing.Point(12, 408);
            this._putInLabel.Name = "_putInLabel";
            this._putInLabel.Size = new System.Drawing.Size(109, 13);
            this._putInLabel.TabIndex = 8;
            this._putInLabel.Text = "Put archive in folders:";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(465, 640);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 12;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButtonClick);
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(551, 640);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 13;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _fiuLabel
            // 
            this._fiuLabel.AutoSize = true;
            this._fiuLabel.Location = new System.Drawing.Point(6, 16);
            this._fiuLabel.Name = "_fiuLabel";
            this._fiuLabel.Size = new System.Drawing.Size(108, 13);
            this._fiuLabel.TabIndex = 18;
            this._fiuLabel.Text = "For internal purposes:";
            // 
            // _releaseLabel
            // 
            this._releaseLabel.AutoSize = true;
            this._releaseLabel.Location = new System.Drawing.Point(6, 55);
            this._releaseLabel.Name = "_releaseLabel";
            this._releaseLabel.Size = new System.Drawing.Size(49, 13);
            this._releaseLabel.TabIndex = 19;
            this._releaseLabel.Text = "Release:";
            // 
            // releaseTextBox
            // 
            this.releaseTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.releaseTextBox.Location = new System.Drawing.Point(6, 71);
            this.releaseTextBox.Name = "releaseTextBox";
            this.releaseTextBox.Size = new System.Drawing.Size(562, 20);
            this.releaseTextBox.TabIndex = 7;
            // 
            // _releaseZipGroupBox
            // 
            this._releaseZipGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._releaseZipGroupBox.Controls.Add(this._fiuLabel);
            this._releaseZipGroupBox.Controls.Add(this.releaseTextBox);
            this._releaseZipGroupBox.Controls.Add(this._releaseLabel);
            this._releaseZipGroupBox.Controls.Add(this.internalPurposeZipArchiveNameFormatTextBox);
            this._releaseZipGroupBox.Location = new System.Drawing.Point(11, 533);
            this._releaseZipGroupBox.Name = "_releaseZipGroupBox";
            this._releaseZipGroupBox.Size = new System.Drawing.Size(574, 101);
            this._releaseZipGroupBox.TabIndex = 5;
            this._releaseZipGroupBox.TabStop = false;
            this._releaseZipGroupBox.Text = "Zip archive file name format strings:";
            // 
            // holdDataSourceConfigureControlPanel
            // 
            this.holdDataSourceConfigureControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.holdDataSourceConfigureControlPanel.Location = new System.Drawing.Point(6, 100);
            this.holdDataSourceConfigureControlPanel.Name = "holdDataSourceConfigureControlPanel";
            this.holdDataSourceConfigureControlPanel.Size = new System.Drawing.Size(622, 305);
            this.holdDataSourceConfigureControlPanel.TabIndex = 1;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "Solution";
            this.saveFileDialog.Filter = "Xml|*.xml";
            // 
            // propertiesToolStrip_
            // 
            this.propertiesToolStrip_.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._viewToolStripLabel,
            this._copyBatToBufferToolStripButton,
            this.toolStripSeparator2,
            this._copyCmdToBufferToolStripButton,
            this.toolStripSeparator1,
            this._copyPowerShellToolStripButton,
            this.toolStripSeparator3,
            this._saveToFileToolStripButton,
            this._testToolStripButton});
            this.propertiesToolStrip_.Location = new System.Drawing.Point(0, 0);
            this.propertiesToolStrip_.Name = "propertiesToolStrip_";
            this.propertiesToolStrip_.Size = new System.Drawing.Size(638, 25);
            this.propertiesToolStrip_.TabIndex = 14;
            this.propertiesToolStrip_.Text = "toolStrip1";
            // 
            // _viewToolStripLabel
            // 
            this._viewToolStripLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._viewToolStripLabel.Margin = new System.Windows.Forms.Padding(4, 1, 4, 2);
            this._viewToolStripLabel.Name = "_viewToolStripLabel";
            this._viewToolStripLabel.Size = new System.Drawing.Size(37, 22);
            this._viewToolStripLabel.Text = "VIEW";
            // 
            // _copyBatToBufferToolStripButton
            // 
            this._copyBatToBufferToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._copyBatToBufferToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._copyBatToBufferToolStripButton.Name = "_copyBatToBufferToolStripButton";
            this._copyBatToBufferToolStripButton.Size = new System.Drawing.Size(33, 22);
            this._copyBatToBufferToolStripButton.Text = "BAT";
            this._copyBatToBufferToolStripButton.Click += new System.EventHandler(this.getbatScriptToolStripMenuItemClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // _copyCmdToBufferToolStripButton
            // 
            this._copyCmdToBufferToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._copyCmdToBufferToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._copyCmdToBufferToolStripButton.Name = "_copyCmdToBufferToolStripButton";
            this._copyCmdToBufferToolStripButton.Size = new System.Drawing.Size(38, 22);
            this._copyCmdToBufferToolStripButton.Text = "CMD";
            this._copyCmdToBufferToolStripButton.Click += new System.EventHandler(this.getcmdScriptToolStripMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _copyPowerShellToolStripButton
            // 
            this._copyPowerShellToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._copyPowerShellToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_copyPowerShellToolStripButton.Image")));
            this._copyPowerShellToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._copyPowerShellToolStripButton.Name = "_copyPowerShellToolStripButton";
            this._copyPowerShellToolStripButton.Size = new System.Drawing.Size(69, 22);
            this._copyPowerShellToolStripButton.Text = "PowerShell";
            this._copyPowerShellToolStripButton.Click += new System.EventHandler(this.onPowerShellCopyScriptToolStripButtonClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // _saveToFileToolStripButton
            // 
            this._saveToFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._saveToFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._saveToFileToolStripButton.Name = "_saveToFileToolStripButton";
            this._saveToFileToolStripButton.Size = new System.Drawing.Size(181, 22);
            this._saveToFileToolStripButton.Text = "Save to File with Relative Paths...";
            this._saveToFileToolStripButton.Click += new System.EventHandler(this.saveSolutionToFileClick);
            // 
            // _testToolStripButton
            // 
            this._testToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._testToolStripButton.Image = global::ZipSolution.Resource.Start;
            this._testToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._testToolStripButton.Name = "_testToolStripButton";
            this._testToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._testToolStripButton.Text = "Tests the current solution in another instance of program";
            this._testToolStripButton.ToolTipText = "Tests the current solution (F5)";
            this._testToolStripButton.Click += new System.EventHandler(this.onTestToolStripButtonClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._archiveBarLabel,
            this._typeToolStripLabel,
            this.outArchiveTypeToolStripComboBox_,
            this._methodToolStripLabel,
            this.compressionMethodToolStripComboBox_,
            this._levelToolStripLabel,
            this.compressionLevelToolStripComboBox_});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(638, 25);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // _archiveBarLabel
            // 
            this._archiveBarLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._archiveBarLabel.Margin = new System.Windows.Forms.Padding(4, 1, 4, 2);
            this._archiveBarLabel.Name = "_archiveBarLabel";
            this._archiveBarLabel.Size = new System.Drawing.Size(57, 22);
            this._archiveBarLabel.Text = "ARCHIVE";
            // 
            // _typeToolStripLabel
            // 
            this._typeToolStripLabel.Name = "_typeToolStripLabel";
            this._typeToolStripLabel.Size = new System.Drawing.Size(33, 22);
            this._typeToolStripLabel.Text = "Type";
            // 
            // outArchiveTypeToolStripComboBox_
            // 
            this.outArchiveTypeToolStripComboBox_.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outArchiveTypeToolStripComboBox_.Name = "outArchiveTypeToolStripComboBox_";
            this.outArchiveTypeToolStripComboBox_.Size = new System.Drawing.Size(121, 25);
            this.outArchiveTypeToolStripComboBox_.SelectedIndexChanged += new System.EventHandler(this.outArchiveTypeChanged);
            // 
            // _methodToolStripLabel
            // 
            this._methodToolStripLabel.Margin = new System.Windows.Forms.Padding(4, 1, 0, 2);
            this._methodToolStripLabel.Name = "_methodToolStripLabel";
            this._methodToolStripLabel.Size = new System.Drawing.Size(49, 22);
            this._methodToolStripLabel.Text = "Method";
            // 
            // compressionMethodToolStripComboBox_
            // 
            this.compressionMethodToolStripComboBox_.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.compressionMethodToolStripComboBox_.Name = "compressionMethodToolStripComboBox_";
            this.compressionMethodToolStripComboBox_.Size = new System.Drawing.Size(121, 25);
            this.compressionMethodToolStripComboBox_.SelectedIndexChanged += new System.EventHandler(this.onCompressionMethodChanged);
            // 
            // _levelToolStripLabel
            // 
            this._levelToolStripLabel.Margin = new System.Windows.Forms.Padding(4, 1, 0, 2);
            this._levelToolStripLabel.Name = "_levelToolStripLabel";
            this._levelToolStripLabel.Size = new System.Drawing.Size(34, 22);
            this._levelToolStripLabel.Text = "Level";
            // 
            // compressionLevelToolStripComboBox_
            // 
            this.compressionLevelToolStripComboBox_.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.compressionLevelToolStripComboBox_.Name = "compressionLevelToolStripComboBox_";
            this.compressionLevelToolStripComboBox_.Size = new System.Drawing.Size(121, 25);
            // 
            // addFolderButton
            // 
            this.addFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addFolderButton.Image = ((System.Drawing.Image)(resources.GetObject("addFolderButton.Image")));
            this.addFolderButton.Location = new System.Drawing.Point(591, 424);
            this.addFolderButton.Name = "addFolderButton";
            this.addFolderButton.Size = new System.Drawing.Size(32, 32);
            this.addFolderButton.TabIndex = 3;
            this.addFolderButton.UseVisualStyleBackColor = true;
            this.addFolderButton.Click += new System.EventHandler(this.addFolderButtonClick);
            // 
            // removeFolderButton
            // 
            this.removeFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeFolderButton.Enabled = false;
            this.removeFolderButton.Image = ((System.Drawing.Image)(resources.GetObject("removeFolderButton.Image")));
            this.removeFolderButton.Location = new System.Drawing.Point(591, 462);
            this.removeFolderButton.Name = "removeFolderButton";
            this.removeFolderButton.Size = new System.Drawing.Size(32, 32);
            this.removeFolderButton.TabIndex = 4;
            this.removeFolderButton.UseVisualStyleBackColor = true;
            this.removeFolderButton.Click += new System.EventHandler(this.removeFolderButtonClick);
            // 
            // supportedFormatItemsButton
            // 
            this.supportedFormatItemsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.supportedFormatItemsButton.Image = ((System.Drawing.Image)(resources.GetObject("supportedFormatItemsButton.Image")));
            this.supportedFormatItemsButton.Location = new System.Drawing.Point(591, 539);
            this.supportedFormatItemsButton.Name = "supportedFormatItemsButton";
            this.supportedFormatItemsButton.Size = new System.Drawing.Size(32, 32);
            this.supportedFormatItemsButton.TabIndex = 8;
            this.supportedFormatItemsButton.UseVisualStyleBackColor = true;
            this.supportedFormatItemsButton.Click += new System.EventHandler(this.supportedFormatItemsHelpButtonClick);
            // 
            // SolutionPropertiesForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(638, 675);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.holdDataSourceConfigureControlPanel);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this._captionLabel);
            this.Controls.Add(this.addFolderButton);
            this.Controls.Add(this.captionTextBox);
            this.Controls.Add(this._putInLabel);
            this.Controls.Add(this.foldersListBox);
            this.Controls.Add(this._releaseZipGroupBox);
            this.Controls.Add(this.removeFolderButton);
            this.Controls.Add(this.supportedFormatItemsButton);
            this.Controls.Add(this.propertiesToolStrip_);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SolutionPropertiesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Item";
            this.Shown += new System.EventHandler(this.newItemFormShown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.onSolutionPropertiesFormKeyDown);
            this.foldersContextMenuStrip.ResumeLayout(false);
            this._releaseZipGroupBox.ResumeLayout(false);
            this._releaseZipGroupBox.PerformLayout();
            this.propertiesToolStrip_.ResumeLayout(false);
            this.propertiesToolStrip_.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.Panel holdDataSourceConfigureControlPanel;
        private System.Windows.Forms.ToolStripMenuItem _openToolStripMenuItem;
		private System.Windows.Forms.Label _putInLabel;
		private System.Windows.Forms.Label _releaseLabel;
		private System.Windows.Forms.Label _fiuLabel;
		private System.Windows.Forms.Label _captionLabel;
		private System.Windows.Forms.ToolStripMenuItem _removeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem _addToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip foldersContextMenuStrip;
		private System.Windows.Forms.Button supportedFormatItemsButton;
		private System.Windows.Forms.TextBox releaseTextBox;
		private System.Windows.Forms.TextBox internalPurposeZipArchiveNameFormatTextBox;
		private System.Windows.Forms.GroupBox _releaseZipGroupBox;
		private System.Windows.Forms.ListBox foldersListBox;
		private System.Windows.Forms.Button addFolderButton;
        private System.Windows.Forms.Button removeFolderButton;
		private System.Windows.Forms.TextBox captionTextBox;
		private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStrip propertiesToolStrip_;
        private System.Windows.Forms.ToolStripButton _copyBatToBufferToolStripButton;
        private System.Windows.Forms.ToolStripButton _copyCmdToBufferToolStripButton;
        private System.Windows.Forms.ToolStripButton _saveToFileToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton _testToolStripButton;
        private System.Windows.Forms.ToolStripButton _copyPowerShellToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel _viewToolStripLabel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel _archiveBarLabel;
        private System.Windows.Forms.ToolStripLabel _typeToolStripLabel;
        private System.Windows.Forms.ToolStripComboBox outArchiveTypeToolStripComboBox_;
        private System.Windows.Forms.ToolStripLabel _methodToolStripLabel;
        private System.Windows.Forms.ToolStripComboBox compressionMethodToolStripComboBox_;
        private System.Windows.Forms.ToolStripLabel _levelToolStripLabel;
        private System.Windows.Forms.ToolStripComboBox compressionLevelToolStripComboBox_;
	}
}
