' This class wires all the top-level objects of the application

Public Class Binder

  Private _builder As Builder

  ' a handler will be used only during startup, to show progress on the splash screen
  Private _progressUpdater As NavigatorFolders.ProgressHandler

  Public Sub New(ByVal theBuilder As Builder)
    _builder = theBuilder
    _progressUpdater = AddressOf _builder._formSplash.UpdateProgress
  End Sub

  Public Sub Bind()
    AddHandler _builder._formMenuToolBar.OnViewFolders, AddressOf _builder._formMain.ShowFolders
    AddHandler _builder._formMenuToolBar.OnViewFolders, AddressOf _builder._userSettings.ShowFolders

    AddHandler _builder._formMenuToolBar.OnViewSearch, AddressOf _builder._formMain.ShowSearch
    AddHandler _builder._formMenuToolBar.OnViewSearch, AddressOf _builder._userSettings.ShowSearch

    AddHandler _builder._formMenuToolBar.OnViewIcons, AddressOf _builder._contentFolders.ShowIcons
    AddHandler _builder._formMenuToolBar.OnViewIcons, AddressOf _builder._contentSearch.ShowIcons

    AddHandler _builder._formMenuToolBar.OnViewDetails, AddressOf _builder._contentFolders.ShowDetails
    AddHandler _builder._formMenuToolBar.OnViewDetails, AddressOf _builder._contentSearch.ShowDetails

    AddHandler _builder._formMenuToolBar.OnUpSelected, AddressOf _builder._navigatorFolders.SelectParentFolder
    AddHandler _builder._formMenuToolBar.OnAddressChanged, AddressOf _builder._navigatorFolders.SelectFolder

    AddHandler _builder._navigatorFolders.OnFolderChanged, AddressOf _builder._contentFolders.Populate
    AddHandler _builder._navigatorFolders.OnFolderChanged, AddressOf _builder._formMenuToolBar.ShowAddress
    AddHandler _builder._navigatorFolders.OnMessage, AddressOf _builder._statusBar.Message

    AddHandler _builder._contentFolders.OnMessage, AddressOf _builder._statusBar.Message
    AddHandler _builder._contentFolders.OnFolderDoubleClicked, AddressOf _builder._navigatorFolders.SelectFolder

    AddHandler _builder._coordinatorSearch.OnSearchRequested, AddressOf _builder._contentSearch.Clear
    _builder._coordinatorSearch.OnSearchStart = AddressOf _builder._navigatorSearch.Start 'a delegate, not an event
    AddHandler _builder._coordinatorSearch.OnItemFound, AddressOf _builder._contentSearch.Add
    AddHandler _builder._coordinatorSearch.OnMessage, AddressOf _builder._statusBar.Message

    AddHandler _builder._navigatorSearch.OnSearchRequested, AddressOf _builder._formMenuToolBar.ShowAddress
    AddHandler _builder._navigatorSearch.OnSearchRequested, AddressOf _builder._coordinatorSearch.StartSearch
    AddHandler _builder._navigatorSearch.OnItemFound, AddressOf _builder._coordinatorSearch.ItemFound
    AddHandler _builder._navigatorSearch.OnMessage, AddressOf _builder._coordinatorSearch.FireMessage

    AddHandler _builder._contentSearch.OnMessage, AddressOf _builder._statusBar.Message
  End Sub

  Public Sub BindFormSplash()
    AddHandler _builder._navigatorFolders.OnProgress, _progressUpdater
  End Sub

  Public Sub UnbindFormSplash()
    RemoveHandler _builder._navigatorFolders.OnProgress, _progressUpdater
  End Sub

End Class
