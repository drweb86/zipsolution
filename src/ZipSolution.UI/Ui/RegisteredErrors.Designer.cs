#region Copyright
/* (c)Cuchuk Sergey Alexandrovich, 2008
 * Cuchuk.Sergey@gmail.com
 * toCuchukSergey@yandex.ru 
 */
#endregion
namespace ZipSolution.Ui
{
	partial class RegisteredErrors
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisteredErrors));
			this.closeButton = new System.Windows.Forms.Button();
			this.errorMessageTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// closeButton
			// 
			this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.closeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.closeButton.Location = new System.Drawing.Point(405, 101);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(75, 23);
			this.closeButton.TabIndex = 0;
			this.closeButton.Text = "OK";
			this.closeButton.UseVisualStyleBackColor = true;
			// 
			// errorMessageTextBox
			// 
			this.errorMessageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.errorMessageTextBox.BackColor = System.Drawing.Color.White;
			this.errorMessageTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.errorMessageTextBox.ForeColor = System.Drawing.Color.Red;
			this.errorMessageTextBox.Location = new System.Drawing.Point(12, 12);
			this.errorMessageTextBox.Multiline = true;
			this.errorMessageTextBox.Name = "errorMessageTextBox";
			this.errorMessageTextBox.ReadOnly = true;
			this.errorMessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.errorMessageTextBox.Size = new System.Drawing.Size(468, 83);
			this.errorMessageTextBox.TabIndex = 1;
			// 
			// RegisteredErrors
			// 
			this.AcceptButton = this.closeButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.closeButton;
			this.ClientSize = new System.Drawing.Size(492, 136);
			this.Controls.Add(this.errorMessageTextBox);
			this.Controls.Add(this.closeButton);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(500, 170);
			this.Name = "RegisteredErrors";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Registered Errors:";
			this.Load += new System.EventHandler(this.registeredErrorsLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox errorMessageTextBox;
		private System.Windows.Forms.Button closeButton;
	}
}
