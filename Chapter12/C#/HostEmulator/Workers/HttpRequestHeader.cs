using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Net;
using System.Net.Sockets;

namespace HostEmulator
{
	/// <summary>
	/// Summary description for HttpRequestHeader.
	/// </summary>
  public class HttpRequestHeader
  {
    // key is name, value is value
    Hashtable headers = new Hashtable();

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
    
    public HttpRequestHeader(NetworkStream theNetworkStream)
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
      ParseVerbLine(theReader);
      ParseOtherLines(theReader);
    }

    // the request must start with a string like this:
    // POST <path> HTTP/1.1\r\n
    void ParseVerbLine(StreamReader theReader)
    {
      string line = theReader.ReadLine();
      string[] words = line.Split(' ');
      if (words.Length < 3)
        throw new Exception("Invalid response header");

      if (words[0] != "POST")
        throw new Exception("Invalid request verb. Only POST accepted");
    }

    void ParseOtherLines(StreamReader theReader)
    {
      string line = theReader.ReadLine();
      while (line != null)
      {
        if (line == String.Empty) return;
        ParseLine(line);
        line = theReader.ReadLine();
      }
    }

    void ParseLine(string theLine)
    {
      int i = theLine.IndexOf(":");
      if (i <=0)
        throw new Exception("Invalid request header");

      string headerName = theLine.Substring(0, i);
      string headerValue = theLine.Substring(i+1).Trim();

      headers.Add(headerName, headerValue);
    }
  }
}
