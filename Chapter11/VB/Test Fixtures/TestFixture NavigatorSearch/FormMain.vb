Public Class FormMain
  Inherits System.Windows.Forms.Form

  Private _coordinatorSearch As CoordinatorSearch
  Private _navigatorSearch As NavigatorSearch

  Private Sub ShowItemFound(ByVal thePath As String, ByVal theCurrentCount As Integer)
    listBoxItemsFound.Items.Add(thePath)
  End Sub

  Private Sub ShowMessage(ByVal theMessage As String)
    labelMessages.Text = theMessage
  End Sub

  Private Sub ClearList()
    listBoxItemsFound.Items.Clear()
  End Sub

  Private Sub AddToList(ByVal theText As String, ByVal theCount As Integer)
    listBoxItemsFound.Items.Add(theText)
  End Sub

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    _navigatorSearch = New NavigatorSearch
    _coordinatorSearch = New CoordinatorSearch(Me)

    AddHandler _coordinatorSearch.OnSearchRequested, AddressOf ClearList
    _coordinatorSearch.OnSearchStart = AddressOf _navigatorSearch.Start
    AddHandler _coordinatorSearch.OnItemFound, AddressOf AddToList
    AddHandler _coordinatorSearch.OnMessage, AddressOf ShowMessage

    AddHandler _navigatorSearch.OnSearchRequested, AddressOf _coordinatorSearch.StartSearch
    AddHandler _navigatorSearch.OnItemFound, AddressOf _coordinatorSearch.ItemFound
    AddHandler _navigatorSearch.OnMessage, AddressOf _coordinatorSearch.FireMessage

    panelSearch.Controls.Add(_navigatorSearch)
    _navigatorSearch.Dock = DockStyle.Fill

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
  Friend WithEvents panelTop As System.Windows.Forms.Panel
  Friend WithEvents listBoxItemsFound As System.Windows.Forms.ListBox
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents labelMessages As System.Windows.Forms.Label
  Friend WithEvents panelSearch As System.Windows.Forms.Panel
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.panelTop = New System.Windows.Forms.Panel
    Me.listBoxItemsFound = New System.Windows.Forms.ListBox
    Me.label1 = New System.Windows.Forms.Label
    Me.labelMessages = New System.Windows.Forms.Label
    Me.panelSearch = New System.Windows.Forms.Panel
    Me.panelTop.SuspendLayout()
    Me.SuspendLayout()
    '
    'panelTop
    '
    Me.panelTop.Controls.Add(Me.listBoxItemsFound)
    Me.panelTop.Controls.Add(Me.label1)
    Me.panelTop.Dock = System.Windows.Forms.DockStyle.Top
    Me.panelTop.Location = New System.Drawing.Point(0, 0)
    Me.panelTop.Name = "panelTop"
    Me.panelTop.Size = New System.Drawing.Size(393, 88)
    Me.panelTop.TabIndex = 1
    '
    'listBoxItemsFound
    '
    Me.listBoxItemsFound.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.listBoxItemsFound.ItemHeight = 16
    Me.listBoxItemsFound.Location = New System.Drawing.Point(92, 0)
    Me.listBoxItemsFound.Name = "listBoxItemsFound"
    Me.listBoxItemsFound.Size = New System.Drawing.Size(301, 68)
    Me.listBoxItemsFound.TabIndex = 1
    '
    'label1
    '
    Me.label1.AutoSize = True
    Me.label1.Location = New System.Drawing.Point(11, 8)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(83, 18)
    Me.label1.TabIndex = 0
    Me.label1.Text = "Items Found:"
    '
    'labelMessages
    '
    Me.labelMessages.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.labelMessages.Location = New System.Drawing.Point(0, 337)
    Me.labelMessages.Name = "labelMessages"
    Me.labelMessages.Size = New System.Drawing.Size(393, 27)
    Me.labelMessages.TabIndex = 3
    Me.labelMessages.Text = "Messages"
    Me.labelMessages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'panelSearch
    '
    Me.panelSearch.Dock = System.Windows.Forms.DockStyle.Fill
    Me.panelSearch.Location = New System.Drawing.Point(0, 88)
    Me.panelSearch.Name = "panelSearch"
    Me.panelSearch.Size = New System.Drawing.Size(393, 249)
    Me.panelSearch.TabIndex = 4
    '
    'FormMain
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
    Me.ClientSize = New System.Drawing.Size(393, 364)
    Me.Controls.Add(Me.panelSearch)
    Me.Controls.Add(Me.labelMessages)
    Me.Controls.Add(Me.panelTop)
    Me.Name = "FormMain"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Test Fixture for NavigatorSearch"
    Me.panelTop.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

End Class
