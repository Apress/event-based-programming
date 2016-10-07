Public Class FormMenuToolBar
    Inherits System.Windows.Forms.Form

  Public Sub SelectFolders()
    toolBarButtonFolders.Pushed = True
    toolBarButtonSearch.Pushed = False

    menuItemViewFolders.Checked = True
    menuItemViewSearch.Checked = False

    FireViewFolders()
  End Sub

  Public Sub SelectSearch()
    toolBarButtonFolders.Pushed = False
    toolBarButtonSearch.Pushed = True

    menuItemViewFolders.Checked = False
    menuItemViewSearch.Checked = True

    FireViewSearch()
  End Sub

  Public Sub ShowAddress(ByVal theAddress As String)
    If theAddress Is Nothing Then theAddress = String.Empty
    textBoxAddress.Text = theAddress
    textBoxAddress.SelectionStart = textBoxAddress.Text.Length
  End Sub

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    'Add any initialization after the InitializeComponent() call

  End Sub

  'Form overrides dispose to clean up the component list.
  Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing Then
      If Not (components Is Nothing) Then
        components.Dispose()
      End If
    End If
    MyBase.Dispose(disposing)
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  Friend WithEvents toolTip1 As System.Windows.Forms.ToolTip
  Friend WithEvents imageListToolBar As System.Windows.Forms.ImageList
  Public WithEvents mainMenu As System.Windows.Forms.MainMenu
  Friend WithEvents menuItemFile As System.Windows.Forms.MenuItem
  Friend WithEvents menuItemFileExit As System.Windows.Forms.MenuItem
  Friend WithEvents menuItemView As System.Windows.Forms.MenuItem
  Friend WithEvents menuItemViewFolders As System.Windows.Forms.MenuItem
  Friend WithEvents menuItemViewSearch As System.Windows.Forms.MenuItem
  Friend WithEvents menuItemViewSeparator As System.Windows.Forms.MenuItem
  Friend WithEvents menuItemViewIcons As System.Windows.Forms.MenuItem
  Friend WithEvents menuItemViewDetails As System.Windows.Forms.MenuItem
  Friend WithEvents menuItemHelp As System.Windows.Forms.MenuItem
  Friend WithEvents menuItemHelpAbout As System.Windows.Forms.MenuItem
  Public WithEvents panelToolBar As System.Windows.Forms.Panel
  Friend WithEvents panelAddressBar As System.Windows.Forms.Panel
  Friend WithEvents textBoxAddress As System.Windows.Forms.TextBox
  Friend WithEvents panel1 As System.Windows.Forms.Panel
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents panelGoButton As System.Windows.Forms.Panel
  Public WithEvents buttonGo As System.Windows.Forms.Button
  Public WithEvents toolBar As System.Windows.Forms.ToolBar
  Friend WithEvents toolBarButtonUp As System.Windows.Forms.ToolBarButton
  Friend WithEvents toolBarButtonSeparator1 As System.Windows.Forms.ToolBarButton
  Friend WithEvents toolBarButtonFolders As System.Windows.Forms.ToolBarButton
  Friend WithEvents toolBarButtonSearch As System.Windows.Forms.ToolBarButton
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FormMenuToolBar))
    Me.toolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.imageListToolBar = New System.Windows.Forms.ImageList(Me.components)
    Me.mainMenu = New System.Windows.Forms.MainMenu
    Me.menuItemFile = New System.Windows.Forms.MenuItem
    Me.menuItemFileExit = New System.Windows.Forms.MenuItem
    Me.menuItemView = New System.Windows.Forms.MenuItem
    Me.menuItemViewFolders = New System.Windows.Forms.MenuItem
    Me.menuItemViewSearch = New System.Windows.Forms.MenuItem
    Me.menuItemViewSeparator = New System.Windows.Forms.MenuItem
    Me.menuItemViewIcons = New System.Windows.Forms.MenuItem
    Me.menuItemViewDetails = New System.Windows.Forms.MenuItem
    Me.menuItemHelp = New System.Windows.Forms.MenuItem
    Me.menuItemHelpAbout = New System.Windows.Forms.MenuItem
    Me.panelToolBar = New System.Windows.Forms.Panel
    Me.panelAddressBar = New System.Windows.Forms.Panel
    Me.textBoxAddress = New System.Windows.Forms.TextBox
    Me.panel1 = New System.Windows.Forms.Panel
    Me.label1 = New System.Windows.Forms.Label
    Me.panelGoButton = New System.Windows.Forms.Panel
    Me.buttonGo = New System.Windows.Forms.Button
    Me.toolBar = New System.Windows.Forms.ToolBar
    Me.toolBarButtonUp = New System.Windows.Forms.ToolBarButton
    Me.toolBarButtonSeparator1 = New System.Windows.Forms.ToolBarButton
    Me.toolBarButtonFolders = New System.Windows.Forms.ToolBarButton
    Me.toolBarButtonSearch = New System.Windows.Forms.ToolBarButton
    Me.panelToolBar.SuspendLayout()
    Me.panelAddressBar.SuspendLayout()
    Me.panel1.SuspendLayout()
    Me.panelGoButton.SuspendLayout()
    Me.SuspendLayout()
    '
    'imageListToolBar
    '
    Me.imageListToolBar.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
    Me.imageListToolBar.ImageSize = New System.Drawing.Size(20, 20)
    Me.imageListToolBar.ImageStream = CType(resources.GetObject("imageListToolBar.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.imageListToolBar.TransparentColor = System.Drawing.Color.White
    '
    'mainMenu
    '
    Me.mainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemFile, Me.menuItemView, Me.menuItemHelp})
    '
    'menuItemFile
    '
    Me.menuItemFile.Index = 0
    Me.menuItemFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemFileExit})
    Me.menuItemFile.Text = "&File"
    '
    'menuItemFileExit
    '
    Me.menuItemFileExit.Index = 0
    Me.menuItemFileExit.Text = "E&xit"
    '
    'menuItemView
    '
    Me.menuItemView.Index = 1
    Me.menuItemView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemViewFolders, Me.menuItemViewSearch, Me.menuItemViewSeparator, Me.menuItemViewIcons, Me.menuItemViewDetails})
    Me.menuItemView.Text = "&View"
    '
    'menuItemViewFolders
    '
    Me.menuItemViewFolders.Checked = True
    Me.menuItemViewFolders.Index = 0
    Me.menuItemViewFolders.Text = "&Folders"
    '
    'menuItemViewSearch
    '
    Me.menuItemViewSearch.Index = 1
    Me.menuItemViewSearch.Text = "&Search"
    '
    'menuItemViewSeparator
    '
    Me.menuItemViewSeparator.Index = 2
    Me.menuItemViewSeparator.Text = "-"
    '
    'menuItemViewIcons
    '
    Me.menuItemViewIcons.Index = 3
    Me.menuItemViewIcons.Text = "&Icons"
    '
    'menuItemViewDetails
    '
    Me.menuItemViewDetails.Checked = True
    Me.menuItemViewDetails.Index = 4
    Me.menuItemViewDetails.Text = "&Details"
    '
    'menuItemHelp
    '
    Me.menuItemHelp.Index = 2
    Me.menuItemHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemHelpAbout})
    Me.menuItemHelp.Text = "&Help"
    '
    'menuItemHelpAbout
    '
    Me.menuItemHelpAbout.Index = 0
    Me.menuItemHelpAbout.Text = "&About..."
    '
    'panelToolBar
    '
    Me.panelToolBar.Controls.Add(Me.panelAddressBar)
    Me.panelToolBar.Controls.Add(Me.toolBar)
    Me.panelToolBar.Dock = System.Windows.Forms.DockStyle.Top
    Me.panelToolBar.Location = New System.Drawing.Point(0, 0)
    Me.panelToolBar.Name = "panelToolBar"
    Me.panelToolBar.Size = New System.Drawing.Size(554, 59)
    Me.panelToolBar.TabIndex = 2
    '
    'panelAddressBar
    '
    Me.panelAddressBar.Controls.Add(Me.textBoxAddress)
    Me.panelAddressBar.Controls.Add(Me.panel1)
    Me.panelAddressBar.Controls.Add(Me.panelGoButton)
    Me.panelAddressBar.Dock = System.Windows.Forms.DockStyle.Top
    Me.panelAddressBar.Location = New System.Drawing.Point(0, 32)
    Me.panelAddressBar.Name = "panelAddressBar"
    Me.panelAddressBar.Size = New System.Drawing.Size(554, 29)
    Me.panelAddressBar.TabIndex = 1
    '
    'textBoxAddress
    '
    Me.textBoxAddress.Dock = System.Windows.Forms.DockStyle.Fill
    Me.textBoxAddress.Location = New System.Drawing.Point(74, 0)
    Me.textBoxAddress.Name = "textBoxAddress"
    Me.textBoxAddress.Size = New System.Drawing.Size(417, 22)
    Me.textBoxAddress.TabIndex = 4
    Me.textBoxAddress.Text = ""
    '
    'panel1
    '
    Me.panel1.Controls.Add(Me.label1)
    Me.panel1.Dock = System.Windows.Forms.DockStyle.Left
    Me.panel1.Location = New System.Drawing.Point(0, 0)
    Me.panel1.Name = "panel1"
    Me.panel1.Size = New System.Drawing.Size(74, 29)
    Me.panel1.TabIndex = 6
    '
    'label1
    '
    Me.label1.Location = New System.Drawing.Point(-1, -3)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(69, 29)
    Me.label1.TabIndex = 3
    Me.label1.Text = "Address:"
    Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'panelGoButton
    '
    Me.panelGoButton.Controls.Add(Me.buttonGo)
    Me.panelGoButton.Dock = System.Windows.Forms.DockStyle.Right
    Me.panelGoButton.Location = New System.Drawing.Point(491, 0)
    Me.panelGoButton.Name = "panelGoButton"
    Me.panelGoButton.Size = New System.Drawing.Size(63, 29)
    Me.panelGoButton.TabIndex = 5
    '
    'buttonGo
    '
    Me.buttonGo.Image = CType(resources.GetObject("buttonGo.Image"), System.Drawing.Image)
    Me.buttonGo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.buttonGo.Location = New System.Drawing.Point(3, 1)
    Me.buttonGo.Name = "buttonGo"
    Me.buttonGo.Size = New System.Drawing.Size(55, 23)
    Me.buttonGo.TabIndex = 0
    Me.buttonGo.Text = "Go"
    Me.buttonGo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'toolBar
    '
    Me.toolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
    Me.toolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.toolBarButtonUp, Me.toolBarButtonSeparator1, Me.toolBarButtonFolders, Me.toolBarButtonSearch})
    Me.toolBar.ButtonSize = New System.Drawing.Size(20, 20)
    Me.toolBar.DropDownArrows = True
    Me.toolBar.ImageList = Me.imageListToolBar
    Me.toolBar.Location = New System.Drawing.Point(0, 0)
    Me.toolBar.Name = "toolBar"
    Me.toolBar.ShowToolTips = True
    Me.toolBar.Size = New System.Drawing.Size(554, 32)
    Me.toolBar.TabIndex = 0
    '
    'toolBarButtonUp
    '
    Me.toolBarButtonUp.ImageIndex = 2
    Me.toolBarButtonUp.ToolTipText = "Up"
    '
    'toolBarButtonFolders
    '
    Me.toolBarButtonFolders.ImageIndex = 0
    Me.toolBarButtonFolders.Pushed = True
    Me.toolBarButtonFolders.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
    Me.toolBarButtonFolders.ToolTipText = "Folders"
    '
    'toolBarButtonSearch
    '
    Me.toolBarButtonSearch.ImageIndex = 1
    Me.toolBarButtonSearch.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
    Me.toolBarButtonSearch.ToolTipText = "Search"
    '
    'FormMenuToolBar
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
    Me.ClientSize = New System.Drawing.Size(554, 332)
    Me.Controls.Add(Me.panelToolBar)
    Me.Menu = Me.mainMenu
    Me.Name = "FormMenuToolBar"
    Me.Text = "FormMenuToolBar"
    Me.panelToolBar.ResumeLayout(False)
    Me.panelAddressBar.ResumeLayout(False)
    Me.panel1.ResumeLayout(False)
    Me.panelGoButton.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

