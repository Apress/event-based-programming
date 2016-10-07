using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SystemBrowser
{
  public class CoordinatorCruise
  {
    // shortcut property
    Builder Builder
    {
      get {return Builder.Singleton;}
    }

    public void Run()
    {
      Builder.formMain.Closing += new CancelEventHandler(formMain_Closing);
      Application.Run(Builder.formMain);  // app exits when this call completes
    }

    private void formMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      // to prevent the app from closing, do this
      // e.Cancel = true;
      // return;

      // let the app shut the app down
      FireExiting();
    }

    public void HandleTopLevelEvents()
    {
      // handle the top-level events than occur during
      // the normal operation of the system...
    }

    public delegate void ExitingHandler();
    public event ExitingHandler OnExiting;
    void FireExiting()
    {
      if (OnExiting == null) return;
      OnExiting();
    }
  }
}
