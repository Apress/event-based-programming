using System;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using HttpService;

namespace Client
{
	/// <summary>
	/// Coordinator handles all the threading logic
	/// </summary>
  public class Coordinator
  {
    // object used to synchronize events with UI thread
    Control uiControl;

    // the component to test
    HttpService.CoordinatorRequestHandler requestHandler; 

	  public Coordinator(Control theUiControl)
	  {
      uiControl = theUiControl;
      requestHandler = HttpService.CoordinatorRequestHandler.Singleton;
	  }

    public void Send(int theNumberOfPipelinedRequests)
    {
      for (int i = 0; i < theNumberOfPipelinedRequests; i++)
      {
        Thread thread = new Thread(new ThreadStart(SendRequest));
        thread.Name = string.Format("Request{0}", i);
        thread.IsBackground = true;
        thread.Start();
      }
    }

    // this method runs on a background thread
    void SendRequest()
    {
      DateTime startTime = DateTime.Now;
      FireRequestSent();

      // RequestHandler.Send blocks until a response comes back
      int sequenceNumber;
      string response = requestHandler.Send("http://localhost", startTime.ToString("HH:mm:ss.ffffff"), out sequenceNumber);

      TimeSpan responseTime = DateTime.Now.Subtract(startTime);
      FireResponseReceived(sequenceNumber, response, responseTime);
    }

    #region Events

    // the following events are fired on the UI thread

    public delegate void RequestSentHandler();
    public event RequestSentHandler OnRequestSent;
    void FireRequestSent()
    {
      if (OnRequestSent != null)
        uiControl.Invoke(OnRequestSent);
    }

    public delegate void ResponseReceivedHandler(int theSequenceNumber, string theResponse, TimeSpan theProcessingTime);
    public event ResponseReceivedHandler OnResponseReceived;
    void FireResponseReceived(int theSequenceNumber, string theResponse, TimeSpan theProcessingTime)
    {
      if (OnResponseReceived != null)
        uiControl.Invoke(OnResponseReceived, new object[] {theSequenceNumber, theResponse, theProcessingTime});
    }
    #endregion
  }
}
