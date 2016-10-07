using System;
using System.Windows.Forms;
using System.Threading;

namespace SystemBrowser
{
	/// <summary>
	/// This class wires all the top-level objects of the application
	/// </summary>
  public class Binder
  {
    private Builder builder;

    // a handler will be used only during startup, to show progress on the splash screen
    NavigatorFolders.ProgressHandler progressUpdater;

    public Binder(Builder theBuilder)
    {
      builder = theBuilder;
      progressUpdater = new NavigatorFolders.ProgressHandler(builder.formSplash.UpdateProgress);
    }

    public void Bind()
    {
      builder.formMenuToolBar.OnViewFolders += new FormMenuToolBar.UniversalHandler(builder.formMain.ShowFolders);
      builder.formMenuToolBar.OnViewFolders += new FormMenuToolBar.UniversalHandler(builder.userSettings.ShowFolders);

      builder.formMenuToolBar.OnViewSearch += new FormMenuToolBar.UniversalHandler(builder.formMain.ShowSearch);
      builder.formMenuToolBar.OnViewSearch += new FormMenuToolBar.UniversalHandler(builder.userSettings.ShowSearch);

      builder.formMenuToolBar.OnViewIcons += new SystemBrowser.FormMenuToolBar.UniversalHandler(builder.contentFolders.ShowIcons);
      builder.formMenuToolBar.OnViewIcons += new SystemBrowser.FormMenuToolBar.UniversalHandler(builder.contentSearch.ShowIcons);

      builder.formMenuToolBar.OnViewDetails += new SystemBrowser.FormMenuToolBar.UniversalHandler(builder.contentFolders.ShowDetails);
      builder.formMenuToolBar.OnViewDetails += new SystemBrowser.FormMenuToolBar.UniversalHandler(builder.contentSearch.ShowDetails);

      builder.formMenuToolBar.OnUpSelected += new SystemBrowser.FormMenuToolBar.UniversalHandler(builder.navigatorFolders.SelectParentFolder);
      builder.formMenuToolBar.OnAddressChanged += new SystemBrowser.FormMenuToolBar.AddressChangedHandler(builder.navigatorFolders.SelectFolder);

      builder.navigatorFolders.OnFolderChanged += new NavigatorFolders.FolderChangedHandler(builder.contentFolders.Populate);
      builder.navigatorFolders.OnFolderChanged += new NavigatorFolders.FolderChangedHandler(builder.formMenuToolBar.ShowAddress);
      builder.navigatorFolders.OnMessage += new NavigatorFolders.MessageHandler(builder.statusBar.Message);

      builder.contentFolders.OnMessage += new ContentFileList.MessageHandler(builder.statusBar.Message);
      builder.contentFolders.OnFolderDoubleClicked += new SystemBrowser.ContentFileList.FolderDoubleClickedHandler(builder.navigatorFolders.SelectFolder);

      builder.coordinatorSearch.OnSearchRequested += new SystemBrowser.CoordinatorSearch.SearchRequestedHandler(builder.contentSearch.Clear);
      builder.coordinatorSearch.OnSearchStart += new ThreadStart(builder.navigatorSearch.Start);
      builder.coordinatorSearch.OnItemFound += new SystemBrowser.CoordinatorSearch.ItemFoundHandler(builder.contentSearch.Add);
      builder.coordinatorSearch.OnMessage += new SystemBrowser.CoordinatorSearch.MessageHandler(builder.statusBar.Message);

      builder.navigatorSearch.OnSearchRequested += new NavigatorSearch.SearchRequestedHandler(builder.formMenuToolBar.ShowAddress);
      builder.navigatorSearch.OnSearchRequested += new NavigatorSearch.SearchRequestedHandler(builder.coordinatorSearch.StartSearch);
      builder.navigatorSearch.OnItemFound += new NavigatorSearch.ItemFoundHandler(builder.coordinatorSearch.ItemFound);
      builder.navigatorSearch.OnMessage += new NavigatorSearch.MessageHandler(builder.coordinatorSearch.FireMessage);

      builder.contentSearch.OnMessage += new SystemBrowser.ContentSearchResults.MessageHandler(builder.statusBar.Message);
    }

    public void BindFormSplash()
    {
      builder.navigatorFolders.OnProgress += progressUpdater;
    }

    public void UnbindFormSplash()
    {
      builder.navigatorFolders.OnProgress -= progressUpdater;
    }
  }
}
