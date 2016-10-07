Public Class FormAbout
    Inherits System.Windows.Forms.Form

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
  Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
  Friend WithEvents ButtonClose As System.Windows.Forms.Button
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FormAbout))
    Me.PictureBox1 = New System.Windows.Forms.PictureBox
    Me.ButtonClose = New System.Windows.Forms.Button
    Me.Label2 = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    Me.SuspendLayout()
    '
    'PictureBox1
    '
    Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
    Me.PictureBox1.Location = New System.Drawing.Point(12, 17)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(32, 33)
    Me.PictureBox1.TabIndex = 7
    Me.PictureBox1.TabStop = False
    '
    'ButtonClose
    '
    Me.ButtonClose.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.ButtonClose.Location = New System.Drawing.Point(298, 140)
    Me.ButtonClose.Name = "ButtonClose"
    Me.ButtonClose.Size = New System.Drawing.Size(74, 29)
    Me.ButtonClose.TabIndex = 6
    Me.ButtonClose.Text = "Close"
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Tahoma", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(10, 139)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(140, 28)
    Me.Label2.TabIndex = 5
    Me.Label2.Text = "Ted Faison - Nov 2005"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(59, 17)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(344, 108)
    Me.Label1.TabIndex = 4
    Me.Label1.Text = "SystemBrowser is a simple application that demonstrates how to build a UI program" & _
    " using Workers, Coordinators, Builders and Binders. By using an event-based arch" & _
    "itecture, most classes are completely decoupled form others, and can be tested i" & _
    "ndependently with a test fixture."
    '
    'FormAbout
    '
    Me.AcceptButton = Me.ButtonClose
    Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
    Me.ClientSize = New System.Drawing.Size(412, 187)
    Me.Controls.Add(Me.PictureBox1)
    Me.Controls.Add(Me.ButtonClose)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Name = "FormAbout"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "About this program"
    Me.ResumeLayout(False)

  End Sub

#End Region

End Class
