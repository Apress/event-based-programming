using System;
using System.Windows.Forms;

namespace SystemBrowser
{
  public class CoordinatorStartup
  {
    // shortcut property
    Builder Builder
    {
      get {return Builder.Singleton;}
    }

    public void Run()
    {
      // name the UI thread, so we can distinguish it 
      // from other threads in the debugger window
      System.Threading.Thread.CurrentThread.Name = "User Interface";

      Builder.formSplash.Show();
      Builder.formSplash.Update(); // otherwise it appears in fragments

      Builder.Build();  // instantiate all the top-level classes
      Builder.binder.Bind();  // wire all the top-level objects
      
      // temporarily wire form splash to handle startup progress updates
      Builder.binder.BindFormSplash();

      InitializeSystem();

      // unwire form splash, since progress updates are no longer required
      Builder.binder.UnbindFormSplash();

      Builder.formMain.Show();
      Builder.formMain.Update();

      Builder.formSplash.Hide();
    }

    void InitializeSystem()
    {
      Builder.userSettings.Load();

      // show initial folders and files
      const string initialFolder = @"c:\";
      Builder.navigatorFolders.Populate(initialFolder);
      Builder.contentFolders.Populate(initialFolder);
      Builder.statusBar.Message(initialFolder);
      Builder.formMenuToolBar.ShowAddress(initialFolder);

      if (Builder.userSettings.ShowFoldersNavigator)
        Builder.formMenuToolBar.SelectFolders();
      else
        Builder.formMenuToolBar.SelectSearch();
    }
  }
}
