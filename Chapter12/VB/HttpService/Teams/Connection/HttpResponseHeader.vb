Imports System.IO
Imports System.Text
Imports System.Collections
Imports System.Net
Imports System.Net.Sockets

Public Class HttpResponseHeader
  ' key is name, value is value
  Private _headers As New Hashtable

  Private _statusCode As HttpStatusCode

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

    Function GetStreamReader(ByVal theNetworkStream as NetworkStream ) as StreamReader
    Const Cr As Byte = &HD     ' UTF8 CarriageReturn

    ' read the incoming data and return it as a StreamReader
    Dim memoryStream As New MemoryStream

    Dim b As Byte = CByte(theNetworkStream.ReadByte())

    ' the header ends with "\r\n\r\n"
    While True
      While (b <> Cr)
        memoryStream.WriteByte(b)
        b = CByte(theNetworkStream.ReadByte())
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
    ParseStatusCode(theReader)
    ParseOtherLines(theReader)
  End Sub

  ' the response must start with a string like this:
  ' HTTP/1.1 200 OK\r\n
  Sub ParseStatusCode(ByVal theReader As StreamReader)
    Dim line As String = theReader.ReadLine()
    If Not line.StartsWith("HTTP") Then
      Throw New Exception("Invalid response header")
    End If

    Dim words As String() = line.Split(" "c)
    If words.Length < 3 Then
      Throw New Exception("Invalid response header")
    End If

    Dim i As Integer = Integer.Parse(words(1))
    _statusCode = CType(i, HttpStatusCode)
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
    Dim words As String() = theLine.Split(":"c)
    If words.Length = 0 Then
      Throw New Exception("Invalid response header")
    End If
    _headers.Add(words(0), words(1))
  End Sub
End Class
