Imports Asap.Cars.CommonTypes

Public Class Router
  Inherits System.ComponentModel.Component

  Public Sub SubmitOrder(ByVal theWorkOrder As WorkOrder)
    MessageQueueOrders.Send(theWorkOrder)
  End Sub

  Public Function GetAllQueuedMessages() As System.Messaging.Message()
    Return MessageQueueOrders.GetAllMessages()
  End Function

  Public Sub ClearQueuedMessages()
    MessageQueueOrders.Purge()
  End Sub

#Region " Component Designer generated code "

  Public Sub New(ByVal Container As System.ComponentModel.IContainer)
    MyClass.New()

    'Required for Windows.Forms Class Composition Designer support
    Container.Add(Me)
  End Sub

  Public Sub New()
    MyBase.New()

    'This call is required by the Component Designer.
    InitializeComponent()

    'Add any initialization after the InitializeComponent() call

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
  Public WithEvents MessageQueueOrders As System.Messaging.MessageQueue
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.MessageQueueOrders = New System.Messaging.MessageQueue
    '
    'MessageQueueOrders
    '
    Me.MessageQueueOrders.Path = "alessandra\Private$\AsapOrders"

  End Sub

#End Region

End Class
