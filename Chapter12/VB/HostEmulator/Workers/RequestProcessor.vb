Imports System.Text
Imports System.Net
Imports System.Net.Sockets

Public Class RequestProcessor
  Private _socket As Socket
  Private _httpRequest As HttpRequest

  Public Sub New(ByVal theSocket As Socket, ByVal theHttpRequest As HttpRequest)
    _socket = theSocket
    _httpRequest = theHttpRequest
  End Sub

  Public Sub HandleRequest()
    Dim startTime As DateTime = DateTime.Now
    FireIdle()  ' simulate processing time
    Dim duration As TimeSpan = DateTime.Now.Subtract(startTime)
    SendResponse(CInt(duration.TotalMilliseconds))
  End Sub

  Private Sub SendResponse(ByVal theProcessingTime As Integer)
    Dim endPoint As IPEndPoint = DirectCast(_socket.RemoteEndPoint, IPEndPoint)

    Dim body As String = String.Format("Response {0}", DateTime.Now.ToString("ffffff"))
    Dim header As String = String.Format("HTTP/1.1 200 OK" + ControlChars.NewLine + _
                                  "Sequence-Number: {0}" + ControlChars.NewLine + _
                                  "Content-Length: {1}" + ControlChars.NewLine, _
                                  _httpRequest.SequenceNumber, _
                                  body.Length)

    Dim message As String = String.Format("{0}{1}{2}", header, ControlChars.NewLine, body)

    Dim bytes As Byte() = Encoding.UTF8.GetBytes(message)
    Dim stream As New NetworkStream(_socket)
    stream.Write(bytes, 0, bytes.Length)

    Dim requestBody As String = Encoding.UTF8.GetString(_httpRequest.Body)
    FireRequestProcessed(requestBody, _httpRequest.SequenceNumber, theProcessingTime, body)
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
