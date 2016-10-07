Imports System.Collections
Imports System.Threading

' ThreadSemaphore is used by RequestQueue, and encapsulates
' the items required to managed blocked request threads

Public Class ThreadSemaphore
  Public requestEvent As New ManualResetEvent(False)
  Public sequenceNumber As Integer
  Public request As String
  Public response As Byte()
  Public inUse As Boolean
  Public startTime As DateTime

  Public Function Wait(ByVal theDuration As TimeSpan) As Boolean
    Return requestEvent.WaitOne(theDuration, True)
  End Function

  Public Sub Signal()
    requestEvent.Set()
  End Sub
End Class

' RequestQueue maintains a list of blocked request threads.
' When a client sends a request, the thread is blocked and 
' a ThreadSemaphore object is kept in a hashtable. When the
' response returns, the ThreadSemaphore is signaled, allowing
' the request thread to continue and return data to the 
' calling client.

Public Class RequestQueue

  Private Shared _singleton As RequestQueue
  Public Shared ReadOnly Property Singleton() As RequestQueue
    Get
      If _singleton Is Nothing Then
        _singleton = New RequestQueue
      End If
      Return _singleton
    End Get
  End Property

  ' a pool of prebuilt semaphores used with blocked requests.
  ' We support up to 500 concurrent requests. The value is arbitrary
  Private _semaphores(500) As ThreadSemaphore

  ' key is SequenceNumber, value is RequestSemaphore
  Private _blockedRequests As New Hashtable

  Public Sub New()
    For i As Integer = 0 To _semaphores.Length - 1
      Dim semaphore As New ThreadSemaphore
      semaphore.requestEvent = New ManualResetEvent(False)
      _semaphores(i) = semaphore
    Next
  End Sub

  Public Function Add(ByVal theSequenceNumber As Integer, ByVal theRequest As String) As ThreadSemaphore
    SyncLock (Me)
      Dim semaphore As ThreadSemaphore = GetFirstAvailableSemaphore()
      _blockedRequests.Add(theSequenceNumber, semaphore)
      semaphore.requestEvent.Reset()
      semaphore.sequenceNumber = theSequenceNumber
      semaphore.request = theRequest
      semaphore.response = Nothing
      semaphore.startTime = DateTime.Now
      Return semaphore
    End SyncLock
  End Function

  Function GetFirstAvailableSemaphore() As ThreadSemaphore
    SyncLock (Me)
      For Each semaphore As ThreadSemaphore In _semaphores
        If Not semaphore.inUse Then
          semaphore.inUse = True
          Return semaphore
        End If
      Next
    End SyncLock
    Throw New Exception("RequestQueue: No semaphores available")
  End Function

  Public Sub Remove(ByVal theSequenceNumber As Integer)
    SyncLock (Me)
      Dim semaphore As ThreadSemaphore = DirectCast(_blockedRequests(theSequenceNumber), ThreadSemaphore)
      _blockedRequests.Remove(theSequenceNumber)
      semaphore.inUse = False
    End SyncLock
  End Sub

  Public Function [Get](ByVal theSequenceNumber As Integer) As ThreadSemaphore
    Return DirectCast(_blockedRequests(theSequenceNumber), ThreadSemaphore)
  End Function
End Class
