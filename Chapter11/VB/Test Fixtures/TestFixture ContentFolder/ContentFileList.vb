Imports System.IO

Public Class ContentFileList
  Inherits System.Windows.Forms.UserControl

  ' ImageList indexes, for images placed next to file and folder names
  Const ImageFolder As Integer = 0
  Const ImageFile As Integer = 1

  ' show a list of all the folders and files in a folder
  Public Sub Populate(ByVal theFolder As String)
    listViewFiles.BeginUpdate()
    listViewFiles.Items.Clear()

    ' first the subdirectories
    For Each dir As String In Directory.GetDirectories(theFolder)
      Dim name As String = Path.GetFileName(dir)
      Dim item As ListViewItem = listViewFiles.Items.Add(name, ImageFolder)
      item.Tag = dir
    Next

    ' then the files
    For Each filePath As String In Directory.GetFiles(theFolder)
      Add(filePath)
    Next

    listViewFiles.EndUpdate()
  End Sub

  ' add a file to the list
  Public Sub Add(ByVal theFilePath As String)
    If Not File.Exists(theFilePath) Then Return
    Dim name As String = Path.GetFileName(theFilePath)
    Dim item As New ListViewItem(name, ImageFile)
    item.Tag = theFilePath
    Dim fi As New FileInfo(theFilePath)
    Dim length As Long = CLng(fi.Length / 1024)
    If length < 1 Then
      length = 1
    End If
    Dim size As String = String.Format("{0:#,##0} KB", length)
    Dim type As String = fi.Extension
    If type.StartsWith(".") Then
      type = type.Substring(1)
    End If
    Dim dateModified As DateTime = fi.LastWriteTime
    item.SubItems.Add(size)
    item.SubItems.Add(type)
    item.SubItems.Add(dateModified.ToString("yyyy-MM-dd HH:mm:ss"))
    listViewFiles.Items.Add(item)
  End Sub

  ' organize file list showing only names
  Public Sub ShowIcons()
    listViewFiles.View = View.SmallIcon
  End Sub

  ' organize file list showing details
  Public Sub ShowDetails()
    listViewFiles.View = View.Details
  End Sub

  Public Sub Clear()
    listViewFiles.Items.Clear()
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
  Friend WithEvents imageList1 As System.Windows.Forms.ImageList
  Friend WithEvents listViewFiles As System.Windows.Forms.ListView
  Friend WithEvents columnHeaderName As System.Windows.Forms.ColumnHeader
  Friend WithEvents columnHeaderSize As System.Windows.Forms.ColumnHeader
  Friend WithEvents columnHeaderType As System.Windows.Forms.ColumnHeader
  Friend WithEvents columnHeaderDateModified As System.Windows.Forms.ColumnHeader
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ContentFileList))
    Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.listViewFiles = New System.Windows.Forms.ListView
    Me.columnHeaderName = New System.Windows.Forms.ColumnHeader
    Me.columnHeaderSize = New System.Windows.Forms.ColumnHeader
    Me.columnHeaderType = New System.Windows.Forms.ColumnHeader
    Me.columnHeaderDateModified = New System.Windows.Forms.ColumnHeader
    Me.SuspendLayout()
    '
    'imageList1
    '
    Me.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
    Me.imageList1.ImageSize = New System.Drawing.Size(16, 16)
    Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
    '
    'listViewFiles
    '
    Me.listViewFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.listViewFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeaderName, Me.columnHeaderSize, Me.columnHeaderType, Me.columnHeaderDateModified})
    Me.listViewFiles.Dock = System.Windows.Forms.DockStyle.Fill
    Me.listViewFiles.HideSelection = False
    Me.listViewFiles.Location = New System.Drawing.Point(0, 0)
    Me.listViewFiles.Name = "listViewFiles"
    Me.listViewFiles.Size = New System.Drawing.Size(470, 288)
    Me.listViewFiles.SmallImageList = Me.imageList1
    Me.listViewFiles.TabIndex = 1
    Me.listViewFiles.View = System.Windows.Forms.View.Details
    '
    'columnHeaderName
    '
    Me.columnHeaderName.Text = "Name"
    Me.columnHeaderName.Width = 201
    '
    'columnHeaderSize
    '
    Me.columnHeaderSize.Text = "Size"
    Me.columnHeaderSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    Me.columnHeaderSize.Width = 76
    '
    'columnHeaderType
    '
    Me.columnHeaderType.Text = "Type"
    '
    'columnHeaderDateModified
    '
    Me.columnHeaderDateModified.Text = "Date Modified"
    Me.columnHeaderDateModified.Width = 128
    '
    'ContentFileList
    '
    Me.Controls.Add(Me.listViewFiles)
    Me.Name = "ContentFileList"
    Me.Size = New System.Drawing.Size(470, 288)
    Me.ResumeLayout(False)

  End Sub

#End Region

  ' show info about a file to the user
  Sub IndicateFileInfo()
    If listViewFiles.FocusedItem Is Nothing Then Return
    If listViewFiles.FocusedItem.ImageIndex = ImageFolder Then
      FireMessage("") ' erase the status bar message
      Return
    End If

    Dim filePath As String = CStr(listViewFiles.FocusedItem.Tag)
    If Not File.Exists(filePath) Then Return
    Dim fi As New FileInfo(filePath)
    Dim length As Long = CLng(fi.Length / 1024)
    If (length < 1) Then
      length = 1
    End If
    Dim size As String = String.Format("File size: {0:#,##0} KB   {1}", length, filePath)
    FireMessage(Size)  ' show a new status bar message
  End Sub

#Region "Event Handlers"
  Private Sub listViewFiles_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles listViewFiles.Enter
    IndicateFileInfo()
  End Sub

  Private Sub listViewFiles_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles listViewFiles.SelectedIndexChanged
    IndicateFileInfo()
  End Sub

  Private Sub listViewFiles_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles listViewFiles.Resize
    columnHeaderDateModified.Width = -2  ' autosize last column
  End Sub

  Private Sub listViewFiles_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles listViewFiles.DoubleClick
    If listViewFiles.SelectedItems.Count = 0 Then Return
    Dim filePath As String = CStr(listViewFiles.SelectedItems(0).Tag)
    FireFolderDoubleClicked(filePath)
  End Sub

#End Region

#Region "Events"
  Public Event OnFolderDoubleClicked(ByVal thePath As String)
  Sub FireFolderDoubleClicked(ByVal thePath As String)
    RaiseEvent OnFolderDoubleClicked(thePath)
  End Sub

  Public Event OnMessage(ByVal theMessage As String)
  Sub FireMessage(ByVal theMessage As String)
    RaiseEvent OnMessage(theMessage)
  End Sub
#End Region

End Class
