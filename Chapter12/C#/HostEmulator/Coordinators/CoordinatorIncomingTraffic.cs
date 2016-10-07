using System;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;

namespace HostEmulator
{
	/// <summary>
	/// CoordinatorIncomingTraffic handles all the threading logic
	/// associated with the handling of incoming traffic
	/// </summary>
  public class CoordinatorIncomingTraffic
  {
    Control uiControl;  // used for thread synchronization with events
    ConnectionListener listener;
    int basicProcessingTime;  // in ms
    int processingTime;       // in ms
    Random random = new Random();  // used to change the processing time

    public CoordinatorIncomingTraffic(Control theUiControl)
    {
      uiControl = theUiControl;
      basicProcessingTime = 2000;  // 2 secs

      listener = new ConnectionListener();
      listener.OnClientConnect += new ConnectionListener.ClientConnectHandler(ClientConnected);
      listener.OnIdle += new HostEmulator.ConnectionListener.IdleHandler(WaitForTenMs);
    }

    public void Run()
    {
      Thread listenerThread = new Thread(new ThreadStart(listener.Listen) );
      listenerThread.IsBackground = true;
      listenerThread.Name = "ConnectionListener";
      listenerThread.Start();
    }

    void ClientConnected(Socket theSocket)
    {
      // dispatch a thread to handle all the requests
      // on the connected socket

      ConnectionProcessor connection = new ConnectionProcessor(theSocket);
      connection.OnRequestStarted += new HostEmulator.ConnectionProcessor.RequestStartedHandler(RequestStarted);
      connection.OnRequestProcessed += new HostEmulator.ConnectionProcessor.RequestProcessedHandler(FireRequestProcessed);
      connection.OnIdle += new HostEmulator.ConnectionProcessor.IdleHandler(WaitForTenMs);
      Thread thread = new Thread(new ThreadStart(connection.WaitForRequests) );
      thread.IsBackground = true;
      thread.Name = "ConnectionProcessor";
      thread.Start();

      FireClientConnected();
    }

    void RequestStarted(Socket theSocket)
    {
      FireRequestStarted();

      HttpRequest httpRequest = new HttpRequest(theSocket);
      httpRequest.Get();  // get the entire incoming request

      RequestProcessor request = new RequestProcessor(theSocket, httpRequest);
      request.OnRequestProcessed += new RequestProcessor.RequestProcessedHandler(FireRequestProcessed);
      request.OnIdle += new RequestProcessor.IdleHandler(SimulateProcessingTime);

      // process request on a separate thread, to 
      // allowing incoming requests to be pipelined
      Thread thread = new Thread(new ThreadStart(request.HandleRequest) );
      thread.IsBackground = true;
      thread.Name = "RequestProcessor";
      thread.Start();
    }

    int GetNextProcessingTime()
    {
      lock(this)
      {
          processingTime = random.Next(basicProcessingTime-1000, basicProcessingTime+1000);
          return processingTime;
      }
    }
      
    private void WaitForTenMs()
    {
      Thread.Sleep(10);
    }

    private void SimulateProcessingTime()
    {
      int duration = GetNextProcessingTime();
      Thread.Sleep(duration);
    }

#region Events
    // ***********************************************************
    // the following Fire methods switch to the UI thread
    // before firing events
    // ***********************************************************

    public delegate void ClientConnectedHandler();
    public event ClientConnectedHandler OnClientConnected;
    public void FireClientConnected()
    {
      if (OnClientConnected != null)
        uiControl.Invoke(OnClientConnected, null);
    }

    public delegate void RequestStartedHandler();
    public event RequestStartedHandler OnRequestStarted;
    public void FireRequestStarted()
    {
      if (OnRequestStarted != null)
        uiControl.Invoke(OnRequestStarted);
    }

    public delegate void RequestProcessedHandler(string theRequest, int theSequenceNumber, int theDuration, string theResponse);
    public event RequestProcessedHandler OnRequestProcessed;
    public void FireRequestProcessed(string theRequest, int theSequenceNumber, int theDuration, string theResponse)
    {
      if (OnRequestProcessed != null)
        uiControl.Invoke(OnRequestProcessed, new object[] {theRequest, theSequenceNumber, theDuration, theResponse});
    }
    #endregion
  }
}
