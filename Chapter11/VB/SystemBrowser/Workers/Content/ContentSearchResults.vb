Imports System.IO

Public Class ContentSearchResults
  Inherits System.Windows.Forms.UserControl

  ' ImageList indexes, for images placed next to files found
  Const ImageFile As Integer = 0

  ' add a file to the list of files found
  Public Sub Add(ByVal theFilePath As String, ByVal theCurrentCount As Integer)
    If Not File.Exists(theFilePath) Then Return

    Dim name As String = Path.GetFileName(theFilePath)
    Dim item As New ListViewItem(name, ImageFile)
    item.Tag = theFilePath
    Dim fi As New FileInfo(theFilePath)
    Dim folder As String = fi.DirectoryName
    item.SubItems.Add(folder)
    Dim length As Long = CLng(fi.Length / 1024)
    If (length < 1) Then
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
  Friend WithEvents imageListFiles As System.Windows.Forms.ImageList
  Friend WithEvents listViewFiles As System.Windows.Forms.ListView
  Friend WithEvents columnHeaderName As System.Windows.Forms.ColumnHeader
  Friend WithEvents columnHeaderInFolder As System.Windows.Forms.ColumnHeader
  Friend WithEvents columnHeaderSize As System.Windows.Forms.ColumnHeader
  Friend WithEvents columnHeaderType As System.Windows.Forms.ColumnHeader
  Friend WithEvents columnHeaderDateModified As System.Windows.Forms.ColumnHeader
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ContentSearchResults))
    Me.imageListFiles = New System.Windows.Forms.ImageList(Me.components)
    Me.listViewFiles = New System.Windows.Forms.ListView
    Me.columnHeaderName = New System.Windows.Forms.ColumnHeader
    Me.columnHeaderInFolder = New System.Windows.Forms.ColumnHeader
    Me.columnHeaderSize = New System.Windows.Forms.ColumnHeader
    Me.columnHeaderType = New System.Windows.Forms.ColumnHeader
    Me.columnHeaderDateModified = New System.Windows.Forms.ColumnHeader
    Me.SuspendLayout()
    '
    'imageListFiles
    '
    Me.imageListFiles.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
    Me.imageListFiles.ImageSize = New System.Drawing.Size(16, 16)
    Me.imageListFiles.ImageStream = CType(resources.GetObject("imageListFiles.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.imageListFiles.TransparentColor = System.Drawing.Color.Transparent
    '
    'listViewFiles
    '
    Me.listViewFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.listViewFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeaderName, Me.columnHeaderInFolder, Me.columnHeaderSize, Me.columnHeaderType, Me.columnHeaderDateModified})
    Me.listViewFiles.Dock = System.Windows.Forms.DockStyle.Fill
    Me.listViewFiles.HideSelection = False
    Me.listViewFiles.Location = New System.Drawing.Point(0, 0)
    Me.listViewFiles.Name = "listViewFiles"
    Me.listViewFiles.Size = New System.Drawing.Size(554, 364)
    Me.listViewFiles.SmallImageList = Me.imageListFiles
    Me.listViewFiles.TabIndex = 2
    Me.listViewFiles.View = System.Windows.Forms.View.Details
    '
    'columnHeaderName
    '
    Me.columnHeaderName.Text = "Name"
    Me.columnHeaderName.Width = 143
    '
    'columnHeaderInFolder
    '
    Me.columnHeaderInFolder.Text = "In Folder"
    Me.columnHeaderInFolder.Width = 162
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
    Me.columnHeaderDateModified.Width = 109
    '
    'ContentSearchResults
    '
    Me.Controls.Add(Me.listViewFiles)
    Me.Name = "ContentSearchResults"
    Me.Size = New System.Drawing.Size(554, 364)
    Me.ResumeLayout(False)

  End Sub

#End Region

#Region "Event Handlers"
  Private Sub listViewFiles_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles listViewFiles.SelectedIndexChanged
    If listViewFiles.SelectedItems.Count = 0 Then
      Dim s As String = String.Format("{0} objects", listViewFiles.Items.Count)
      FireMessage(s)  ' no file selected
    Else
      Dim item As ListViewItem = listViewFiles.SelectedItems(0)
      Dim folder As String = item.SubItems(1).Text
      FireMessage("In folder: " + folder)
    End If
  End Sub

  Private Sub listViewFiles_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles listViewFiles.Resize
    columnHeaderDateModified.Width = -2  ' autosize last column
  End Sub

#End Region

#Region "Events"
  Public Event OnMessage(ByVal theMessage As String)
  Private Sub FireMessage(ByVal theMessage As String)
    RaiseEvent OnMessage(theMessage)
  End Sub
#End Region

End Class
