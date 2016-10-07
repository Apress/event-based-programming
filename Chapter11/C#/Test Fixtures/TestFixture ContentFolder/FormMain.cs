using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using SystemBrowser;

namespace TestFixtureContentFileList
{
	/// <summary>
	/// Summary description for FormMain.
	/// </summary>
  public class FormMain : System.Windows.Forms.Form
  {
    #region Controls
    private System.Windows.Forms.Panel panelTop;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBoxFolder;
    private System.Windows.Forms.Panel panelContent;
    private System.ComponentModel.IContainer components;
    private System.Windows.Forms.Button buttonPopulate;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button buttonAdd;
    private System.Windows.Forms.TextBox textBoxFileToAdd;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label labelFolderDoubleClicked;
    private System.Windows.Forms.Label labelMessages;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.RadioButton radioButtonShowIcons;
    private System.Windows.Forms.RadioButton radioButtonShowDetails;
    #endregion

    ContentFileList contentFileList;

	  public FormMain()
	  {
      contentFileList = new ContentFileList();

		  // Required for Windows Form Designer support
		  InitializeComponent();

      contentFileList.OnFolderDoubleClicked += new ContentFileList.FolderDoubleClickedHandler(ShowFolderPath);  
      contentFileList.OnMessage += new SystemBrowser.ContentFileList.MessageHandler(ShowMessage);
      panelContent.Controls.Add(contentFileList);
      contentFileList.Dock = DockStyle.Fill;
	  }

    void ShowFolderPath(string thePath)
    {
      labelFolderDoubleClicked.Text = thePath;
    }

    private void ShowMessage(string theMessage)
    {
      labelMessages.Text = theMessage;
    }

    private void textBoxFolder_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
      if (e.KeyChar == '\r')  // the Enter key
      {
        contentFileList.Populate(textBoxFolder.Text);
        e.Handled = true; // to prevent TextBox from beeping
      }
    }

    private void buttonPopulate_Click(object sender, System.EventArgs e)
    {
      contentFileList.Populate(textBoxFolder.Text);
    }

    private void buttonAdd_Click(object sender, System.EventArgs e)
    {
      contentFileList.Add(textBoxFileToAdd.Text);
    }

    private void radioButtonShowIcons_CheckedChanged(object sender, System.EventArgs e)
    {
      SetMode();
    }

    private void radioButtonShowDetails_CheckedChanged(object sender, System.EventArgs e)
    {
      SetMode();
    }

