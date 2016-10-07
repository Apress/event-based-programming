using System;
using System.Threading;

namespace SystemBrowser
{
  public class CoordinatorShutdown
  {
    // shortcut property
    Builder Builder
    {
      get {return Builder.Singleton;}
    }

    public void Run()
    {
      // disable the user interface during shutdown
      if (Builder.formMain != null)
        Builder.formMain.Visible = false;

      Builder.userSettings.Save();
    }
  }
}
