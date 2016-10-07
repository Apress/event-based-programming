using System;
using System.Net;
using System.Net.Sockets;

namespace HostEmulator
{
  /// <summary>
  /// ConnectionListener waits for client connections. When
  /// a connection comes in, the class fires an event
  /// </summary>
  public class ConnectionListener
  {
    TcpListener listener;

    public void Listen()
    {
      IPAddress ipAddress = Dns.Resolve("localhost").AddressList[0];
      listener = new TcpListener(ipAddress, 8020); // listen on port 8020
      listener.Start();

      while (true) 
      {
        // wait until a client connects
        if (!listener.Pending() ) 
        {
          FireIdle();
          continue;
        }
          
        // process the client
        Socket socket = listener.AcceptSocket();
  			
        FireClientConnected(socket);
      }
    }

    public delegate void ClientConnectHandler(Socket theSocket);
    public event ClientConnectHandler OnClientConnect;
    public void FireClientConnected(Socket theSocket)
    {
      if (OnClientConnect != null)
        OnClientConnect(theSocket);
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
