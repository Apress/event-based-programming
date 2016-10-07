using System;
using System.Net.Sockets;

namespace HttpService
{
	/// <summary>
	/// Receiver handles all the incoming traffic
	/// for a given socket
	/// </summary>
  public class Receiver
  {
    bool stopRequested;
    Socket socket;

	  public Receiver(Socket theSocket)
    {
      socket = theSocket;
    }

    public void Stop()
    {
      stopRequested = true;
    }

    public void Run()
    {
      stopRequested = false;
      while (!stopRequested)
        CheckForIncomingTraffic();
    }

    void CheckForIncomingTraffic()
    {
      if (socket.Available == 0)
        FireIdle();
      else
        FireResponse(socket);
    }

    public delegate void ResponseHandler(Socket theSocket);
    public event ResponseHandler OnResponse;
    void FireResponse(Socket theSocket)
    {
      if (OnResponse != null)
        OnResponse(theSocket);
    }

    public delegate void IdleHandler();
    public event IdleHandler OnIdle;
    void FireIdle()
    {
      if (OnIdle != null)
        OnIdle();
    }
  }
}
