Imports System.Net
Imports System.Net.Sockets

Public Class ConnectionProcessor
  Private _socket As Socket

  Public Sub New(ByVal theSocket As Socket)
    _socket = theSocket
  End Sub

  Public Sub WaitForRequests()
    While True
      If _socket.Available > 0 Then
        FireRequestStarted(_socket)
      End If

      FireIdle()
    End While
  End Sub

  Public Event OnRequestStarted(ByVal theSocket As Socket)
  Public Sub FireRequestStarted(ByVal theSocket As Socket)
    RaiseEvent OnRequestStarted(theSocket)
  End Sub

  Public Event OnRequestProcessed(ByVal theRequest As String, ByVal theSequenceNumber As Integer, ByVal theDuration As Integer, ByVal theResponse As String)
  Public Sub FireRequestProcessed(ByVal theRequest As String, ByVal theSequenceNumber As Integer, ByVal theDuration As Integer, ByVal theResponse As String)
    RaiseEvent OnRequestProcessed(theRequest, theSequenceNumber, theDuration, theResponse)
  End Sub

  Public Event OnIdle()
  Public Sub FireIdle()
    RaiseEvent OnIdle()
  End Sub
End Class
