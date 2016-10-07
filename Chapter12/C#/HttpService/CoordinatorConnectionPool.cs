using System;
using System.Collections;
using System.Threading;

namespace HttpService
{
	/// <summary>
  /// This class manages the connection pool, including all
  /// related threading issues. The Coordinator also runs
  /// a background task to remove idle connections from the pool
  /// </summary>
  public class CoordinatorConnectionPool
  {
    Thread idleConnectionMonitorThread;
    Hashtable pool = new Hashtable(); //key is host address, value is ConnectionCoordinator

    public CoordinatorConnectionPool() 
    {
      idleConnectionMonitorThread = new Thread(new ThreadStart(RemoveIdleConnections));
      idleConnectionMonitorThread.IsBackground = true;
      idleConnectionMonitorThread.Start();
    }

    void RemoveIdleConnections()
    {
      while (true)
      {
        Monitor.Enter(this);
        DoRemoveIdleConnections();
        Monitor.Exit(this);
        Thread.Sleep(10000); // wait for 10 seconds
      }
    }

    private void DoRemoveIdleConnections()
    {
      // Removing items from a collection during iteration
      // is not allowed, so we create a clone of the original
      // collection. We then iterate over the clone, but
      // remove items from the original collection
      Hashtable clonedHashtable = pool.Clone() as Hashtable;

      foreach (string hostAddress in clonedHashtable.Keys)
      {
        CoordinatorConnection coordinator = clonedHashtable[hostAddress] as CoordinatorConnection;
        if (coordinator.IsIdle)
        {
          pool.Remove(hostAddress);
          coordinator.Disconnect();
        }
      }
    }

    TimeSpan rxTimeout = new TimeSpan(0, 0, 20); // twenty seconds

    public CoordinatorConnection GetConnection(string theHostAddress)
    {
        CoordinatorConnection coordinator;
        Monitor.Enter(this); // don't let other threads alter the pool while we're working on it
        if (pool.Contains(theHostAddress))
          coordinator = pool[theHostAddress] as CoordinatorConnection;
        else
        {
          coordinator = new CoordinatorConnection(theHostAddress, rxTimeout);
          pool.Add(theHostAddress, coordinator);
        }
        Monitor.Exit(this); // let other threads in
        return coordinator;
    }
  }
}
