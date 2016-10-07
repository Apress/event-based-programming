Public Class FormSplash
    Inherits System.Windows.Forms.Form

  Public Sub UpdateProgress(ByVal thePercentComplete As Integer)
    If thePercentComplete < 0 Then thePercentComplete = 0
    If thePercentComplete > 100 Then thePercentComplete = 100
    ProgressBar1.Value = thePercentComplete
    ProgressBar1.Update()
  End Sub

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    'Add any initialization after the InitializeComponent() call

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
  Friend WithEvents PanelMain As System.Windows.Forms.Panel
  Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FormSplash))
    Me.PanelMain = New System.Windows.Forms.Panel
    Me.PictureBox1 = New System.Windows.Forms.PictureBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
    Me.PanelMain.SuspendLayout()
    Me.SuspendLayout()
    '
    'PanelMain
    '
    Me.PanelMain.BackColor = System.Drawing.Color.Honeydew
    Me.PanelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.PanelMain.Controls.Add(Me.PictureBox1)
    Me.PanelMain.Controls.Add(Me.Label1)
    Me.PanelMain.Controls.Add(Me.ProgressBar1)
    Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
    Me.PanelMain.Location = New System.Drawing.Point(0, 0)
    Me.PanelMain.Name = "PanelMain"
    Me.PanelMain.Size = New System.Drawing.Size(300, 98)
    Me.PanelMain.TabIndex = 1
    '
    'PictureBox1
    '
    Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
    Me.PictureBox1.Location = New System.Drawing.Point(34, 26)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(34, 32)
    Me.PictureBox1.TabIndex = 1
    Me.PictureBox1.TabStop = False
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(82, 36)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(165, 18)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Loading System Explorer..."
    '
    'ProgressBar1
    '
    Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.ProgressBar1.Location = New System.Drawing.Point(0, 82)
    Me.ProgressBar1.Name = "ProgressBar1"
    Me.ProgressBar1.Size = New System.Drawing.Size(298, 14)
    Me.ProgressBar1.TabIndex = 1
    '
    'FormSplash
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
    Me.ClientSize = New System.Drawing.Size(300, 98)
    Me.Controls.Add(Me.PanelMain)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.Name = "FormSplash"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "FormSplash"
    Me.PanelMain.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

End Class
