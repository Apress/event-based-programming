Public Class CoordinatorCruise

  ' shortcut property
  ReadOnly Property Builder() As Builder
    Get
      Return Builder.Singleton
    End Get
  End Property

  Public Sub Run()
    AddHandler Builder._formMain.Closing, AddressOf formMain_Closing
    Application.Run(Builder._formMain)  ' app exits when this call completes
  End Sub

  Private Sub formMain_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
    'to prevent the app from closing, do this
    'e.Cancel = true;
    'return;

    ' let the app shut the app down
    FireExiting()
  End Sub

  Public Sub HandleTopLevelEvents()
    ' handle the top-level events than occur during
    ' the normal operation of the system...
  End Sub

  Public Event OnExiting()
  Sub FireExiting()
    RaiseEvent OnExiting()
  End Sub

End Class