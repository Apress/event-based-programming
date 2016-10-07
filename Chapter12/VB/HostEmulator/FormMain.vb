Public Class FormMain
  Inherits System.Windows.Forms.Form

  Private _numberOfActiveConnections As Integer
  Private _numberOfRequestsReceived As Integer
  Private _numberOfRequestsInProgress As Integer

  Private _incomingTraffic As CoordinatorIncomingTraffic

  Sub ListenForRequests()
    _incomingTraffic = New CoordinatorIncomingTraffic(Me)

    AddHandler _incomingTraffic.OnClientConnected, AddressOf ClientConnected
    AddHandler _incomingTraffic.OnRequestStarted, AddressOf RequestStarted
    AddHandler _incomingTraffic.OnRequestProcessed, AddressOf RequestProcessed

    _incomingTraffic.Run()
  End Sub

  Private Sub ClientConnected()
    _numberOfActiveConnections += 1
    LabelActiveConnections.Text = _numberOfActiveConnections.ToString()
  End Sub

  Public Sub RequestStarted()
    _numberOfRequestsReceived += 1
    LabelRequestsReceived.Text = _numberOfRequestsReceived.ToString()

    _numberOfRequestsInProgress += 1
    LabelRequestsInProgress.Text = _numberOfRequestsInProgress.ToString() + " ms"
  End Sub

  Public Sub RequestProcessed(ByVal theRequest As String, ByVal theSequenceNumber As Integer, ByVal theDuration As Integer, ByVal theResponse As String)
    _numberOfRequestsInProgress -= 1
    LabelRequestsInProgress.Text = _numberOfRequestsInProgress.ToString()

    Dim item As New ListViewItem(DateTime.Now.ToString("HH:mm:ss.fff"))
    item.SubItems.Add(theDuration.ToString())
    item.SubItems.Add(theSequenceNumber.ToString())
    item.SubItems.Add(theResponse)
    ListViewResponses.Items.Add(item)
  End Sub

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    ColumnHeaderResponse.Width = -2  ' autosize last column
    ListenForRequests()

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
  Friend WithEvents PanelCenter As System.Windows.Forms.Panel
  Friend WithEvents ListViewResponses As System.Windows.Forms.ListView
  Friend WithEvents PanelTop As System.Windows.Forms.Panel
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents LabelActiveConnections As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents LabelRequestsReceived As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents LabelRequestsInProgress As System.Windows.Forms.Label
  Friend WithEvents ButtonClearList As System.Windows.Forms.Button
  Friend WithEvents ColumnHeaderTimestamp As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeaderProcessingTime As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeaderSequenceNumber As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeaderResponse As System.Windows.Forms.ColumnHeader
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.PanelMain = New System.Windows.Forms.Panel
    Me.PanelCenter = New System.Windows.Forms.Panel
    Me.ListViewResponses = New System.Windows.Forms.ListView
    Me.ColumnHeaderTimestamp = New System.Windows.Forms.ColumnHeader
    Me.ColumnHeaderProcessingTime = New System.Windows.Forms.ColumnHeader
    Me.ColumnHeaderSequenceNumber = New System.Windows.Forms.ColumnHeader
    Me.ColumnHeaderResponse = New System.Windows.Forms.ColumnHeader
    Me.PanelTop = New System.Windows.Forms.Panel
    Me.Label1 = New System.Windows.Forms.Label
    Me.LabelActiveConnections = New System.Windows.Forms.Label
    Me.Label6 = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.LabelRequestsReceived = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.LabelRequestsInProgress = New System.Windows.Forms.Label
    Me.ButtonClearList = New System.Windows.Forms.Button
    Me.PanelMain.SuspendLayout()
    Me.PanelCenter.SuspendLayout()
    Me.PanelTop.SuspendLayout()
    Me.SuspendLayout()
    '
    'PanelMain
    '
    Me.PanelMain.Controls.Add(Me.PanelCenter)
    Me.PanelMain.Controls.Add(Me.PanelTop)
    Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
    Me.PanelMain.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.PanelMain.Location = New System.Drawing.Point(0, 0)
    Me.PanelMain.Name = "PanelMain"
    Me.PanelMain.Size = New System.Drawing.Size(671, 383)
    Me.PanelMain.TabIndex = 2
    '
    'PanelCenter
    '
    Me.PanelCenter.Controls.Add(Me.ListViewResponses)
    Me.PanelCenter.Dock = System.Windows.Forms.DockStyle.Fill
    Me.PanelCenter.Location = New System.Drawing.Point(0, 121)
    Me.PanelCenter.Name = "PanelCenter"
    Me.PanelCenter.Size = New System.Drawing.Size(671, 262)
    Me.PanelCenter.TabIndex = 9
    '
    'ListViewResponses
    '
    Me.ListViewResponses.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderTimestamp, Me.ColumnHeaderProcessingTime, Me.ColumnHeaderSequenceNumber, Me.ColumnHeaderResponse})
    Me.ListViewResponses.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ListViewResponses.Location = New System.Drawing.Point(0, 0)
    Me.ListViewResponses.Name = "ListViewResponses"
    Me.ListViewResponses.Size = New System.Drawing.Size(671, 262)
    Me.ListViewResponses.TabIndex = 1
    Me.ListViewResponses.View = System.Windows.Forms.View.Details
    '
    'ColumnHeaderTimestamp
    '
    Me.ColumnHeaderTimestamp.Text = "Timestamp"
    Me.ColumnHeaderTimestamp.Width = 100
    '
    'ColumnHeaderProcessingTime
    '
    Me.ColumnHeaderProcessingTime.Text = "Processing Time"
    Me.ColumnHeaderProcessingTime.Width = 150
    '
    'ColumnHeaderSequenceNumber
    '
    Me.ColumnHeaderSequenceNumber.Text = "Sequence Number"
    Me.ColumnHeaderSequenceNumber.Width = 150
    '
    'ColumnHeaderResponse
    '
    Me.ColumnHeaderResponse.Text = "Response"
    Me.ColumnHeaderResponse.Width = 200
    '
    'PanelTop
    '
    Me.PanelTop.Controls.Add(Me.Label1)
    Me.PanelTop.Controls.Add(Me.LabelActiveConnections)
    Me.PanelTop.Controls.Add(Me.Label6)
    Me.PanelTop.Controls.Add(Me.Label4)
    Me.PanelTop.Controls.Add(Me.LabelRequestsReceived)
    Me.PanelTop.Controls.Add(Me.Label2)
    Me.PanelTop.Controls.Add(Me.LabelRequestsInProgress)
    Me.PanelTop.Controls.Add(Me.ButtonClearList)
    Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
    Me.PanelTop.Location = New System.Drawing.Point(0, 0)
    Me.PanelTop.Name = "PanelTop"
    Me.PanelTop.Size = New System.Drawing.Size(671, 121)
    Me.PanelTop.TabIndex = 8
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(8, 97)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(104, 20)
    Me.Label1.TabIndex = 8
    Me.Label1.Text = "Responses Sent"
    '
    'LabelActiveConnections
    '
    Me.LabelActiveConnections.AutoSize = True
    Me.LabelActiveConnections.Location = New System.Drawing.Point(308, 12)
    Me.LabelActiveConnections.Name = "LabelActiveConnections"
    Me.LabelActiveConnections.Size = New System.Drawing.Size(13, 20)
    Me.LabelActiveConnections.TabIndex = 1
    Me.LabelActiveConnections.Text = "0"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(76, 66)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(198, 19)
    Me.Label6.TabIndex = 5
    Me.Label6.Text = "Number of requests received:"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(59, 39)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(215, 19)
    Me.Label4.TabIndex = 2
    Me.Label4.Text = "Number of requests in progress:"
    '
    'LabelRequestsReceived
    '
    Me.LabelRequestsReceived.AutoSize = True
    Me.LabelRequestsReceived.Location = New System.Drawing.Point(308, 66)
    Me.LabelRequestsReceived.Name = "LabelRequestsReceived"
    Me.LabelRequestsReceived.Size = New System.Drawing.Size(13, 20)
    Me.LabelRequestsReceived.TabIndex = 6
    Me.LabelRequestsReceived.Text = "0"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(70, 12)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(203, 19)
    Me.Label2.TabIndex = 0
    Me.Label2.Text = "Number of active connections:"
    '
    'LabelRequestsInProgress
    '
    Me.LabelRequestsInProgress.AutoSize = True
    Me.LabelRequestsInProgress.Location = New System.Drawing.Point(308, 39)
    Me.LabelRequestsInProgress.Name = "LabelRequestsInProgress"
    Me.LabelRequestsInProgress.Size = New System.Drawing.Size(13, 20)
    Me.LabelRequestsInProgress.TabIndex = 3
    Me.LabelRequestsInProgress.Text = "0"
    '
    'ButtonClearList
    '
    Me.ButtonClearList.Location = New System.Drawing.Point(549, 87)
    Me.ButtonClearList.Name = "ButtonClearList"
    Me.ButtonClearList.Size = New System.Drawing.Size(109, 28)
    Me.ButtonClearList.TabIndex = 7
    Me.ButtonClearList.Text = "Clear List"
    '
    'FormMain
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
    Me.ClientSize = New System.Drawing.Size(671, 383)
    Me.Controls.Add(Me.PanelMain)
    Me.Name = "FormMain"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Pipelined HTTP Host Emulator"
    Me.PanelMain.ResumeLayout(False)
    Me.PanelCenter.ResumeLayout(False)
    Me.PanelTop.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub ButtonClearList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearList.Click
    _numberOfRequestsReceived = 0
    LabelRequestsReceived.Text = _numberOfRequestsReceived.ToString()
    ListViewResponses.Items.Clear()
  End Sub

  Private Sub FormMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
    ColumnHeaderResponse.Width = -2  ' autosize last column
  End Sub
End Class
