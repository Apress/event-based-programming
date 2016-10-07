using System;
using System.Net.Sockets;

namespace HttpService
{
  /// <summary>
  /// Summary description for HttpResponse.
  /// </summary>
  public class HttpResponse
  {
    Socket socket;

    HttpResponseHeader header;
    public HttpResponseHeader Header
    {
      get {return header;}
    }

    byte[] body;
    public byte[] Body
    {
      get {return body;}
    }

    public int SequenceNumber
    {
      get {return header.SequenceNumber;}
    }

    public HttpResponse(Socket theSocket)
    {
      socket = theSocket;
    }

    public void Get()
    {
      NetworkStream networkStream = new NetworkStream(socket);

      // read the response header
      header = new HttpResponseHeader(networkStream);

      // read the response body (if any)
      if (header.ContentLength == 0) 
        return;

      byte[] buffer = new byte[header.ContentLength];
      networkStream.Read(buffer, 0, buffer.Length);
      body = buffer;
    }
  }
}
