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
  /// NavigatorSearch allows a user to enter an expression for
  /// a filename. When the Start button is clicked, an event is
  /// fired to the Coordinator, which spawns a background thread
  /// and runs the search on.
  /// </summary>
  public class NavigatorSearch : System.Windows.Forms.UserControl
  {
    #region Controls
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    private System.ComponentModel.IContainer components;
    internal System.Windows.Forms.Button buttonBrowse;
    internal System.Windows.Forms.TextBox textBoxLookIn;
    internal System.Windows.Forms.Label label3;
    internal System.Windows.Forms.Button buttonSearch;
    internal System.Windows.Forms.TextBox textBoxFilename;
    internal System.Windows.Forms.Label label2;
    internal System.Windows.Forms.Label label1;
    #endregion

    int itemsFound;
    bool searching;

    bool stopRequested;

    public NavigatorSearch()
	  {
		  // This call is required by the Windows.Forms Form Designer.
		  InitializeComponent();
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
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
      this.buttonBrowse = new System.Windows.Forms.Button();
      this.textBoxLookIn = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.buttonSearch = new System.Windows.Forms.Button();
      this.textBoxFilename = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // buttonBrowse
      // 
      this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonBrowse.BackColor = System.Drawing.SystemColors.Control;
      this.buttonBrowse.Location = new System.Drawing.Point(184, 120);
      this.buttonBrowse.Name = "buttonBrowse";
      this.buttonBrowse.Size = new System.Drawing.Size(25, 23);
      this.buttonBrowse.TabIndex = 20;
      this.buttonBrowse.Text = "...";
      this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
      // 
      // textBoxLookIn
      // 
      this.textBoxLookIn.AcceptsReturn = true;
      this.textBoxLookIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
      this.textBoxLookIn.Location = new System.Drawing.Point(6, 120);
      this.textBoxLookIn.Name = "textBoxLookIn";
      this.textBoxLookIn.Size = new System.Drawing.Size(171, 22);
      this.textBoxLookIn.TabIndex = 19;
      this.textBoxLookIn.Text = "c:\\";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(10, 102);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(48, 18);
      this.label3.TabIndex = 18;
      this.label3.Text = "Look in";
      // 
      // buttonSearch
      // 
      this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonSearch.BackColor = System.Drawing.SystemColors.Control;
      this.buttonSearch.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.buttonSearch.Location = new System.Drawing.Point(124, 180);
      this.buttonSearch.Name = "buttonSearch";
      this.buttonSearch.TabIndex = 17;
      this.buttonSearch.Text = "Search";
      this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
      // 
      // textBoxFilename
      // 
      this.textBoxFilename.AcceptsReturn = true;
      this.textBoxFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
      this.textBoxFilename.Location = new System.Drawing.Point(6, 58);
      this.textBoxFilename.Name = "textBoxFilename";
      this.textBoxFilename.Size = new System.Drawing.Size(193, 22);
      this.textBoxFilename.TabIndex = 16;
      this.textBoxFilename.Text = "";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(10, 40);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(153, 18);
      this.label2.TabIndex = 15;
      this.label2.Text = "All or part of the filename";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label1.Location = new System.Drawing.Point(8, 12);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(170, 19);
      this.label1.TabIndex = 14;
      this.label1.Text = "Enter your search criteria";
      // 
      // NavigatorSearch
      // 
      this.BackColor = System.Drawing.Color.Honeydew;
      this.Controls.Add(this.buttonBrowse);
      this.Controls.Add(this.textBoxLookIn);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.buttonSearch);
      this.Controls.Add(this.textBoxFilename);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "NavigatorSearch";
      this.Size = new System.Drawing.Size(213, 315);
      this.ResumeLayout(false);

    }
	  #endregion

    public void Start()
    {
      Cursor = Cursors.WaitCursor;
      itemsFound = 0;
      buttonSearch.Text = "Stop";
      stopRequested = false;
      searching = true;
      DoSearch(textBoxLookIn.Text);
      searching = false;
      SearchFinished();
      Cursor = Cursors.Default;
    }

    // recursive method
    void DoSearch(string theFolder)
    {
      if (!Directory.Exists(theFolder)) return;

      // search this folder
      string pattern = textBoxFilename.Text;
      foreach (string filePath in Directory.GetFiles(theFolder, pattern))
      {
        itemsFound++;
        FireItemFound(filePath, itemsFound);
      }

      // search all subdirectories
      foreach (string directory in Directory.GetDirectories(theFolder))
      {
        DoSearch(directory);
        if (stopRequested) 
        {
          FireMessage(string.Format("{0} items found", itemsFound));
          return;
        }
      }
    }

    void SearchFinished()
    {
      buttonSearch.Text = "Search";
      Cursor = Cursors.Default;
    }

    void StartSearch(string theFolderPath)
    {
      FireSearchRequested(theFolderPath);
      Cursor = Cursors.WaitCursor;
    }

    void StopSearch()
    {
      stopRequested = true;
      Cursor = Cursors.Default;
    }

    #region Event Handlers
    private void buttonSearch_Click(object sender, System.EventArgs e)
    {
      if (!searching)
        StartSearch(textBoxLookIn.Text);
      else
        StopSearch();
    }

    private void buttonBrowse_Click(object sender, System.EventArgs e)
    {
      if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
        textBoxLookIn.Text = folderBrowserDialog1.SelectedPath;
    }
    #endregion

    #region Events
    public delegate void SearchRequestedHandler(string theFolderPath);
    public event SearchRequestedHandler OnSearchRequested;
    void FireSearchRequested(string theFolderPath)
    {
      if (OnSearchRequested != null)
        OnSearchRequested(theFolderPath);
    }

    public delegate void ItemFoundHandler(string thePath, int theCurrentCount);
    public event ItemFoundHandler OnItemFound;
    void FireItemFound(string thePath, int theCurrentCount)
    {
      if (OnItemFound != null)
        OnItemFound(thePath, theCurrentCount);
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
