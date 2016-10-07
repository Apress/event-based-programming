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
	/// ContentFileList is used to show all folders and files in a folder
	/// </summary>
	public class ContentFileList : System.Windows.Forms.UserControl
	{
    #region Controls
    private System.Windows.Forms.ListView listViewFiles;
    private System.Windows.Forms.ColumnHeader columnHeaderName;
    private System.Windows.Forms.ColumnHeader columnHeaderSize;
    private System.Windows.Forms.ColumnHeader columnHeaderType;
    private System.Windows.Forms.ColumnHeader columnHeaderDateModified;
    private System.Windows.Forms.ImageList imageList1;
    private System.ComponentModel.IContainer components;
    #endregion

    // ImageList indexes, for images placed next to file and folder names
    const int ImageFolder = 0;
    const int ImageFile = 1;

		public ContentFileList()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
    }

    // show a list of all the folders and files in a folder
    public void Populate(string theFolder)
    {
      listViewFiles.BeginUpdate();
      listViewFiles.Items.Clear();

      // first the subdirectories
      foreach (string directory in Directory.GetDirectories(theFolder))
      {
        string name = Path.GetFileName(directory);
        ListViewItem item = listViewFiles.Items.Add(name, ImageFolder);
        item.Tag = directory;
      }

      // then the files
      foreach (string filePath in Directory.GetFiles(theFolder))
        Add(filePath);

      listViewFiles.EndUpdate();
    }

    // add a file to the list
    public void Add(string theFilePath)
    {
      if (!File.Exists(theFilePath)) return;
      string name = Path.GetFileName(theFilePath);
      ListViewItem item = new ListViewItem(name, ImageFile);
      item.Tag = theFilePath;
      FileInfo fileInfo = new FileInfo(theFilePath);
      long length = fileInfo.Length / 1024;
      if (length < 1)
        length = 1;
      string size = string.Format("{0:#,##0} KB", length);
      string type = fileInfo.Extension;
      if (type.StartsWith("."))
        type = type.Substring(1);
      DateTime dateModified = fileInfo.LastWriteTime;
      item.SubItems.Add(size);
      item.SubItems.Add(type);
      item.SubItems.Add(dateModified.ToString("yyyy-MM-dd HH:mm:ss"));
      listViewFiles.Items.Add(item);
    }

    // organize file list showing only names
    public void ShowIcons()
    {
      listViewFiles.View = View.SmallIcon;
    }

    // organize file list showing details
    public void ShowDetails()
    {
      listViewFiles.View = View.Details;
    }

    public void Clear()
    {
      listViewFiles.Items.Clear();
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
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ContentFileList));
      this.listViewFiles = new System.Windows.Forms.ListView();
      this.columnHeaderName = new System.Windows.Forms.ColumnHeader();
      this.columnHeaderSize = new System.Windows.Forms.ColumnHeader();
      this.columnHeaderType = new System.Windows.Forms.ColumnHeader();
      this.columnHeaderDateModified = new System.Windows.Forms.ColumnHeader();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.SuspendLayout();
      // 
      // listViewFiles
      // 
      this.listViewFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.listViewFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                    this.columnHeaderName,
                                                                                    this.columnHeaderSize,
                                                                                    this.columnHeaderType,
                                                                                    this.columnHeaderDateModified});
      this.listViewFiles.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listViewFiles.HideSelection = false;
      this.listViewFiles.Location = new System.Drawing.Point(0, 0);
      this.listViewFiles.Name = "listViewFiles";
      this.listViewFiles.Size = new System.Drawing.Size(470, 288);
      this.listViewFiles.SmallImageList = this.imageList1;
      this.listViewFiles.TabIndex = 0;
      this.listViewFiles.View = System.Windows.Forms.View.Details;
      this.listViewFiles.Resize += new System.EventHandler(this.listViewFiles_Resize);
      this.listViewFiles.DoubleClick += new System.EventHandler(this.listViewFiles_DoubleClick);
      this.listViewFiles.Enter += new System.EventHandler(this.listViewFiles_Enter);
      this.listViewFiles.SelectedIndexChanged += new System.EventHandler(this.listViewFiles_SelectedIndexChanged);
      // 
      // columnHeaderName
      // 
      this.columnHeaderName.Text = "Name";
      this.columnHeaderName.Width = 201;
      // 
      // columnHeaderSize
      // 
      this.columnHeaderSize.Text = "Size";
      this.columnHeaderSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.columnHeaderSize.Width = 76;
      // 
      // columnHeaderType
      // 
      this.columnHeaderType.Text = "Type";
      // 
      // columnHeaderDateModified
      // 
      this.columnHeaderDateModified.Text = "Date Modified";
      this.columnHeaderDateModified.Width = 128;
      // 
      // imageList1
      // 
      this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
      this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      // 
      // ContentFileList
      // 
      this.Controls.Add(this.listViewFiles);
      this.Name = "ContentFileList";
      this.Size = new System.Drawing.Size(470, 288);
      this.ResumeLayout(false);

    }
		#endregion

    // show info about a file to the user
    void IndicateFileInfo()
    {
      if (listViewFiles.FocusedItem == null) return;
      if (listViewFiles.FocusedItem.ImageIndex == ImageFolder)
      {
        FireMessage(""); // erase the status bar message
        return;
      }

      string filePath = listViewFiles.FocusedItem.Tag as string;
      if (!File.Exists(filePath)) return;
      FileInfo fileInfo = new FileInfo(filePath);
      long length = fileInfo.Length / 1024;
      if (length < 1)
        length = 1;
      string size = string.Format("File size: {0:#,##0} KB   {1}", length, filePath);
      FireMessage(size);  // show a new status bar message
    }

    #region Event Handlers
    private void listViewFiles_Enter(object sender, System.EventArgs e)
    {
      IndicateFileInfo();
    }

    private void listViewFiles_SelectedIndexChanged(object sender, System.EventArgs e)
    {
      IndicateFileInfo();
    }

    private void listViewFiles_Resize(object sender, System.EventArgs e)
    {
      columnHeaderDateModified.Width = -2;  // autosize last column
    }

    private void listViewFiles_DoubleClick(object sender, System.EventArgs e)
    {
      if (listViewFiles.SelectedItems.Count == 0) return;
      string  filePath = listViewFiles.SelectedItems[0].Tag as string;
      FireFolderDoubleClicked(filePath);
    }
    #endregion

    #region Events
    public delegate void FolderDoubleClickedHandler(string thePath);
    public event FolderDoubleClickedHandler OnFolderDoubleClicked;
    void FireFolderDoubleClicked(string thePath)
    {
      if (OnFolderDoubleClicked != null)
        OnFolderDoubleClicked(thePath);
    }

    public delegate void MessageHandler(string theMessage);
    public event MessageHandler OnMessage;
    void FireMessage(string theMessage)
    {
      if (OnMessage != null)
        OnMessage(theMessage);
    }
    #endregion
  }
}
