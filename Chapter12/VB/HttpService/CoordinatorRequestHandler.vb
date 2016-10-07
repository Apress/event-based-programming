' CoordinatorRequestHandler is the only object clients interact with
' in HttpService, by calling the Send method

Public Class CoordinatorRequestHandler

  Private Shared _singleton As CoordinatorRequestHandler
  Public Shared ReadOnly Property Singleton() As CoordinatorRequestHandler
    Get
      ' use a lock to ensure that only one
      ' instance of CoordinatorRequestHandler is created
      SyncLock (GetType(CoordinatorRequestHandler))
        If _singleton Is Nothing Then
          _singleton = New CoordinatorRequestHandler
        End If
        Return _singleton
      End SyncLock
    End Get
  End Property

  Private _sequenceNumber As Integer
  Private Function GetNextSequenceNumber() As Integer
    SyncLock (GetType(CoordinatorRequestHandler))
      _sequenceNumber += 1
      Return _sequenceNumber
    End SyncLock
  End Function

  Private _coordinatorConnectionPool As CoordinatorConnectionPool

  Private Sub New()
    _coordinatorConnectionPool = New CoordinatorConnectionPool
  End Sub

  ' This method sends a requests and waits until a response is returned.
  ' The SequenceNumber doesn't need to be returned to the caller, but we
  ' return it to display the number in our test fixture.
  Public Function Send(ByVal theUri As String, ByVal theMessage As String, ByRef theSequenceNumber As Integer) As String
    Dim uri As New Uri(theUri)
    Dim hostAddress As String = uri.Host
    Dim coordinator As CoordinatorConnection

    SyncLock (GetType(CoordinatorRequestHandler))
      coordinator = _coordinatorConnectionPool.GetConnection(hostAddress)
      theSequenceNumber = GetNextSequenceNumber()
    End SyncLock

    ' Send blocks until a response is returned, or a timeout occurs
    Return coordinator.Send(uri.LocalPath, theSequenceNumber, theMessage)
  End Function
End Class
