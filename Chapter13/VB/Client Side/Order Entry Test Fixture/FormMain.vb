Imports Asap.Cars.CommonTypes

Public Class FormMain
  Inherits System.Windows.Forms.Form

  Private _workerOrderEntry As WorkerOrderEntry
  Private _coordinatorOrderEntry As CoordinatorOrderEntry

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    ' build everything
    _workerOrderEntry = New WorkerOrderEntry
    _coordinatorOrderEntry = New CoordinatorOrderEntry

    ' bind everything
    _workerOrderEntry.OnGetColors = AddressOf _coordinatorOrderEntry.GetColors 'delegate
    _workerOrderEntry.OnGetOptions = AddressOf _coordinatorOrderEntry.GetOptions 'delegate
    _workerOrderEntry.OnGetStyles = AddressOf _coordinatorOrderEntry.GetStyles 'delegate
    AddHandler _workerOrderEntry.OnSubmitOrder, AddressOf _coordinatorOrderEntry.SubmitOrder 'event
    _workerOrderEntry.OnComputeCostOfOptions = AddressOf _coordinatorOrderEntry.ComputeCostOfOptions 'delegate

    _coordinatorOrderEntry.OnGetColors = AddressOf coordinatorOrderEntry_OnGetColors 'delegate
    _coordinatorOrderEntry.OnGetOptions = AddressOf coordinatorOrderEntry_OnGetOptions 'delegate
    _coordinatorOrderEntry.OnGetStyles = AddressOf coordinatorOrderEntry_OnGetStyles 'delegate
    AddHandler _coordinatorOrderEntry.OnSubmit, AddressOf coordinatorOrderEntry_OnSubmit 'event

    ' setup UI elements
    Controls.Add(_workerOrderEntry.PanelMain)
    Dim models As String() = New String() {"Model 1", "Model 2", "Model 3"}
    _workerOrderEntry.PopulateModels(models)
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
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    '
    'FormMain
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
    Me.ClientSize = New System.Drawing.Size(456, 395)
    Me.Name = "FormMain"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Order Entry Test Fixture"

  End Sub

#End Region

  Private Function coordinatorOrderEntry_OnGetModels() As String()
    Dim models As String() = New String() {"Model 1", "Model 2", "Model 3"}
    Return models
  End Function

  Private Function coordinatorOrderEntry_OnGetColors(ByVal theModel As String, ByVal theStyle As String) As Color()
    Dim colors As Color() = New Color() {Color.White, Color.Navy, Color.Lavender}
    Return colors
  End Function

  Private Function coordinatorOrderEntry_OnGetOptions(ByVal theModel As String, ByVal theStyle As String) As ArrayList
    Dim options As New ArrayList

    Dim category1 As New ArrayList
    Dim category1Items() As PricedItem = New PricedItem() _
    {New PricedItem("Category 1", 0), _
     New PricedItem("Option 1", 111), _
     New PricedItem("Option 2", 222), _
     New PricedItem("Option 3", 333)}
    options.Add(category1Items)

    Dim category2 As New ArrayList
    Dim category2Items() As PricedItem = New PricedItem() _
     {New PricedItem("Category 2", 0), _
      New PricedItem("Option 11", 777), _
      New PricedItem("Option 22", 888), _
      New PricedItem("Option 33", 999)}
    options.Add(category2Items)

    Return options
  End Function

  Private Function coordinatorOrderEntry_OnGetStyles(ByVal theModel As String) As String()
    Dim styles As String() = New String() {"Style 1", "Style 2", "Style 3"}
    Return styles
  End Function

  Private Sub coordinatorOrderEntry_OnSubmit(ByVal theModel As String, ByVal theStyle As String, ByVal theColor As Color, ByVal theOptions As PricedItem())
    Dim s As String = String.Format("Model=[{0}] Style=[{1}] Color=[{2}]", theModel, theStyle, theColor)
    For i As Integer = 0 To theOptions.Length - 1
      s += String.Format(" Option[{0}]=[{1}]", i, theOptions(i).Name)
    Next
    MessageBox.Show(s, "Order submitted")
  End Sub

End Class
