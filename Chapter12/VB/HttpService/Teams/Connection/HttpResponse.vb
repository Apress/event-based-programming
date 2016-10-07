Imports System.Net.Sockets

Public Class HttpResponse
  Private _socket As Socket

  Private _header As HttpResponseHeader
  Public ReadOnly Property Header() As HttpResponseHeader
    Get
      Return _header
    End Get
  End Property

  Private _body As Byte()
  Public ReadOnly Property Body() As Byte()
    Get
      Return _body
    End Get
  End Property

  Public ReadOnly Property SequenceNumber() As Integer
    Get
      Return _header.SequenceNumber
    End Get
  End Property

  Public Sub New(ByVal theSocket As Socket)
    _socket = theSocket
  End Sub

  Public Sub [Get]()
    Dim networkStream As New NetworkStream(_socket)

    ' read the response header
    _header = New HttpResponseHeader(networkStream)

    ' read the response body (if any)
    If _header.ContentLength = 0 Then Return

    Dim buffer(_header.ContentLength - 1) As Byte
    networkStream.Read(buffer, 0, buffer.Length)
    _body = buffer
  End Sub
End Class
