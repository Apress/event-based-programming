using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace SystemBrowser
{
	/// <summary>
	/// NavigatorFolders shows a list of directories using a 
	/// hierarchical tree. 
	/// </summary>
  public class NavigatorFolders : System.Windows.Forms.UserControl
  {
    #region Controls
    private System.Windows.Forms.TreeView treeViewFolders;
    private System.Windows.Forms.ImageList imageListFolders;
    private System.ComponentModel.IContainer components;
    #endregion

    string folderSelected;

    // ImageList indexes
    const int ImageFolder = 0;
    const int ImageFolderOpened = 1;
    const int ImageHardDrive = 2;

	  public NavigatorFolders()
	  {
		  // This call is required by the Windows.Forms Form Designer.
		  InitializeComponent();
	  }

    public void Populate(string theFolder)
    {
      Cursor = Cursors.WaitCursor;
      treeViewFolders.BeginUpdate();
      treeViewFolders.Nodes.Clear();

      int percentComplete = 0;
      
      // strip off  trailing backslash
      string name = theFolder;
      if (name.EndsWith(@"\"))
        name = name.Substring(0, name.Length-1);
        
      TreeNode rootNode = new TreeNode(name, ImageHardDrive, ImageHardDrive);
      rootNode.Tag = theFolder;  // save the directory's full path
      treeViewFolders.Nodes.Add(rootNode);

      int i = 0;
      string[] directories = Directory.GetDirectories(theFolder);
      int totalFiles = directories.Length;
      foreach (string directory in directories)
      {
        AddNode(rootNode.Nodes, directory);
        percentComplete = (i * 100 ) / totalFiles;
        FireProgress(percentComplete);
        i++;
      }

      treeViewFolders.EndUpdate();
      rootNode.Expand();
      FireProgress(100);
      Cursor = Cursors.Default;
    }
    
    public void SelectFolder(string thePath)
    {
      if (thePath == null) return;
      if (treeViewFolders.Nodes.Count == 0) return;

      if (thePath.EndsWith("\\"))
      {
        // root folder
        treeViewFolders.SelectedNode = treeViewFolders.Nodes[0];
        return;
      }

      string[] directories = thePath.Split(new char[] {'\\'});
      TreeNode node = treeViewFolders.Nodes[0];
      foreach (string directory in directories)
      {
        node = FindNodeFor(node, directory);
        if (node == null) return;
      }

      AddChildren(node);
      treeViewFolders.SelectedNode = node;
    }

    public void SelectParentFolder()
    {
      TreeNode currentNode = treeViewFolders.SelectedNode;
      if (currentNode == null) return;

      string currentDirectory = currentNode.Tag as string;
      DirectoryInfo parentDirectory = Directory.GetParent(currentDirectory);
      if (parentDirectory == null) return;
      SelectFolder(parentDirectory.FullName);
    }

    /// <summary> 
	  /// Clean up any resources being used.
	  /// </summary>
	  protected override void Dispose( bool disposing )
	  {
		  if( disposing )
		  {
			  if(components != null)
			  {
				  components.Dispose();
			  }
		  }
		  base.Dispose( disposing );
	  }

	  #region Component Designer generated code
	  /// <summary> 
	  /// Required method for Designer support - do not modify 
	  /// the contents of this method with the code editor.
	  /// </summary>
	  private void InitializeComponent()
	  {
      this.components = new System.ComponentModel.Container();
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NavigatorFolders));
      this.treeViewFolders = new System.Windows.Forms.TreeView();
      this.imageListFolders = new System.Windows.Forms.ImageList(this.components);
      this.SuspendLayout();
      // 
      // treeViewFolders
      // 
      this.treeViewFolders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.treeViewFolders.Dock = System.Windows.Forms.DockStyle.Fill;
      this.treeViewFolders.HideSelection = false;
      this.treeViewFolders.ImageList = this.imageListFolders;
      this.treeViewFolders.Location = new System.Drawing.Point(0, 0);
      this.treeViewFolders.Name = "treeViewFolders";
      this.treeViewFolders.Size = new System.Drawing.Size(210, 232);
      this.treeViewFolders.TabIndex = 0;
      this.treeViewFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFolders_AfterSelect);
      this.treeViewFolders.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewFolders_BeforeExpand);
      this.treeViewFolders.Enter += new System.EventHandler(this.treeViewFolders_Enter);
      // 
      // imageListFolders
      // 
      this.imageListFolders.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
      this.imageListFolders.ImageSize = new System.Drawing.Size(16, 16);
      this.imageListFolders.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListFolders.ImageStream")));
      this.imageListFolders.TransparentColor = System.Drawing.Color.Transparent;
      // 
      // NavigatorFolders
      // 
      this.Controls.Add(this.treeViewFolders);
      this.Name = "NavigatorFolders";
      this.Size = new System.Drawing.Size(210, 232);
      this.ResumeLayout(false);

    }
	  #endregion

    void AddNode(TreeNodeCollection theParentCollection, string theDirectory)
    {
      string name = Path.GetFileName(theDirectory);
      TreeNode node = new TreeNode(name, ImageFolder, ImageFolderOpened);
      node.Tag = theDirectory;  // save the directory's full path
      theParentCollection.Add(node);

      string[] subdirectories = null;
      try
      {
        subdirectories = Directory.GetDirectories(theDirectory);
      }
      catch 
      {
        return;  // ignore restricted directories
      }

      if (subdirectories == null) return;
      if (subdirectories.Length == 0) return;

      // if directory has subdirectories, add just 1 subdirectory, to
      // make a '+' sign appear next to the node
      name = Path.GetFileName(subdirectories[0]);
      TreeNode subNode = new TreeNode(name, ImageFolder, ImageFolder);
      subNode.Tag = string.Format(@"{0}\{1}", theDirectory, name);
      node.Nodes.Add(subNode);
    }

    void AddChildren(TreeNode theNode)
    {
      treeViewFolders.BeginUpdate();
      theNode.Nodes.Clear();  // remove the single subdirectory added
      string directory = theNode.Tag as string;
      foreach (string subdirectory in Directory.GetDirectories(directory))
        AddNode(theNode.Nodes, subdirectory);
      treeViewFolders.EndUpdate();
    }

    void UpdateStatusBar()
    {
      FireMessage(folderSelected);
    }

    TreeNode FindNodeFor(TreeNode theStartingNode, string theDirectory)
    {
      if (theStartingNode.Text.ToLower() == theDirectory.ToLower()) 
        return theStartingNode;

      // search the direct children
      foreach (TreeNode node in theStartingNode.Nodes)
        if (node.Text.ToLower() == theDirectory.ToLower()) 
          return node;
      return null;
    }

    #region Event Handlers
    private void treeViewFolders_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
    {
      AddChildren(e.Node);
    }

    private void treeViewFolders_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
    {
      if (e.Node == null) return;
      folderSelected = e.Node.Tag as string;
      FireFolderChanged(folderSelected);
      UpdateStatusBar();
    }

    private void treeViewFolders_Enter(object sender, System.EventArgs e)
    {
      UpdateStatusBar();
    }
    #endregion
    
    #region Events
    public delegate void FolderChangedHandler(string theFolderPath);
    public event FolderChangedHandler OnFolderChanged;
    void FireFolderChanged(string theFolderPath)
    {
      if (OnFolderChanged != null)
        OnFolderChanged(theFolderPath);
    }

    public delegate void MessageHandler(string theMessage);
    public event MessageHandler OnMessage;
    void FireMessage(string theMessage)
    {
      if (OnMessage != null)
        OnMessage(theMessage);
    }

    public delegate void ProgressHandler(int percentComplete);
    public event ProgressHandler OnProgress;
    void FireProgress(int percentComplete)
    {
      if (OnProgress != null)
        OnProgress(percentComplete);
    }
    #endregion
  }
}
