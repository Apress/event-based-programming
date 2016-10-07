Imports Asap.Cars.CommonTypes

Public Class WorkerOrderEntry
  Inherits System.Windows.Forms.UserControl

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
  Public WithEvents PanelMain As System.Windows.Forms.Panel
  Friend WithEvents ComboBoxColor As System.Windows.Forms.ComboBox
  Friend WithEvents LabelTotalPrice As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents ButtonSubmit As System.Windows.Forms.Button
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TreeViewOptions As System.Windows.Forms.TreeView
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents ComboBoxStyle As System.Windows.Forms.ComboBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents ComboBoxModel As System.Windows.Forms.ComboBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.PanelMain = New System.Windows.Forms.Panel
    Me.ComboBoxColor = New System.Windows.Forms.ComboBox
    Me.LabelTotalPrice = New System.Windows.Forms.Label
    Me.Label5 = New System.Windows.Forms.Label
    Me.ButtonSubmit = New System.Windows.Forms.Button
    Me.Label4 = New System.Windows.Forms.Label
    Me.TreeViewOptions = New System.Windows.Forms.TreeView
    Me.Label3 = New System.Windows.Forms.Label
    Me.ComboBoxStyle = New System.Windows.Forms.ComboBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.ComboBoxModel = New System.Windows.Forms.ComboBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.PanelMain.SuspendLayout()
    Me.SuspendLayout()
    '
    'PanelMain
    '
    Me.PanelMain.Controls.Add(Me.ComboBoxColor)
    Me.PanelMain.Controls.Add(Me.LabelTotalPrice)
    Me.PanelMain.Controls.Add(Me.Label5)
    Me.PanelMain.Controls.Add(Me.ButtonSubmit)
    Me.PanelMain.Controls.Add(Me.Label4)
    Me.PanelMain.Controls.Add(Me.TreeViewOptions)
    Me.PanelMain.Controls.Add(Me.Label3)
    Me.PanelMain.Controls.Add(Me.ComboBoxStyle)
    Me.PanelMain.Controls.Add(Me.Label2)
    Me.PanelMain.Controls.Add(Me.ComboBoxModel)
    Me.PanelMain.Controls.Add(Me.Label1)
    Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
    Me.PanelMain.Location = New System.Drawing.Point(0, 0)
    Me.PanelMain.Name = "PanelMain"
    Me.PanelMain.Size = New System.Drawing.Size(379, 338)
    Me.PanelMain.TabIndex = 1
    '
    'ComboBoxColor
    '
    Me.ComboBoxColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ComboBoxColor.Location = New System.Drawing.Point(255, 30)
    Me.ComboBoxColor.Name = "ComboBoxColor"
    Me.ComboBoxColor.Size = New System.Drawing.Size(97, 24)
    Me.ComboBoxColor.TabIndex = 5
    '
    'LabelTotalPrice
    '
    Me.LabelTotalPrice.AutoSize = True
    Me.LabelTotalPrice.Location = New System.Drawing.Point(165, 268)
    Me.LabelTotalPrice.Name = "LabelTotalPrice"
    Me.LabelTotalPrice.Size = New System.Drawing.Size(23, 18)
    Me.LabelTotalPrice.TabIndex = 9
    Me.LabelTotalPrice.Text = "$ 0"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(31, 268)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(137, 18)
    Me.Label5.TabIndex = 8
    Me.Label5.Text = "Total Price of Options:"
    '
    'ButtonSubmit
    '
    Me.ButtonSubmit.Location = New System.Drawing.Point(149, 299)
    Me.ButtonSubmit.Name = "ButtonSubmit"
    Me.ButtonSubmit.Size = New System.Drawing.Size(102, 23)
    Me.ButtonSubmit.TabIndex = 10
    Me.ButtonSubmit.Text = "Submit Order"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(29, 59)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(55, 18)
    Me.Label4.TabIndex = 6
    Me.Label4.Text = "Options:"
    '
    'TreeViewOptions
    '
    Me.TreeViewOptions.CheckBoxes = True
    Me.TreeViewOptions.ImageIndex = -1
    Me.TreeViewOptions.Location = New System.Drawing.Point(26, 78)
    Me.TreeViewOptions.Name = "TreeViewOptions"
    Me.TreeViewOptions.SelectedImageIndex = -1
    Me.TreeViewOptions.Size = New System.Drawing.Size(327, 180)
    Me.TreeViewOptions.TabIndex = 7
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(259, 10)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(41, 18)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "Color:"
    '
    'ComboBoxStyle
    '
    Me.ComboBoxStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ComboBoxStyle.Location = New System.Drawing.Point(137, 30)
    Me.ComboBoxStyle.Name = "ComboBoxStyle"
    Me.ComboBoxStyle.Size = New System.Drawing.Size(97, 24)
    Me.ComboBoxStyle.TabIndex = 3
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(142, 10)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(38, 18)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "Style:"
    '
    'ComboBoxModel
    '
    Me.ComboBoxModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ComboBoxModel.Location = New System.Drawing.Point(22, 29)
    Me.ComboBoxModel.Name = "ComboBoxModel"
    Me.ComboBoxModel.Size = New System.Drawing.Size(97, 24)
    Me.ComboBoxModel.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(21, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(45, 18)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Model:"
    '
    'WorkerOrderEntry
    '
    Me.Controls.Add(Me.PanelMain)
    Me.Name = "WorkerOrderEntry"
    Me.Size = New System.Drawing.Size(379, 338)
    Me.PanelMain.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub ComboBoxModel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxModel.SelectedIndexChanged
    ComboBoxStyle.Items.Clear()
    Dim model As String = ComboBoxModel.Text
    Dim styles As String() = FireGetStyles(model)
    If styles Is Nothing Then Return
    If styles.Length = 0 Then Return
    ComboBoxStyle.Items.AddRange(styles)
    ComboBoxStyle.SelectedIndex = 0
  End Sub

  Private Sub ComboBoxStyle_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxStyle.SelectedIndexChanged
    TreeViewOptions.Nodes.Clear()
    Dim model As String = ComboBoxModel.Text
    Dim style As String = ComboBoxStyle.Text
    Dim options As ArrayList = FireGetOptions(model, style)
    If Not options Is Nothing Then
      PopulateOptions(options)
    End If

    Dim colors As Color() = FireGetColors(model, style)
    ComboBoxColor.Items.Clear()
    If colors Is Nothing Then Return
    If colors.Length = 0 Then Return
    For Each clr As Color In colors
      ComboBoxColor.Items.Add(clr.ToKnownColor().ToString())
    Next
    ComboBoxColor.SelectedIndex = 0
  End Sub

  ' each entry in theOptions is a PricedItem array. In each array, the
  ' first element is the option category, the remaining elements
  ' are the options for the given category
  Sub PopulateOptions(ByVal theOptions As ArrayList)
    If theOptions Is Nothing Then Return

    For Each options As PricedItem() In theOptions
      PopulateOption(options)
    Next

    TreeViewOptions.ExpandAll()
  End Sub

  ' first item is category, remainders are options
  Sub PopulateOption(ByVal theOptions As PricedItem())
    If theOptions.Length = 0 Then Return

    Dim category As PricedItem = theOptions(0)
    Dim categoryNode As New TreeNode(category.Name)
    categoryNode.Tag = category
    TreeViewOptions.Nodes.Add(categoryNode)

    For i As Integer = 1 To theOptions.Length - 1
      Dim opt As PricedItem = theOptions(i)
      Dim node As New TreeNode(opt.Name)
      node.Tag = opt
      categoryNode.Nodes.Add(node)
    Next
  End Sub

  Sub PopulateOption(ByVal theNode As TreeNode, ByVal theOptions As PricedItem())
    For Each opt As PricedItem In theOptions
      Dim node As New TreeNode(opt.Name)
      theNode.Nodes.Add(node)
    Next
  End Sub

  Public Sub PopulateModels(ByVal theModels As String())
    ComboBoxModel.Items.Clear()
    If theModels Is Nothing Then Return
    If theModels.Length = 0 Then Return
    ComboBoxModel.Items.AddRange(theModels)
    ComboBoxModel.SelectedIndex = 0
  End Sub

  Private Sub TreeViewOptions_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeViewOptions.AfterCheck
    Dim node As TreeNode = e.Node
    If node Is Nothing Then Return

    If IsCategoryNode(node) Then
      ' check or uncheck all the child options
      For Each childNode As TreeNode In node.Nodes
        childNode.Checked = node.Checked
      Next
    Else
        ' must be an Options node
        UpdateOptionsCost()
    End If
  End Sub

  Function IsCategoryNode(ByVal theNode As TreeNode) As Boolean
    ' category nodes are at the root level
    Return theNode.Parent Is Nothing
  End Function

  Sub UpdateOptionsCost()
    Dim optionsSelected As New ArrayList

    ' get a list of all the selected options
    For Each categoryNode As TreeNode In TreeViewOptions.Nodes
      For Each optionNode As TreeNode In categoryNode.Nodes
        If optionNode.Checked Then
          optionsSelected.Add(optionNode.Tag)
        End If
      Next
    Next

    ' get total cost of options and show result
    Dim options As PricedItem() = DirectCast(optionsSelected.ToArray(GetType(PricedItem)), PricedItem())
    Dim totalPrice As Decimal = FireComputeCostOfOptions(options)
    LabelTotalPrice.Text = totalPrice.ToString("C")  ' display as a currency
  End Sub

  Private Sub ButtonSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSubmit.Click
    Dim options As New ArrayList
    For Each categoryNode As TreeNode In TreeViewOptions.Nodes
      For Each optionNode As TreeNode In categoryNode.Nodes
        If optionNode.Checked Then
          options.Add(optionNode.Tag)
        End If
      Next
    Next
    Dim items As PricedItem() = DirectCast(options.ToArray(GetType(PricedItem)), PricedItem())
    Dim clr As Color = Color.FromName(ComboBoxColor.Text)
    FireSubmitOrder(ComboBoxModel.Text, ComboBoxStyle.Text, clr, items)
  End Sub

  Public Delegate Function GetStylesHandler(ByVal theModel As String) As String()
  Public OnGetStyles As GetStylesHandler
  Function FireGetStyles(ByVal theModel As String) As String()
    If OnGetStyles Is Nothing Then Return Nothing
    Return OnGetStyles(theModel)
  End Function

  Public Delegate Function GetColorsHandler(ByVal theModel As String, ByVal theStyle As String) As Color()
  Public OnGetColors As GetColorsHandler
  Function FireGetColors(ByVal theModel As String, ByVal theStyle As String) As Color()
    If OnGetColors Is Nothing Then Return Nothing
    Return OnGetColors(theModel, theStyle)
  End Function

  Public Delegate Function GetOptionsHandler(ByVal theModel As String, ByVal theStyle As String) As ArrayList
  Public OnGetOptions As GetOptionsHandler
  Function FireGetOptions(ByVal theModel As String, ByVal theStyle As String) As ArrayList
    If OnGetOptions Is Nothing Then Return Nothing
    Return OnGetOptions(theModel, theStyle)
  End Function

  Public Event OnSubmitOrder(ByVal theModel As String, ByVal theStyle As String, ByVal theColor As Color, ByVal theOptions As PricedItem())

  Sub FireSubmitOrder(ByVal theModel As String, ByVal theStyle As String, ByVal theColor As Color, ByVal theOptions As PricedItem())
    RaiseEvent OnSubmitOrder(theModel, theStyle, theColor, theOptions)
  End Sub

  Public Delegate Function ComputeCostOfOptionsHandler(ByVal theOptionsSelected As PricedItem()) As Decimal
  Public OnComputeCostOfOptions As ComputeCostOfOptionsHandler
  Function FireComputeCostOfOptions(ByVal theOptionsSelected As PricedItem()) As Decimal
    If OnComputeCostOfOptions Is Nothing Then Return Nothing
    Return OnComputeCostOfOptions(theOptionsSelected)
  End Function

End Class
