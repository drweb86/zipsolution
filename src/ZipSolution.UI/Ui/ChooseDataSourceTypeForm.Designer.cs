
namespace ZipSolution.UI
{
	partial class ChooseDataSourceTypeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseDataSourceTypeForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this._manualDesignButton = new System.Windows.Forms.Button();
            this._useFilterChainButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(319, 113);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // _manualDesignButton
            // 
            this._manualDesignButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._manualDesignButton.Image = ((System.Drawing.Image)(resources.GetObject("_manualDesignButton.Image")));
            this._manualDesignButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._manualDesignButton.Location = new System.Drawing.Point(12, 59);
            this._manualDesignButton.Name = "_manualDesignButton";
            this._manualDesignButton.Size = new System.Drawing.Size(384, 41);
            this._manualDesignButton.TabIndex = 6;
            this._manualDesignButton.Text = "Design of archive contents";
            this._manualDesignButton.UseVisualStyleBackColor = true;
            this._manualDesignButton.Click += new System.EventHandler(this.onManualDesignButtonClick);
            // 
            // _useFilterChainButton
            // 
            this._useFilterChainButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._useFilterChainButton.Image = global::ZipSolution.Resource.FilterChain;
            this._useFilterChainButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._useFilterChainButton.Location = new System.Drawing.Point(12, 12);
            this._useFilterChainButton.Name = "_useFilterChainButton";
            this._useFilterChainButton.Size = new System.Drawing.Size(384, 41);
            this._useFilterChainButton.TabIndex = 5;
            this._useFilterChainButton.Text = "Apply chain of filters to a folder";
            this._useFilterChainButton.UseVisualStyleBackColor = true;
            this._useFilterChainButton.Click += new System.EventHandler(this.onUseFilterChainButtonClick);
            // 
            // ChooseTheDataSourceTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(406, 148);
            this.Controls.Add(this._manualDesignButton);
            this.Controls.Add(this._useFilterChainButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseDataSourceTypeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose The Data Source Type:";
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button _useFilterChainButton;
        private System.Windows.Forms.Button _manualDesignButton;
	}
}
