using System;
using System.Net;
using System.Net.Sockets;

namespace HttpService
{
  /// <summary>
  /// Summary description for Connection.
  /// </summary>
  public class Connection
  {
    Socket socket;
    public Socket Socket
    {
      get {return socket;}
    }

    string hostAddress;
    public string HostAddress
    {
      get {return hostAddress;}
      set {hostAddress = value;}
    }

    public bool Connected
    {
      get {return socket != null;}
    }

    DateTime lastActivity = DateTime.Now;
    public DateTime LastActivity
    {
      get {return lastActivity;}
      set {lastActivity = value;}
    }

    // theHostAddress can be an IP or a DNS Address
    public Connection(string theHostAddress)
    {
      hostAddress = theHostAddress;
    }

    TimeSpan TwentyMinutes = new TimeSpan(0, 20, 0);
    public bool IsIdle
    {
      get {return (DateTime.Now - LastActivity) > TwentyMinutes;}
    }
    
    public void Connect()
    {
      if (Connected) return;

      socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
      IPHostEntry hostEntry = Dns.GetHostByName(hostAddress);
      IPEndPoint endPoint = new IPEndPoint(hostEntry.AddressList[0], 8020);
      socket.Connect(endPoint);

      FireConnected(socket);
    }

    public void Disconnect()
    {
      if (socket == null) return;

      socket.Close();
      socket = null;

      FireDisconnected();
    }

    public delegate void ConnectedHandler(Socket theSocket);
    public event ConnectedHandler OnConnected;
    void FireConnected(Socket theSocket)
    {
      if (OnConnected != null)
        OnConnected(theSocket);
    }

    public delegate void DisconnectedHandler();
    public event DisconnectedHandler OnDisconnected;
    void FireDisconnected()
    {
      if (OnDisconnected != null)
        OnDisconnected();
    }
  }
}
