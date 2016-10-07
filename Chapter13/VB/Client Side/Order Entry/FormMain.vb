Public Class FormMain
  Inherits System.Windows.Forms.Form

  Private _workerOrderEntry As WorkerOrderEntry
  Private _coordinatorOrderEntry As CoordinatorOrderEntry
  Private _router As Router

  Sub Build()
    _workerOrderEntry = New WorkerOrderEntry
    _coordinatorOrderEntry = New CoordinatorOrderEntry
    _router = New Router
  End Sub

  Sub Bind()
    _workerOrderEntry.OnGetColors = AddressOf _coordinatorOrderEntry.GetColors 'delegate
    _workerOrderEntry.OnGetOptions = AddressOf _coordinatorOrderEntry.GetOptions 'delegate
    _workerOrderEntry.OnGetStyles = AddressOf _coordinatorOrderEntry.GetStyles 'delegate
    AddHandler _workerOrderEntry.OnSubmitOrder, AddressOf _coordinatorOrderEntry.SubmitOrder 'event
    _workerOrderEntry.OnComputeCostOfOptions = AddressOf _coordinatorOrderEntry.ComputeCostOfOptions 'delegate

    _coordinatorOrderEntry.OnGetColors = AddressOf _router.GetColors 'delegate
    _coordinatorOrderEntry.OnGetOptions = AddressOf _router.GetOptions 'delegate
    _coordinatorOrderEntry.OnGetStyles = AddressOf _router.GetStyles 'delegate
    AddHandler _coordinatorOrderEntry.OnSubmit, AddressOf _router.SubmitOrder 'event
  End Sub

  Sub SetupUi()
    Controls.Add(_workerOrderEntry.PanelMain)
    PopulateModels()
  End Sub

  Sub PopulateModels()
    Try
      Dim models As String() = _router.GetModels()
      _workerOrderEntry.PopulateModels(models)
    Catch ex As Exception
      Dim msg As String = String.Format("The server must be running before starting the Order Entry program. " + _
                                  "To run the server, start OrderProcessingHostProgram.exe.\nException Details: [{0}]", ex.Message)
      MessageBox.Show(msg, "An exception occurred while connecting to server")
      Throw ex
    End Try
  End Sub

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    Build()
    Bind()

    SetupUi()
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
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
    Me.ClientSize = New System.Drawing.Size(468, 387)
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "ASAP Cars - Custom Tailor Your Car"

  End Sub

#End Region

  Shared Sub Main()
    Dim _formMain As FormMain = Nothing
    Try
      _formMain = New FormMain
    Catch ex As Exception
      ' exceptions typically occur if the client can't connect to the server
      MessageBox.Show(ex.Message, "An exception occurred")
      Return
    End Try

    Application.Run(_formMain)
  End Sub

End Class
