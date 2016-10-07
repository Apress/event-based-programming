Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp

Imports Asap.Cars.OrderProcessor

Public Class FormMain
  Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    'configure the server component to listen for orders
    Dim channel As New TcpChannel(8011)
    ChannelServices.RegisterChannel(channel)
    RemotingConfiguration.RegisterWellKnownServiceType(GetType(OrderSystem), "AsapOrders", WellKnownObjectMode.Singleton)
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
  Friend WithEvents LabelTotalOrdersReceived As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TimerOrdersReceived As System.Windows.Forms.Timer
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Me.LabelTotalOrdersReceived = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    Me.TimerOrdersReceived = New System.Windows.Forms.Timer(Me.components)
    Me.SuspendLayout()
    '
    'LabelTotalOrdersReceived
    '
    Me.LabelTotalOrdersReceived.AutoSize = True
    Me.LabelTotalOrdersReceived.Location = New System.Drawing.Point(268, 57)
    Me.LabelTotalOrdersReceived.Name = "LabelTotalOrdersReceived"
    Me.LabelTotalOrdersReceived.Size = New System.Drawing.Size(12, 18)
    Me.LabelTotalOrdersReceived.TabIndex = 3
    Me.LabelTotalOrdersReceived.Text = "0"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(133, 55)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(134, 18)
    Me.Label1.TabIndex = 2
    Me.Label1.Text = "Total orders received:"
    '
    'TimerOrdersReceived
    '
    Me.TimerOrdersReceived.Enabled = True
    '
    'FormMain
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
    Me.ClientSize = New System.Drawing.Size(412, 130)
    Me.Controls.Add(Me.LabelTotalOrdersReceived)
    Me.Controls.Add(Me.Label1)
    Me.Name = "FormMain"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "ASAP Order Status"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub TimerOrdersReceived_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerOrdersReceived.Tick
    UpdateOrdersReceived()
  End Sub

  Private _ordersReceived As Integer
  Sub UpdateOrdersReceived()
    Dim c As Integer = OrderSystem.OrdersReceived
    If c = _ordersReceived Then Return

    LabelTotalOrdersReceived.Text = c.ToString()
    _ordersReceived = c
  End Sub

End Class
