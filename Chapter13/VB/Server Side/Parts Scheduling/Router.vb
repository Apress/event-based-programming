Imports Asap.Cars.CommonTypes

Public Class Router
  Inherits System.ComponentModel.Component

  Public Sub SubmitForAssembly(ByVal theWorkOrder As WorkOrder)
    MessageQueueVehiclesToAssemble.Send(theWorkOrder)
  End Sub

  Public Function GetVehicleAssemblyMessages() As System.Messaging.Message()
    Return MessageQueueVehiclesToAssemble.GetAllMessages()
  End Function

#Region " Component Designer generated code "

  Public Sub New(ByVal Container As System.ComponentModel.IContainer)
    MyClass.New()

    'Required for Windows.Forms Class Composition Designer support
    Container.Add(Me)

    ' start waiting for the first incoming message
    MessageQueueOrders.BeginReceive()
  End Sub

  Public Sub New()
    MyBase.New()

    'This call is required by the Component Designer.
    InitializeComponent()

    ' start waiting for the first incoming message
    MessageQueueOrders.BeginReceive()
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
  Friend WithEvents MessageQueueOrders As System.Messaging.MessageQueue
  Friend WithEvents MessageQueueVehiclesToAssemble As System.Messaging.MessageQueue
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.MessageQueueOrders = New System.Messaging.MessageQueue
    Me.MessageQueueVehiclesToAssemble = New System.Messaging.MessageQueue
    '
    'MessageQueueOrders
    '
    Me.MessageQueueOrders.Path = "alessandra\Private$\AsapOrders"
    '
    'MessageQueueVehiclesToAssemble
    '
    Me.MessageQueueVehiclesToAssemble.Path = "alessandra\Private$\AsapVehiclesToAssemble"

  End Sub

#End Region

  Private Sub MessageQueueOrders_ReceiveCompleted(ByVal sender As Object, ByVal e As System.Messaging.ReceiveCompletedEventArgs) Handles MessageQueueOrders.ReceiveCompleted
    Dim formatter As New System.Messaging.XmlMessageFormatter(New Type() {GetType(WorkOrder)})
    Dim msg As System.Messaging.Message = MessageQueueOrders.EndReceive(e.AsyncResult)
    msg.Formatter = formatter

    Dim wo As WorkOrder = DirectCast(msg.Body, WorkOrder)

    ' start waiting for the next message
    MessageQueueOrders.BeginReceive()

    FireMessage(wo)
  End Sub

  Public Event OnMessage(ByVal theWorkOrder As WorkOrder)
  Private Sub FireMessage(ByVal theWorkOrder As WorkOrder)
    RaiseEvent OnMessage(theWorkOrder)
  End Sub

End Class
