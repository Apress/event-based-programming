using System;
using System.ComponentModel;
using System.Collections;

using Asap.Cars.CommonTypes;

namespace Asap.Cars.Invoicing
{
	/// <summary>
	/// Summary description for Router.
	/// </summary>
	public class Router : System.ComponentModel.Component
	{
    private System.Messaging.MessageQueue messageQueueVehiclesToInvoice;
		private System.ComponentModel.Container components = null;

		public Router(System.ComponentModel.IContainer container)
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			container.Add(this);
			InitializeComponent();

			messageQueueVehiclesToInvoice.BeginReceive();
		}

		public Router()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();

      messageQueueVehiclesToInvoice.BeginReceive();
    }

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      this.messageQueueVehiclesToInvoice = new System.Messaging.MessageQueue();
      // 
      // messageQueueVehiclesToInvoice
      // 
      this.messageQueueVehiclesToInvoice.Path = "FormatName:DIRECT=OS:alessandra\\private$\\asapvehiclestoinvoice";
      this.messageQueueVehiclesToInvoice.ReceiveCompleted += new System.Messaging.ReceiveCompletedEventHandler(this.OrderReceived);

    }
		#endregion

    private void OrderReceived(object sender, System.Messaging.ReceiveCompletedEventArgs e)
    {
      System.Messaging.XmlMessageFormatter formatter = new System.Messaging.XmlMessageFormatter(new Type[] {typeof(WorkOrder)});
      System.Messaging.Message msg = messageQueueVehiclesToInvoice.EndReceive(e.AsyncResult);
      msg.Formatter = formatter;

      WorkOrder workOrder = msg.Body as WorkOrder;

      // start waiting for the next message
      messageQueueVehiclesToInvoice.BeginReceive();

      FireMessage(workOrder);
    }

    public delegate void MessageHandler(WorkOrder theWorkOrder);
    public event MessageHandler OnMessage;
    void FireMessage(WorkOrder theWorkOrder)
    {
      if (OnMessage != null)
        OnMessage(theWorkOrder);
    }
  }
}
