using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace SystemBrowser
{
	/// <summary>
  /// ContentSearchResults is used to show the results of a file search
  /// </summary>
	public class ContentSearchResults : System.Windows.Forms.UserControl
	{
    #region Controls
    private System.Windows.Forms.ListView listViewFiles;
    private System.Windows.Forms.ColumnHeader columnHeaderName;
    private System.Windows.Forms.ColumnHeader columnHeaderSize;
    private System.Windows.Forms.ColumnHeader columnHeaderType;
    private System.Windows.Forms.ColumnHeader columnHeaderDateModified;
    private System.Windows.Forms.ColumnHeader columnHeaderInFolder;
    private System.ComponentModel.IContainer components;
    private System.Windows.Forms.ImageList imageListFiles;
    #endregion

    // ImageList indexes, for images placed next to files found
    const int ImageFile = 0;

    public ContentSearchResults()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
    }

    // add a file to the list of files found
    public void Add(string theFilePath, int theCurrentCount)
    {
      if (!File.Exists(theFilePath)) return;

      string name = Path.GetFileName(theFilePath);
      ListViewItem item = new ListViewItem(name, ImageFile);
      item.Tag = theFilePath;
      FileInfo fileInfo = new FileInfo(theFilePath);
      string folder = fileInfo.DirectoryName;
      item.SubItems.Add(folder);
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
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ContentSearchResults));
      this.listViewFiles = new System.Windows.Forms.ListView();
      this.columnHeaderName = new System.Windows.Forms.ColumnHeader();
      this.columnHeaderInFolder = new System.Windows.Forms.ColumnHeader();
      this.columnHeaderSize = new System.Windows.Forms.ColumnHeader();
      this.columnHeaderType = new System.Windows.Forms.ColumnHeader();
      this.columnHeaderDateModified = new System.Windows.Forms.ColumnHeader();
      this.imageListFiles = new System.Windows.Forms.ImageList(this.components);
      this.SuspendLayout();
      // 
      // listViewFiles
      // 
      this.listViewFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.listViewFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                    this.columnHeaderName,
                                                                                    this.columnHeaderInFolder,
                                                                                    this.columnHeaderSize,
                                                                                    this.columnHeaderType,
                                                                                    this.columnHeaderDateModified});
      this.listViewFiles.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listViewFiles.HideSelection = false;
      this.listViewFiles.Location = new System.Drawing.Point(0, 0);
      this.listViewFiles.Name = "listViewFiles";
      this.listViewFiles.Size = new System.Drawing.Size(554, 364);
      this.listViewFiles.SmallImageList = this.imageListFiles;
      this.listViewFiles.TabIndex = 1;
      this.listViewFiles.View = System.Windows.Forms.View.Details;
      this.listViewFiles.Resize += new System.EventHandler(this.listViewFiles_Resize);
      this.listViewFiles.SelectedIndexChanged += new System.EventHandler(this.listViewFiles_SelectedIndexChanged);
      // 
      // columnHeaderName
      // 
      this.columnHeaderName.Text = "Name";
      this.columnHeaderName.Width = 143;
      // 
      // columnHeaderInFolder
      // 
      this.columnHeaderInFolder.Text = "In Folder";
      this.columnHeaderInFolder.Width = 162;
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
      this.columnHeaderDateModified.Width = 109;
      // 
      // imageListFiles
      // 
      this.imageListFiles.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
      this.imageListFiles.ImageSize = new System.Drawing.Size(16, 16);
      this.imageListFiles.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListFiles.ImageStream")));
      this.imageListFiles.TransparentColor = System.Drawing.Color.Transparent;
      // 
      // ContentSearchResults
      // 
      this.Controls.Add(this.listViewFiles);
      this.Name = "ContentSearchResults";
      this.Size = new System.Drawing.Size(554, 364);
      this.ResumeLayout(false);

    }
		#endregion

    #region Event Handlers
    private void listViewFiles_SelectedIndexChanged(object sender, System.EventArgs e)
    {
      if (listViewFiles.SelectedItems.Count == 0)
      {
        string s = string.Format("{0} objects", listViewFiles.Items.Count);
        FireMessage(s);  // no file selected
      }
      else
      {
        ListViewItem item = listViewFiles.SelectedItems[0];
        string folder = item.SubItems[1].Text;
        FireMessage("In folder: " + folder);
      }
    }

    private void listViewFiles_Resize(object sender, System.EventArgs e)
    {
      columnHeaderDateModified.Width = -2;  // autosize last column
    }
    #endregion

    #region Events
    public delegate void MessageHandler(string theMessage);
    public event MessageHandler OnMessage;
    private void FireMessage(string theMessage)
    {
      if (OnMessage != null)
        OnMessage(theMessage);
    }
    #endregion
  }
}
