
namespace ZipSolution.UI
{
	partial class DesignArchiveUserControl
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Archive contents");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DesignArchiveUserControl));
            this.archiveStructureTreeView = new System.Windows.Forms.TreeView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subfolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entireFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.addButton = new System.Windows.Forms.Button();
            this.renameButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.addContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.subfolderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.filesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.folderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.entireFolderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip.SuspendLayout();
            this.addContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // archiveStructureTreeView
            // 
            this.archiveStructureTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.archiveStructureTreeView.ContextMenuStrip = this.contextMenuStrip;
            this.archiveStructureTreeView.Location = new System.Drawing.Point(6, 3);
            this.archiveStructureTreeView.Name = "archiveStructureTreeView";
            treeNode1.Name = "rootNode";
            treeNode1.StateImageIndex = 2;
            treeNode1.Tag = " ";
            treeNode1.Text = "Archive contents";
            this.archiveStructureTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.archiveStructureTreeView.PathSeparator = "*";
            this.archiveStructureTreeView.Size = new System.Drawing.Size(299, 280);
            this.archiveStructureTreeView.StateImageList = this.imageList;
            this.archiveStructureTreeView.TabIndex = 0;
            this.archiveStructureTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.archiveStructureTreeViewAfterSelect);
            this.archiveStructureTreeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.archiveStructureTreeViewKeyDown);
            this.archiveStructureTreeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.archiveStructureTreeViewMouseDown);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(141, 70);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subfolderToolStripMenuItem,
            this.filesToolStripMenuItem,
            this.folderToolStripMenuItem,
            this.entireFolderToolStripMenuItem});
            this.addToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addToolStripMenuItem.Image")));
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // subfolderToolStripMenuItem
            // 
            this.subfolderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("subfolderToolStripMenuItem.Image")));
            this.subfolderToolStripMenuItem.Name = "subfolderToolStripMenuItem";
            this.subfolderToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.subfolderToolStripMenuItem.Text = "Subfolder...";
            this.subfolderToolStripMenuItem.Click += new System.EventHandler(this.addSubfolder);
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("filesToolStripMenuItem.Image")));
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.filesToolStripMenuItem.Text = "Files...";
            this.filesToolStripMenuItem.Click += new System.EventHandler(this.addFiles);
            // 
            // folderToolStripMenuItem
            // 
            this.folderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("folderToolStripMenuItem.Image")));
            this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            this.folderToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.folderToolStripMenuItem.Text = "Folder...";
            this.folderToolStripMenuItem.Click += new System.EventHandler(this.addFolder);
            // 
            // entireFolderToolStripMenuItem
            // 
            this.entireFolderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("entireFolderToolStripMenuItem.Image")));
            this.entireFolderToolStripMenuItem.Name = "entireFolderToolStripMenuItem";
            this.entireFolderToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.entireFolderToolStripMenuItem.Text = "Entire folder...";
            this.entireFolderToolStripMenuItem.Click += new System.EventHandler(this.addEntireFolder);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("renameToolStripMenuItem.Image")));
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.renameToolStripMenuItem.Text = "Rename...";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.rename);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("removeToolStripMenuItem.Image")));
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.remove);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "FolderFixed16x16.PNG");
            this.imageList.Images.SetKeyName(1, "File16x16.PNG");
            this.imageList.Images.SetKeyName(2, "Folder16x16.PNG");
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Image = ((System.Drawing.Image)(resources.GetObject("addButton.Image")));
            this.addButton.Location = new System.Drawing.Point(311, 3);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(32, 32);
            this.addButton.TabIndex = 2;
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButtonClick);
            // 
            // renameButton
            // 
            this.renameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.renameButton.Image = ((System.Drawing.Image)(resources.GetObject("renameButton.Image")));
            this.renameButton.Location = new System.Drawing.Point(311, 41);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(32, 32);
            this.renameButton.TabIndex = 3;
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.rename);
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.Image = ((System.Drawing.Image)(resources.GetObject("removeButton.Image")));
            this.removeButton.Location = new System.Drawing.Point(311, 79);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(32, 32);
            this.removeButton.TabIndex = 4;
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.remove);
            // 
            // addContextMenuStrip
            // 
            this.addContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subfolderToolStripMenuItem1,
            this.filesToolStripMenuItem1,
            this.folderToolStripMenuItem1,
            this.entireFolderToolStripMenuItem1});
            this.addContextMenuStrip.Name = "addContextMenuStrip";
            this.addContextMenuStrip.Size = new System.Drawing.Size(163, 92);
            // 
            // subfolderToolStripMenuItem1
            // 
            this.subfolderToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("subfolderToolStripMenuItem1.Image")));
            this.subfolderToolStripMenuItem1.Name = "subfolderToolStripMenuItem1";
            this.subfolderToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.subfolderToolStripMenuItem1.Text = "Subfolder...";
            this.subfolderToolStripMenuItem1.Click += new System.EventHandler(this.addSubfolder);
            // 
            // filesToolStripMenuItem1
            // 
            this.filesToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("filesToolStripMenuItem1.Image")));
            this.filesToolStripMenuItem1.Name = "filesToolStripMenuItem1";
            this.filesToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.filesToolStripMenuItem1.Text = "Files...";
            this.filesToolStripMenuItem1.Click += new System.EventHandler(this.addFiles);
            // 
            // folderToolStripMenuItem1
            // 
            this.folderToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("folderToolStripMenuItem1.Image")));
            this.folderToolStripMenuItem1.Name = "folderToolStripMenuItem1";
            this.folderToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.folderToolStripMenuItem1.Text = "Folder...";
            this.folderToolStripMenuItem1.Click += new System.EventHandler(this.addFolder);
            // 
            // entireFolderToolStripMenuItem1
            // 
            this.entireFolderToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("entireFolderToolStripMenuItem1.Image")));
            this.entireFolderToolStripMenuItem1.Name = "entireFolderToolStripMenuItem1";
            this.entireFolderToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.entireFolderToolStripMenuItem1.Text = "Entire Folder...";
            this.entireFolderToolStripMenuItem1.Click += new System.EventHandler(this.addEntireFolder);
            // 
            // ofd
            // 
            this.ofd.Multiselect = true;
            // 
            // DesignArchiveUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.archiveStructureTreeView);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.renameButton);
            this.Name = "DesignArchiveUserControl";
            this.Size = new System.Drawing.Size(346, 286);
            this.contextMenuStrip.ResumeLayout(false);
            this.addContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

		}
        private System.Windows.Forms.OpenFileDialog ofd;
		private System.Windows.Forms.ToolStripMenuItem entireFolderToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem subfolderToolStripMenuItem1;
		private System.Windows.Forms.ContextMenuStrip addContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem subfolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem entireFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
		private System.Windows.Forms.Button removeButton;
		private System.Windows.Forms.Button renameButton;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.TreeView archiveStructureTreeView;
	}
}
