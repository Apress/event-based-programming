Imports System.IO

Public Class NavigatorFolders
  Inherits System.Windows.Forms.UserControl

  Private _folderSelected As String

  ' ImageList indexes
  Const ImageFolder As Integer = 0
  Const ImageFolderOpened As Integer = 1
  Const ImageHardDrive As Integer = 2

  Public Sub Populate(ByVal theFolder As String)
    Cursor = Cursors.WaitCursor
    treeViewFolders.BeginUpdate()
    treeViewFolders.Nodes.Clear()

    Dim percentComplete As Integer = 0

    ' strip off  trailing backslash
    Dim name As String = theFolder
    If name.EndsWith("\") Then
      name = name.Substring(0, name.Length - 1)
    End If

    Dim rootNode As New TreeNode(name, ImageHardDrive, ImageHardDrive)
    rootNode.Tag = theFolder  ' save the directory's full path
    treeViewFolders.Nodes.Add(rootNode)

    Dim i As Integer = 0
    Dim directories As String() = Directory.GetDirectories(theFolder)
    Dim totalFiles As Integer = directories.Length
    For Each directory As String In directories
      AddNode(rootNode.Nodes, directory)
      percentComplete = CInt((i * 100) / totalFiles)
      FireProgress(percentComplete)
      i += 1
    Next

    treeViewFolders.EndUpdate()
    rootNode.Expand()
    FireProgress(100)
    Cursor = Cursors.Default
  End Sub

  Public Sub SelectFolder(ByVal thePath As String)
    If thePath Is Nothing Then Return
    If treeViewFolders.Nodes.Count = 0 Then Return

    If thePath.EndsWith("\") Then
      ' root folder
      treeViewFolders.SelectedNode = treeViewFolders.Nodes(0)
      Return
    End If

    Dim directories As String() = thePath.Split(New Char() {"\"c})
    Dim node As TreeNode = treeViewFolders.Nodes(0)
    For Each directory As String In directories
      node = FindNodeFor(node, directory)
      If node Is Nothing Then Return
    Next

    AddChildren(node)
    treeViewFolders.SelectedNode = node
  End Sub

  Public Sub SelectParentFolder()
    Dim currentNode As TreeNode = treeViewFolders.SelectedNode
    If currentNode Is Nothing Then Return

    Dim currentDirectory As String = CStr(currentNode.Tag)
    Dim parentDirectory As DirectoryInfo = Directory.GetParent(currentDirectory)
    If parentDirectory Is Nothing Then Return
    SelectFolder(parentDirectory.FullName)
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
  Friend WithEvents imageListFolders As System.Windows.Forms.ImageList
  Friend WithEvents treeViewFolders As System.Windows.Forms.TreeView
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NavigatorFolders))
    Me.imageListFolders = New System.Windows.Forms.ImageList(Me.components)
    Me.treeViewFolders = New System.Windows.Forms.TreeView
    Me.SuspendLayout()
    '
    'imageListFolders
    '
    Me.imageListFolders.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
    Me.imageListFolders.ImageSize = New System.Drawing.Size(16, 16)
    Me.imageListFolders.ImageStream = CType(resources.GetObject("imageListFolders.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.imageListFolders.TransparentColor = System.Drawing.Color.Transparent
    '
    'treeViewFolders
    '
    Me.treeViewFolders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.treeViewFolders.Dock = System.Windows.Forms.DockStyle.Fill
    Me.treeViewFolders.HideSelection = False
    Me.treeViewFolders.ImageList = Me.imageListFolders
    Me.treeViewFolders.Location = New System.Drawing.Point(0, 0)
    Me.treeViewFolders.Name = "treeViewFolders"
    Me.treeViewFolders.Size = New System.Drawing.Size(210, 232)
    Me.treeViewFolders.TabIndex = 1
    '
    'NavigatorFolders
    '
    Me.Controls.Add(Me.treeViewFolders)
    Me.Name = "NavigatorFolders"
    Me.Size = New System.Drawing.Size(210, 232)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Sub AddNode(ByVal theParentCollection As TreeNodeCollection, ByVal theDirectory As String)
    Dim name As String = Path.GetFileName(theDirectory)
    Dim node As New TreeNode(name, ImageFolder, ImageFolderOpened)
    node.Tag = theDirectory  ' save the directory's full path
    theParentCollection.Add(node)

    Dim subdirectories As String() = Nothing
    Try
      subdirectories = Directory.GetDirectories(theDirectory)
    Catch
      Return  ' ignore restricted directories
    End Try

    If subdirectories Is Nothing Then Return
    If subdirectories.Length = 0 Then Return

    ' if directory has subdirectories, add just 1 subdirectory, to
    ' make a '+' sign appear next to the node
    name = Path.GetFileName(subdirectories(0))
    Dim subNode As New TreeNode(name, ImageFolder, ImageFolder)
    subNode.Tag = String.Format("{0}\{1}", theDirectory, name)
    node.Nodes.Add(subNode)
  End Sub

  Sub AddChildren(ByVal theNode As TreeNode)
    treeViewFolders.BeginUpdate()
    theNode.Nodes.Clear()  ' remove the single subdirectory added
    Dim dir As String = CStr(theNode.Tag)
    For Each subdirectory As String In Directory.GetDirectories(dir)
      AddNode(theNode.Nodes, subdirectory)
      treeViewFolders.EndUpdate()
    Next
  End Sub

  Sub UpdateStatusBar()
    FireMessage(_folderSelected)
  End Sub

  Function FindNodeFor(ByVal theStartingNode As TreeNode, ByVal theDirectory As String) As TreeNode
    If theStartingNode.Text.ToLower() = theDirectory.ToLower() Then
      Return theStartingNode
    End If

    ' search the direct children
    For Each node As TreeNode In theStartingNode.Nodes
      If node.Text.ToLower() = theDirectory.ToLower() Then Return node
    Next
    Return Nothing
  End Function

#Region "Event Handlers"
  Private Sub treeViewFolders_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles treeViewFolders.BeforeExpand
    AddChildren(e.Node)
  End Sub

  Private Sub treeViewFolders_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles treeViewFolders.AfterSelect
    If e.Node Is Nothing Then Return
    _folderSelected = CStr(e.Node.Tag)
    FireFolderChanged(_folderSelected)
    UpdateStatusBar()
  End Sub

  Private Sub treeViewFolders_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles treeViewFolders.Enter
    UpdateStatusBar()
  End Sub

#End Region

#Region "Events"
  Public Event OnFolderChanged(ByVal theFolderPath As String)
  Sub FireFolderChanged(ByVal theFolderPath As String)
    RaiseEvent OnFolderChanged(theFolderPath)
  End Sub

  Public Event OnMessage(ByVal theMessage As String)
  Sub FireMessage(ByVal theMessage As String)
    RaiseEvent OnMessage(theMessage)
  End Sub

  Public Delegate Sub ProgressHandler(ByVal percentComplete As Integer)
  Public Event OnProgress As ProgressHandler
  Sub FireProgress(ByVal percentComplete As Integer)
    RaiseEvent OnProgress(percentComplete)
  End Sub
#End Region

End Class
