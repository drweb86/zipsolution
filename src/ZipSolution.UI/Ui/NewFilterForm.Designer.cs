/*
 * Created by SharpDevelop.
 * User: Siarhei_Kuchuk
 * Date: 7/23/2008
 * Time: 5:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ZipSolution
{
	partial class NewFilterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewFilterForm));
            this.actionLabel = new System.Windows.Forms.Label();
            this.affectedLabel = new System.Windows.Forms.Label();
            this.maskLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.parameterTextBox = new System.Windows.Forms.TextBox();
            this.actionComboBox = new System.Windows.Forms.ComboBox();
            this.affectedItemsComboBox = new System.Windows.Forms.ComboBox();
            this.filterPropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.helpButton = new System.Windows.Forms.Button();
            this.filterPropertiesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // actionLabel
            // 
            this.actionLabel.Location = new System.Drawing.Point(6, 16);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(152, 23);
            this.actionLabel.TabIndex = 0;
            this.actionLabel.Text = "Action:";
            this.actionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // affectedLabel
            // 
            this.affectedLabel.Location = new System.Drawing.Point(6, 34);
            this.affectedLabel.Name = "affectedLabel";
            this.affectedLabel.Size = new System.Drawing.Size(152, 31);
            this.affectedLabel.TabIndex = 1;
            this.affectedLabel.Text = "Affected items:";
            this.affectedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // maskLabel
            // 
            this.maskLabel.Location = new System.Drawing.Point(6, 65);
            this.maskLabel.Name = "maskLabel";
            this.maskLabel.Size = new System.Drawing.Size(152, 23);
            this.maskLabel.TabIndex = 2;
            this.maskLabel.Text = "Mask:";
            this.maskLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(281, 118);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(200, 118);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButtonClick);
            // 
            // parameterTextBox
            // 
            this.parameterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.parameterTextBox.Location = new System.Drawing.Point(164, 67);
            this.parameterTextBox.Name = "parameterTextBox";
            this.parameterTextBox.Size = new System.Drawing.Size(174, 20);
            this.parameterTextBox.TabIndex = 2;
            this.parameterTextBox.TextChanged += new System.EventHandler(this.parameterTextBoxTextChanged);
            // 
            // actionComboBox
            // 
            this.actionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.actionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionComboBox.FormattingEnabled = true;
            this.actionComboBox.Location = new System.Drawing.Point(164, 13);
            this.actionComboBox.Name = "actionComboBox";
            this.actionComboBox.Size = new System.Drawing.Size(174, 21);
            this.actionComboBox.TabIndex = 1;
            this.actionComboBox.SelectedIndexChanged += new System.EventHandler(this.actionComboBoxSelectedIndexChanged);
            // 
            // affectedItemsComboBox
            // 
            this.affectedItemsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.affectedItemsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.affectedItemsComboBox.FormattingEnabled = true;
            this.affectedItemsComboBox.Location = new System.Drawing.Point(164, 40);
            this.affectedItemsComboBox.Name = "affectedItemsComboBox";
            this.affectedItemsComboBox.Size = new System.Drawing.Size(174, 21);
            this.affectedItemsComboBox.TabIndex = 2;
            // 
            // filterPropertiesGroupBox
            // 
            this.filterPropertiesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.filterPropertiesGroupBox.Controls.Add(this.actionComboBox);
            this.filterPropertiesGroupBox.Controls.Add(this.affectedItemsComboBox);
            this.filterPropertiesGroupBox.Controls.Add(this.actionLabel);
            this.filterPropertiesGroupBox.Controls.Add(this.affectedLabel);
            this.filterPropertiesGroupBox.Controls.Add(this.parameterTextBox);
            this.filterPropertiesGroupBox.Controls.Add(this.maskLabel);
            this.filterPropertiesGroupBox.Location = new System.Drawing.Point(12, 12);
            this.filterPropertiesGroupBox.Name = "filterPropertiesGroupBox";
            this.filterPropertiesGroupBox.Size = new System.Drawing.Size(344, 100);
            this.filterPropertiesGroupBox.TabIndex = 0;
            this.filterPropertiesGroupBox.TabStop = false;
            this.filterPropertiesGroupBox.Text = "Properties";
            // 
            // helpButton
            // 
            this.helpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.helpButton.Image = ((System.Drawing.Image)(resources.GetObject("helpButton.Image")));
            this.helpButton.Location = new System.Drawing.Point(12, 118);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(32, 32);
            this.helpButton.TabIndex = 6;
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButtonClick);
            // 
            // NewFilterForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(368, 156);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.filterPropertiesGroupBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(374, 184);
            this.Name = "NewFilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Filter";
            this.filterPropertiesGroupBox.ResumeLayout(false);
            this.filterPropertiesGroupBox.PerformLayout();
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.Label maskLabel;
		private System.Windows.Forms.Label affectedLabel;
		private System.Windows.Forms.Label actionLabel;
		private System.Windows.Forms.Button helpButton;
		private System.Windows.Forms.GroupBox filterPropertiesGroupBox;
		private System.Windows.Forms.ComboBox affectedItemsComboBox;
		private System.Windows.Forms.ComboBox actionComboBox;
		private System.Windows.Forms.TextBox parameterTextBox;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
	}
}
