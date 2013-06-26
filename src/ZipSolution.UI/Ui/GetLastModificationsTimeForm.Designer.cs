namespace ZipSolution.Ui
{
	partial class GetLastModificationsTimeForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetLastModificationsTimeForm));
			this.lastModificationsDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.cancelButton = new System.Windows.Forms.Button();
			this.OkButton = new System.Windows.Forms.Button();
			this.helpButton = new System.Windows.Forms.Button();
			this.doNotApplyButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lastModificationsDateTimePicker
			// 
			this.lastModificationsDateTimePicker.CustomFormat = "dddd, dd MMMM yyyy HH:mm:ss";
			this.lastModificationsDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.lastModificationsDateTimePicker.Location = new System.Drawing.Point(12, 12);
			this.lastModificationsDateTimePicker.Name = "lastModificationsDateTimePicker";
			this.lastModificationsDateTimePicker.Size = new System.Drawing.Size(283, 20);
			this.lastModificationsDateTimePicker.TabIndex = 0;
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(259, 48);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 4;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// OkButton
			// 
			this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OkButton.Location = new System.Drawing.Point(12, 48);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(75, 23);
			this.OkButton.TabIndex = 2;
			this.OkButton.Text = "OK";
			this.OkButton.UseVisualStyleBackColor = true;
			// 
			// helpButton
			// 
			this.helpButton.Image = ((System.Drawing.Image)(resources.GetObject("helpButton.Image")));
			this.helpButton.Location = new System.Drawing.Point(301, 6);
			this.helpButton.Name = "helpButton";
			this.helpButton.Size = new System.Drawing.Size(32, 32);
			this.helpButton.TabIndex = 1;
			this.helpButton.UseVisualStyleBackColor = true;
			this.helpButton.Click += new System.EventHandler(this.helpButtonClick);
			// 
			// doNotApplyButton
			// 
			this.doNotApplyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.doNotApplyButton.DialogResult = System.Windows.Forms.DialogResult.No;
			this.doNotApplyButton.Location = new System.Drawing.Point(93, 48);
			this.doNotApplyButton.Name = "doNotApplyButton";
			this.doNotApplyButton.Size = new System.Drawing.Size(160, 23);
			this.doNotApplyButton.TabIndex = 3;
			this.doNotApplyButton.Text = "Do Not Apply Filter";
			this.doNotApplyButton.UseVisualStyleBackColor = true;
			// 
			// GetLastModificationsTimeForm
			// 
			this.AcceptButton = this.OkButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(346, 83);
			this.Controls.Add(this.doNotApplyButton);
			this.Controls.Add(this.helpButton);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.lastModificationsDateTimePicker);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GetLastModificationsTimeForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Please, Enter Start Time";
			this.Load += new System.EventHandler(this.getLastModificationsTimeFormLoad);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button doNotApplyButton;
		private System.Windows.Forms.Button helpButton;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.DateTimePicker lastModificationsDateTimePicker;
	}
}
