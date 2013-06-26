using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using BULocalization;
using HDE.Platform.Logging;
using Ionic.Utils;
using ZipSolution.Core.DataSources;
using ZipSolution.Core.Filters;
using ZipSolution.Core.Tree;

namespace ZipSolution.UI
{
	/// <summary>
	/// Provides ability to design the contents of an archive.
	/// </summary>
	sealed partial class DesignArchiveUserControl : UserControl, IDataSourceConfig
	{
		#region Types
		
		/// <summary>
		/// Provides binding node to images
		/// </summary>
		enum StateImages
		{
			FolderFixed = 0,
			File = 1,
			Folder = 2
		}
		
		#endregion
		
		#region Constants
		
		const string FixedFolderOrFileView = "{0} [{1}]";
		
		#endregion
		
		#region Fields

	    private ILog _log;
		private TreeNode _selectedNode;
	    private Action<string> _showError;

		#endregion
		
		#region Properties
		
		/// <summary>
		/// The data source
		/// </summary>
		[DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
		public IDataSource DataSource 
		{
			get 
			{
				if (!ValidStorageState())
				{
					throw new InvalidOperationException("State is invalid!");
				}
				
				return new ManualArchiveDesignDataSource(getPlainTreeRepresentation());
			}
			set 
			{
				archiveStructureTreeView.BeginUpdate();
				try
				{
                    List<PlainTreeRepresentation> data = value.PrepareZipEntries(_log);
					
					foreach (var item in data)
					{
						// first is binded file or folder
						// second is path in an archive
						
						TreeNode node = getTreeNodeOnPath(item.RelativeFolderInArchive.Replace(@"\", "*"));
						if (File.Exists(item.Target))
						{
                            addFile(node, item.Target);
						}
						else
						{
                            addEntireFolder(node, item.Target);
						}
					}
				}
				finally
				{
					archiveStructureTreeView.EndUpdate();
					archiveStructureTreeView.ExpandAll();
				}
			}
		}
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// The default constructor.
		/// Don't forget to run Init
		/// </summary>
		public DesignArchiveUserControl()
		{
			InitializeComponent();
		}

	    #endregion		
		
		#region Public Methods

        /// <summary>
        /// Inits the control state
        /// </summary>
        public void Init(ILog log, Action<string> showError, Func<FilterConfiguration> addFilter)
        {
            _showError = showError;
            _log = log;

            applyLocals();

            archiveStructureTreeView.SelectedNode = archiveStructureTreeView.Nodes[0];
            _selectedNode = archiveStructureTreeView.Nodes[0];
            _selectedNode.Tag = null;
            refreshFunctionalAvailability(_selectedNode);
        }
	
		/// <summary>
		/// Checks wheather the state of control is valid.
		/// If not control shows to user messages about this and returnes false
		/// </summary>
		/// <returns></returns>
		public bool ValidStorageState()
		{
			bool goodArchive = archiveStructureTreeView.Nodes[0].Nodes.Count > 0;
			
			if (!goodArchive)
			{
                _showError(Translation.Current[59]);
			}
			
			return goodArchive;
		}
		
		#endregion
		
		#region Private Methods

        void applyLocals()
        {
            archiveStructureTreeView.Nodes[0].Text = Translation.Current[63];
            addToolStripMenuItem.Text = Translation.Current[64];
            renameToolStripMenuItem.Text = Translation.Current[65];
            removeToolStripMenuItem.Text = Translation.Current[41];
            subfolderToolStripMenuItem.Text = subfolderToolStripMenuItem1.Text = Translation.Current[66];
            filesToolStripMenuItem.Text = filesToolStripMenuItem1.Text = Translation.Current[67];
            folderToolStripMenuItem.Text = folderToolStripMenuItem1.Text = Translation.Current[68];
            entireFolderToolStripMenuItem.Text = entireFolderToolStripMenuItem1.Text = Translation.Current[69];
        }
		
		void refreshFunctionalAvailability(TreeNode node)
		{
			_selectedNode = node;
			if (_selectedNode != null)
			{
				bool rootNode = _selectedNode == archiveStructureTreeView.Nodes[0];
				bool structuralNode = _selectedNode.Tag == null;
				bool bindedNode = _selectedNode.Tag is string;
				
				addButton.Enabled = addToolStripMenuItem.Enabled = !bindedNode;//+ + -
				renameButton.Enabled = renameToolStripMenuItem.Enabled = structuralNode && !rootNode && !bindedNode;// - + -
				removeButton.Enabled = removeToolStripMenuItem.Enabled = !rootNode;// - - +
			}
			else
			{
				addButton.Enabled = addToolStripMenuItem.Enabled = false;
				renameButton.Enabled = renameToolStripMenuItem.Enabled = false;
				removeButton.Enabled = removeToolStripMenuItem.Enabled = false;
			}
		}
		
		#region Event Handlers
		
		void archiveStructureTreeViewAfterSelect(object sender, TreeViewEventArgs e)
		{
			refreshFunctionalAvailability(e.Node);
		}
		
		void addButtonClick(object sender, EventArgs e)
		{
			addContextMenuStrip.Show(addButton, addButton.Width / 2, addButton.Height / 2);
		}
		
		void remove(object sender, EventArgs e)
		{
			int indexOfSelectedNode = _selectedNode.Index;

			// if it was the last node - we're selecting parent node
			TreeNode nodeToSelect = _selectedNode.Parent;
		
			_selectedNode.Remove();
			
			// if not - the other node with the same index
			if (nodeToSelect.Nodes.Count > indexOfSelectedNode)
			{
				nodeToSelect = nodeToSelect.Nodes[indexOfSelectedNode];
			}
			// if not - the other last one
			else if (nodeToSelect.Nodes.Count > 0)
			{
				nodeToSelect = nodeToSelect.Nodes[nodeToSelect.Nodes.Count - 1];
			}

			archiveStructureTreeView.SelectedNode = nodeToSelect;
			refreshFunctionalAvailability(nodeToSelect);
			_selectedNode = nodeToSelect;
		}

		void rename(object sender, EventArgs e)
		{
			using (InputForm form = new InputForm(Translation.Current[60], Translation.Current[60], _selectedNode.Text))
			{
				if (form.ShowDialog() == DialogResult.OK)
				{
					if (_selectedNode.Text != form.InputValue)
					{
						if (!checkIfNameIsUnique(_selectedNode.Parent, form.InputValue))
						{
							nameIsNotUnique(form.InputValue);
							return;
						}
						_selectedNode.Text = form.InputValue;
					}
				}
			}
		}
		
		void addSubfolder(object sender, EventArgs e)
		{
			using (InputForm form = new InputForm(Translation.Current[61], Translation.Current[61], string.Empty))
			{
				if (form.ShowDialog() == DialogResult.OK)
				{
					if (!checkIfNameIsUnique(_selectedNode, form.InputValue))
					{
						nameIsNotUnique(form.InputValue);
						return;
					}
					archiveStructureTreeView.SelectedNode = addSubfolder(_selectedNode, form.InputValue);
					refreshFunctionalAvailability(archiveStructureTreeView.SelectedNode);
				}
			}
		}	
		
		void addFiles(object sender, EventArgs e)
		{
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				foreach (string file in ofd.FileNames)
				{
					if (!checkIfNameIsUnique(_selectedNode, Path.GetFileName(file)))
					{
						nameIsNotUnique(file);
					}
					else
					{
						addFile(_selectedNode, file);
					}
				}
				_selectedNode.Expand();
			}			
		}

		void addFolder(object sender, EventArgs e)
		{
            if (FolderBrowserDialogEx.Execute())
			{
                if (!checkIfNameIsUnique(_selectedNode, Path.GetFileName(FolderBrowserDialogEx.LastSelectedPath)))
				{
                    nameIsNotUnique(FolderBrowserDialogEx.LastSelectedPath);
					return;
				}
                TreeNode node = addSubfolder(_selectedNode, Path.GetFileName(FolderBrowserDialogEx.LastSelectedPath));
                addFolder(node, FolderBrowserDialogEx.LastSelectedPath);
				archiveStructureTreeView.SelectedNode = node;
				refreshFunctionalAvailability(node);
				node.ExpandAll();
			}
		}
		
		void addEntireFolder(object sender, EventArgs e)
		{
            if (FolderBrowserDialogEx.Execute())
            {
                if (!checkIfNameIsUnique(_selectedNode, Path.GetFileName(FolderBrowserDialogEx.LastSelectedPath)))
				{
                    nameIsNotUnique(FolderBrowserDialogEx.LastSelectedPath);
					return;
				}				
				archiveStructureTreeView.BeginUpdate();
                addEntireFolder(_selectedNode, FolderBrowserDialogEx.LastSelectedPath);
				archiveStructureTreeView.EndUpdate();
			}
		}
		
		/// <summary>
		/// Shortcuts support
		/// </summary>
		void archiveStructureTreeViewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F2)
			{
				if (renameButton.Enabled)
				{
					rename(this, e);
				}
			}
			else if (e.KeyCode == Keys.Delete)
			{
				if (removeButton.Enabled)
				{
					remove(this, e);
				}
			}
		}
		
