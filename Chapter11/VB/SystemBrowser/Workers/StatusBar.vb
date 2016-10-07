Public Class StatusBar
    Inherits System.Windows.Forms.UserControl

  Public Sub Message(ByVal theMessage As String)
    LabelMessage.Text = theMessage
    labelMessage.Update()
  End Sub

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
  Friend WithEvents LabelMessage As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.LabelMessage = New System.Windows.Forms.Label
    Me.SuspendLayout()
    '
    'LabelMessage
    '
    Me.LabelMessage.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelMessage.Location = New System.Drawing.Point(0, 0)
    Me.LabelMessage.Name = "LabelMessage"
    Me.LabelMessage.Size = New System.Drawing.Size(421, 24)
    Me.LabelMessage.TabIndex = 1
    Me.LabelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'StatusBar
    '
    Me.Controls.Add(Me.LabelMessage)
    Me.Name = "StatusBar"
    Me.Size = New System.Drawing.Size(421, 24)
    Me.ResumeLayout(False)

  End Sub

#End Region

End Class
