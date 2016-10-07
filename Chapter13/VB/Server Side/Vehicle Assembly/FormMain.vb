Imports Asap.Cars.CommonTypes

Public Class FormMain
  Inherits System.Windows.Forms.Form

  ' manages connections to incoming and outgoing message queues
  Private _router As Router

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    _router = New Router
    AddHandler _router.OnMessage, AddressOf HandleOrder
  End Sub

  Private Sub HandleOrder(ByVal theWorkOrder As WorkOrder)
    ' a WorkerOrder has arrived. Skip the actual vehicle
    ' assembly details and just issue and invoice
    _router.SubmitForInvoicing(theWorkOrder)
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
    Me.ClientSize = New System.Drawing.Size(405, 133)
    Me.Name = "FormMain"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Vehicle Assembly"

  End Sub

#End Region

End Class
