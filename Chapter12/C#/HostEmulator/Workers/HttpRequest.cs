using System;
using System.Net;
using System.Net.Sockets;

namespace HostEmulator
{
  /// <summary>
  /// HttpRequest encapsulates HTTP request messages
  /// </summary>
  public class HttpRequest
  {
    Socket socket;

    // all the message headers
    HttpRequestHeader header;
    public HttpRequestHeader Header
    {
      get {return header;}
    }

    // the message body
    byte[] body;
    public byte[] Body
    {
      get {return body;}
    }

    public int SequenceNumber
    {
      get {return header.SequenceNumber;}
    }

    public HttpRequest(Socket theSocket)
    {
      socket = theSocket;
    }

    // reads the request from a stream
    public void Get()
    {
      NetworkStream networkStream = new NetworkStream(socket);

      // read the request header
      header = new HttpRequestHeader(networkStream);

      // read the response body (if any)
      if (header.ContentLength == 0) 
        return;

      byte[] buffer = new byte[header.ContentLength];
      networkStream.Read(buffer, 0, buffer.Length);
      body = buffer;
    }
  }
}
