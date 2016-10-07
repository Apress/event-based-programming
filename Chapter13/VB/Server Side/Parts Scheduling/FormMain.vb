Imports Asap.Cars.CommonTypes

Public Class FormMain
  Inherits System.Windows.Forms.Form

  ' manages connections to incoming and outgoing message queues
  Private _router As Router

  ' manages a list of scheduled parts
  Private _partsList As New WorkerPartsList

  Private _removingPartsFromPartsList As Boolean

  Private Sub CheckPartsList()
    While (True)
      Dim workOrdersReady As ArrayList = _partsList.GetWorkToAssemble()
      If workOrdersReady Is Nothing Then
        System.Threading.Thread.Sleep(100)
      Else
        ' lock out DisplayScheduledParts from running temporarily
        _removingPartsFromPartsList = True
        ' send all ready WorkOrders to next queue
        For Each wo As WorkOrder In workOrdersReady
          _partsList.Remove(wo)
          _router.SubmitForAssembly(wo)
        Next
        _removingPartsFromPartsList = False
      End If
    End While
  End Sub

  Private Sub HandleOrder(ByVal theWorkOrder As WorkOrder)
    ' a WorkerOrder has arrived. Add three parts for it, with
    ' hard-coded delivery dates

    If theWorkOrder Is Nothing Then Return

    ' pretend the work order has three parts
    _partsList.AddPart(theWorkOrder, "Part 1", DateTime.Now.AddSeconds(3))
    _partsList.AddPart(theWorkOrder, "Part 2", DateTime.Now.AddSeconds(6))
    _partsList.AddPart(theWorkOrder, "Part 3", DateTime.Now.AddSeconds(9))
  End Sub

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    System.Threading.Thread.CurrentThread.Name = "User Interface"

    _router = New Router
    AddHandler _router.OnMessage, AddressOf HandleOrder

    Dim partsListMonitor As New System.Threading.Thread(AddressOf CheckPartsList)
    partsListMonitor.IsBackground = True
    partsListMonitor.Name = "PartsListMonitor"
    partsListMonitor.Start()

    DisplayScheduledParts()
    ShowVehiclesReadyForAssembly()
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
  Friend WithEvents TimerUpdatePartsScheduled As System.Windows.Forms.Timer
  Friend WithEvents ListViewVehiclesToAssemble As System.Windows.Forms.ListView
  Friend WithEvents ColumnHeaderOutgoingId As System.Windows.Forms.ColumnHeader
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents ListViewPartsSchedule As System.Windows.Forms.ListView
  Friend WithEvents ColumnHeaderIncomingId As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeaderPart As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeaderPartSchedule As System.Windows.Forms.ColumnHeader
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Me.ListViewVehiclesToAssemble = New System.Windows.Forms.ListView
    Me.ColumnHeaderOutgoingId = New System.Windows.Forms.ColumnHeader
    Me.Label2 = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    Me.ListViewPartsSchedule = New System.Windows.Forms.ListView
    Me.ColumnHeaderIncomingId = New System.Windows.Forms.ColumnHeader
    Me.ColumnHeaderPart = New System.Windows.Forms.ColumnHeader
    Me.ColumnHeaderPartSchedule = New System.Windows.Forms.ColumnHeader
    Me.TimerUpdatePartsScheduled = New System.Windows.Forms.Timer(Me.components)
    Me.SuspendLayout()
    '
    'ListViewVehiclesToAssemble
    '
    Me.ListViewVehiclesToAssemble.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderOutgoingId})
    Me.ListViewVehiclesToAssemble.Location = New System.Drawing.Point(548, 45)
    Me.ListViewVehiclesToAssemble.Name = "ListViewVehiclesToAssemble"
    Me.ListViewVehiclesToAssemble.Size = New System.Drawing.Size(312, 166)
    Me.ListViewVehiclesToAssemble.TabIndex = 29
    Me.ListViewVehiclesToAssemble.View = System.Windows.Forms.View.Details
    '
    'ColumnHeaderOutgoingId
    '
    Me.ColumnHeaderOutgoingId.Text = "Order ID"
    Me.ColumnHeaderOutgoingId.Width = 277
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(546, 26)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(136, 18)
    Me.Label2.TabIndex = 28
    Me.Label2.Text = "Vehicles to Assemble:"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(16, 24)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(99, 18)
    Me.Label1.TabIndex = 26
    Me.Label1.Text = "Parts Schedule:"
    '
    'ListViewPartsSchedule
    '
    Me.ListViewPartsSchedule.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderIncomingId, Me.ColumnHeaderPart, Me.ColumnHeaderPartSchedule})
    Me.ListViewPartsSchedule.Location = New System.Drawing.Point(18, 42)
    Me.ListViewPartsSchedule.Name = "ListViewPartsSchedule"
    Me.ListViewPartsSchedule.Size = New System.Drawing.Size(470, 166)
    Me.ListViewPartsSchedule.TabIndex = 27
    Me.ListViewPartsSchedule.View = System.Windows.Forms.View.Details
    '
    'ColumnHeaderIncomingId
    '
    Me.ColumnHeaderIncomingId.Text = "Order ID"
    Me.ColumnHeaderIncomingId.Width = 153
    '
    'ColumnHeaderPart
    '
    Me.ColumnHeaderPart.Text = "Part"
    Me.ColumnHeaderPart.Width = 111
    '
    'ColumnHeaderPartSchedule
    '
    Me.ColumnHeaderPartSchedule.Text = "Schedule"
    Me.ColumnHeaderPartSchedule.Width = 201
    '
    'TimerUpdatePartsScheduled
    '
    Me.TimerUpdatePartsScheduled.Enabled = True
    '
    'FormMain
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
    Me.ClientSize = New System.Drawing.Size(876, 235)
    Me.Controls.Add(Me.ListViewVehiclesToAssemble)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.ListViewPartsSchedule)
    Me.Name = "FormMain"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "ASAP Parts Scheduling System"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub TimerUpdatePartsScheduled_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerUpdatePartsScheduled.Tick
    DisplayScheduledParts()
    ShowVehiclesReadyForAssembly()
  End Sub

  Private _scheduledPartsDisplayed As Integer = 0

  Private Sub DisplayScheduledParts()
    If _removingPartsFromPartsList Then
      Return ' can't display the list while it's being changed
    End If

    If _scheduledPartsDisplayed = _partsList.TotalNumberOfScheduledParts Then
      Return
    End If

    ListViewPartsSchedule.Items.Clear()

    For Each parts As ArrayList In _partsList.List.Values
      For Each part As ScheduledPart In parts
        Dim item As New ListViewItem(part._workOrder.Id)
        item.SubItems.Add(part._part)
        item.SubItems.Add(part._deliveryDate.ToString("yyyy-MM-dd HH:mm:ss"))
        ListViewPartsSchedule.Items.Add(item)
      Next
      _scheduledPartsDisplayed = _partsList.TotalNumberOfScheduledParts
    Next
  End Sub

  Private _vehiclesToAssembleDisplayed As Integer = 0

  Sub ShowVehiclesReadyForAssembly()
    Dim messages As System.Messaging.Message() = _router.GetVehicleAssemblyMessages()

    If (_vehiclesToAssembleDisplayed = messages.Length) Then
      Return
    End If

    Dim formatter As System.Messaging.XmlMessageFormatter
    formatter = New System.Messaging.XmlMessageFormatter(New Type() {GetType(WorkOrder)})

    ListViewVehiclesToAssemble.Items.Clear()

    For Each message As System.Messaging.Message In messages
      message.Formatter = formatter
      Dim wo As WorkOrder = DirectCast(message.Body, WorkOrder)
      Dim item As New ListViewItem(wo.Id)
      ListViewVehiclesToAssemble.Items.Add(item)
    Next
    _vehiclesToAssembleDisplayed = messages.Length
  End Sub

End Class
