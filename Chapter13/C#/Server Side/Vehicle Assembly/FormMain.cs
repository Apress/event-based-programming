using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Asap.Cars.CommonTypes;

namespace Asap.Cars.VehicleAssembly
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

    // manages connections to incoming and outgoing message queues
    Router router;
    
    public FormMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

      router = new Router();
      router.OnMessage += new Router.MessageHandler(HandleOrder);
    }

    private void HandleOrder(WorkOrder theWorkOrder)
    {
      // a WorkerOrder has arrived. Skip the actual vehicle
      // assembly details and just issue and invoice
      router.SubmitForInvoicing(theWorkOrder);
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
      this.ClientSize = new System.Drawing.Size(338, 116);
      this.Name = "FormMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Vehicle Assembly";

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
	}
}
