using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SystemBrowser
{
  /// <summary>
  /// FormMenuToolBar is used as a design-time host for
  /// the application's toolbar and statusbar. At runtime,
  /// these elements are moved over onto FormMain. 
  /// FormMenuToolBar is useful because it contains all the
  /// event handling code for the menu and toolbar, obviating
  /// the need to put that code in FormMain.
  /// </summary>
  public class FormMenuToolBar : System.Windows.Forms.Form
  {
    #region Controls
    public System.Windows.Forms.MainMenu mainMenu;
    private System.Windows.Forms.MenuItem menuItemFile;
    private System.Windows.Forms.MenuItem menuItemFileExit;
    private System.Windows.Forms.MenuItem menuItemView;
    private System.Windows.Forms.MenuItem menuItemViewSearch;
    private System.Windows.Forms.MenuItem menuItemViewFolders;
    private System.Windows.Forms.MenuItem menuItemViewIcons;
    private System.Windows.Forms.MenuItem menuItemViewDetails;
    private System.Windows.Forms.MenuItem menuItemHelp;
    private System.Windows.Forms.MenuItem menuItemHelpAbout;
    private System.Windows.Forms.MenuItem menuItemViewSeparator;
    private System.Windows.Forms.ImageList imageListToolBar;
    private System.Windows.Forms.ToolBarButton toolBarButtonFolders;
    private System.Windows.Forms.ToolBarButton toolBarButtonSearch;
    public System.Windows.Forms.ToolBar toolBar;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.Panel panelAddressBar;
    private System.Windows.Forms.TextBox textBoxAddress;
    public System.Windows.Forms.Panel panelToolBar;
    private System.Windows.Forms.ToolBarButton toolBarButtonUp;
    private System.Windows.Forms.ToolBarButton toolBarButtonSeparator1;
    private System.Windows.Forms.Panel panelGoButton;
    public System.Windows.Forms.Button buttonGo;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label1;
    private System.ComponentModel.IContainer components;
    #endregion

    public FormMenuToolBar()
    {
      // Required for Windows Form Designer support
      InitializeComponent();
    }

    public void SelectFolders()
    {
      toolBarButtonFolders.Pushed = true;
      toolBarButtonSearch.Pushed = false;

      menuItemViewFolders.Checked = true;
      menuItemViewSearch.Checked = false;

      FireViewFolders();
    }

    public void SelectSearch()
    {
      toolBarButtonFolders.Pushed = false;
      toolBarButtonSearch.Pushed = true;

      menuItemViewFolders.Checked = false;
      menuItemViewSearch.Checked = true;

      FireViewSearch();
    }

    public void ShowAddress(string theAddress)
    {
      if (theAddress == null) theAddress = string.Empty;
      textBoxAddress.Text = theAddress;
      textBoxAddress.SelectionStart = textBoxAddress.Text.Length; 
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

    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormMenuToolBar));
      this.mainMenu = new System.Windows.Forms.MainMenu();
      this.menuItemFile = new System.Windows.Forms.MenuItem();
      this.menuItemFileExit = new System.Windows.Forms.MenuItem();
      this.menuItemView = new System.Windows.Forms.MenuItem();
      this.menuItemViewFolders = new System.Windows.Forms.MenuItem();
      this.menuItemViewSearch = new System.Windows.Forms.MenuItem();
      this.menuItemViewSeparator = new System.Windows.Forms.MenuItem();
      this.menuItemViewIcons = new System.Windows.Forms.MenuItem();
      this.menuItemViewDetails = new System.Windows.Forms.MenuItem();
      this.menuItemHelp = new System.Windows.Forms.MenuItem();
      this.menuItemHelpAbout = new System.Windows.Forms.MenuItem();
      this.toolBar = new System.Windows.Forms.ToolBar();
      this.toolBarButtonUp = new System.Windows.Forms.ToolBarButton();
      this.toolBarButtonSeparator1 = new System.Windows.Forms.ToolBarButton();
      this.toolBarButtonFolders = new System.Windows.Forms.ToolBarButton();
      this.toolBarButtonSearch = new System.Windows.Forms.ToolBarButton();
      this.imageListToolBar = new System.Windows.Forms.ImageList(this.components);
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.panelToolBar = new System.Windows.Forms.Panel();
      this.panelAddressBar = new System.Windows.Forms.Panel();
      this.textBoxAddress = new System.Windows.Forms.TextBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.label1 = new System.Windows.Forms.Label();
      this.panelGoButton = new System.Windows.Forms.Panel();
      this.buttonGo = new System.Windows.Forms.Button();
      this.panelToolBar.SuspendLayout();
      this.panelAddressBar.SuspendLayout();
      this.panel1.SuspendLayout();
      this.panelGoButton.SuspendLayout();
      this.SuspendLayout();
      // 
      // mainMenu
      // 
      this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                              this.menuItemFile,
                                                                              this.menuItemView,
                                                                              this.menuItemHelp});
      // 
      // menuItemFile
      // 
      this.menuItemFile.Index = 0;
      this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                  this.menuItemFileExit});
      this.menuItemFile.Text = "&File";
      // 
      // menuItemFileExit
      // 
      this.menuItemFileExit.Index = 0;
      this.menuItemFileExit.Text = "E&xit";
      this.menuItemFileExit.Click += new System.EventHandler(this.menuItemFileExit_Click);
      // 
      // menuItemView
      // 
      this.menuItemView.Index = 1;
      this.menuItemView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                  this.menuItemViewFolders,
                                                                                  this.menuItemViewSearch,
                                                                                  this.menuItemViewSeparator,
                                                                                  this.menuItemViewIcons,
                                                                                  this.menuItemViewDetails});
      this.menuItemView.Text = "&View";
      // 
      // menuItemViewFolders
      // 
      this.menuItemViewFolders.Checked = true;
      this.menuItemViewFolders.Index = 0;
      this.menuItemViewFolders.Text = "&Folders";
      this.menuItemViewFolders.Click += new System.EventHandler(this.menuItemViewFolders_Click);
      // 
      // menuItemViewSearch
      // 
      this.menuItemViewSearch.Index = 1;
      this.menuItemViewSearch.Text = "&Search";
      this.menuItemViewSearch.Click += new System.EventHandler(this.menuItemViewSearch_Click);
      // 
      // menuItemViewSeparator
      // 
      this.menuItemViewSeparator.Index = 2;
      this.menuItemViewSeparator.Text = "-";
      // 
      // menuItemViewIcons
      // 
      this.menuItemViewIcons.Index = 3;
      this.menuItemViewIcons.Text = "&Icons";
      this.menuItemViewIcons.Click += new System.EventHandler(this.menuItemViewIcons_Click);
      // 
      // menuItemViewDetails
      // 
      this.menuItemViewDetails.Checked = true;
      this.menuItemViewDetails.Index = 4;
      this.menuItemViewDetails.Text = "&Details";
      this.menuItemViewDetails.Click += new System.EventHandler(this.menuItemViewDetails_Click);
      // 
      // menuItemHelp
      // 
      this.menuItemHelp.Index = 2;
      this.menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                  this.menuItemHelpAbout});
      this.menuItemHelp.Text = "&Help";
      // 
      // menuItemHelpAbout
      // 
      this.menuItemHelpAbout.Index = 0;
      this.menuItemHelpAbout.Text = "&About...";
      this.menuItemHelpAbout.Click += new System.EventHandler(this.menuItemHelpAbout_Click);
      // 
      // toolBar
      // 
      this.toolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
      this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
                                                                                this.toolBarButtonUp,
                                                                                this.toolBarButtonSeparator1,
                                                                                this.toolBarButtonFolders,
                                                                                this.toolBarButtonSearch});
      this.toolBar.ButtonSize = new System.Drawing.Size(20, 20);
      this.toolBar.DropDownArrows = true;
      this.toolBar.ImageList = this.imageListToolBar;
      this.toolBar.Location = new System.Drawing.Point(0, 0);
      this.toolBar.Name = "toolBar";
      this.toolBar.ShowToolTips = true;
      this.toolBar.Size = new System.Drawing.Size(554, 32);
      this.toolBar.TabIndex = 0;
      this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
      // 
      // toolBarButtonUp
      // 
      this.toolBarButtonUp.ImageIndex = 2;
      this.toolBarButtonUp.ToolTipText = "Up";
      // 
      // toolBarButtonFolders
      // 
      this.toolBarButtonFolders.ImageIndex = 0;
      this.toolBarButtonFolders.Pushed = true;
      this.toolBarButtonFolders.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
      this.toolBarButtonFolders.ToolTipText = "Folders";
      // 
      // toolBarButtonSearch
      // 
      this.toolBarButtonSearch.ImageIndex = 1;
      this.toolBarButtonSearch.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
      this.toolBarButtonSearch.ToolTipText = "Search";
      // 
      // imageListToolBar
      // 
      this.imageListToolBar.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
      this.imageListToolBar.ImageSize = new System.Drawing.Size(20, 20);
      this.imageListToolBar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListToolBar.ImageStream")));
      this.imageListToolBar.TransparentColor = System.Drawing.Color.White;
      // 
      // panelToolBar
      // 
      this.panelToolBar.Controls.Add(this.panelAddressBar);
      this.panelToolBar.Controls.Add(this.toolBar);
      this.panelToolBar.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelToolBar.Location = new System.Drawing.Point(0, 0);
      this.panelToolBar.Name = "panelToolBar";
      this.panelToolBar.Size = new System.Drawing.Size(554, 59);
      this.panelToolBar.TabIndex = 1;
      // 
      // panelAddressBar
      // 
      this.panelAddressBar.Controls.Add(this.textBoxAddress);
      this.panelAddressBar.Controls.Add(this.panel1);
      this.panelAddressBar.Controls.Add(this.panelGoButton);
      this.panelAddressBar.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelAddressBar.Location = new System.Drawing.Point(0, 32);
      this.panelAddressBar.Name = "panelAddressBar";
      this.panelAddressBar.Size = new System.Drawing.Size(554, 29);
      this.panelAddressBar.TabIndex = 1;
      // 
      // textBoxAddress
      // 
      this.textBoxAddress.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textBoxAddress.Location = new System.Drawing.Point(74, 0);
      this.textBoxAddress.Name = "textBoxAddress";
      this.textBoxAddress.Size = new System.Drawing.Size(417, 22);
      this.textBoxAddress.TabIndex = 4;
      this.textBoxAddress.Text = "";
      this.textBoxAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAddress_KeyPress);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.label1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(74, 29);
      this.panel1.TabIndex = 6;
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(-1, -3);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(69, 29);
      this.label1.TabIndex = 3;
      this.label1.Text = "Address:";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // panelGoButton
      // 
      this.panelGoButton.Controls.Add(this.buttonGo);
      this.panelGoButton.Dock = System.Windows.Forms.DockStyle.Right;
      this.panelGoButton.Location = new System.Drawing.Point(491, 0);
      this.panelGoButton.Name = "panelGoButton";
      this.panelGoButton.Size = new System.Drawing.Size(63, 29);
      this.panelGoButton.TabIndex = 5;
      // 
      // buttonGo
      // 
      this.buttonGo.Image = ((System.Drawing.Image)(resources.GetObject("buttonGo.Image")));
      this.buttonGo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.buttonGo.Location = new System.Drawing.Point(3, 1);
      this.buttonGo.Name = "buttonGo";
      this.buttonGo.Size = new System.Drawing.Size(55, 23);
      this.buttonGo.TabIndex = 0;
      this.buttonGo.Text = "Go";
      this.buttonGo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
      // 
      // FormMenuToolBar
      // 
      this.AcceptButton = this.buttonGo;
      this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
      this.ClientSize = new System.Drawing.Size(554, 306);
      this.Controls.Add(this.panelToolBar);
      this.Menu = this.mainMenu;
      this.Name = "FormMenuToolBar";
      this.Text = "FormMenuToolbar";
      this.panelToolBar.ResumeLayout(false);
      this.panelAddressBar.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panelGoButton.ResumeLayout(false);
      this.ResumeLayout(false);

    }
    #endregion

    #region Event Handlers
    private void menuItemFileExit_Click(object sender, System.EventArgs e)
    {
      Application.Exit();
    }

    private void menuItemViewFolders_Click(object sender, System.EventArgs e)
    {
      SelectFolders();
    }

    private void menuItemViewSearch_Click(object sender, System.EventArgs e)
    {
      SelectSearch();
    }

    private void menuItemViewIcons_Click(object sender, System.EventArgs e)
    {
      menuItemViewIcons.Checked = true;
      menuItemViewDetails.Checked = false;
      FireViewIcons();
    }

    private void menuItemViewDetails_Click(object sender, System.EventArgs e)
    {
      menuItemViewIcons.Checked = false;
      menuItemViewDetails.Checked = true;
      FireViewDetails();
    }

    private void menuItemHelpAbout_Click(object sender, System.EventArgs e)
    {
      FormAbout formAbout = new FormAbout();
      formAbout.ShowDialog();
    }

    private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
    {
      if (e.Button == toolBarButtonUp)
      {
        SelectFolders();
        FireUpSelected();
      }
      else if (e.Button == toolBarButtonFolders)
      {
        SelectFolders();
      }
      else if (e.Button == toolBarButtonSearch) 
      {
        SelectSearch();
      }
    }

    private void buttonGo_Click(object sender, System.EventArgs e)
    {
      FireAddressChanged(textBoxAddress.Text);
    }

    private void textBoxAddress_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
      if (e.KeyChar == '\r')
      {
        e.Handled = true; // to prevent Windows from beeping
        FireAddressChanged(textBoxAddress.Text);
      }
    }
    #endregion

    #region Events
    public delegate void UniversalHandler();

    public event UniversalHandler OnViewFolders;
    void FireViewFolders()
    {
      if (OnViewFolders != null)
        OnViewFolders();
    }

    public event UniversalHandler OnViewSearch;
    void FireViewSearch()
    {
      if (OnViewSearch != null)
        OnViewSearch();
    }

    public event UniversalHandler OnViewIcons;
    void FireViewIcons()
    {
      if (OnViewIcons != null)
        OnViewIcons();
    }

    public event UniversalHandler OnViewDetails;
    void FireViewDetails()
    {
      if (OnViewDetails != null)
        OnViewDetails();
    }

    public event UniversalHandler OnUpSelected;
    void FireUpSelected()
    {
      if (OnUpSelected != null)
        OnUpSelected();
    }

    public delegate void AddressChangedHandler(string theNewAddress);
    public event AddressChangedHandler OnAddressChanged;
    void FireAddressChanged(string theNewAddress)
    {
      if (OnAddressChanged != null)
        OnAddressChanged(theNewAddress);
    }
    #endregion
  }
}