    void SetMode()
    {
      if (radioButtonShowIcons.Checked)
        contentFileList.ShowIcons();
      else
        contentFileList.ShowDetails();
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
      this.components = new System.ComponentModel.Container();
      this.panelTop = new System.Windows.Forms.Panel();
      this.labelFolderDoubleClicked = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.buttonAdd = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.buttonPopulate = new System.Windows.Forms.Button();
      this.textBoxFolder = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.textBoxFileToAdd = new System.Windows.Forms.TextBox();
      this.panelContent = new System.Windows.Forms.Panel();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.labelMessages = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.radioButtonShowIcons = new System.Windows.Forms.RadioButton();
      this.radioButtonShowDetails = new System.Windows.Forms.RadioButton();
      this.panelTop.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelTop
      // 
      this.panelTop.Controls.Add(this.groupBox1);
      this.panelTop.Controls.Add(this.labelFolderDoubleClicked);
      this.panelTop.Controls.Add(this.label3);
      this.panelTop.Controls.Add(this.buttonAdd);
      this.panelTop.Controls.Add(this.label2);
      this.panelTop.Controls.Add(this.buttonPopulate);
      this.panelTop.Controls.Add(this.textBoxFolder);
      this.panelTop.Controls.Add(this.label1);
      this.panelTop.Controls.Add(this.textBoxFileToAdd);
      this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelTop.Location = new System.Drawing.Point(0, 0);
      this.panelTop.Name = "panelTop";
      this.panelTop.Size = new System.Drawing.Size(585, 143);
      this.panelTop.TabIndex = 0;
      // 
      // labelFolderDoubleClicked
      // 
      this.labelFolderDoubleClicked.AutoSize = true;
      this.labelFolderDoubleClicked.Location = new System.Drawing.Point(146, 114);
      this.labelFolderDoubleClicked.Name = "labelFolderDoubleClicked";
      this.labelFolderDoubleClicked.Size = new System.Drawing.Size(50, 18);
      this.labelFolderDoubleClicked.TabIndex = 6;
      this.labelFolderDoubleClicked.Text = "<none>";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(9, 114);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(141, 18);
      this.label3.TabIndex = 5;
      this.label3.Text = "Folder Double-Clicked:";
      // 
      // buttonAdd
      // 
      this.buttonAdd.Location = new System.Drawing.Point(478, 38);
      this.buttonAdd.Name = "buttonAdd";
      this.buttonAdd.Size = new System.Drawing.Size(90, 27);
      this.buttonAdd.TabIndex = 4;
      this.buttonAdd.Text = "Add";
      this.toolTip1.SetToolTip(this.buttonAdd, "Add the file to the end of the list");
      this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(8, 38);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(72, 18);
      this.label2.TabIndex = 3;
      this.label2.Text = "File to Add:";
      // 
      // buttonPopulate
      // 
      this.buttonPopulate.Location = new System.Drawing.Point(476, 7);
      this.buttonPopulate.Name = "buttonPopulate";
      this.buttonPopulate.Size = new System.Drawing.Size(90, 26);
      this.buttonPopulate.TabIndex = 2;
      this.buttonPopulate.Text = "Populate";
      this.toolTip1.SetToolTip(this.buttonPopulate, "Populate the listview with files from the selected folder");
      this.buttonPopulate.Click += new System.EventHandler(this.buttonPopulate_Click);
      // 
      // textBoxFolder
      // 
      this.textBoxFolder.Location = new System.Drawing.Point(82, 7);
      this.textBoxFolder.Name = "textBoxFolder";
      this.textBoxFolder.Size = new System.Drawing.Size(384, 22);
      this.textBoxFolder.TabIndex = 1;
      this.textBoxFolder.Text = "c:\\";
      this.textBoxFolder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFolder_KeyPress);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(34, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(47, 18);
      this.label1.TabIndex = 0;
      this.label1.Text = "Folder:";
      // 
      // textBoxFileToAdd
      // 
      this.textBoxFileToAdd.Location = new System.Drawing.Point(80, 37);
      this.textBoxFileToAdd.Name = "textBoxFileToAdd";
      this.textBoxFileToAdd.Size = new System.Drawing.Size(384, 22);
      this.textBoxFileToAdd.TabIndex = 2;
      this.textBoxFileToAdd.Text = "c:\\config.sys";
      // 
      // panelContent
      // 
      this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelContent.Location = new System.Drawing.Point(0, 143);
      this.panelContent.Name = "panelContent";
      this.panelContent.Size = new System.Drawing.Size(585, 136);
      this.panelContent.TabIndex = 1;
      // 
      // labelMessages
      // 
      this.labelMessages.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.labelMessages.Location = new System.Drawing.Point(0, 279);
      this.labelMessages.Name = "labelMessages";
      this.labelMessages.Size = new System.Drawing.Size(585, 27);
      this.labelMessages.TabIndex = 2;
      this.labelMessages.Text = "Messages";
      this.labelMessages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.radioButtonShowDetails);
      this.groupBox1.Controls.Add(this.radioButtonShowIcons);
      this.groupBox1.Location = new System.Drawing.Point(19, 67);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(442, 42);
      this.groupBox1.TabIndex = 7;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Mode";
      // 
      // radioButtonShowIcons
      // 
      this.radioButtonShowIcons.Location = new System.Drawing.Point(64, 12);
      this.radioButtonShowIcons.Name = "radioButtonShowIcons";
      this.radioButtonShowIcons.TabIndex = 0;
      this.radioButtonShowIcons.Text = "Show Icons";
      this.radioButtonShowIcons.CheckedChanged += new System.EventHandler(this.radioButtonShowIcons_CheckedChanged);
      // 
      // radioButtonShowDetails
      // 
      this.radioButtonShowDetails.Checked = true;
      this.radioButtonShowDetails.Location = new System.Drawing.Point(238, 13);
      this.radioButtonShowDetails.Name = "radioButtonShowDetails";
      this.radioButtonShowDetails.TabIndex = 1;
      this.radioButtonShowDetails.TabStop = true;
      this.radioButtonShowDetails.Text = "Show Details";
      this.radioButtonShowDetails.CheckedChanged += new System.EventHandler(this.radioButtonShowDetails_CheckedChanged);
      // 
      // FormMain
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
      this.ClientSize = new System.Drawing.Size(585, 306);
      this.Controls.Add(this.panelContent);
      this.Controls.Add(this.labelMessages);
      this.Controls.Add(this.panelTop);
      this.Name = "FormMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Test Fixture ContentFileList";
      this.panelTop.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
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
  }
}
