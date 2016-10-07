Public Class FormMain
  Inherits System.Windows.Forms.Form

  Private _navigatorFolders As NavigatorFolders

  Private Sub ShowFolderPath(ByVal theFolderPath As String)
    labelFolderPath.Text = theFolderPath
  End Sub

  Private Sub ShowMessage(ByVal theMessage As String)
    labelMessages.Text = theMessage
  End Sub

  Private Sub UpdateProgress(ByVal thePercentComplete As Integer)
    progressBar1.Value = thePercentComplete
    progressBar1.Update()
  End Sub

  Private Sub textBoxFolderToSelect_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles textBoxFolderToSelect.KeyPress
    If e.KeyChar <> vbCr Then Return
    e.Handled = True  ' to prevent the TextBox from beeping
    _navigatorFolders.SelectFolder(textBoxFolderToSelect.Text)
  End Sub

  Private Sub buttonPopulate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonPopulate.Click
    _navigatorFolders.Populate("C:\")
  End Sub

  Private Sub buttonSelectParentFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonSelectParentFolder.Click
    _navigatorFolders.SelectParentFolder()
  End Sub

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    _navigatorFolders = New NavigatorFolders
    panelFolders.Controls.Add(_navigatorFolders)
    _navigatorFolders.Dock = DockStyle.Fill

    AddHandler _navigatorFolders.OnFolderChanged, AddressOf ShowFolderPath
    AddHandler _navigatorFolders.OnMessage, AddressOf ShowMessage
    AddHandler _navigatorFolders.OnProgress, AddressOf UpdateProgress

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
  Friend WithEvents buttonPopulate As System.Windows.Forms.Button
  Friend WithEvents buttonSelectParentFolder As System.Windows.Forms.Button
  Friend WithEvents textBoxFolderToSelect As System.Windows.Forms.TextBox
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents labelFolderPath As System.Windows.Forms.Label
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents panelStatusBar As System.Windows.Forms.Panel
  Friend WithEvents labelMessages As System.Windows.Forms.Label
  Friend WithEvents progressBar1 As System.Windows.Forms.ProgressBar
  Friend WithEvents panelFolders As System.Windows.Forms.Panel
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.panelTop = New System.Windows.Forms.Panel
    Me.buttonPopulate = New System.Windows.Forms.Button
    Me.buttonSelectParentFolder = New System.Windows.Forms.Button
    Me.textBoxFolderToSelect = New System.Windows.Forms.TextBox
    Me.label2 = New System.Windows.Forms.Label
    Me.labelFolderPath = New System.Windows.Forms.Label
    Me.label1 = New System.Windows.Forms.Label
    Me.panelStatusBar = New System.Windows.Forms.Panel
    Me.labelMessages = New System.Windows.Forms.Label
    Me.progressBar1 = New System.Windows.Forms.ProgressBar
    Me.panelFolders = New System.Windows.Forms.Panel
    Me.panelTop.SuspendLayout()
    Me.panelStatusBar.SuspendLayout()
    Me.SuspendLayout()
    '
    'panelTop
    '
    Me.panelTop.Controls.Add(Me.buttonPopulate)
    Me.panelTop.Controls.Add(Me.buttonSelectParentFolder)
    Me.panelTop.Controls.Add(Me.textBoxFolderToSelect)
    Me.panelTop.Controls.Add(Me.label2)
    Me.panelTop.Controls.Add(Me.labelFolderPath)
    Me.panelTop.Controls.Add(Me.label1)
    Me.panelTop.Dock = System.Windows.Forms.DockStyle.Top
    Me.panelTop.Location = New System.Drawing.Point(0, 0)
    Me.panelTop.Name = "panelTop"
    Me.panelTop.Size = New System.Drawing.Size(512, 102)
    Me.panelTop.TabIndex = 1
    '
    'buttonPopulate
    '
    Me.buttonPopulate.Location = New System.Drawing.Point(34, 66)
    Me.buttonPopulate.Name = "buttonPopulate"
    Me.buttonPopulate.Size = New System.Drawing.Size(75, 26)
    Me.buttonPopulate.TabIndex = 5
    Me.buttonPopulate.Text = "Populate"
    '
    'buttonSelectParentFolder
    '
    Me.buttonSelectParentFolder.Location = New System.Drawing.Point(125, 64)
    Me.buttonSelectParentFolder.Name = "buttonSelectParentFolder"
    Me.buttonSelectParentFolder.Size = New System.Drawing.Size(141, 26)
    Me.buttonSelectParentFolder.TabIndex = 4
    Me.buttonSelectParentFolder.Text = "Select Parent Folder"
    '
    'textBoxFolderToSelect
    '
    Me.textBoxFolderToSelect.AcceptsReturn = True
    Me.textBoxFolderToSelect.Location = New System.Drawing.Point(116, 36)
    Me.textBoxFolderToSelect.Name = "textBoxFolderToSelect"
    Me.textBoxFolderToSelect.Size = New System.Drawing.Size(374, 22)
    Me.textBoxFolderToSelect.TabIndex = 3
    Me.textBoxFolderToSelect.Text = ""
    '
    'label2
    '
    Me.label2.AutoSize = True
    Me.label2.Location = New System.Drawing.Point(12, 39)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(107, 18)
    Me.label2.TabIndex = 2
    Me.label2.Text = "Folder To Select:"
    '
    'labelFolderPath
    '
    Me.labelFolderPath.AutoSize = True
    Me.labelFolderPath.Location = New System.Drawing.Point(88, 14)
    Me.labelFolderPath.Name = "labelFolderPath"
    Me.labelFolderPath.Size = New System.Drawing.Size(50, 18)
    Me.labelFolderPath.TabIndex = 1
    Me.labelFolderPath.Text = "<none>"
    '
    'label1
    '
    Me.label1.AutoSize = True
    Me.label1.Location = New System.Drawing.Point(11, 14)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(78, 18)
    Me.label1.TabIndex = 0
    Me.label1.Text = "Folder Path:"
    '
    'panelStatusBar
    '
    Me.panelStatusBar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.panelStatusBar.Controls.Add(Me.labelMessages)
    Me.panelStatusBar.Controls.Add(Me.progressBar1)
    Me.panelStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.panelStatusBar.Location = New System.Drawing.Point(0, 285)
    Me.panelStatusBar.Name = "panelStatusBar"
    Me.panelStatusBar.Size = New System.Drawing.Size(512, 21)
    Me.panelStatusBar.TabIndex = 4
    '
    'labelMessages
    '
    Me.labelMessages.Dock = System.Windows.Forms.DockStyle.Fill
    Me.labelMessages.Location = New System.Drawing.Point(0, 0)
    Me.labelMessages.Name = "labelMessages"
    Me.labelMessages.Size = New System.Drawing.Size(408, 17)
    Me.labelMessages.TabIndex = 2
    Me.labelMessages.Text = "Messages"
    Me.labelMessages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'progressBar1
    '
    Me.progressBar1.Dock = System.Windows.Forms.DockStyle.Right
    Me.progressBar1.Location = New System.Drawing.Point(408, 0)
    Me.progressBar1.Name = "progressBar1"
    Me.progressBar1.Size = New System.Drawing.Size(100, 17)
    Me.progressBar1.TabIndex = 3
    '
    'panelFolders
    '
    Me.panelFolders.Dock = System.Windows.Forms.DockStyle.Fill
    Me.panelFolders.Location = New System.Drawing.Point(0, 102)
    Me.panelFolders.Name = "panelFolders"
    Me.panelFolders.Size = New System.Drawing.Size(512, 183)
    Me.panelFolders.TabIndex = 5
    '
    'FormMain
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
    Me.ClientSize = New System.Drawing.Size(512, 306)
    Me.Controls.Add(Me.panelFolders)
    Me.Controls.Add(Me.panelStatusBar)
    Me.Controls.Add(Me.panelTop)
    Me.Name = "FormMain"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Test Fixture NavigatorFolders"
    Me.panelTop.ResumeLayout(False)
    Me.panelStatusBar.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

End Class
