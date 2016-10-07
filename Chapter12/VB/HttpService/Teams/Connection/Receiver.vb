Imports System.Net.Sockets

Public Class Receiver
  Private _stopRequested As Boolean
  Private _socket As Socket

  Public Sub New(ByVal theSocket As Socket)
    _socket = theSocket
  End Sub

  Public Sub [Stop]()
    _stopRequested = True
  End Sub

  Public Sub Run()
    _stopRequested = False
    While Not _stopRequested
      CheckForIncomingTraffic()
    End While
  End Sub

  Sub CheckForIncomingTraffic()
    If _socket.Available = 0 Then
      FireIdle()
    Else
      FireResponse(_socket)
    End If
  End Sub

  Public Event OnResponse(ByVal theSocket As Socket)
  Sub FireResponse(ByVal theSocket As Socket)
    RaiseEvent OnResponse(theSocket)
  End Sub

  Public Event OnIdle()
  Sub FireIdle()
    RaiseEvent OnIdle()
  End Sub
End Class
