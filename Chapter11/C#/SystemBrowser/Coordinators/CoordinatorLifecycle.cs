using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SystemBrowser
{
  public class LifecycleCoordinator
  {
    // The main entry point for the application
    [STAThread]
    static void Main() 
    {
      LifecycleCoordinator coordinator = new LifecycleCoordinator();
      coordinator.Start(); // app exits when this call completes
    }
    
    enum LifecycleState {StartingUp, Running, ShuttingDown};
    LifecycleState state;

    // shortcut property
    Builder Builder
    {
      get {return Builder.Singleton;}
    }

    public void Start()
    {
      StartupSystem();
      RunSystem(); // app exits when this call completes
    }
    
    void StartupSystem()  
    {
      state = LifecycleState.StartingUp;
      Builder.startup.Run();
    }
    
    void RunSystem()
    {
      if (state != LifecycleState.StartingUp)
        throw new Exception("Invalid lifecycle state");

      state = LifecycleState.Running;
      Builder.cruise.OnExiting += new CoordinatorCruise.ExitingHandler(ShutDownSystem);
      Builder.cruise.Run(); // app exits when this call completes
    }

    void ShutDownSystem()
    {
      if (state != LifecycleState.Running)
        throw new Exception("Invalid lifecycle state");

      state = LifecycleState.ShuttingDown;
      Builder.shutdown.Run();
    }
  }
}
