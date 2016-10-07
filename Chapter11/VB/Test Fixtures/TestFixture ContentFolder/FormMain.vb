Public Class FormMain
  Inherits System.Windows.Forms.Form

  Private _contentFileList As ContentFileList

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    _contentFileList = New ContentFileList

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    AddHandler _contentFileList.OnFolderDoubleClicked, AddressOf ShowFolderPath
    AddHandler _contentFileList.OnMessage, AddressOf ShowMessage
    panelContent.Controls.Add(_contentFileList)
    _contentFileList.Dock = DockStyle.Fill
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
  Friend WithEvents panelTop As System.Windows.Forms.Panel
  Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents radioButtonShowDetails As System.Windows.Forms.RadioButton
  Friend WithEvents radioButtonShowIcons As System.Windows.Forms.RadioButton
  Friend WithEvents labelFolderDoubleClicked As System.Windows.Forms.Label
  Friend WithEvents label3 As System.Windows.Forms.Label
  Friend WithEvents buttonAdd As System.Windows.Forms.Button
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents buttonPopulate As System.Windows.Forms.Button
  Friend WithEvents textBoxFolder As System.Windows.Forms.TextBox
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents textBoxFileToAdd As System.Windows.Forms.TextBox
  Friend WithEvents labelMessages As System.Windows.Forms.Label
  Friend WithEvents panelContent As System.Windows.Forms.Panel
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Me.toolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.buttonAdd = New System.Windows.Forms.Button
    Me.buttonPopulate = New System.Windows.Forms.Button
    Me.panelTop = New System.Windows.Forms.Panel
    Me.groupBox1 = New System.Windows.Forms.GroupBox
    Me.radioButtonShowDetails = New System.Windows.Forms.RadioButton
    Me.radioButtonShowIcons = New System.Windows.Forms.RadioButton
    Me.labelFolderDoubleClicked = New System.Windows.Forms.Label
    Me.label3 = New System.Windows.Forms.Label
    Me.label2 = New System.Windows.Forms.Label
    Me.textBoxFolder = New System.Windows.Forms.TextBox
    Me.label1 = New System.Windows.Forms.Label
    Me.textBoxFileToAdd = New System.Windows.Forms.TextBox
    Me.labelMessages = New System.Windows.Forms.Label
    Me.panelContent = New System.Windows.Forms.Panel
    Me.panelTop.SuspendLayout()
    Me.groupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'buttonAdd
    '
    Me.buttonAdd.Location = New System.Drawing.Point(478, 38)
    Me.buttonAdd.Name = "buttonAdd"
    Me.buttonAdd.Size = New System.Drawing.Size(90, 27)
    Me.buttonAdd.TabIndex = 4
    Me.buttonAdd.Text = "Add"
    Me.toolTip1.SetToolTip(Me.buttonAdd, "Add the file to the end of the list")
    '
    'buttonPopulate
    '
    Me.buttonPopulate.Location = New System.Drawing.Point(476, 7)
    Me.buttonPopulate.Name = "buttonPopulate"
    Me.buttonPopulate.Size = New System.Drawing.Size(90, 26)
    Me.buttonPopulate.TabIndex = 2
    Me.buttonPopulate.Text = "Populate"
    Me.toolTip1.SetToolTip(Me.buttonPopulate, "Populate the listview with files from the selected folder")
    '
    'panelTop
    '
    Me.panelTop.Controls.Add(Me.groupBox1)
    Me.panelTop.Controls.Add(Me.labelFolderDoubleClicked)
    Me.panelTop.Controls.Add(Me.label3)
    Me.panelTop.Controls.Add(Me.buttonAdd)
    Me.panelTop.Controls.Add(Me.label2)
    Me.panelTop.Controls.Add(Me.buttonPopulate)
    Me.panelTop.Controls.Add(Me.textBoxFolder)
    Me.panelTop.Controls.Add(Me.label1)
    Me.panelTop.Controls.Add(Me.textBoxFileToAdd)
    Me.panelTop.Dock = System.Windows.Forms.DockStyle.Top
    Me.panelTop.Location = New System.Drawing.Point(0, 0)
    Me.panelTop.Name = "panelTop"
    Me.panelTop.Size = New System.Drawing.Size(585, 143)
    Me.panelTop.TabIndex = 1
    '
    'groupBox1
    '
    Me.groupBox1.Controls.Add(Me.radioButtonShowDetails)
    Me.groupBox1.Controls.Add(Me.radioButtonShowIcons)
    Me.groupBox1.Location = New System.Drawing.Point(19, 67)
    Me.groupBox1.Name = "groupBox1"
    Me.groupBox1.Size = New System.Drawing.Size(442, 42)
    Me.groupBox1.TabIndex = 7
    Me.groupBox1.TabStop = False
    Me.groupBox1.Text = "Mode"
    '
    'radioButtonShowDetails
    '
    Me.radioButtonShowDetails.Checked = True
    Me.radioButtonShowDetails.Location = New System.Drawing.Point(238, 13)
    Me.radioButtonShowDetails.Name = "radioButtonShowDetails"
    Me.radioButtonShowDetails.TabIndex = 1
    Me.radioButtonShowDetails.TabStop = True
    Me.radioButtonShowDetails.Text = "Show Details"
    '
    'radioButtonShowIcons
    '
    Me.radioButtonShowIcons.Location = New System.Drawing.Point(64, 12)
    Me.radioButtonShowIcons.Name = "radioButtonShowIcons"
    Me.radioButtonShowIcons.TabIndex = 0
    Me.radioButtonShowIcons.Text = "Show Icons"
    '
    'labelFolderDoubleClicked
    '
    Me.labelFolderDoubleClicked.AutoSize = True
    Me.labelFolderDoubleClicked.Location = New System.Drawing.Point(146, 114)
    Me.labelFolderDoubleClicked.Name = "labelFolderDoubleClicked"
    Me.labelFolderDoubleClicked.Size = New System.Drawing.Size(50, 18)
    Me.labelFolderDoubleClicked.TabIndex = 6
    Me.labelFolderDoubleClicked.Text = "<none>"
    '
    'label3
    '
    Me.label3.AutoSize = True
    Me.label3.Location = New System.Drawing.Point(9, 114)
    Me.label3.Name = "label3"
    Me.label3.Size = New System.Drawing.Size(141, 18)
    Me.label3.TabIndex = 5
    Me.label3.Text = "Folder Double-Clicked:"
    '
    'label2
    '
    Me.label2.AutoSize = True
    Me.label2.Location = New System.Drawing.Point(8, 38)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(72, 18)
    Me.label2.TabIndex = 3
    Me.label2.Text = "File to Add:"
    '
    'textBoxFolder
    '
    Me.textBoxFolder.Location = New System.Drawing.Point(82, 7)
    Me.textBoxFolder.Name = "textBoxFolder"
    Me.textBoxFolder.Size = New System.Drawing.Size(384, 22)
    Me.textBoxFolder.TabIndex = 1
    Me.textBoxFolder.Text = "c:\"
    '
    'label1
    '
    Me.label1.AutoSize = True
    Me.label1.Location = New System.Drawing.Point(34, 9)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(47, 18)
    Me.label1.TabIndex = 0
    Me.label1.Text = "Folder:"
    '
    'textBoxFileToAdd
    '
    Me.textBoxFileToAdd.Location = New System.Drawing.Point(80, 37)
    Me.textBoxFileToAdd.Name = "textBoxFileToAdd"
    Me.textBoxFileToAdd.Size = New System.Drawing.Size(384, 22)
    Me.textBoxFileToAdd.TabIndex = 2
    Me.textBoxFileToAdd.Text = "c:\config.sys"
    '
    'labelMessages
    '
    Me.labelMessages.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.labelMessages.Location = New System.Drawing.Point(0, 279)
    Me.labelMessages.Name = "labelMessages"
    Me.labelMessages.Size = New System.Drawing.Size(585, 27)
    Me.labelMessages.TabIndex = 3
    Me.labelMessages.Text = "Messages"
    Me.labelMessages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'panelContent
    '
    Me.panelContent.Dock = System.Windows.Forms.DockStyle.Fill
    Me.panelContent.Location = New System.Drawing.Point(0, 143)
    Me.panelContent.Name = "panelContent"
    Me.panelContent.Size = New System.Drawing.Size(585, 136)
    Me.panelContent.TabIndex = 4
    '
    'FormMain
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
    Me.ClientSize = New System.Drawing.Size(585, 306)
    Me.Controls.Add(Me.panelContent)
    Me.Controls.Add(Me.labelMessages)
    Me.Controls.Add(Me.panelTop)
    Me.Name = "FormMain"
    Me.Text = "Form1"
    Me.panelTop.ResumeLayout(False)
    Me.groupBox1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Sub ShowFolderPath(ByVal thePath As String)
    labelFolderDoubleClicked.Text = thePath
  End Sub

  Private Sub ShowMessage(ByVal theMessage As String)
    labelMessages.Text = theMessage
  End Sub

  Private Sub textBoxFolder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles textBoxFolder.KeyPress
    If e.KeyChar = vbCr Then  ' the Enter key
      _contentFileList.Populate(textBoxFolder.Text)
      e.Handled = True ' to prevent TextBox from beeping
    End If
  End Sub

  Private Sub buttonPopulate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonPopulate.Click
    _contentFileList.Populate(textBoxFolder.Text)
  End Sub

  Private Sub buttonAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonAdd.Click
    _contentFileList.Add(textBoxFileToAdd.Text)
  End Sub

  Private Sub radioButtonShowIcons_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioButtonShowIcons.CheckedChanged
    SetMode()
  End Sub

  Private Sub radioButtonShowDetails_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioButtonShowDetails.CheckedChanged
    SetMode()
  End Sub

  Sub SetMode()
    If radioButtonShowIcons.Checked Then
      _contentFileList.ShowIcons()
    Else
      _contentFileList.ShowDetails()
    End If
  End Sub
End Class
