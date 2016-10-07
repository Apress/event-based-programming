using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace HttpService
{
	/// <summary>
	/// Summary description for HttpRequest.
	/// </summary>
	public class HttpRequest
  {
    Socket socket;

		public HttpRequest(Socket theSocket)
		{
      socket = theSocket;
		}

    public void Post(string theLocalPath, int theSequenceNumber, string theMessage)
    {
      IPEndPoint endPoint = socket.RemoteEndPoint as IPEndPoint;
      string header = string.Format("POST {0} HTTP/1.1\r\n" +
                                    "Host: {1}:{2}\r\n" +
                                    "Sequence-Number: {3}\r\n" +
                                    "Connection: Keep-Alive\r\n" +
                                    "Content-Length: {4}\r\n",
                                    theLocalPath, endPoint.Address, 
                                    endPoint.Port, theSequenceNumber,
                                    theMessage.Length);
      
      string message = string.Format("{0}\r\n{1}", header, theMessage);
      byte[] bytes = Encoding.UTF8.GetBytes(message);
      NetworkStream stream = new NetworkStream(socket);
      stream.Write(bytes, 0, bytes.Length);
    }
	}
}
