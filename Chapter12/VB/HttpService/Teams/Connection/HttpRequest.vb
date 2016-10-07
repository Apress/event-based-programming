Imports System.Text
Imports System.Net
Imports System.Net.Sockets

Public Class HttpRequest
  Private _socket As Socket

  Public Sub New(ByVal theSocket As Socket)
    _socket = theSocket
  End Sub

  Public Sub Post(ByVal theLocalPath As String, ByVal theSequenceNumber As Integer, ByVal theMessage As String)
    Dim endPoint As IPEndPoint = DirectCast(_socket.RemoteEndPoint, IPEndPoint)
    Dim header As String = String.Format("POST {0} HTTP/1.1" + ControlChars.NewLine + _
                                  "Host: {1}:{2}" + ControlChars.NewLine + _
                                  "Sequence-Number: {3}" + ControlChars.NewLine + _
                                  "Connection: Keep-Alive" + ControlChars.NewLine + _
                                  "Content-Length: {4}" + ControlChars.NewLine, _
                                  theLocalPath, endPoint.Address, _
                                  endPoint.Port, theSequenceNumber, _
                                  theMessage.Length)

    Dim message As String = String.Format("{0}{1}{2}", header, ControlChars.NewLine, theMessage)
    Dim bytes As Byte() = Encoding.UTF8.GetBytes(message)
    Dim stream As New NetworkStream(_socket)
    stream.Write(bytes, 0, bytes.Length)
  End Sub
End Class
