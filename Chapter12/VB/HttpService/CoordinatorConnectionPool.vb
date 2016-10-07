Imports System.Threading

' This class manages the connection pool, including all
' related threading issues. The Coordinator also runs
' a background task to remove idle connections from the pool

Public Class CoordinatorConnectionPool

  Private _idleConnectionMonitorThread As Thread
  Private _pool As New Hashtable 'key is host address, value is ConnectionCoordinator

  Public Sub New()
    _idleConnectionMonitorThread = New Thread(AddressOf RemoveIdleConnections)
    _idleConnectionMonitorThread.IsBackground = True
    _idleConnectionMonitorThread.Start()
  End Sub

  Sub RemoveIdleConnections()
    While True
      Monitor.Enter(Me)
      DoRemoveIdleConnections()
      Monitor.Exit(Me)
      Thread.Sleep(10000) ' wait for 10 seconds
    End While
  End Sub

  Private Sub DoRemoveIdleConnections()
    ' Removing items from a collection during iteration
    ' is not allowed, so we create a clone of the original
    ' collection. We then iterate over the clone, but
    ' remove items from the original collection
    Dim clonedHashtable As Hashtable = DirectCast(_pool.Clone(), Hashtable)

    For Each hostAddress As String In clonedHashtable.Keys
      Dim coordinator As CoordinatorConnection = DirectCast(clonedHashtable(hostAddress), CoordinatorConnection)
      If coordinator.IsIdle Then
        _pool.Remove(hostAddress)
        coordinator.Disconnect()
      End If
    Next
  End Sub

  Private _rxTimeout As New TimeSpan(0, 0, 20) ' twenty seconds

  'get an existing connection or create a new one
  Public Function GetConnection(ByVal theHostAddress As String) As CoordinatorConnection
    Dim coordinator As CoordinatorConnection
    Monitor.Enter(Me) 'don't let other threads alter the pool while we're working on it
    If _pool.Contains(theHostAddress) Then
      coordinator = DirectCast(_pool(theHostAddress), CoordinatorConnection)
    Else
      coordinator = New CoordinatorConnection(theHostAddress, _rxTimeout)
      _pool.Add(theHostAddress, coordinator)
    End If
    Monitor.Exit(Me) 'let other threads in
    Return coordinator
  End Function

End Class
