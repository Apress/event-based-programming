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

    System.Threading.Thread.CurrentThread.Name = "User Interface"
    _router = New Router
    AddHandler _router.OnMessage, AddressOf HandleOrder
  End Sub

  Delegate Sub WorkOrderHandler(ByVal theWorkOrder As WorkOrder)
  Private Sub HandleOrder(ByVal theWorkOrder As WorkOrder)
    ' process order on the UI thread
    Me.Invoke(New WorkOrderHandler(AddressOf DoHandleOrder), New Object() {theWorkOrder})
  End Sub

  Private _invoiceCount As Integer = 0
  Private Sub DoHandleOrder(ByVal theWorkOrder As WorkOrder)
    ' just update the displayed info
    _invoiceCount += 1
    LabelInvoicesGenerated.Text = _invoiceCount.ToString()
    LabelModel.Text = theWorkOrder.Model
    LabelStyle.Text = theWorkOrder.Style
    LabelColor.Text = theWorkOrder.Color

    Dim options As String = String.Empty
    For i As Integer = 0 To theWorkOrder.Options.Length - 1
      options += String.Format("{0};", theWorkOrder.Options(i).Name)
    Next
    LabelOptions.Text = options
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
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents LabelOptions As System.Windows.Forms.Label
  Friend WithEvents LabelColor As System.Windows.Forms.Label
  Friend WithEvents LabelStyle As System.Windows.Forms.Label
  Friend WithEvents LabelModel As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents LabelInvoicesGenerated As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox
    Me.LabelOptions = New System.Windows.Forms.Label
    Me.LabelColor = New System.Windows.Forms.Label
    Me.LabelStyle = New System.Windows.Forms.Label
    Me.LabelModel = New System.Windows.Forms.Label
    Me.Label5 = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.LabelInvoicesGenerated = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.LabelOptions)
    Me.GroupBox1.Controls.Add(Me.LabelColor)
    Me.GroupBox1.Controls.Add(Me.LabelStyle)
    Me.GroupBox1.Controls.Add(Me.LabelModel)
    Me.GroupBox1.Controls.Add(Me.Label5)
    Me.GroupBox1.Controls.Add(Me.Label4)
    Me.GroupBox1.Controls.Add(Me.Label3)
    Me.GroupBox1.Controls.Add(Me.Label2)
    Me.GroupBox1.Location = New System.Drawing.Point(35, 72)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(338, 160)
    Me.GroupBox1.TabIndex = 5
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Details for last invoice generated"
    '
    'LabelOptions
    '
    Me.LabelOptions.Location = New System.Drawing.Point(72, 104)
    Me.LabelOptions.Name = "LabelOptions"
    Me.LabelOptions.Size = New System.Drawing.Size(250, 44)
    Me.LabelOptions.TabIndex = 7
    Me.LabelOptions.Text = "<options>"
    '
    'LabelColor
    '
    Me.LabelColor.AutoSize = True
    Me.LabelColor.Location = New System.Drawing.Point(72, 81)
    Me.LabelColor.Name = "LabelColor"
    Me.LabelColor.Size = New System.Drawing.Size(50, 18)
    Me.LabelColor.TabIndex = 6
    Me.LabelColor.Text = "<color>"
    '
    'LabelStyle
    '
    Me.LabelStyle.AutoSize = True
    Me.LabelStyle.Location = New System.Drawing.Point(72, 58)
    Me.LabelStyle.Name = "LabelStyle"
    Me.LabelStyle.Size = New System.Drawing.Size(48, 18)
    Me.LabelStyle.TabIndex = 5
    Me.LabelStyle.Text = "<style>"
    '
    'LabelModel
    '
    Me.LabelModel.AutoSize = True
    Me.LabelModel.Location = New System.Drawing.Point(72, 35)
    Me.LabelModel.Name = "LabelModel"
    Me.LabelModel.Size = New System.Drawing.Size(57, 18)
    Me.LabelModel.TabIndex = 4
    Me.LabelModel.Text = "<model>"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(12, 104)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(55, 18)
    Me.Label5.TabIndex = 3
    Me.Label5.Text = "Options:"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(26, 81)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(41, 18)
    Me.Label4.TabIndex = 2
    Me.Label4.Text = "Color:"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(28, 58)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(38, 18)
    Me.Label3.TabIndex = 1
    Me.Label3.Text = "Style:"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(22, 35)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(45, 18)
    Me.Label2.TabIndex = 0
    Me.Label2.Text = "Model:"
    '
    'LabelInvoicesGenerated
    '
    Me.LabelInvoicesGenerated.AutoSize = True
    Me.LabelInvoicesGenerated.Location = New System.Drawing.Point(217, 31)
    Me.LabelInvoicesGenerated.Name = "LabelInvoicesGenerated"
    Me.LabelInvoicesGenerated.Size = New System.Drawing.Size(12, 18)
    Me.LabelInvoicesGenerated.TabIndex = 4
    Me.LabelInvoicesGenerated.Text = "0"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(35, 31)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(187, 18)
    Me.Label1.TabIndex = 3
    Me.Label1.Text = "Number of invoices generated:"
    '
    'FormMain
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
    Me.ClientSize = New System.Drawing.Size(408, 263)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.LabelInvoicesGenerated)
    Me.Controls.Add(Me.Label1)
    Me.Name = "FormMain"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Invoicing"
    Me.GroupBox1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

End Class
