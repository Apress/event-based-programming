using System;

namespace HttpService
{
	/// <summary>
	/// CoordinatorRequestHandler is the only object clients interact with
	/// in HttpService, by calling the Send method
	/// </summary>
	public class CoordinatorRequestHandler
	{
    static CoordinatorRequestHandler singleton;
    public static CoordinatorRequestHandler Singleton
    {
      get 
      {
        // use a lock to ensure that only one
        // instance of CoordinatorRequestHandler is created
        lock(typeof(CoordinatorRequestHandler))
        {
          if (singleton == null)
            singleton = new CoordinatorRequestHandler();
          return singleton;
        }
      }
    }

    int sequenceNumber;
    int GetNextSequenceNumber()
    {
      lock(typeof(CoordinatorRequestHandler))
      {
        sequenceNumber++;
        return sequenceNumber;
      }
    }

    CoordinatorConnectionPool coordinatorConnectionPool;

    private CoordinatorRequestHandler() 
    {
      coordinatorConnectionPool = new CoordinatorConnectionPool();
    }

    // This method sends a requests and waits until a response is returned.
    // The SequenceNumber doesn't need to be returned to the caller, but we
    // return it to display the number in our test fixture.
    public string Send(string theUri, string theMessage, out int theSequenceNumber)
    {
      Uri uri = new Uri(theUri);
      string hostAddress = uri.Host;
      CoordinatorConnection coordinator;

      lock(typeof(CoordinatorRequestHandler))
      {
        coordinator = coordinatorConnectionPool.GetConnection(hostAddress);
        theSequenceNumber = GetNextSequenceNumber();
      }

      // Send blocks until a response is returned, or a timeout occurs
      return coordinator.Send(uri.LocalPath, theSequenceNumber, theMessage);  
    }
	}
}
