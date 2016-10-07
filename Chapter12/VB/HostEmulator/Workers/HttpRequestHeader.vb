Imports System.IO
Imports System.Text
Imports System.Collections
Imports System.Net
Imports System.Net.Sockets

Public Class HttpRequestHeader
  ' key is name, value is value
  Private _headers As New Hashtable

  Public ReadOnly Property ContentLength() As Integer
    Get
      If Not _headers.Contains("Content-Length") Then Return 0
      Dim s As String = DirectCast(_headers("Content-Length"), String)
      Return Integer.Parse(s)
    End Get
  End Property

  Public ReadOnly Property SequenceNumber() As Integer
    Get
      If Not _headers.Contains("Sequence-Number") Then
        Throw New Exception("Sequence-Number not found")
      End If
      Dim s As String = DirectCast(_headers("Sequence-Number"), String)
      Return Integer.Parse(s)
    End Get
  End Property

  Public Sub New(ByVal theNetworkStream As NetworkStream)
    Dim reader As StreamReader = GetStreamReader(theNetworkStream)
    Parse(reader)
  End Sub

  Private Function GetStreamReader(ByVal theNetworkStream As NetworkStream) As StreamReader
    Const Cr As Byte = &HD     ' UTF8 CarriageReturn

    ' read the incoming data and return it as a StreamReader
    Dim memoryStream As New MemoryStream

    Dim t As String = String.Empty

    Dim b As Byte = CByte(theNetworkStream.ReadByte())
    t = Convert.ToChar(b).ToString

    ' the header ends with "\r\n\r\n"
    While True
      While b <> Cr
        memoryStream.WriteByte(b)
        b = CByte(theNetworkStream.ReadByte())
        t = t + Convert.ToChar(b).ToString
      End While

      memoryStream.WriteByte(b) ' Cr
      b = CByte(theNetworkStream.ReadByte())
      memoryStream.WriteByte(b) ' Lf

      b = CByte(theNetworkStream.ReadByte())
      If (b = Cr) Then
        memoryStream.WriteByte(b) ' Cr
        b = CByte(theNetworkStream.ReadByte())
        memoryStream.WriteByte(b) ' Lf
        memoryStream.Position = 0
        Dim reader As New StreamReader(memoryStream, Encoding.UTF8)
        Return reader
      End If
    End While
  End Function

  Public Sub Parse(ByVal theReader As StreamReader)
    _headers.Clear()
    ParseVerbLine(theReader)
    ParseOtherLines(theReader)
  End Sub

  ' the request must start with a string like this:
  ' POST <path> HTTP/1.1\r\n
  Sub ParseVerbLine(ByVal theReader As StreamReader)
    Dim line As String = theReader.ReadLine()
    Dim words As String() = line.Split(" "c)
    If words.Length < 3 Then
      Throw New Exception("Invalid response header")
    End If

    If words(0) <> "POST" Then
      Throw New Exception("Invalid request verb. Only POST accepted")
    End If
  End Sub

  Sub ParseOtherLines(ByVal theReader As StreamReader)
    Dim line As String = theReader.ReadLine()
    While Not line Is Nothing
      If line = String.Empty Then Return
      ParseLine(line)
      line = theReader.ReadLine()
    End While
  End Sub

  Sub ParseLine(ByVal theLine As String)
    Dim i As Integer = theLine.IndexOf(":")
    If i <= 0 Then
      Throw New Exception("Invalid request header")
    End If

    Dim headerName As String = theLine.Substring(0, i)
    Dim headerValue As String = theLine.Substring(i + 1).Trim()

    _headers.Add(headerName, headerValue)
  End Sub
End Class
