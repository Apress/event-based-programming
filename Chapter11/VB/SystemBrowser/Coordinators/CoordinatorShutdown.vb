Public Class CoordinatorShutdown
  ' shortcut property
  ReadOnly Property Builder() As Builder
    Get
      Return Builder.Singleton
    End Get
  End Property

  Public Sub Run()
    ' disable the user interface during shutdown
    If Not Builder._formMain Is Nothing Then
      Builder._formMain.Visible = False
    End If

    Builder._userSettings.Save()
  End Sub
End Class