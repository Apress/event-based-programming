Imports System.Net
Imports System.Net.Sockets

Public Class Connection
  Private _socket As Socket
  Public ReadOnly Property Socket() As Socket
    Get
      Return _socket
    End Get
  End Property

  Private _hostAddress As String
  Public Property HostAddress() As String
    Get
      Return _hostAddress
    End Get
    Set(ByVal Value As String)
      _hostAddress = Value
    End Set
  End Property

  Public ReadOnly Property Connected() As Boolean
    Get
      Return Not Socket Is Nothing
    End Get
  End Property

  Private _lastActivity As DateTime = DateTime.Now
  Public Property LastActivity() As DateTime
    Get
      Return _lastActivity
    End Get
    Set(ByVal Value As DateTime)
      _lastActivity = Value
    End Set
  End Property

  ' theHostAddress can be an IP or a DNS Address
  Public Sub New(ByVal theHostAddress As String)
    _hostAddress = theHostAddress
  End Sub

  Private TwentyMinutes As TimeSpan = New TimeSpan(0, 20, 0)
  Public ReadOnly Property IsIdle() As Boolean
    Get
      Return TimeSpan.op_GreaterThan(DateTime.Now.Subtract(LastActivity), TwentyMinutes)
    End Get
  End Property

  Public Sub Connect()
    If Connected Then Return

    _socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
    Dim hostEntry As IPHostEntry = Dns.GetHostByName(HostAddress)
    Dim endPoint As New IPEndPoint(hostEntry.AddressList(0), 8020)
    Socket.Connect(EndPoint)

    FireConnected(Socket)
  End Sub

  Public Sub Disconnect()
    If _socket Is Nothing Then Return

    _socket.Close()
    _socket = Nothing

    FireDisconnected()
  End Sub

  Public Event OnConnected(ByVal theSocket As Socket)
  Sub FireConnected(ByVal theSocket As Socket)
    RaiseEvent OnConnected(theSocket)
  End Sub

  Public Event OnDisconnected()
  Sub FireDisconnected()
    RaiseEvent OnDisconnected()
  End Sub
End Class
