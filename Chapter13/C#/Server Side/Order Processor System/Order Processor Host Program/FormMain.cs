using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

using Asap.Cars.OrderProcessor;

namespace Asap.Cars.OrderProcessor.HostProgram
{
	/// <summary>
	/// Summary description for FormMain.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
    #region Controls
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label labelTotalOrdersReceived;
    private System.Windows.Forms.Timer timerOrdersReceived;
    private System.ComponentModel.IContainer components;
    #endregion

		public FormMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

      // configure the server component to listen for orders
      TcpChannel channel = new TcpChannel(8011);
      ChannelServices.RegisterChannel(channel);
      RemotingConfiguration.RegisterWellKnownServiceType(typeof(OrderSystem), "AsapOrders", WellKnownObjectMode.Singleton);
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
      this.components = new System.ComponentModel.Container();
      this.label1 = new System.Windows.Forms.Label();
      this.labelTotalOrdersReceived = new System.Windows.Forms.Label();
      this.timerOrdersReceived = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(83, 48);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(114, 16);
      this.label1.TabIndex = 0;
      this.label1.Text = "Total orders received:";
      // 
      // labelTotalOrdersReceived
      // 
      this.labelTotalOrdersReceived.AutoSize = true;
      this.labelTotalOrdersReceived.Location = new System.Drawing.Point(196, 49);
      this.labelTotalOrdersReceived.Name = "labelTotalOrdersReceived";
      this.labelTotalOrdersReceived.Size = new System.Drawing.Size(10, 16);
      this.labelTotalOrdersReceived.TabIndex = 1;
      this.labelTotalOrdersReceived.Text = "0";
      // 
      // timerOrdersReceived
      // 
      this.timerOrdersReceived.Enabled = true;
      this.timerOrdersReceived.Tick += new System.EventHandler(this.timerOrdersReceived_Tick);
      // 
      // FormMain
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(344, 113);
      this.Controls.Add(this.labelTotalOrdersReceived);
      this.Controls.Add(this.label1);
      this.Name = "FormMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "ASAP Order Status";
      this.ResumeLayout(false);

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

    private void timerOrdersReceived_Tick(object sender, System.EventArgs e)
    {
      UpdateOrdersReceived();
    }

    int ordersReceived;
    void UpdateOrdersReceived()
    {
      int c = OrderSystem.OrdersReceived;
      if (c == ordersReceived) return;

      labelTotalOrdersReceived.Text = c.ToString();
      ordersReceived = c;
    }
	}
}
