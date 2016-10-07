using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Asap.Cars.CommonTypes;

namespace Order_Entry_Test_Fixture
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

    Asap.Cars.OrderEntry.WorkerOrderEntry workerOrderEntry;
    Asap.Cars.OrderEntry.CoordinatorOrderEntry coordinatorOrderEntry;
    
    public FormMain()
	  {
		  //
		  // Required for Windows Form Designer support
		  //
		  InitializeComponent();

      // build everything
      workerOrderEntry = new Asap.Cars.OrderEntry.WorkerOrderEntry();
      coordinatorOrderEntry = new Asap.Cars.OrderEntry.CoordinatorOrderEntry();
      
      // bind everything
      workerOrderEntry.OnGetColors += new Asap.Cars.OrderEntry.WorkerOrderEntry.GetColorsHandler(coordinatorOrderEntry.GetColors);
      workerOrderEntry.OnGetOptions += new Asap.Cars.OrderEntry.WorkerOrderEntry.GetOptionsHandler(coordinatorOrderEntry.GetOptions);
      workerOrderEntry.OnGetStyles += new Asap.Cars.OrderEntry.WorkerOrderEntry.GetStylesHandler(coordinatorOrderEntry.GetStyles);
      workerOrderEntry.OnSubmitOrder += new Asap.Cars.OrderEntry.WorkerOrderEntry.SubmitOrderHandler(coordinatorOrderEntry.SubmitOrder);
      workerOrderEntry.OnComputeCostOfOptions += new Asap.Cars.OrderEntry.WorkerOrderEntry.ComputeCostOfOptionsHandler(coordinatorOrderEntry.ComputeCostOfOptions);

      coordinatorOrderEntry.OnGetColors += new Asap.Cars.OrderEntry.CoordinatorOrderEntry.GetColorsHandler(coordinatorOrderEntry_OnGetColors);
      coordinatorOrderEntry.OnGetOptions += new Asap.Cars.OrderEntry.CoordinatorOrderEntry.GetOptionsHandler(coordinatorOrderEntry_OnGetOptions);
      coordinatorOrderEntry.OnGetStyles += new Asap.Cars.OrderEntry.CoordinatorOrderEntry.GetStylesHandler(coordinatorOrderEntry_OnGetStyles);
      coordinatorOrderEntry.OnSubmit += new Asap.Cars.OrderEntry.CoordinatorOrderEntry.SubmitHandler(coordinatorOrderEntry_OnSubmit);

      // setup UI elements
      Controls.Add(workerOrderEntry.panelMain);
      string[] models = new string[] {"Model 1", "Model 2", "Model 3"};
      workerOrderEntry.PopulateModels(models);
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
      // FormMain
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(380, 343);
      this.Name = "FormMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Order Entry Test Fixture";

    }
	  #endregion

	  /// <summary>
	  /// The main entry point for the application.
	  /// </summary>
	  [STAThread]
	  static void Main() 
	  {
		  Application.Run(new FormMain());
    }

    private string[] coordinatorOrderEntry_OnGetModels()
    {
      string[] models = new string[] {"Model 1", "Model 2", "Model 3"};
      return models;
    }
    
    private Color[] coordinatorOrderEntry_OnGetColors(string theModel, string theStyle)
    {
      Color[] colors = new Color[] {Color.White, Color.Navy, Color.Lavender};
      return colors;
    }

    private ArrayList coordinatorOrderEntry_OnGetOptions(string theModel, string theStyle)
    {
      ArrayList options = new ArrayList();

      ArrayList category1 = new ArrayList();
      PricedItem[] category1Items = new PricedItem[] {
        new PricedItem("Category 1", 0),
        new PricedItem("Option 1", 111),
        new PricedItem("Option 2", 222),
        new PricedItem("Option 3", 333)};
      options.Add(category1Items);

      ArrayList category2 = new ArrayList();
      PricedItem[] category2Items = new PricedItem[] {
        new PricedItem("Category 2", 0),
        new PricedItem("Option 11", 777),
        new PricedItem("Option 22", 888),
        new PricedItem("Option 33", 999)};
      options.Add(category2Items);

      return options;
    }

    private string[] coordinatorOrderEntry_OnGetStyles(string theModel)
    {
      string[] styles = new string[] {"Style 1", "Style 2", "Style 3"};
      return styles;
    }

    private void coordinatorOrderEntry_OnSubmit(string theModel, string theStyle, Color theColor, PricedItem[] theOptions)
    {
      string s = string.Format("Model=[{0}] Style=[{1}] Color=[{2}]", theModel, theStyle, theColor);
      for (int i = 0; i < theOptions.Length; i++)
        s += string.Format(" Option[{0}]=[{1}]", i, theOptions[i].Name);

      MessageBox.Show(s, "Order submitted");
    }
  }
}
