Imports System.Threading
Imports System.Net.Sockets

Public Class CoordinatorIncomingTraffic
  Private _uiControl As Control  ' used for thread synchronization with events
  Private _listener As ConnectionListener
  Private _basicProcessingTime As Integer  ' in ms
  Private processingTime As Integer      ' in ms
  Private _random As New Random    ' used to change the processing time

  Public Sub New(ByVal theUiControl As Control)
    _uiControl = theUiControl
    _basicProcessingTime = 2000  ' 2 secs

    _listener = New ConnectionListener
    AddHandler _listener.OnClientConnect, AddressOf ClientConnected
    AddHandler _listener.OnIdle, AddressOf WaitForTenMs
  End Sub

  Public Sub Run()
    Dim listenerThread As New Thread(AddressOf _listener.Listen)
    listenerThread.IsBackground = True
    listenerThread.Name = "ConnectionListener"
    listenerThread.Start()
  End Sub

  Sub ClientConnected(ByVal theSocket As Socket)
    ' dispatch a thread to handle all the requests
    ' on the connected socket

    Dim connection As New ConnectionProcessor(theSocket)
    AddHandler connection.OnRequestStarted, AddressOf RequestStarted
    AddHandler connection.OnRequestProcessed, AddressOf FireRequestProcessed
    AddHandler connection.OnIdle, AddressOf WaitForTenMs

    Dim thread As New Thread(AddressOf connection.WaitForRequests)
    thread.IsBackground = True
    thread.Name = "ConnectionProcessor"
    thread.Start()

    FireClientConnected()
  End Sub

  Sub RequestStarted(ByVal theSocket As Socket)
    FireRequestStarted()

    Dim httpRequest As New HttpRequest(theSocket)
    HttpRequest.Get()  ' get the entire incoming request

    Dim request As New RequestProcessor(theSocket, httpRequest)
    AddHandler request.OnRequestProcessed, AddressOf FireRequestProcessed
    AddHandler request.OnIdle, AddressOf SimulateProcessingTime

    ' process request on a separate thread, to 
    ' allowing incoming requests to be pipelined
    Dim thread As New Thread(AddressOf request.HandleRequest)
    Thread.IsBackground = True
    Thread.Name = "RequestProcessor"
    Thread.Start()
  End Sub

  Function GetNextProcessingTime() As Integer
    SyncLock (Me)
      processingTime = _random.Next(_basicProcessingTime - 1000, _basicProcessingTime + 1000)
      Return processingTime
    End SyncLock
  End Function

  Private Sub WaitForTenMs()
    Thread.Sleep(10)
  End Sub

  Private Sub SimulateProcessingTime()
    Dim duration As Integer = GetNextProcessingTime()
    Thread.Sleep(duration)
  End Sub

#Region "Events"
  ' ***********************************************************
  ' the following Fire methods switch to the UI thread
  ' before firing events
  ' ***********************************************************

  Public Delegate Sub ClientConnectedHandler()
  Public Event OnClientConnected As ClientConnectedHandler
  Public Sub FireClientConnected()
    _uiControl.Invoke(New ClientConnectedHandler(AddressOf DoFireClientConnected))
  End Sub
  Public Sub DoFireClientConnected()
    RaiseEvent OnClientConnected()
  End Sub

  Public Delegate Sub RequestStartedHandler()
  Public Event OnRequestStarted As RequestStartedHandler
  Public Sub FireRequestStarted()
    _uiControl.Invoke(New RequestStartedHandler(AddressOf DoFireRequestStarted))
  End Sub
  Public Sub DoFireRequestStarted()
    RaiseEvent OnRequestStarted()
  End Sub

  Public Delegate Sub RequestProcessedHandler(ByVal theRequest As String, ByVal theSequenceNumber As Integer, ByVal theDuration As Integer, ByVal theResponse As String)
  Public Event OnRequestProcessed As RequestProcessedHandler
  Public Sub FireRequestProcessed(ByVal theRequest As String, ByVal theSequenceNumber As Integer, ByVal theDuration As Integer, ByVal theResponse As String)
    _uiControl.Invoke(New RequestProcessedHandler(AddressOf DoFireRequestProcessed), New Object() {theRequest, theSequenceNumber, theDuration, theResponse})
  End Sub
  Public Sub DoFireRequestProcessed(ByVal theRequest As String, ByVal theSequenceNumber As Integer, ByVal theDuration As Integer, ByVal theResponse As String)
    RaiseEvent OnRequestProcessed(theRequest, theSequenceNumber, theDuration, theResponse)
  End Sub
#End Region

End Class
