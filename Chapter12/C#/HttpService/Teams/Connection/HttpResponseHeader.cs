using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Net;
using System.Net.Sockets;

namespace HttpService
{
	/// <summary>
	/// Summary description for HttpResponseHeader.
	/// </summary>
  public class HttpResponseHeader
  {
    // key is name, value is value
    Hashtable headers = new Hashtable();

    HttpStatusCode statusCode;

    public int ContentLength
    {
      get 
      {
        if (!headers.Contains("Content-Length"))
          return 0;
        string s = headers["Content-Length"] as string;
        return int.Parse(s);
      }
    }

    public int SequenceNumber
    {
      get 
      {
        if (!headers.Contains("Sequence-Number"))
          throw new Exception("Sequence-Number not found");
        string s = headers["Sequence-Number"] as string;
        return int.Parse(s);
      }
    }
    
    public HttpResponseHeader(NetworkStream theNetworkStream)
    {
     StreamReader reader = GetStreamReader(theNetworkStream);
     Parse(reader);
    }

    StreamReader GetStreamReader(NetworkStream theNetworkStream)
    {
      const byte Cr = 0x0d;  // UTF8 CarriageReturn

      // read the incoming data and return it as a StreamReader
      MemoryStream memoryStream = new MemoryStream();

      byte b = (byte) theNetworkStream.ReadByte();

      // the header ends with "\r\n\r\n"
      while (true)
      {
        while (b != Cr) 
        {
          memoryStream.WriteByte(b);
          b = (byte) theNetworkStream.ReadByte();
        }

        memoryStream.WriteByte(b); // Cr
        b = (byte) theNetworkStream.ReadByte();
        memoryStream.WriteByte(b); // Lf
 
        b = (byte) theNetworkStream.ReadByte();
        if (b == Cr) 
        {
          memoryStream.WriteByte(b); // Cr
          b = (byte) theNetworkStream.ReadByte();
          memoryStream.WriteByte(b); // Lf
          memoryStream.Position = 0;
          StreamReader reader = new StreamReader(memoryStream, Encoding.UTF8);
          return reader;
        }
      }
    }

    public void Parse(StreamReader theReader)
    {
      headers.Clear();
      ParseStatusCode(theReader);
      ParseOtherLines(theReader);
    }

    // the response must start with a string like this:
    // HTTP/1.1 200 OK\r\n
    void ParseStatusCode(StreamReader theReader)
    {
      string line = theReader.ReadLine();
      if (!line.StartsWith("HTTP"))
        throw new Exception("Invalid response header");

      string[] words = line.Split(' ');
      if (words.Length < 3)
        throw new Exception("Invalid response header");

      int i = int.Parse(words[1]);
      statusCode = (HttpStatusCode) i;
    }

    void ParseOtherLines(StreamReader theReader)
    {
      string line = theReader.ReadLine();
      while (line != null)
      {
        if (line == "") return;
        ParseLine(line);
        line = theReader.ReadLine();
      }
    }

    void ParseLine(string theLine)
    {
      string[] words = theLine.Split(':');
      if (words.Length == 0)
        throw new Exception("Invalid response header");

      headers.Add(words[0], words[1]);
    }
  }
}