#Region "Event Handlers"

  Private Sub menuItemFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuItemFileExit.Click
    Application.Exit()
  End Sub

  Private Sub menuItemViewFolders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuItemViewFolders.Click
    SelectFolders()
  End Sub

  Private Sub menuItemViewSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuItemViewSearch.Click
    SelectSearch()
  End Sub

  Private Sub menuItemViewIcons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuItemViewIcons.Click
    menuItemViewIcons.Checked = True
    menuItemViewDetails.Checked = False
    FireViewIcons()
  End Sub

  Private Sub menuItemViewDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuItemViewDetails.Click
    menuItemViewIcons.Checked = False
    menuItemViewDetails.Checked = True
    FireViewDetails()
  End Sub

  Private Sub menuItemHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuItemHelpAbout.Click
    Dim formAbout As New FormAbout
    formAbout.ShowDialog()
  End Sub

  Private Sub toolBar_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles toolBar.ButtonClick
    If e.Button Is toolBarButtonUp Then
      SelectFolders()
      FireUpSelected()
    ElseIf e.Button Is toolBarButtonFolders Then
      SelectFolders()
    ElseIf e.Button Is toolBarButtonSearch Then
      SelectSearch()
    End If
  End Sub

  Private Sub buttonGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonGo.Click
    FireAddressChanged(textBoxAddress.Text)
  End Sub

  Private Sub textBoxAddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles textBoxAddress.KeyPress
    If e.KeyChar = vbCr Then
      e.Handled = True  ' to prevent Windows from beeping
      FireAddressChanged(textBoxAddress.Text)
    End If
  End Sub

#End Region

#Region "Events"
  Public Event OnViewFolders()
  Sub FireViewFolders()
    RaiseEvent OnViewFolders()
  End Sub

  Public Event OnViewSearch()
  Sub FireViewSearch()
    RaiseEvent OnViewSearch()
  End Sub

  Public Event OnViewIcons()
  Sub FireViewIcons()
    RaiseEvent OnViewIcons()
  End Sub

  Public Event OnViewDetails()
  Sub FireViewDetails()
    RaiseEvent OnViewDetails()
  End Sub

  Public Event OnUpSelected()
  Sub FireUpSelected()
    RaiseEvent OnUpSelected()
  End Sub

  Public Event OnAddressChanged(ByVal theNewAddress As String)
  Sub FireAddressChanged(ByVal theNewAddress As String)
    RaiseEvent OnAddressChanged(theNewAddress)
  End Sub
#End Region

End Class
