using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

using Asap.Cars.CommonTypes;

namespace Asap.Cars.PartsScheduling
{
	/// <summary>
	/// Summary description for Router.
	/// </summary>
	public class Router : System.ComponentModel.Component
	{
    private System.Messaging.MessageQueue messageQueueVehiclesToAssemble;
    private System.Messaging.MessageQueue messageQueueOrders;
		private System.ComponentModel.Container components = null;
 
		public Router(System.ComponentModel.IContainer container)
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			container.Add(this);
			InitializeComponent();

      // start waiting for the first incoming message
      messageQueueOrders.BeginReceive();
    }

		public Router()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();

      // start waiting for the first incoming message
      messageQueueOrders.BeginReceive();
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
      this.messageQueueVehiclesToAssemble = new System.Messaging.MessageQueue();
      this.messageQueueOrders = new System.Messaging.MessageQueue();
      // 
      // messageQueueVehiclesToAssemble
      // 
      this.messageQueueVehiclesToAssemble.Path = "alessandra\\Private$\\AsapVehiclesToAssemble";
      // 
      // messageQueueOrders
      // 
      this.messageQueueOrders.Path = "alessandra\\Private$\\AsapOrders";
      this.messageQueueOrders.ReceiveCompleted += new System.Messaging.ReceiveCompletedEventHandler(this.OrderReceived);

    }
		#endregion

    public void SubmitForAssembly(WorkOrder theWorkOrder)
    {
      messageQueueVehiclesToAssemble.Send(theWorkOrder);
    }
    
    public System.Messaging.Message[] GetVehicleAssemblyMessages()
    {
      return messageQueueVehiclesToAssemble.GetAllMessages();
    }

    private void OrderReceived(object sender, System.Messaging.ReceiveCompletedEventArgs e)
    {
      System.Messaging.XmlMessageFormatter formatter = new System.Messaging.XmlMessageFormatter(new Type[] {typeof(WorkOrder)});
      System.Messaging.Message msg = messageQueueOrders.EndReceive(e.AsyncResult);
      msg.Formatter = formatter;

      WorkOrder workOrder = msg.Body as WorkOrder;

      // start waiting for the next message
      messageQueueOrders.BeginReceive();

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
