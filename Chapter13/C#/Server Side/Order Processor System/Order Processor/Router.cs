using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

using Asap.Cars.CommonTypes;

namespace Asap.Cars.OrderProcessor
{
	/// <summary>
	/// Summary description for Router.
	/// </summary>
	public class Router : System.ComponentModel.Component
	{
    public System.Messaging.MessageQueue messageQueueOrders;
		private System.ComponentModel.Container components = null;

		public Router(System.ComponentModel.IContainer container)
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			container.Add(this);
			InitializeComponent();
		}

		public Router()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();
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
      this.messageQueueOrders = new System.Messaging.MessageQueue();
      // 
      // messageQueueOrders
      // 
      this.messageQueueOrders.Path = "alessandra\\Private$\\AsapOrders";

    }
		#endregion

    public void SubmitOrder(WorkOrder theWorkOrder)
    {
      messageQueueOrders.Send(theWorkOrder);
    }

    public System.Messaging.Message[] GetAllQueuedMessages()
    {
      return messageQueueOrders.GetAllMessages();
    }

    public void ClearQueuedMessages()
    {
      messageQueueOrders.Purge();
    }
  }
}
