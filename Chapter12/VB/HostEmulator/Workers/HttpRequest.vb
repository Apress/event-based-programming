Imports System.Net
Imports System.Net.Sockets


Public Class HttpRequest
  Private _socket As Socket

  ' all the message headers
  Private _header As HttpRequestHeader
  Public ReadOnly Property Header() As HttpRequestHeader
    Get
      Return _header
    End Get
  End Property

  ' the message body
  Private _body As Byte()
  Public ReadOnly Property Body() As Byte()
    Get
      Return _body
    End Get
  End Property

  Public ReadOnly Property SequenceNumber() As Integer
    Get
      Return _header.SequenceNumber()
    End Get
  End Property

  Public Sub New(ByVal theSocket As Socket)
    _socket = theSocket
  End Sub

  ' reads the request from a stream
  Public Sub [Get]()
    Dim networkStream As New NetworkStream(_socket)

    ' read the request header
    _header = New HttpRequestHeader(networkStream)

    ' read the response body (if any)
    If header.ContentLength = 0 Then Return

    Dim buffer(_header.ContentLength - 1) As Byte
    networkStream.Read(buffer, 0, buffer.Length)
    _body = buffer
  End Sub
End Class
