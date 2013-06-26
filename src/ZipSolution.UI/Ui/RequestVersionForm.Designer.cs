#region Copyright
/* (c)Cuchuk Sergey Alexandrovich, 2008
 * Cuchuk.Sergey@gmail.com
 * toCuchukSergey@yandex.ru 
 */
#endregion
namespace ZipSolution.Ui
{
	partial class RequestVersionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequestVersionForm));
            this.versionLabel = new System.Windows.Forms.Label();
            this.versionTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // versionLabel
            // 
            this.versionLabel.Location = new System.Drawing.Point(12, 9);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(54, 23);
            this.versionLabel.TabIndex = 0;
            this.versionLabel.Text = "Version:";
            // 
            // versionTextBox
            // 
            this.versionTextBox.Location = new System.Drawing.Point(72, 6);
            this.versionTextBox.Name = "versionTextBox";
            this.versionTextBox.Size = new System.Drawing.Size(144, 20);
            this.versionTextBox.TabIndex = 1;
            this.versionTextBox.TextChanged += new System.EventHandler(this.versionTextBoxTextChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(141, 32);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(60, 32);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButtonClick);
            // 
            // errorLabel
            // 
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(12, 32);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(29, 23);
            this.errorLabel.TabIndex = 4;
            // 
            // RequestVersionForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(226, 61);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.versionTextBox);
            this.Controls.Add(this.versionLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RequestVersionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please, enter new version:";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.requestVersionFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.Label errorLabel;
		private System.Windows.Forms.Label versionLabel;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.TextBox versionTextBox;
	}
}
