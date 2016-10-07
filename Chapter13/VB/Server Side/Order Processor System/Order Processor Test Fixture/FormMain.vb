Imports Asap.Cars.OrderProcessor
Imports Asap.Cars.CommonTypes

Public Class FormMain
  Inherits System.Windows.Forms.Form

  Private _orderSystem As New OrderSystem

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    ComboBoxColors.Items.Add("White")
    ComboBoxColors.SelectedIndex = 0

    columnHeaderOptions.Width = -2   ' auto size last column

    DisplayQueuedMessages()
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
  Friend WithEvents columnHeaderModel As System.Windows.Forms.ColumnHeader
  Friend WithEvents columnHeaderStyle As System.Windows.Forms.ColumnHeader
  Friend WithEvents columnHeaderColor As System.Windows.Forms.ColumnHeader
  Friend WithEvents columnHeaderOptions As System.Windows.Forms.ColumnHeader
  Friend WithEvents ButtonRefreshList As System.Windows.Forms.Button
  Friend WithEvents ListViewQueuedMessages As System.Windows.Forms.ListView
  Friend WithEvents ButtonClearQueue As System.Windows.Forms.Button
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents ButtonGetOptions As System.Windows.Forms.Button
  Friend WithEvents ButtonGetColors As System.Windows.Forms.Button
  Friend WithEvents ButtonGetStyles As System.Windows.Forms.Button
  Friend WithEvents ButtonGetModels As System.Windows.Forms.Button
  Friend WithEvents ComboBoxColors As System.Windows.Forms.ComboBox
  Friend WithEvents ComboBoxStyles As System.Windows.Forms.ComboBox
  Friend WithEvents ComboBoxModels As System.Windows.Forms.ComboBox
  Friend WithEvents TextBoxOptions As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents ButtonSubmitOrder As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.ButtonRefreshList = New System.Windows.Forms.Button
    Me.ListViewQueuedMessages = New System.Windows.Forms.ListView
    Me.columnHeaderModel = New System.Windows.Forms.ColumnHeader
    Me.columnHeaderStyle = New System.Windows.Forms.ColumnHeader
    Me.columnHeaderColor = New System.Windows.Forms.ColumnHeader
    Me.columnHeaderOptions = New System.Windows.Forms.ColumnHeader
    Me.ButtonClearQueue = New System.Windows.Forms.Button
    Me.Label5 = New System.Windows.Forms.Label
    Me.ButtonGetOptions = New System.Windows.Forms.Button
    Me.ButtonGetColors = New System.Windows.Forms.Button
    Me.ButtonGetStyles = New System.Windows.Forms.Button
    Me.ButtonGetModels = New System.Windows.Forms.Button
    Me.ComboBoxColors = New System.Windows.Forms.ComboBox
    Me.ComboBoxStyles = New System.Windows.Forms.ComboBox
    Me.ComboBoxModels = New System.Windows.Forms.ComboBox
    Me.TextBoxOptions = New System.Windows.Forms.TextBox
    Me.Label4 = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    Me.ButtonSubmitOrder = New System.Windows.Forms.Button
    Me.SuspendLayout()
    '
    'ButtonRefreshList
    '
    Me.ButtonRefreshList.Location = New System.Drawing.Point(679, 222)
    Me.ButtonRefreshList.Name = "ButtonRefreshList"
    Me.ButtonRefreshList.Size = New System.Drawing.Size(90, 26)
    Me.ButtonRefreshList.TabIndex = 37
    Me.ButtonRefreshList.Text = "Refresh List"
    '
    'ListViewQueuedMessages
    '
    Me.ListViewQueuedMessages.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeaderModel, Me.columnHeaderStyle, Me.columnHeaderColor, Me.columnHeaderOptions})
    Me.ListViewQueuedMessages.Location = New System.Drawing.Point(451, 42)
    Me.ListViewQueuedMessages.Name = "ListViewQueuedMessages"
    Me.ListViewQueuedMessages.Size = New System.Drawing.Size(391, 163)
    Me.ListViewQueuedMessages.TabIndex = 36
    Me.ListViewQueuedMessages.View = System.Windows.Forms.View.Details
    '
    'columnHeaderModel
    '
    Me.columnHeaderModel.Text = "Model"
    Me.columnHeaderModel.Width = 69
    '
    'columnHeaderStyle
    '
    Me.columnHeaderStyle.Text = "Style"
    Me.columnHeaderStyle.Width = 91
    '
    'columnHeaderColor
    '
    Me.columnHeaderColor.Text = "Color"
    '
    'columnHeaderOptions
    '
    Me.columnHeaderOptions.Text = "Options"
    Me.columnHeaderOptions.Width = 101
    '
    'ButtonClearQueue
    '
    Me.ButtonClearQueue.Location = New System.Drawing.Point(499, 222)
    Me.ButtonClearQueue.Name = "ButtonClearQueue"
    Me.ButtonClearQueue.Size = New System.Drawing.Size(96, 26)
    Me.ButtonClearQueue.TabIndex = 35
    Me.ButtonClearQueue.Text = "Clear Queue"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(449, 23)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(121, 18)
    Me.Label5.TabIndex = 34
    Me.Label5.Text = "Queued Messages:"
    '
    'ButtonGetOptions
    '
    Me.ButtonGetOptions.Location = New System.Drawing.Point(302, 137)
    Me.ButtonGetOptions.Name = "ButtonGetOptions"
    Me.ButtonGetOptions.Size = New System.Drawing.Size(90, 27)
    Me.ButtonGetOptions.TabIndex = 33
    Me.ButtonGetOptions.Text = "Get Options"
    '
    'ButtonGetColors
    '
    Me.ButtonGetColors.Location = New System.Drawing.Point(302, 97)
    Me.ButtonGetColors.Name = "ButtonGetColors"
    Me.ButtonGetColors.Size = New System.Drawing.Size(90, 27)
    Me.ButtonGetColors.TabIndex = 32
    Me.ButtonGetColors.Text = "Get Colors"
    '
    'ButtonGetStyles
    '
    Me.ButtonGetStyles.Location = New System.Drawing.Point(302, 60)
    Me.ButtonGetStyles.Name = "ButtonGetStyles"
    Me.ButtonGetStyles.Size = New System.Drawing.Size(90, 27)
    Me.ButtonGetStyles.TabIndex = 31
    Me.ButtonGetStyles.Text = "Get Styles"
    '
    'ButtonGetModels
    '
    Me.ButtonGetModels.Location = New System.Drawing.Point(302, 23)
    Me.ButtonGetModels.Name = "ButtonGetModels"
    Me.ButtonGetModels.Size = New System.Drawing.Size(90, 27)
    Me.ButtonGetModels.TabIndex = 30
    Me.ButtonGetModels.Text = "Get Models"
    '
    'ComboBoxColors
    '
    Me.ComboBoxColors.Location = New System.Drawing.Point(86, 97)
    Me.ComboBoxColors.Name = "ComboBoxColors"
    Me.ComboBoxColors.Size = New System.Drawing.Size(202, 24)
    Me.ComboBoxColors.TabIndex = 29
    '
    'ComboBoxStyles
    '
    Me.ComboBoxStyles.Location = New System.Drawing.Point(86, 62)
    Me.ComboBoxStyles.Name = "ComboBoxStyles"
    Me.ComboBoxStyles.Size = New System.Drawing.Size(202, 24)
    Me.ComboBoxStyles.TabIndex = 28
    Me.ComboBoxStyles.Text = "4-door sedan"
    '
    'ComboBoxModels
    '
    Me.ComboBoxModels.Location = New System.Drawing.Point(86, 25)
    Me.ComboBoxModels.Name = "ComboBoxModels"
    Me.ComboBoxModels.Size = New System.Drawing.Size(202, 24)
    Me.ComboBoxModels.TabIndex = 27
    Me.ComboBoxModels.Text = "Safari"
    '
    'TextBoxOptions
    '
    Me.TextBoxOptions.Location = New System.Drawing.Point(86, 134)
    Me.TextBoxOptions.Multiline = True
    Me.TextBoxOptions.Name = "TextBoxOptions"
    Me.TextBoxOptions.Size = New System.Drawing.Size(202, 69)
    Me.TextBoxOptions.TabIndex = 26
    Me.TextBoxOptions.Text = "Option1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Option2"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(29, 136)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(55, 18)
    Me.Label4.TabIndex = 24
    Me.Label4.Text = "Options:"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(43, 99)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(41, 18)
    Me.Label3.TabIndex = 23
    Me.Label3.Text = "Color:"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(44, 67)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(38, 18)
    Me.Label2.TabIndex = 22
    Me.Label2.Text = "Style:"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(38, 30)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(45, 18)
    Me.Label1.TabIndex = 21
    Me.Label1.Text = "Model:"
    '
    'ButtonSubmitOrder
    '
    Me.ButtonSubmitOrder.Location = New System.Drawing.Point(120, 238)
    Me.ButtonSubmitOrder.Name = "ButtonSubmitOrder"
    Me.ButtonSubmitOrder.Size = New System.Drawing.Size(103, 26)
    Me.ButtonSubmitOrder.TabIndex = 25
    Me.ButtonSubmitOrder.Text = "Submit Order"
    '
    'FormMain
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
    Me.ClientSize = New System.Drawing.Size(871, 286)
    Me.Controls.Add(Me.ButtonRefreshList)
    Me.Controls.Add(Me.ListViewQueuedMessages)
    Me.Controls.Add(Me.ButtonClearQueue)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.ButtonGetOptions)
    Me.Controls.Add(Me.ButtonGetColors)
    Me.Controls.Add(Me.ButtonGetStyles)
    Me.Controls.Add(Me.ButtonGetModels)
    Me.Controls.Add(Me.ComboBoxColors)
    Me.Controls.Add(Me.ComboBoxStyles)
    Me.Controls.Add(Me.ComboBoxModels)
    Me.Controls.Add(Me.TextBoxOptions)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.ButtonSubmitOrder)
    Me.Name = "FormMain"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Order Processor Test Fixture"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub ButtonGetModels_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonGetModels.Click
    Dim models As String() = _orderSystem.GetModels()
    ComboBoxModels.Items.Clear()
    If models Is Nothing Then Return

    For Each model As String In models
      ComboBoxModels.Items.Add(model)
    Next
    ComboBoxModels.SelectedIndex = 0
  End Sub

  Private Sub ButtonGetStyles_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonGetStyles.Click
    Dim styles As String() = _orderSystem.GetStyles(ComboBoxModels.Text)
    ComboBoxStyles.Items.Clear()
    If styles Is Nothing Then Return

    For Each style As String In styles
      ComboBoxStyles.Items.Add(style)
    Next
    ComboBoxStyles.SelectedIndex = 0
  End Sub

  Private Sub ButtonGetColors_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonGetColors.Click
    Dim colors As Color() = _orderSystem.GetColors(ComboBoxModels.Text, ComboBoxStyles.Text)
    ComboBoxColors.Items.Clear()
    If colors Is Nothing Then Return

    For Each clr As Color In colors
      ComboBoxColors.Items.Add(clr.Name)
    Next
    ComboBoxColors.SelectedIndex = 0
  End Sub

  Private _options As New ArrayList
  Private Sub ButtonGetOptions_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonGetOptions.Click
    _options = _orderSystem.GetOptions(ComboBoxModels.Text, ComboBoxStyles.Text)
    TextBoxOptions.Text = ""
    If _options Is Nothing Then Return

    Dim items As New ArrayList
    For Each pItems As PricedItem() In _options
      For Each pItem As PricedItem In pItems
        items.Add(pItem)
      Next
    Next

    ' show options in the textbox
    Dim lines(items.Count) As String
    For i As Integer = 0 To items.Count - 1
      lines(i) = DirectCast(items(i), PricedItem).Name
    Next
    TextBoxOptions.Lines = lines
  End Sub

  Private Sub ButtonSubmitOrder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSubmitOrder.Click
    Dim requestedOptions As PricedItem()
    If _options.Count > 0 Then
      ' convert an array of PriceItem arrays into a PricedItem array
      Dim items As New ArrayList
      For Each pItems As PricedItem() In _options
        For Each pItem As PricedItem In pItems
          items.Add(pItem)
        Next
        requestedOptions = DirectCast(items.ToArray(GetType(PricedItem)), PricedItem())
      Next
    Else
      requestedOptions = New PricedItem() {New PricedItem("Option1", 11), New PricedItem("Option2", 22)}
    End If
    Dim clr As Color = Color.FromName(ComboBoxColors.Text)
    _orderSystem.SubmitOrder(ComboBoxModels.Text, ComboBoxStyles.Text, clr, requestedOptions)
    DisplayQueuedMessages()
  End Sub

  Private Sub DisplayQueuedMessages()
    ListViewQueuedMessages.Items.Clear()

    Dim messages As System.Messaging.Message() = _orderSystem.GetAllQueuedMessages()
    Dim formatter As System.Messaging.XmlMessageFormatter
    formatter = New System.Messaging.XmlMessageFormatter(New Type() {GetType(WorkOrder)})

    For Each message As System.Messaging.Message In messages
      message.Formatter = formatter
      Dim wo As WorkOrder = DirectCast(message.Body, WorkOrder)
      Dim item As New ListViewItem(wo.Model)
      item.SubItems.Add(wo.Style)
      item.SubItems.Add(wo.Color)
      Dim options As String = String.Empty
      For Each opt As PricedItem In wo.Options
        options += opt.Name + ";"
      Next
      item.SubItems.Add(options)
      ListViewQueuedMessages.Items.Add(item)
    Next
  End Sub

  Private Sub ButtonClearQueue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonClearQueue.Click
    _orderSystem.ClearQueuedMessages()
    DisplayQueuedMessages()
  End Sub

  Private Sub ButtonRefreshList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRefreshList.Click
    DisplayQueuedMessages()
  End Sub
End Class
