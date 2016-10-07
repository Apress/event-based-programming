using System;
using System.Windows.Forms;
using System.Threading;

namespace SystemBrowser
{
  /// <summary>
  /// This class builds all the top-level objects of the application
  /// </summary>
  public class Builder
  {
    // there can only be one instance of the Builder
    static Builder singleton;
    static public Builder Singleton
    {
      get 
      {
        if (singleton == null)
          singleton = new Builder();
        return singleton;
      }
    }

    public Binder binder;
    public UserSettings userSettings;

    // UI elements
    public FormSplash formSplash;
    public FormMain formMain;
    public FormMenuToolBar formMenuToolBar;
    public StatusBar statusBar;

    // Workers
    public NavigatorFolders navigatorFolders;
    public NavigatorSearch navigatorSearch;
    public ContentFileList contentFolders;
    public ContentSearchResults contentSearch;

    // Coordinators
    public CoordinatorStartup startup;   // lifecycle: starting up state 
    public CoordinatorShutdown shutdown; // lifecycle: shutting down state
    public CoordinatorCruise cruise;     // lifecycle: cruising state
    public CoordinatorSearch coordinatorSearch;

    public Builder()
    {
      formSplash = new FormSplash();
      binder = new Binder(this);
      startup = new CoordinatorStartup();
      userSettings = new UserSettings();
    }

    public void Build()
    {
      // create the navigators for the left pane
      navigatorFolders = new NavigatorFolders();
      navigatorSearch = new NavigatorSearch();

      // create the content managers for the right pane
      contentFolders = new ContentFileList();
      contentSearch = new ContentSearchResults();

      // UI elements
      formMenuToolBar = new FormMenuToolBar();
      statusBar = new StatusBar();
      formMain = new FormMain();

      // Coordinators
      cruise = new CoordinatorCruise();
      shutdown = new CoordinatorShutdown();
      coordinatorSearch = new CoordinatorSearch(formMain);

      // move the navigators and content viewers into FormMain
      formMain.NavigatorFolders = navigatorFolders;
      formMain.NavigatorSearch = navigatorSearch;
      formMain.ContentFolders = contentFolders;
      formMain.ContentSearch = contentSearch;

      // move the menu, toolbar and statusbar into FormMain
      formMain.Menu = formMenuToolBar.mainMenu;
      formMain.Toolbar = formMenuToolBar.panelToolBar;
      formMain.Statusbar = statusBar;
    }
  }
}
