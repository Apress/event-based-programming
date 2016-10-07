Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

'CoordinatorConnection manages a team of two workers:
'Connection and Receiver. Together these classes
'handle pipelined requests, blocking sender thread.
'When a response comes back, using its SequenceNumber
'it is matched with a request thread and that thread
'is unblocked.

Public Class CoordinatorConnection
  Private _blockedRequests As RequestQueue  ' a queue of blocked send threads
  Private _receiver As Receiver             ' listens for incoming traffic
  Private _connection As Connection         ' sends requests and handles responses
  Private _rxTimeout As TimeSpan            ' time to wait for a response
  Private _receiverThread As Thread         ' background receiver thread

  Public ReadOnly Property IsIdle() As Boolean
    Get
      Return _connection.IsIdle
    End Get
  End Property

  Public Sub New(ByVal theHostAddress As String, ByVal theRxTimeout As TimeSpan)
    _rxTimeout = theRxTimeout
    _blockedRequests = New RequestQueue

    _connection = New Connection(theHostAddress)
    AddHandler _connection.OnConnected, AddressOf ConnectHandler
    AddHandler _connection.OnDisconnected, AddressOf DisconnectHandler
  End Sub

  ' returns the response
  Public Function Send(ByVal theLocalPath As String, ByVal theSequenceNumber As Integer, ByVal theMessage As String) As String
    Dim semaphore As ThreadSemaphore = Nothing

    SyncLock (Me)
      ' we use a lock here, to prevent concurrent requests
      ' from getting mixed together on their way out
      _connection.Connect()
      _connection.LastActivity = DateTime.Now
      Dim request As New HttpRequest(_connection.Socket)
      request.Post(theLocalPath, theSequenceNumber, theMessage)
      semaphore = _blockedRequests.Add(theSequenceNumber, theMessage)
    End SyncLock

    ' block until the response arrives, or a timeout occurs
    If Not semaphore.Wait(_rxTimeout) Then
      Throw New Exception("No response received")
    End If

    ' get the response from the semaphore
    Dim response As Byte() = semaphore.response
    _blockedRequests.Remove(theSequenceNumber)
    Return Encoding.UTF8.GetString(response)
  End Function

  Public Sub Disconnect()
    _connection.Disconnect()
  End Sub

  Sub HandleResponse(ByVal theSocket As Socket)
    ' read the response
    Dim response As New HttpResponse(theSocket)
    response.Get()

    ' get the semaphore for the blocked request thread
    Dim semaphore As ThreadSemaphore = _blockedRequests.Get(response.SequenceNumber)
    If semaphore Is Nothing Then
      Throw New Exception("No pending request found for response")
    End If

    ' save the response in the semaphore
    semaphore.response = response.Body

    ' unblock the request thread waiting for this response
    semaphore.Signal()
  End Sub

  Private Sub ConnectHandler(ByVal theSocket As Socket)
    _receiver = New Receiver(theSocket)
    AddHandler _receiver.OnIdle, AddressOf ReceiverIdle
    AddHandler _receiver.OnResponse, AddressOf HandleResponse
    _receiverThread = New Thread(AddressOf _receiver.Run)
    _receiverThread.Name = "Receiver"
    _receiverThread.IsBackground = True
    _receiverThread.Start()
  End Sub

  Private Sub DisconnectHandler()
    _receiver.Stop()
    _receiverThread.Join()  ' wait for thread to stop
    _receiver = Nothing
  End Sub

  Sub ReceiverIdle()
    Thread.Sleep(10)
  End Sub

End Class
