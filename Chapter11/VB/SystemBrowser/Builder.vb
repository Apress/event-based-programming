Imports System.Threading

' This class builds all the top-level objects of the application

Public Class Builder
  ' there can only be one instance of the Builder
  Private Shared _singleton As Builder
  Public Shared ReadOnly Property Singleton() As Builder
    Get
      If _singleton Is Nothing Then
        _singleton = New Builder
      End If
      Return _singleton
    End Get
  End Property

  Public _binder As Binder
  Public _userSettings As UserSettings

  ' UI elements
  Public _formSplash As FormSplash
  Public _formMain As FormMain
  Public _formMenuToolBar As FormMenuToolBar
  Public _statusBar As StatusBar

  ' Workers
  Public _navigatorFolders As NavigatorFolders
  Public _navigatorSearch As NavigatorSearch
  Public _contentFolders As ContentFileList
  Public _contentSearch As ContentSearchResults

  ' Coordinators
  Public _startup As CoordinatorStartup 'lifecycle: starting up state
  Public _shutdown As CoordinatorShutdown 'lifecycle: shutting down state
  Public _cruise As CoordinatorCruise 'lifecycle: cruising state
  Public _coordinatorSearch As CoordinatorSearch '

  Public Sub New()
    _formSplash = New FormSplash
    _binder = New Binder(Me)
    _startup = New CoordinatorStartup
    _userSettings = New UserSettings
  End Sub

  Public Sub Build()
    ' create the navigators for the left pane
    _navigatorFolders = New NavigatorFolders
    _navigatorSearch = New NavigatorSearch

    ' create the content managers for the right pane
    _contentFolders = New ContentFileList
    _contentSearch = New ContentSearchResults

    ' UI elements
    _formMenuToolBar = New FormMenuToolBar
    _statusBar = New StatusBar
    _formMain = New FormMain

    ' Coordinators
    _cruise = New CoordinatorCruise
    _shutdown = New CoordinatorShutdown
    _coordinatorSearch = New CoordinatorSearch(_formMain)

    ' move the navigators and content viewers into FormMain
    _formMain.NavigatorFolders = _navigatorFolders
    _formMain.NavigatorSearch = _navigatorSearch
    _formMain.ContentFolders = _contentFolders
    _formMain.ContentSearch = _contentSearch

    ' move the menu, toolbar and statusbar into FormMain
    _formMain.Menu = _formMenuToolBar.mainMenu
    _formMain.Toolbar = _formMenuToolBar.panelToolBar
    _formMain.Statusbar = _statusBar
  End Sub
End Class
