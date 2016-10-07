using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Asap.Cars.OrderEntry
{
	/// <summary>
	/// Summary description for FormMain.
	/// </summary>
  public class FormMain : System.Windows.Forms.Form
  {
	  /// <summary>
	  /// Required designer variable.
	  /// </summary>
	  private System.ComponentModel.Container components = null;

    WorkerOrderEntry workerOrderEntry;
    CoordinatorOrderEntry coordinatorOrderEntry;
    Router router;

	  public FormMain()
	  {
		  //
		  // Required for Windows Form Designer support
		  //
		  InitializeComponent();

      Build();
      Bind();

      SetupUi();
	  }

    void Build()
    {
      workerOrderEntry = new WorkerOrderEntry();
      coordinatorOrderEntry = new CoordinatorOrderEntry();
      router = new Router();
    }

    void Bind()
    {
      workerOrderEntry.OnGetColors += new Asap.Cars.OrderEntry.WorkerOrderEntry.GetColorsHandler(coordinatorOrderEntry.GetColors);
      workerOrderEntry.OnGetOptions += new Asap.Cars.OrderEntry.WorkerOrderEntry.GetOptionsHandler(coordinatorOrderEntry.GetOptions);
      workerOrderEntry.OnGetStyles += new Asap.Cars.OrderEntry.WorkerOrderEntry.GetStylesHandler(coordinatorOrderEntry.GetStyles);
      workerOrderEntry.OnSubmitOrder += new Asap.Cars.OrderEntry.WorkerOrderEntry.SubmitOrderHandler(coordinatorOrderEntry.SubmitOrder);
      workerOrderEntry.OnComputeCostOfOptions += new Asap.Cars.OrderEntry.WorkerOrderEntry.ComputeCostOfOptionsHandler(coordinatorOrderEntry.ComputeCostOfOptions);

      coordinatorOrderEntry.OnGetColors += new Asap.Cars.OrderEntry.CoordinatorOrderEntry.GetColorsHandler(router.GetColors);
      coordinatorOrderEntry.OnGetOptions += new Asap.Cars.OrderEntry.CoordinatorOrderEntry.GetOptionsHandler(router.GetOptions);
      coordinatorOrderEntry.OnGetStyles += new Asap.Cars.OrderEntry.CoordinatorOrderEntry.GetStylesHandler(router.GetStyles);
      coordinatorOrderEntry.OnSubmit += new Asap.Cars.OrderEntry.CoordinatorOrderEntry.SubmitHandler(router.SubmitOrder);
    }

    void SetupUi()
    {
      Controls.Add(workerOrderEntry.panelMain);
      PopulateModels();
    }

    void PopulateModels()
    {
      try
      {
        string[] models = router.GetModels();
        workerOrderEntry.PopulateModels(models);
      }
      catch (Exception ex)
      {
        string msg = string.Format("The server must be running before starting the Order Entry program. " +
                                    "To run the server, start OrderProcessingHostProgram.exe.\nException Details: [{0}]", ex.Message);
        MessageBox.Show(msg, "An exception occurred while connecting to server");
        throw ex;
      }
    }


	  /// <summary>
	  /// Clean up any resources being used.
	  /// </summary>
	  protected override void Dispose( bool disposing )
	  {
		  if( disposing )
		  {
			  if (components != null) 
			  {
				  components.Dispose();
			  }
		  }
		  base.Dispose( disposing );
	  }

	  #region Windows Form Designer generated code
	  /// <summary>
	  /// Required method for Designer support - do not modify
	  /// the contents of this method with the code editor.
	  /// </summary>
	  private void InitializeComponent()
	  {
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(390, 336);
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "ASAP Cars - Custom Tailor Your Car";

    }
	  #endregion

	  /// <summary>
	  /// The main entry point for the application.
	  /// </summary>
	  [STAThread]
	  static void Main() 
	  {
      FormMain formMain = null;
      try
      {
        formMain = new FormMain();
      }
      catch (Exception ex)
      {
        // exceptions typically occur if the client can't connect to the server
        MessageBox.Show(ex.Message, "An exception occurred");
        return;
      }

		  Application.Run(formMain);
	  }

  }
}
