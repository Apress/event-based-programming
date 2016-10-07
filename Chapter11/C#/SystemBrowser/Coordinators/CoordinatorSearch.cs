using System;
using System.Windows.Forms;
using System.Threading;

namespace SystemBrowser
{
	/// <summary>
	/// CoordinatorSearch manages the file-search process. It manages all
	/// thread-related logic. CoordinatorSearch handles all the search
	/// worker's notifications, and switches to the UI thread before firing
	/// any events of its own.
	/// </summary>
	public class CoordinatorSearch
	{
    Control uiControl;
    Thread searchThread;

    public CoordinatorSearch(Control theUiControl)
    {
      uiControl = theUiControl;
    }

    public void StartSearch(string theFolderPath)
    {
      if (searchThread != null)
        if (searchThread.IsAlive)
          searchThread.Abort();

      FireMessage("Searching...");
      FireSearchRequested();
      StartBackgroundSearch();
    }

    public void ItemFound(string thePath, int theCurrentCount)
    {
      FireItemFound(thePath, theCurrentCount);

      if (theCurrentCount == 1)
        FireMessage("1 item found");
      else
        FireMessage(string.Format("{0} items found", theCurrentCount));
    }

    // a reference to the search entry point. We call this
    // method on a background thread 
    public ThreadStart OnSearchStart;

    // start the search on a background thread
    void StartBackgroundSearch()
    {
      if (OnSearchStart == null) return;
      searchThread = new Thread(OnSearchStart);
      searchThread.Start();
    }

    #region Events
    // ***********************************************************
    // the following Fire methods switch to the UI thread
    // before firing events
    // ***********************************************************

    public delegate void SearchRequestedHandler();
    public event SearchRequestedHandler OnSearchRequested;
    void FireSearchRequested()
    {
      if (OnSearchRequested != null)
        uiControl.Invoke(OnSearchRequested);
    }

    public delegate void ItemFoundHandler(string thePath, int theCurrentCount);
    public event ItemFoundHandler OnItemFound;
    void FireItemFound(string thePath, int theCurrentCount)
    {
      if (OnItemFound != null)
        uiControl.Invoke(OnItemFound, new object[] {thePath, theCurrentCount});
    }

    public delegate void MessageHandler(string theMessage);
    public event MessageHandler OnMessage;
    public void FireMessage(string theMessage)
    {
      if (OnMessage != null)
        uiControl.Invoke(OnMessage, new object[] {theMessage});
    }
    #endregion
  }
}
