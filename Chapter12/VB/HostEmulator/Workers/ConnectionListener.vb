Imports System.Net
Imports System.Net.Sockets

Public Class ConnectionListener
  Dim _listener As TcpListener

  Public Sub Listen()
    Dim ipAddress As IPAddress = Dns.Resolve("localhost").AddressList(0)
    _listener = New TcpListener(ipAddress, 8020) ' listen on port 8020
    _listener.Start()

    While True
      ' wait until a client connects
      If Not _listener.Pending() Then
        FireIdle()
      Else
        ' process the client
        Dim socket As Socket = _listener.AcceptSocket()
        FireClientConnected(socket)
      End If
    End While
  End Sub

  Public Event OnClientConnect(ByVal theSocket As Socket)
  Public Sub FireClientConnected(ByVal theSocket As Socket)
    RaiseEvent OnClientConnect(theSocket)
  End Sub

  Public Event OnIdle()
  Public Sub FireIdle()
    RaiseEvent OnIdle()
  End Sub
End Class
