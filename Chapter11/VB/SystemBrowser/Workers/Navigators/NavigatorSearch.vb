Imports System.IO

Public Class NavigatorSearch
  Inherits System.Windows.Forms.UserControl

  Private _itemsFound As Integer
  Private _searching As Boolean
  Private _stopRequested As Boolean

  Public Sub Start()
    Cursor = Cursors.WaitCursor
    _itemsFound = 0
    buttonSearch.Text = "Stop"
    _stopRequested = False
    _searching = True
    DoSearch(textBoxLookIn.Text)
    _searching = False
    SearchFinished()
    Cursor = Cursors.Default
  End Sub

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    'Add any initialization after the InitializeComponent() call

  End Sub

  'UserControl overrides dispose to clean up the component list.
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
  Friend WithEvents buttonBrowse As System.Windows.Forms.Button
  Friend WithEvents textBoxLookIn As System.Windows.Forms.TextBox
  Friend WithEvents label3 As System.Windows.Forms.Label
  Friend WithEvents buttonSearch As System.Windows.Forms.Button
  Friend WithEvents textBoxFilename As System.Windows.Forms.TextBox
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents toolTip1 As System.Windows.Forms.ToolTip
  Friend WithEvents folderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Me.buttonBrowse = New System.Windows.Forms.Button
    Me.textBoxLookIn = New System.Windows.Forms.TextBox
    Me.label3 = New System.Windows.Forms.Label
    Me.buttonSearch = New System.Windows.Forms.Button
    Me.textBoxFilename = New System.Windows.Forms.TextBox
    Me.label2 = New System.Windows.Forms.Label
    Me.label1 = New System.Windows.Forms.Label
    Me.toolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.folderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
    Me.SuspendLayout()
    '
    'buttonBrowse
    '
    Me.buttonBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.buttonBrowse.BackColor = System.Drawing.SystemColors.Control
    Me.buttonBrowse.Location = New System.Drawing.Point(187, 123)
    Me.buttonBrowse.Name = "buttonBrowse"
    Me.buttonBrowse.Size = New System.Drawing.Size(25, 23)
    Me.buttonBrowse.TabIndex = 13
    Me.buttonBrowse.Text = "..."
    '
    'textBoxLookIn
    '
    Me.textBoxLookIn.AcceptsReturn = True
    Me.textBoxLookIn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.textBoxLookIn.Location = New System.Drawing.Point(9, 123)
    Me.textBoxLookIn.Name = "textBoxLookIn"
    Me.textBoxLookIn.Size = New System.Drawing.Size(171, 22)
    Me.textBoxLookIn.TabIndex = 12
    Me.textBoxLookIn.Text = "c:\"
    '
    'label3
    '
    Me.label3.AutoSize = True
    Me.label3.Location = New System.Drawing.Point(13, 105)
    Me.label3.Name = "label3"
    Me.label3.Size = New System.Drawing.Size(48, 18)
    Me.label3.TabIndex = 11
    Me.label3.Text = "Look in"
    '
    'buttonSearch
    '
    Me.buttonSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.buttonSearch.BackColor = System.Drawing.SystemColors.Control
    Me.buttonSearch.Cursor = System.Windows.Forms.Cursors.Arrow
    Me.buttonSearch.Location = New System.Drawing.Point(127, 183)
    Me.buttonSearch.Name = "buttonSearch"
    Me.buttonSearch.TabIndex = 10
    Me.buttonSearch.Text = "Search"
    '
    'textBoxFilename
    '
    Me.textBoxFilename.AcceptsReturn = True
    Me.textBoxFilename.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.textBoxFilename.Location = New System.Drawing.Point(9, 61)
    Me.textBoxFilename.Name = "textBoxFilename"
    Me.textBoxFilename.Size = New System.Drawing.Size(193, 22)
    Me.textBoxFilename.TabIndex = 9
    Me.textBoxFilename.Text = ""
    '
    'label2
    '
    Me.label2.AutoSize = True
    Me.label2.Location = New System.Drawing.Point(13, 43)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(153, 18)
    Me.label2.TabIndex = 8
    Me.label2.Text = "All or part of the filename"
    '
    'label1
    '
    Me.label1.AutoSize = True
    Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label1.Location = New System.Drawing.Point(11, 15)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(170, 19)
    Me.label1.TabIndex = 7
    Me.label1.Text = "Enter your search criteria"
    '
    'NavigatorSearch
    '
    Me.BackColor = System.Drawing.Color.Honeydew
    Me.Controls.Add(Me.buttonBrowse)
    Me.Controls.Add(Me.textBoxLookIn)
    Me.Controls.Add(Me.label3)
    Me.Controls.Add(Me.buttonSearch)
    Me.Controls.Add(Me.textBoxFilename)
    Me.Controls.Add(Me.label2)
    Me.Controls.Add(Me.label1)
    Me.Name = "NavigatorSearch"
    Me.Size = New System.Drawing.Size(213, 315)
    Me.ResumeLayout(False)

  End Sub

#End Region

  ' recursive method
  Sub DoSearch(ByVal theFolder As String)
    If Not Directory.Exists(theFolder) Then Return

    ' search this folder
    Dim pattern As String = textBoxFilename.Text
    For Each filePath As String In Directory.GetFiles(theFolder, pattern)
      _itemsFound += 1
      FireItemFound(filePath, _itemsFound)
    Next

    ' search all subdirectories
    For Each dir As String In Directory.GetDirectories(theFolder)
      DoSearch(dir)
      If _stopRequested Then
        FireMessage(String.Format("{0} items found", _itemsFound))
        Return
      End If
    Next
  End Sub

  Sub SearchFinished()
    buttonSearch.Text = "Search"
    Cursor = Cursors.Default
  End Sub

  Sub StartSearch(ByVal theFolderPath As String)
    FireSearchRequested(theFolderPath)
    Cursor = Cursors.WaitCursor
  End Sub

  Sub StopSearch()
    _stopRequested = True
    Cursor = Cursors.Default
  End Sub

#Region "Event Handlers"
  Private Sub buttonSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonSearch.Click
    If Not _searching Then
      StartSearch(textBoxLookIn.Text)
    Else
      StopSearch()
    End If
  End Sub

  Private Sub buttonBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonBrowse.Click
    If folderBrowserDialog1.ShowDialog() = DialogResult.OK Then
      textBoxLookIn.Text = folderBrowserDialog1.SelectedPath
    End If
  End Sub

#End Region

#Region "Events"
  Public Event OnSearchRequested(ByVal theFolderPath As String)
  Sub FireSearchRequested(ByVal theFolderPath As String)
    RaiseEvent OnSearchRequested(theFolderPath)
  End Sub

  Public Event OnItemFound(ByVal thePath As String, ByVal theCurrentCount As Integer)
  Sub FireItemFound(ByVal thePath As String, ByVal theCurrentCount As Integer)
    RaiseEvent OnItemFound(thePath, theCurrentCount)
  End Sub

  Public Event OnMessage(ByVal theMessage As String)
  Sub FireMessage(ByVal theMessage As String)
    RaiseEvent OnMessage(theMessage)
  End Sub
#End Region

End Class
