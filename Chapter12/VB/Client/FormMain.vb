Public Class FormMain
  Inherits System.Windows.Forms.Form

  Private _coordinator As Coordinator
  Private _numberOfRequestsInProgress As Integer

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    ColumnHeaderResponseMessage.Width = -2  ' auto size last column

    _coordinator = New Coordinator(Me)
    AddHandler _coordinator.OnRequestSent, AddressOf RequestSent
    AddHandler _coordinator.OnResponseReceived, AddressOf ResponseReceived
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
  Friend WithEvents columnHeaderTimestamp As System.Windows.Forms.ColumnHeader
  Friend WithEvents PanelTop As System.Windows.Forms.Panel
  Friend WithEvents NumericUpDownNumberOfPipelinedRequests As System.Windows.Forms.NumericUpDown
  Friend WithEvents ButtonClearList As System.Windows.Forms.Button
  Friend WithEvents Label32 As System.Windows.Forms.Label
  Friend WithEvents LabelRequestsInProgress As System.Windows.Forms.Label
  Friend WithEvents ButtonSend As System.Windows.Forms.Button
  Friend WithEvents Label31 As System.Windows.Forms.Label
  Friend WithEvents Label30 As System.Windows.Forms.Label
  Friend WithEvents ListViewResponses As System.Windows.Forms.ListView
  Friend WithEvents ColumnHeadeResponseTime As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeaderSequenceNumber As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeaderResponseMessage As System.Windows.Forms.ColumnHeader
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.PanelTop = New System.Windows.Forms.Panel
    Me.NumericUpDownNumberOfPipelinedRequests = New System.Windows.Forms.NumericUpDown
    Me.ButtonClearList = New System.Windows.Forms.Button
    Me.Label32 = New System.Windows.Forms.Label
    Me.LabelRequestsInProgress = New System.Windows.Forms.Label
    Me.ButtonSend = New System.Windows.Forms.Button
    Me.Label31 = New System.Windows.Forms.Label
    Me.Label30 = New System.Windows.Forms.Label
    Me.ListViewResponses = New System.Windows.Forms.ListView
    Me.columnHeaderTimestamp = New System.Windows.Forms.ColumnHeader
    Me.ColumnHeadeResponseTime = New System.Windows.Forms.ColumnHeader
    Me.ColumnHeaderSequenceNumber = New System.Windows.Forms.ColumnHeader
    Me.ColumnHeaderResponseMessage = New System.Windows.Forms.ColumnHeader
    Me.PanelTop.SuspendLayout()
    CType(Me.NumericUpDownNumberOfPipelinedRequests, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'PanelTop
    '
    Me.PanelTop.Controls.Add(Me.NumericUpDownNumberOfPipelinedRequests)
    Me.PanelTop.Controls.Add(Me.ButtonClearList)
    Me.PanelTop.Controls.Add(Me.Label32)
    Me.PanelTop.Controls.Add(Me.LabelRequestsInProgress)
    Me.PanelTop.Controls.Add(Me.ButtonSend)
    Me.PanelTop.Controls.Add(Me.Label31)
    Me.PanelTop.Controls.Add(Me.Label30)
    Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
    Me.PanelTop.Location = New System.Drawing.Point(0, 0)
    Me.PanelTop.Name = "PanelTop"
    Me.PanelTop.Size = New System.Drawing.Size(646, 114)
    Me.PanelTop.TabIndex = 63
    '
    'NumericUpDownNumberOfPipelinedRequests
    '
    Me.NumericUpDownNumberOfPipelinedRequests.Location = New System.Drawing.Point(297, 21)
    Me.NumericUpDownNumberOfPipelinedRequests.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
    Me.NumericUpDownNumberOfPipelinedRequests.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
    Me.NumericUpDownNumberOfPipelinedRequests.Name = "NumericUpDownNumberOfPipelinedRequests"
    Me.NumericUpDownNumberOfPipelinedRequests.Size = New System.Drawing.Size(67, 22)
    Me.NumericUpDownNumberOfPipelinedRequests.TabIndex = 57
    Me.NumericUpDownNumberOfPipelinedRequests.Value = New Decimal(New Integer() {1, 0, 0, 0})
    '
    'ButtonClearList
    '
    Me.ButtonClearList.Location = New System.Drawing.Point(526, 80)
    Me.ButtonClearList.Name = "ButtonClearList"
    Me.ButtonClearList.Size = New System.Drawing.Size(98, 28)
    Me.ButtonClearList.TabIndex = 58
    Me.ButtonClearList.Text = "Clear List"
    '
    'Label32
    '
    Me.Label32.AutoSize = True
    Me.Label32.Location = New System.Drawing.Point(134, 53)
    Me.Label32.Name = "Label32"
    Me.Label32.Size = New System.Drawing.Size(135, 18)
    Me.Label32.TabIndex = 60
    Me.Label32.Text = "Requests in progress:"
    Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LabelRequestsInProgress
    '
    Me.LabelRequestsInProgress.AutoSize = True
    Me.LabelRequestsInProgress.Location = New System.Drawing.Point(294, 53)
    Me.LabelRequestsInProgress.Name = "LabelRequestsInProgress"
    Me.LabelRequestsInProgress.Size = New System.Drawing.Size(12, 18)
    Me.LabelRequestsInProgress.TabIndex = 61
    Me.LabelRequestsInProgress.Text = "0"
    Me.LabelRequestsInProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'ButtonSend
    '
    Me.ButtonSend.Location = New System.Drawing.Point(400, 19)
    Me.ButtonSend.Name = "ButtonSend"
    Me.ButtonSend.Size = New System.Drawing.Size(105, 28)
    Me.ButtonSend.TabIndex = 54
    Me.ButtonSend.Text = "Send"
    '
    'Label31
    '
    Me.Label31.AutoSize = True
    Me.Label31.Location = New System.Drawing.Point(8, 95)
    Me.Label31.Name = "Label31"
    Me.Label31.Size = New System.Drawing.Size(76, 18)
    Me.Label31.TabIndex = 55
    Me.Label31.Text = "Responses:"
    '
    'Label30
    '
    Me.Label30.AutoSize = True
    Me.Label30.Location = New System.Drawing.Point(17, 24)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(230, 18)
    Me.Label30.TabIndex = 56
    Me.Label30.Text = "Number of pipelined requests to send:"
    Me.Label30.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'ListViewResponses
    '
    Me.ListViewResponses.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeaderTimestamp, Me.ColumnHeadeResponseTime, Me.ColumnHeaderSequenceNumber, Me.ColumnHeaderResponseMessage})
    Me.ListViewResponses.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ListViewResponses.Location = New System.Drawing.Point(0, 114)
    Me.ListViewResponses.Name = "ListViewResponses"
    Me.ListViewResponses.Size = New System.Drawing.Size(646, 291)
    Me.ListViewResponses.TabIndex = 64
    Me.ListViewResponses.View = System.Windows.Forms.View.Details
    '
    'columnHeaderTimestamp
    '
    Me.columnHeaderTimestamp.Text = "Timestamp"
    Me.columnHeaderTimestamp.Width = 100
    '
    'ColumnHeadeResponseTime
    '
    Me.ColumnHeadeResponseTime.Text = "Response Time"
    Me.ColumnHeadeResponseTime.Width = 150
    '
    'ColumnHeaderSequenceNumber
    '
    Me.ColumnHeaderSequenceNumber.Text = "Sequence Number"
    Me.ColumnHeaderSequenceNumber.Width = 150
    '
    'ColumnHeaderResponseMessage
    '
    Me.ColumnHeaderResponseMessage.Text = "Response Message"
    Me.ColumnHeaderResponseMessage.Width = 200
    '
    'FormMain
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
    Me.ClientSize = New System.Drawing.Size(646, 405)
    Me.Controls.Add(Me.ListViewResponses)
    Me.Controls.Add(Me.PanelTop)
    Me.Name = "FormMain"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Client Test Fixture for Pipelined HTTP Service"
    Me.PanelTop.ResumeLayout(False)
    CType(Me.NumericUpDownNumberOfPipelinedRequests, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub RequestSent()
    _numberOfRequestsInProgress += 1
    LabelRequestsInProgress.Text = _numberOfRequestsInProgress.ToString()
    LabelRequestsInProgress.Update()
    Cursor = Cursors.WaitCursor
  End Sub

  Private Sub ResponseReceived(ByVal theSequenceNumber As Integer, ByVal theResponse As String, ByVal theProcessingTime As TimeSpan)
    Dim s As String = DateTime.Now.ToString("HH:mm:ss.ffff")
    Dim item As New ListViewItem(s)
    s = CInt(theProcessingTime.TotalMilliseconds).ToString()
    item.SubItems.Add(s + " ms")
    item.SubItems.Add(theSequenceNumber.ToString())
    item.SubItems.Add(theResponse)

    listViewResponses.Items.Add(item)

    _numberOfRequestsInProgress -= 1
    LabelRequestsInProgress.Text = _numberOfRequestsInProgress.ToString()
    If _numberOfRequestsInProgress = 0 Then
      Cursor = Cursors.Default
    End If
  End Sub

  Private Sub FormMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
    ColumnHeaderResponseMessage.Width = -2  ' auto size last column
  End Sub

  Private Sub ButtonSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSend.Click
    _coordinator.Send(CInt(NumericUpDownNumberOfPipelinedRequests.Value))
  End Sub

  Private Sub ButtonClearList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearList.Click
    ListViewResponses.Items.Clear()
  End Sub

End Class
