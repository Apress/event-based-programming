using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace SystemBrowser
{
  /// <summary>
  /// FormMain hosts all the UI elements in the application,
  /// but doesn't manage any of them. The Binder wires event
  /// sources to handlers, without getting FormMain involved.
  /// </summary>
  public class FormMain : System.Windows.Forms.Form
  {
    #region Controls
    private System.ComponentModel.Container components = null;
    private System.Windows.Forms.Panel panelToolBar;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panelStatusBar;
    private System.Windows.Forms.Panel panelNavigator;
    private System.Windows.Forms.Panel panelContent;
    #endregion

    #region UI Children
    public Control Toolbar
    {
      set 
      {
        value.Dock = DockStyle.Fill;
        panelToolBar.Controls.Add(value);
      }
    }

    public Control Statusbar
    {
      set 
      {
        value.Dock = DockStyle.Fill;
        panelStatusBar.Controls.Add(value);
      }
    }

    private Control navigatorFolders;
    public Control NavigatorFolders
    {
      set {navigatorFolders = value;}
    }

    private Control navigatorSearch;
    public Control NavigatorSearch
    {
      set {navigatorSearch = value;}
    }

    private Control contentFolders;
    private System.Windows.Forms.Splitter splitter1;
  
    public Control ContentFolders
    {
      set {contentFolders = value;}
    }

    private Control contentSearch;
    public Control ContentSearch
    {
      set {contentSearch = value;}
    }
    #endregion

    public FormMain()
    {
      // Required for Windows Form Designer support
      InitializeComponent();
    }

    public void ShowFolders()
    {
      panelNavigator.Controls.Clear();
      panelNavigator.Controls.Add(navigatorFolders);
      navigatorFolders.Dock = DockStyle.Fill;

      panelContent.Controls.Clear();
      panelContent.Controls.Add(contentFolders);
      contentFolders.Dock = DockStyle.Fill;
    }

    public void ShowSearch()
    {
      panelNavigator.Controls.Clear();
      panelNavigator.Controls.Add(navigatorSearch);
      navigatorSearch.Dock = DockStyle.Fill;

      panelContent.Controls.Clear();
      panelContent.Controls.Add(contentSearch);
      contentSearch.Dock = DockStyle.Fill;
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
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormMain));
      this.panelToolBar = new System.Windows.Forms.Panel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.panelStatusBar = new System.Windows.Forms.Panel();
      this.panelNavigator = new System.Windows.Forms.Panel();
      this.splitter1 = new System.Windows.Forms.Splitter();
      this.panelContent = new System.Windows.Forms.Panel();
      this.SuspendLayout();
      // 
      // panelToolBar
      // 
      this.panelToolBar.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelToolBar.Location = new System.Drawing.Point(0, 0);
      this.panelToolBar.Name = "panelToolBar";
      this.panelToolBar.Size = new System.Drawing.Size(770, 60);
      this.panelToolBar.TabIndex = 0;
      // 
      // panel1
      // 
      this.panel1.Location = new System.Drawing.Point(166, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(539, 263);
      this.panel1.TabIndex = 2;
      // 
      // panelStatusBar
      // 
      this.panelStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelStatusBar.Location = new System.Drawing.Point(0, 398);
      this.panelStatusBar.Name = "panelStatusBar";
      this.panelStatusBar.Size = new System.Drawing.Size(770, 24);
      this.panelStatusBar.TabIndex = 1;
      // 
      // panelNavigator
      // 
      this.panelNavigator.Dock = System.Windows.Forms.DockStyle.Left;
      this.panelNavigator.Location = new System.Drawing.Point(0, 60);
      this.panelNavigator.Name = "panelNavigator";
      this.panelNavigator.Size = new System.Drawing.Size(222, 338);
      this.panelNavigator.TabIndex = 2;
      // 
      // splitter1
      // 
      this.splitter1.Location = new System.Drawing.Point(222, 60);
      this.splitter1.MinSize = 100;
      this.splitter1.Name = "splitter1";
      this.splitter1.Size = new System.Drawing.Size(6, 338);
      this.splitter1.TabIndex = 3;
      this.splitter1.TabStop = false;
      // 
      // panelContent
      // 
      this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelContent.Location = new System.Drawing.Point(228, 60);
      this.panelContent.Name = "panelContent";
      this.panelContent.Size = new System.Drawing.Size(542, 338);
      this.panelContent.TabIndex = 4;
      // 
      // FormMain
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
      this.ClientSize = new System.Drawing.Size(770, 422);
      this.Controls.Add(this.panelContent);
      this.Controls.Add(this.splitter1);
      this.Controls.Add(this.panelNavigator);
      this.Controls.Add(this.panelStatusBar);
      this.Controls.Add(this.panelToolBar);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "FormMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "SystemBrowser";
      this.ResumeLayout(false);

    }
    #endregion
  }
}
