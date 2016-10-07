using System;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace HostEmulator
{
  /// <summary>
  /// RequestProcessor handles all the incoming requests
  /// for a given client connection
  /// </summary>
  public class RequestProcessor
  {
    Socket socket;
    HttpRequest httpRequest;

    public RequestProcessor(Socket theSocket, HttpRequest theHttpRequest)
    {
      socket = theSocket;
      httpRequest = theHttpRequest;
    }

    public void HandleRequest()
    {
      DateTime startTime = DateTime.Now;
      FireIdle();  // simulate processing time
      TimeSpan duration = DateTime.Now.Subtract(startTime);
      SendResponse((int) duration.TotalMilliseconds);
    }

    private void SendResponse(int theProcessingTime)
    {
      IPEndPoint endPoint = socket.RemoteEndPoint as IPEndPoint;

      string body = string.Format("Response {0}", DateTime.Now.ToString("ffffff"));
      string header = string.Format("HTTP/1.1 200 OK\r\n" +
                                    "Sequence-Number: {0}\r\n" +
                                    "Content-Length: {1}\r\n",
                                    httpRequest.SequenceNumber,
                                    body.Length);
      
      string message = string.Format("{0}\r\n{1}", header, body);

      byte[] bytes = Encoding.UTF8.GetBytes(message);
      NetworkStream stream = new NetworkStream(socket);
      stream.Write(bytes, 0, bytes.Length);

      string requestBody = Encoding.UTF8.GetString(httpRequest.Body);
      FireRequestProcessed(requestBody, httpRequest.SequenceNumber, theProcessingTime, body);
    }

    public delegate void RequestProcessedHandler(string theRequest, int theSequenceNumber, int theDuration, string theResponse);
    public event RequestProcessedHandler OnRequestProcessed;
    public void FireRequestProcessed(string theRequest, int theSequenceNumber, int theDuration, string theResponse)
    {
      if (OnRequestProcessed == null) return;
      OnRequestProcessed(theRequest, theSequenceNumber, theDuration, theResponse);
    }

    public delegate void IdleHandler();
    public event IdleHandler OnIdle;
    public void FireIdle()
    {
      if (OnIdle != null)
        OnIdle();
    }
  }
}
