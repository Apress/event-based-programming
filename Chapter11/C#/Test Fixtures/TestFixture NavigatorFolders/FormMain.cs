using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using SystemBrowser;

namespace TestFixtureNavigatorFolders
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
    private System.Windows.Forms.Label labelFolderPath;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textBoxFolderToSelect;
    private System.Windows.Forms.Panel panelFolders;
    private System.Windows.Forms.Label labelMessages;
    private System.Windows.Forms.Button buttonSelectParentFolder;
    private System.Windows.Forms.Button buttonPopulate;
    private System.Windows.Forms.Panel panelStatusBar;
    private System.Windows.Forms.ProgressBar progressBar1;
    #endregion

    NavigatorFolders navigatorFolders;

	  public FormMain()
	  {
		  //
		  // Required for Windows Form Designer support
		  //
		  InitializeComponent();

      navigatorFolders = new NavigatorFolders();
      panelFolders.Controls.Add(navigatorFolders);
      navigatorFolders.Dock = DockStyle.Fill;

      navigatorFolders.OnFolderChanged += new SystemBrowser.NavigatorFolders.FolderChangedHandler(ShowFolderPath);
      navigatorFolders.OnMessage += new SystemBrowser.NavigatorFolders.MessageHandler(ShowMessage);
      navigatorFolders.OnProgress += new SystemBrowser.NavigatorFolders.ProgressHandler(UpdateProgress);
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
      this.buttonPopulate = new System.Windows.Forms.Button();
      this.buttonSelectParentFolder = new System.Windows.Forms.Button();
      this.textBoxFolderToSelect = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.labelFolderPath = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.panelFolders = new System.Windows.Forms.Panel();
      this.labelMessages = new System.Windows.Forms.Label();
      this.panelStatusBar = new System.Windows.Forms.Panel();
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      this.panelTop.SuspendLayout();
      this.panelStatusBar.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelTop
      // 
      this.panelTop.Controls.Add(this.buttonPopulate);
      this.panelTop.Controls.Add(this.buttonSelectParentFolder);
      this.panelTop.Controls.Add(this.textBoxFolderToSelect);
      this.panelTop.Controls.Add(this.label2);
      this.panelTop.Controls.Add(this.labelFolderPath);
      this.panelTop.Controls.Add(this.label1);
      this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelTop.Location = new System.Drawing.Point(0, 0);
      this.panelTop.Name = "panelTop";
      this.panelTop.Size = new System.Drawing.Size(512, 102);
      this.panelTop.TabIndex = 0;
      // 
      // buttonPopulate
      // 
      this.buttonPopulate.Location = new System.Drawing.Point(34, 66);
      this.buttonPopulate.Name = "buttonPopulate";
      this.buttonPopulate.Size = new System.Drawing.Size(75, 26);
      this.buttonPopulate.TabIndex = 5;
      this.buttonPopulate.Text = "Populate";
      this.buttonPopulate.Click += new System.EventHandler(this.buttonPopulate_Click);
      // 
      // buttonSelectParentFolder
      // 
      this.buttonSelectParentFolder.Location = new System.Drawing.Point(125, 64);
      this.buttonSelectParentFolder.Name = "buttonSelectParentFolder";
      this.buttonSelectParentFolder.Size = new System.Drawing.Size(141, 26);
      this.buttonSelectParentFolder.TabIndex = 4;
      this.buttonSelectParentFolder.Text = "Select Parent Folder";
      this.buttonSelectParentFolder.Click += new System.EventHandler(this.buttonSelectParentFolder_Click);
      // 
      // textBoxFolderToSelect
      // 
      this.textBoxFolderToSelect.AcceptsReturn = true;
      this.textBoxFolderToSelect.Location = new System.Drawing.Point(116, 36);
      this.textBoxFolderToSelect.Name = "textBoxFolderToSelect";
      this.textBoxFolderToSelect.Size = new System.Drawing.Size(374, 22);
      this.textBoxFolderToSelect.TabIndex = 3;
      this.textBoxFolderToSelect.Text = "";
      this.textBoxFolderToSelect.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFolderToSelect_KeyPress);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 39);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(107, 18);
      this.label2.TabIndex = 2;
      this.label2.Text = "Folder To Select:";
      // 
      // labelFolderPath
      // 
      this.labelFolderPath.AutoSize = true;
      this.labelFolderPath.Location = new System.Drawing.Point(88, 14);
      this.labelFolderPath.Name = "labelFolderPath";
      this.labelFolderPath.Size = new System.Drawing.Size(50, 18);
      this.labelFolderPath.TabIndex = 1;
      this.labelFolderPath.Text = "<none>";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(11, 14);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(78, 18);
      this.label1.TabIndex = 0;
      this.label1.Text = "Folder Path:";
      // 
      // panelFolders
      // 
      this.panelFolders.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelFolders.Location = new System.Drawing.Point(0, 102);
      this.panelFolders.Name = "panelFolders";
      this.panelFolders.Size = new System.Drawing.Size(512, 183);
      this.panelFolders.TabIndex = 1;
      // 
      // labelMessages
      // 
      this.labelMessages.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelMessages.Location = new System.Drawing.Point(0, 0);
      this.labelMessages.Name = "labelMessages";
      this.labelMessages.Size = new System.Drawing.Size(408, 17);
      this.labelMessages.TabIndex = 2;
      this.labelMessages.Text = "Messages";
      this.labelMessages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // panelStatusBar
      // 
      this.panelStatusBar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.panelStatusBar.Controls.Add(this.labelMessages);
      this.panelStatusBar.Controls.Add(this.progressBar1);
      this.panelStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelStatusBar.Location = new System.Drawing.Point(0, 285);
      this.panelStatusBar.Name = "panelStatusBar";
      this.panelStatusBar.Size = new System.Drawing.Size(512, 21);
      this.panelStatusBar.TabIndex = 3;
      // 
      // progressBar1
      // 
      this.progressBar1.Dock = System.Windows.Forms.DockStyle.Right;
      this.progressBar1.Location = new System.Drawing.Point(408, 0);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(100, 17);
      this.progressBar1.TabIndex = 3;
      // 
      // FormMain
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
      this.ClientSize = new System.Drawing.Size(512, 306);
      this.Controls.Add(this.panelFolders);
      this.Controls.Add(this.panelStatusBar);
      this.Controls.Add(this.panelTop);
      this.Name = "FormMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Test Fixture NavigatorFolders";
      this.panelTop.ResumeLayout(false);
      this.panelStatusBar.ResumeLayout(false);
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

    private void ShowFolderPath(string theFolderPath)
    {
      labelFolderPath.Text = theFolderPath;
    }

    private void ShowMessage(string theMessage)
    {
      labelMessages.Text = theMessage;
    }

    private void UpdateProgress(int thePercentComplete)
    {
      progressBar1.Value = thePercentComplete;
      progressBar1.Update();
    }

    private void textBoxFolderToSelect_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r') return;
      e.Handled = true;  // to prevent the TextBox from beeping
      navigatorFolders.SelectFolder(textBoxFolderToSelect.Text);
    }

    private void buttonPopulate_Click(object sender, System.EventArgs e)
    {
      navigatorFolders.Populate(@"C:\");
    }

    private void buttonSelectParentFolder_Click(object sender, System.EventArgs e)
    {
      navigatorFolders.SelectParentFolder();
    }
  }
}