		/// <summary>
		/// This is to support selection with right mouse
		/// </summary>
		void archiveStructureTreeViewMouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				TreeNode node = archiveStructureTreeView.GetNodeAt(e.Location);
				if (node != _selectedNode)
				{
					archiveStructureTreeView.SelectedNode = node;
					refreshFunctionalAvailability(node);
				}
			}
		}	
		
		#endregion
		
		/// <summary>
		/// Checks wheather the name is unique in this folder
		/// </summary>
		/// <param name="targetNode">folder node</param>
		/// <param name="name">or subnode name or Path.GetFileName for folders and pathes</param>
		/// <returns>True if it is unque</returns>
		static bool checkIfNameIsUnique(TreeNode targetNode, string name)
		{
			foreach (TreeNode node in targetNode.Nodes)
			{
				if (node.Tag == null)
				{
					if (node.Text == name)
					{
						return false;
					}
				}
				else if (node.Tag is string)
				{
					if (Path.GetFileName((string)node.Tag) == name)
					{
						return false;
					}
				}
			}
			return true;
		}
		
		/// <summary>
		/// Adds sub node to the target node
		/// </summary>
		/// <param name="targetNode">The place where to create the subfolder</param>
		/// <param name="name">The sunnode name</param>
		/// <returns>The new subnode treenode</returns>
		static TreeNode addSubfolder(TreeNode targetNode, string name)
		{
			TreeNode node = new TreeNode(name);
			node.StateImageIndex = (int)StateImages.Folder;
			targetNode.Nodes.Add(node);
			
			return node;
		}
		
		/// <summary>
		/// Adds file to the target node
		/// </summary>
		/// <param name="targetNode"></param>
		/// <param name="file"></param>
		static void addFile(TreeNode targetNode, string file)
		{
			TreeNode node = new TreeNode(string.Format(CultureInfo.CurrentUICulture, FixedFolderOrFileView, Path.GetFileName(file), Path.GetDirectoryName(file)));
			node.Tag = file;
			node.StateImageIndex = (int)StateImages.File;
			targetNode.Nodes.Add(node);		
		}
		
		/// <summary>
		/// Adds folder as subnodes and files
		/// </summary>
		/// <param name="targetNode">The target place</param>
		/// <param name="folder">The full folder name</param>
		static void addFolder(TreeNode targetNode, string folder)
		{
			// adding files of a folder
			string[] files = Directory.GetFiles(folder);
			foreach (string file in files)
			{
				addFile(targetNode, file);
			}
			
			// adding directories
			string[] dirs = Directory.GetDirectories(folder);
			
			foreach (string dir in dirs)
			{
				addFolder(addSubfolder(targetNode, Path.GetFileName(dir)), dir);
			}
		}
		
		/// <summary>
		/// Binds folder to the target folder-node
		/// </summary>
		/// <param name="targetNode">The node where to bind the folder</param>
		/// <param name="name">The Full Folder name</param>
		static void addEntireFolder(TreeNode targetNode, string name)
		{
			TreeNode node = new TreeNode(
				name.Length > 3 ? string.Format(CultureInfo.CurrentUICulture, 
				              FixedFolderOrFileView, 
				              Path.GetFileName(name), 
				              Path.GetDirectoryName(name))
				: name);
			node.Tag = name;
			node.StateImageIndex = (int)StateImages.FolderFixed;
			targetNode.Nodes.Add(node);
		}
		
		/// <summary>
		/// Tries to get or create the node with target path
		/// </summary>
		/// <param name="path">Path separated with *</param>
		/// <returns>The result TreeNode</returns>
		TreeNode getTreeNodeOnPath(string path)
		{
			TreeNode startNode = archiveStructureTreeView.Nodes[0];
			if (string.IsNullOrEmpty(path))
			{
				return startNode;
			}
			else
			{
				string[] subNodes = path.Split(new string[] {"*"}, StringSplitOptions.RemoveEmptyEntries);
				
				foreach (string nodePath in subNodes)
				{
					bool nodeFound = false;
					foreach (TreeNode node in startNode.Nodes)
					{
						if (node.Text == nodePath)
						{
							startNode = node;
							nodeFound = true;
							break;
						}
					}
					
					if (!nodeFound)
					{
						startNode = addSubfolder(startNode, nodePath);
					}
				}
				
				return startNode;
			}
		}
		
		/// <summary>
		/// Gets the plain representation of tree
		/// </summary>
		/// <returns>Dictionary of target folders and files and target folder as value</returns>
        List<PlainTreeRepresentation> getPlainTreeRepresentation()
		{
            List<PlainTreeRepresentation> result = new List<PlainTreeRepresentation>();
			getPlainRepresentation(result, archiveStructureTreeView.Nodes[0]);
			return result;
		}

		/// <summary>
		/// Shows the message that name is not unque
		/// </summary>
		/// <param name="element">The file or folder or subfolder name that conflicts</param>
		void nameIsNotUnique(string element)
		{
			_showError(element + Environment.NewLine + Environment.NewLine + Translation.Current[74]);
		}

        void getPlainRepresentation(List<PlainTreeRepresentation> result, TreeNode currentNode)
		{
			foreach (TreeNode node in currentNode.Nodes)
			{
				if (node.Tag is string)
				{
					int startIndex = node.FullPath.IndexOf('*');
					string strippedStart = node.FullPath.Substring(startIndex + 1);
					
					int endIndex = strippedStart.LastIndexOf('*');
					string strippedEnd = string.Empty;
					if (endIndex > -1)
					{
						strippedEnd = strippedStart.Substring(0, endIndex);
					}
                    result.Add(new PlainTreeRepresentation { Target = (string)node.Tag, RelativeFolderInArchive = strippedEnd.Replace("*", @"\") });
				}
				else
				{
					getPlainRepresentation(result, node);
				}
			}
		}

		#endregion
	}
}
