using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;

using SystemBrowser;

namespace TestFixtureNavigatorSearch
{
	/// <summary>
	/// Summary description for FormMain.
	/// </summary>
  public class FormMain : System.Windows.Forms.Form
  {
    #region Controls
	  private System.ComponentModel.Container components = null;
    private System.Windows.Forms.Panel panelTop;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ListBox listBoxItemsFound;
    private System.Windows.Forms.Panel panelSearch;
    private System.Windows.Forms.Label labelMessages;
    #endregion

    CoordinatorSearch coordinatorSearch;
    NavigatorSearch navigatorSearch;

	  public FormMain()
	  {
		  //
		  // Required for Windows Form Designer support
		  //
		  InitializeComponent();

      navigatorSearch = new NavigatorSearch();
      coordinatorSearch = new CoordinatorSearch(this);

      coordinatorSearch.OnSearchRequested += new CoordinatorSearch.SearchRequestedHandler(ClearList);
      coordinatorSearch.OnSearchStart += new ThreadStart(navigatorSearch.Start);
      coordinatorSearch.OnItemFound += new CoordinatorSearch.ItemFoundHandler(AddToList);
      coordinatorSearch.OnMessage += new CoordinatorSearch.MessageHandler(ShowMessage);

      navigatorSearch.OnSearchRequested += new NavigatorSearch.SearchRequestedHandler(coordinatorSearch.StartSearch);
      navigatorSearch.OnItemFound += new NavigatorSearch.ItemFoundHandler(coordinatorSearch.ItemFound);
      navigatorSearch.OnMessage += new NavigatorSearch.MessageHandler(coordinatorSearch.FireMessage);

      panelSearch.Controls.Add(navigatorSearch);
      navigatorSearch.Dock = DockStyle.Fill;
	  }

	  /// <summary>
	  /// Clean up any resources being used.
	  /// </summary>
	  protected override void Dispose( bool disposing )
	  {
		  if( disposing )
		  {
			  if (components != null) 
			  {
				  components.Dispose();
			  }
		  }
		  base.Dispose( disposing );
	  }

	  #region Windows Form Designer generated code
	  /// <summary>
	  /// Required method for Designer support - do not modify
	  /// the contents of this method with the code editor.
	  /// </summary>
	  private void InitializeComponent()
	  {
      this.panelTop = new System.Windows.Forms.Panel();
      this.listBoxItemsFound = new System.Windows.Forms.ListBox();
      this.label1 = new System.Windows.Forms.Label();
      this.panelSearch = new System.Windows.Forms.Panel();
      this.labelMessages = new System.Windows.Forms.Label();
      this.panelTop.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelTop
      // 
      this.panelTop.Controls.Add(this.listBoxItemsFound);
      this.panelTop.Controls.Add(this.label1);
      this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelTop.Location = new System.Drawing.Point(0, 0);
      this.panelTop.Name = "panelTop";
      this.panelTop.Size = new System.Drawing.Size(328, 76);
      this.panelTop.TabIndex = 0;
      // 
      // listBoxItemsFound
      // 
      this.listBoxItemsFound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
      this.listBoxItemsFound.Location = new System.Drawing.Point(77, 0);
      this.listBoxItemsFound.Name = "listBoxItemsFound";
      this.listBoxItemsFound.Size = new System.Drawing.Size(251, 69);
      this.listBoxItemsFound.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 7);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(70, 16);
      this.label1.TabIndex = 0;
      this.label1.Text = "Items Found:";
      // 
      // panelSearch
      // 
      this.panelSearch.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelSearch.Location = new System.Drawing.Point(0, 76);
      this.panelSearch.Name = "panelSearch";
      this.panelSearch.Size = new System.Drawing.Size(328, 217);
      this.panelSearch.TabIndex = 1;
      // 
      // labelMessages
      // 
      this.labelMessages.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.labelMessages.Location = new System.Drawing.Point(0, 293);
      this.labelMessages.Name = "labelMessages";
      this.labelMessages.Size = new System.Drawing.Size(328, 23);
      this.labelMessages.TabIndex = 2;
      this.labelMessages.Text = "Messages";
      this.labelMessages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // FormMain
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(328, 316);
      this.Controls.Add(this.panelSearch);
      this.Controls.Add(this.labelMessages);
      this.Controls.Add(this.panelTop);
      this.Name = "FormMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Test Fixture for NavigatorSearch";
      this.panelTop.ResumeLayout(false);
      this.ResumeLayout(false);

    }
	  #endregion

	  /// <summary>
	  /// The main entry point for the application.
	  /// </summary>
	  [STAThread]
	  static void Main() 
	  {
		  Application.Run(new FormMain());
    }

    private void ShowItemFound(string thePath, int theCurrentCount)
    {
      listBoxItemsFound.Items.Add(thePath);
    }

    private void ShowMessage(string theMessage)
    {
      labelMessages.Text = theMessage;
    }

    private void ClearList()
    {
      listBoxItemsFound.Items.Clear();
    }

    private void AddToList(string theText, int theCount)
    {
      listBoxItemsFound.Items.Add(theText);
    }
  }
}
