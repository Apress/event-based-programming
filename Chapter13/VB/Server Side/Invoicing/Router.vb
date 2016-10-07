Imports Asap.Cars.CommonTypes

Public Class Router
  Inherits System.ComponentModel.Component

#Region " Component Designer generated code "

  Public Sub New(ByVal Container As System.ComponentModel.IContainer)
    MyClass.New()

    'Required for Windows.Forms Class Composition Designer support
    Container.Add(Me)

    MessageQueueVehiclesToInvoice.BeginReceive()
  End Sub

  Public Sub New()
    MyBase.New()

    'This call is required by the Component Designer.
    InitializeComponent()

    MessageQueueVehiclesToInvoice.BeginReceive()
  End Sub

  'Component overrides dispose to clean up the component list.
  Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing Then
      If Not (components Is Nothing) Then
        components.Dispose()
      End If
    End If
    MyBase.Dispose(disposing)
  End Sub

  'Required by the Component Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Component Designer
  'It can be modified using the Component Designer.
  'Do not modify it using the code editor.
  Friend WithEvents MessageQueueVehiclesToInvoice As System.Messaging.MessageQueue
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.MessageQueueVehiclesToInvoice = New System.Messaging.MessageQueue
    '
    'MessageQueueVehiclesToInvoice
    '
    Me.MessageQueueVehiclesToInvoice.Path = "FormatName:DIRECT=OS:alessandra\private$\asapvehiclestoinvoice"

  End Sub

#End Region

  Private Sub MessageQueueVehiclesToInvoice_ReceiveCompleted(ByVal sender As Object, ByVal e As System.Messaging.ReceiveCompletedEventArgs) Handles MessageQueueVehiclesToInvoice.ReceiveCompleted
    Dim formatter As New System.Messaging.XmlMessageFormatter(New Type() {GetType(WorkOrder)})
    Dim msg As System.Messaging.Message = MessageQueueVehiclesToInvoice.EndReceive(e.AsyncResult)
    msg.Formatter = formatter

    Dim wo As WorkOrder = DirectCast(msg.Body, WorkOrder)

    ' start waiting for the next message
    MessageQueueVehiclesToInvoice.BeginReceive()

    FireMessage(wo)
  End Sub

  Public Event OnMessage(ByVal theWorkOrder As WorkOrder)
  Sub FireMessage(ByVal theWorkOrder As WorkOrder)
    RaiseEvent OnMessage(theWorkOrder)
  End Sub

End Class
