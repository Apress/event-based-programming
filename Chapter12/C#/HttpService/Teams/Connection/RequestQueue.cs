using System;
using System.Collections;
using System.Threading;

namespace HttpService
{
  /// <summary>
  /// ThreadSemaphore is used by RequestQueue, and encapsulates
  /// the items required to managed blocked request threads
  /// </summary>
  public class ThreadSemaphore
  {
    public ManualResetEvent requestEvent = new ManualResetEvent(false);
    public int sequenceNumber;
    public string request;
    public byte[] response;
    public bool inUse;
    public DateTime startTime;

    public bool Wait(TimeSpan theDuration)
    {
      return requestEvent.WaitOne(theDuration, true);
    }

    public void Signal()
    {
      requestEvent.Set();
    }
  }

  /// <summary>
  /// RequestQueue maintains a list of blocked request threads.
  /// When a client sends a request, the thread is blocked and 
  /// a ThreadSemaphore object is kept in a hashtable. When the
  /// response returns, the ThreadSemaphore is signaled, allowing
  /// the request thread to continue and return data to the 
  /// calling client.
  /// </summary>
  public class RequestQueue
  {
    static RequestQueue singleton;
    public static RequestQueue Singleton
    {
      get 
      {
        if (singleton == null)
          singleton = new RequestQueue();
        return singleton;
      }
    }

    // a pool of prebuilt semaphores used with blocked requests
    ThreadSemaphore[] semaphores;

    // key is SequenceNumber, value is RequestSemaphore
    Hashtable blockedRequests = new Hashtable();

    public RequestQueue()
    {
      // we support up to 500 concurrent requests. The value is arbitrary
      semaphores = new ThreadSemaphore[500];  
      for (int i = 0; i < semaphores.Length; i++)
      {
        ThreadSemaphore semaphore = new ThreadSemaphore();
        semaphore.requestEvent = new ManualResetEvent(false);
        semaphores[i] = semaphore;
      }
    }
    
    public ThreadSemaphore Add(int theSequenceNumber, string theRequest)
    {
      lock(this)
      {
        ThreadSemaphore semaphore = GetFirstAvailableSemaphore();
        blockedRequests.Add(theSequenceNumber, semaphore);
        semaphore.requestEvent.Reset();
        semaphore.sequenceNumber = theSequenceNumber;
        semaphore.request = theRequest;
        semaphore.response = null;
        semaphore.startTime = DateTime.Now;
        return semaphore;
      }
    }

    ThreadSemaphore GetFirstAvailableSemaphore()
    {
      lock(this)
      {
        foreach (ThreadSemaphore semaphore in semaphores)
        {
          if (semaphore.inUse) continue;
          semaphore.inUse = true;
          return semaphore;
        }
      }
      throw new Exception("RequestQueue: No semaphores available");
    }

    public void Remove(int theSequenceNumber)
    {
      lock(this)
      {
        ThreadSemaphore semaphore = blockedRequests[theSequenceNumber] as ThreadSemaphore;
        blockedRequests.Remove(theSequenceNumber);
        semaphore.inUse = false;
      }
    }

    public ThreadSemaphore Get(int theSequenceNumber)
    {
      return blockedRequests[theSequenceNumber] as ThreadSemaphore;
    }
  }
}
