Public Class FormMain
  Inherits System.Windows.Forms.Form

#Region "UI Children"
  Public WriteOnly Property Toolbar() As Control
    Set(ByVal Value As Control)
      Value.Dock = DockStyle.Fill
      panelToolBar.Controls.Add(Value)
    End Set
  End Property

  Public WriteOnly Property Statusbar() As Control
    Set(ByVal Value As Control)
      Value.Dock = DockStyle.Fill
      panelStatusBar.Controls.Add(Value)
    End Set
  End Property

  Private _navigatorFolders As Control
  Public WriteOnly Property NavigatorFolders() As Control
    Set(ByVal Value As Control)
      _navigatorFolders = Value
    End Set
  End Property

  Private _navigatorSearch As Control
  Public WriteOnly Property NavigatorSearch() As Control
    Set(ByVal Value As Control)
      _navigatorSearch = Value
    End Set
  End Property

  Private _contentFolders As Control
  Public WriteOnly Property ContentFolders() As Control
    Set(ByVal Value As Control)
      _contentFolders = Value
    End Set
  End Property

  Private _contentSearch As Control
  Public WriteOnly Property ContentSearch() As Control
    Set(ByVal Value As Control)
      _contentSearch = Value
    End Set
  End Property

#End Region

  Public Sub ShowFolders()
    PanelNavigator.Controls.Clear()
    PanelNavigator.Controls.Add(_navigatorFolders)
    _navigatorFolders.Dock = DockStyle.Fill

    PanelContent.Controls.Clear()
    PanelContent.Controls.Add(_contentFolders)
    _contentFolders.Dock = DockStyle.Fill
  End Sub

  Public Sub ShowSearch()
    PanelNavigator.Controls.Clear()
    PanelNavigator.Controls.Add(_navigatorSearch)
    _navigatorSearch.Dock = DockStyle.Fill

    PanelContent.Controls.Clear()
    PanelContent.Controls.Add(_contentSearch)
    _contentSearch.Dock = DockStyle.Fill
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
  Friend WithEvents PanelToolBar As System.Windows.Forms.Panel
  Friend WithEvents PanelStatusBar As System.Windows.Forms.Panel
  Friend WithEvents PanelNavigator As System.Windows.Forms.Panel
  Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
  Friend WithEvents PanelContent As System.Windows.Forms.Panel
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FormMain))
    Me.PanelToolBar = New System.Windows.Forms.Panel
    Me.PanelStatusBar = New System.Windows.Forms.Panel
    Me.PanelNavigator = New System.Windows.Forms.Panel
    Me.Splitter1 = New System.Windows.Forms.Splitter
    Me.PanelContent = New System.Windows.Forms.Panel
    Me.SuspendLayout()
    '
    'PanelToolBar
    '
    Me.PanelToolBar.Dock = System.Windows.Forms.DockStyle.Top
    Me.PanelToolBar.Location = New System.Drawing.Point(0, 0)
    Me.PanelToolBar.Name = "PanelToolBar"
    Me.PanelToolBar.Size = New System.Drawing.Size(770, 60)
    Me.PanelToolBar.TabIndex = 1
    '
    'PanelStatusBar
    '
    Me.PanelStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.PanelStatusBar.Location = New System.Drawing.Point(0, 398)
    Me.PanelStatusBar.Name = "PanelStatusBar"
    Me.PanelStatusBar.Size = New System.Drawing.Size(770, 24)
    Me.PanelStatusBar.TabIndex = 2
    '
    'PanelNavigator
    '
    Me.PanelNavigator.Dock = System.Windows.Forms.DockStyle.Left
    Me.PanelNavigator.Location = New System.Drawing.Point(0, 60)
    Me.PanelNavigator.Name = "PanelNavigator"
    Me.PanelNavigator.Size = New System.Drawing.Size(222, 338)
    Me.PanelNavigator.TabIndex = 3
    '
    'Splitter1
    '
    Me.Splitter1.Location = New System.Drawing.Point(222, 60)
    Me.Splitter1.MinSize = 100
    Me.Splitter1.Name = "Splitter1"
    Me.Splitter1.Size = New System.Drawing.Size(6, 338)
    Me.Splitter1.TabIndex = 4
    Me.Splitter1.TabStop = False
    '
    'PanelContent
    '
    Me.PanelContent.Dock = System.Windows.Forms.DockStyle.Fill
    Me.PanelContent.Location = New System.Drawing.Point(228, 60)
    Me.PanelContent.Name = "PanelContent"
    Me.PanelContent.Size = New System.Drawing.Size(542, 338)
    Me.PanelContent.TabIndex = 5
    '
    'FormMain
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
    Me.ClientSize = New System.Drawing.Size(770, 422)
    Me.Controls.Add(Me.PanelContent)
    Me.Controls.Add(Me.Splitter1)
    Me.Controls.Add(Me.PanelNavigator)
    Me.Controls.Add(Me.PanelStatusBar)
    Me.Controls.Add(Me.PanelToolBar)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Name = "FormMain"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "SystemBrowser"
    Me.ResumeLayout(False)

  End Sub

#End Region

End Class
