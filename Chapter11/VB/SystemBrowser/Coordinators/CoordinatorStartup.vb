Public Class CoordinatorStartup
  ' shortcut property
  ReadOnly Property Builder() As Builder
    Get
      Return Builder.Singleton
    End Get
  End Property

  Public Sub Run()
    ' name the UI thread, so we can distinguish it 
    ' from other threads in the debugger window
    System.Threading.Thread.CurrentThread.Name = "User Interface"

    Builder._formSplash.Show()
    Builder._formSplash.Update() ' otherwise it appears in fragments

    Builder.Build()  ' instantiate all the top-level classes
    Builder._binder.Bind()  ' wire all the top-level objects

    ' temporarily wire form splash to handle startup progress updates
    Builder._binder.BindFormSplash()

    InitializeSystem()

    ' unwire form splash, since progress updates are no longer required
    Builder._binder.UnbindFormSplash()

    Builder._formMain.Show()
    Builder._formMain.Update()

    Builder._formSplash.Hide()
  End Sub

  Sub InitializeSystem()
    Builder._userSettings.Load()

    ' show initial folders and files
    Const initialFolder As String = "c:\"
    Builder._navigatorFolders.Populate(initialFolder)
    Builder._contentFolders.Populate(initialFolder)
    Builder._statusBar.Message(initialFolder)
    Builder._formMenuToolBar.ShowAddress(initialFolder)

    If (Builder._userSettings.ShowFoldersNavigator) Then
      Builder._formMenuToolBar.SelectFolders()
    Else
      Builder._formMenuToolBar.SelectSearch()
    End If
  End Sub
End Class
