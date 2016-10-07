Public Class LifecycleCoordinator

  ' The main entry point for the application
  Shared Sub Main()
    Dim coordinator As New LifecycleCoordinator
    coordinator.Start() ' app exits when this call completes
  End Sub

  Enum LifecycleState
    StartingUp
    Running
    ShuttingDown
  End Enum

  Private state As LifecycleState

  ' shortcut property
  ReadOnly Property Builder() As Builder
    Get
      Return Builder.Singleton
    End Get
  End Property

  Public Sub Start()
    StartupSystem()
    RunSystem() ' app exits when this call completes
  End Sub

  Sub StartupSystem()
    state = LifecycleState.StartingUp
    Builder._startup.Run()
  End Sub

  Sub RunSystem()
    If state <> LifecycleState.StartingUp Then
      Throw New Exception("Invalid lifecycle state")
    End If

    state = LifecycleState.Running
    AddHandler Builder._cruise.OnExiting, AddressOf ShutDownSystem
    Builder._cruise.Run() ' app exits when this call completes
  End Sub

  Sub ShutDownSystem()
    If state <> LifecycleState.Running Then
      Throw New Exception("Invalid lifecycle state")
    End If

    state = LifecycleState.ShuttingDown
    Builder._shutdown.Run()
  End Sub

End Class