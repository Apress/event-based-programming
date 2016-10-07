using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace HttpService
{
	/// <summary>
	/// CoordinatorConnection manages a team of two workers:
	/// Connection and Receiver. Together these classes
	/// handle pipelined requests, blocking sender thread.
	/// When a response comes back, using its SequenceNumber
	/// it is matched with a request thread and that thread
	/// is unblocked.
	/// </summary>
  public class CoordinatorConnection
  {
    RequestQueue blockedRequests;  // a queue of blocked send threads
    Receiver receiver;             // listens for incoming traffic
    Connection connection;         // sends requests and handles responses
    TimeSpan rxTimeout;            // time to wait for a response
    Thread receiverThread;         // background receiver thread

    public bool IsIdle
    {
      get {return connection.IsIdle;}
    }

    public CoordinatorConnection(string theHostAddress, TimeSpan theRxTimeout)
    {
      rxTimeout = theRxTimeout;
      blockedRequests = new RequestQueue();

      connection = new Connection(theHostAddress);
      connection.OnConnected += new HttpService.Connection.ConnectedHandler(ConnectHandler);
      connection.OnDisconnected += new HttpService.Connection.DisconnectedHandler(DisconnectHandler);
    }

    // returns the response
    public string Send(string theLocalPath, int theSequenceNumber, string theMessage)
    {
      ThreadSemaphore semaphore = null;

      lock(this)
      {
        // we use a lock here, to prevent concurrent requests
        // from getting mixed together on their way out
        connection.Connect();
        connection.LastActivity = DateTime.Now;
        HttpRequest request = new HttpRequest(connection.Socket);
        request.Post(theLocalPath, theSequenceNumber, theMessage);
        semaphore = blockedRequests.Add(theSequenceNumber, theMessage);
      }

      // block until the response arrives, or a timeout occurs
      if (!semaphore.Wait(rxTimeout))
        throw new Exception("No response received");

      // get the response from the semaphore
      byte[] response = semaphore.response;
      blockedRequests.Remove(theSequenceNumber);
      return Encoding.UTF8.GetString(response);
    }

    public void Disconnect()
    {
      connection.Disconnect();
    }

    void HandleResponse(Socket theSocket)
    {
      // read the response
      HttpResponse response = new HttpResponse(theSocket);
      response.Get();

      // get the semaphore for the blocked request thread
      ThreadSemaphore semaphore = blockedRequests.Get(response.SequenceNumber);
      if (semaphore == null)
        throw new Exception("No pending request found for response");

      // save the response in the semaphore
      semaphore.response = response.Body;

      // unblock the request thread waiting for this response
      semaphore.Signal();
    }

    private void ConnectHandler(Socket theSocket)
    {
      receiver = new Receiver(theSocket);
      receiver.OnIdle += new HttpService.Receiver.IdleHandler(ReceiverIdle);
      receiver.OnResponse += new HttpService.Receiver.ResponseHandler(HandleResponse);
      receiverThread = new Thread(new ThreadStart(receiver.Run));
      receiverThread.Name = "Receiver";
      receiverThread.IsBackground = true;
      receiverThread.Start();
    }

    private void DisconnectHandler()
    {
      receiver.Stop();
      receiverThread.Join();  // wait for thread to stop
      receiver = null;
    }

    void ReceiverIdle()
    {
      Thread.Sleep(10);
    }
  }
}
