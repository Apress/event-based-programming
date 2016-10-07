using System;
using System.Net.Sockets;

namespace HostEmulator
{
	/// <summary>
	/// ConnectionProcessor waits for incoming requests on a given connection.
	/// When a request arrives, ConnectionListener fires an event.
	/// </summary>
  public class ConnectionProcessor
  {
    Socket socket;

    public ConnectionProcessor(Socket theSocket)
    {
      socket = theSocket;
    }

    public void WaitForRequests()
    {
      while (true)
      {
        if (socket.Available > 0)
          FireRequestStarted(socket);

        FireIdle();
      }
    }
  		
    public delegate void RequestStartedHandler(Socket theSocket);
    public event RequestStartedHandler OnRequestStarted;
    public void FireRequestStarted(Socket theSocket)
    {
      if (OnRequestStarted != null)
        OnRequestStarted(theSocket);
    }

    public delegate void RequestProcessedHandler(string theRequest, int theSequenceNumber, int theDuration, string theResponse);
    public event RequestProcessedHandler OnRequestProcessed;
    public void FireRequestProcessed(string theRequest, int theSequenceNumber, int theDuration, string theResponse)
    {
      if (OnRequestProcessed != null)
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
