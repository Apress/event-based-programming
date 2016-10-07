using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;

using Asap.Cars.CommonTypes;

namespace Asap.Cars.PartsScheduling
{
	/// <summary>
	/// Summary description for FormMain.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
    #region Controls
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ColumnHeader columnHeaderPart;
    private System.Windows.Forms.ColumnHeader columnHeaderPartSchedule;
    private System.Windows.Forms.ColumnHeader columnHeaderIncomingId;
    private System.Windows.Forms.ListView listViewVehiclesToAssemble;
    private System.Windows.Forms.ColumnHeader columnHeaderOutgoingId;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ListView listViewPartsSchedule;
    private System.Windows.Forms.Timer timerUpdatePartsScheduled;
    private System.ComponentModel.IContainer components;
    #endregion

    // manages connections to incoming and outgoing message queues
    Router router;

    // manages a list of scheduled parts
    WorkerPartsList partsList = new WorkerPartsList();

		public FormMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

      System.Threading.Thread.CurrentThread.Name = "User Interface";

      router = new Router();
      router.OnMessage += new Router.MessageHandler(HandleOrder);

      Thread partsListMonitor = new Thread(new ThreadStart(CheckPartsList));
      partsListMonitor.IsBackground = true;
      partsListMonitor.Name = "PartsListMonitor";
      partsListMonitor.Start();

      DisplayScheduledParts();
      ShowVehiclesReadyForAssembly();
    }

    bool removingPartsFromPartsList;
    void CheckPartsList()
    {
      while (true)
      {
        ArrayList workOrdersReady = partsList.GetWorkToAssemble();
        if (workOrdersReady == null)
        {
          Thread.Sleep(100);
          continue;
        }
        else
        {
          // lock out DisplayScheduledParts from running temporarily
          removingPartsFromPartsList = true;
          // send all ready WorkOrders to next queue
          foreach (WorkOrder workOrder in workOrdersReady)
          {
            partsList.Remove(workOrder);
            router.SubmitForAssembly(workOrder);
          }
          removingPartsFromPartsList = false;
        }
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
      this.components = new System.ComponentModel.Container();
      this.label1 = new System.Windows.Forms.Label();
      this.listViewPartsSchedule = new System.Windows.Forms.ListView();
      this.columnHeaderIncomingId = new System.Windows.Forms.ColumnHeader();
      this.columnHeaderPart = new System.Windows.Forms.ColumnHeader();
      this.columnHeaderPartSchedule = new System.Windows.Forms.ColumnHeader();
      this.timerUpdatePartsScheduled = new System.Windows.Forms.Timer(this.components);
      this.listViewVehiclesToAssemble = new System.Windows.Forms.ListView();
      this.columnHeaderOutgoingId = new System.Windows.Forms.ColumnHeader();
      this.label2 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(22, 21);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(99, 18);
      this.label1.TabIndex = 22;
      this.label1.Text = "Parts Schedule:";
      // 
      // listViewPartsSchedule
      // 
      this.listViewPartsSchedule.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                            this.columnHeaderIncomingId,
                                                                                            this.columnHeaderPart,
                                                                                            this.columnHeaderPartSchedule});
      this.listViewPartsSchedule.Location = new System.Drawing.Point(24, 39);
      this.listViewPartsSchedule.Name = "listViewPartsSchedule";
      this.listViewPartsSchedule.Size = new System.Drawing.Size(470, 166);
      this.listViewPartsSchedule.TabIndex = 23;
      this.listViewPartsSchedule.View = System.Windows.Forms.View.Details;
      // 
      // columnHeaderIncomingId
      // 
      this.columnHeaderIncomingId.Text = "Order ID";
      this.columnHeaderIncomingId.Width = 153;
      // 
      // columnHeaderPart
      // 
      this.columnHeaderPart.Text = "Part";
      this.columnHeaderPart.Width = 111;
      // 
      // columnHeaderPartSchedule
      // 
      this.columnHeaderPartSchedule.Text = "Schedule";
      this.columnHeaderPartSchedule.Width = 201;
      // 
      // timerUpdatePartsScheduled
      // 
      this.timerUpdatePartsScheduled.Enabled = true;
      this.timerUpdatePartsScheduled.Tick += new System.EventHandler(this.timerUpdatePartsScheduled_Tick);
      // 
      // listViewVehiclesToAssemble
      // 
      this.listViewVehiclesToAssemble.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                                 this.columnHeaderOutgoingId});
      this.listViewVehiclesToAssemble.Location = new System.Drawing.Point(554, 42);
      this.listViewVehiclesToAssemble.Name = "listViewVehiclesToAssemble";
      this.listViewVehiclesToAssemble.Size = new System.Drawing.Size(312, 166);
      this.listViewVehiclesToAssemble.TabIndex = 25;
      this.listViewVehiclesToAssemble.View = System.Windows.Forms.View.Details;
      // 
      // columnHeaderOutgoingId
      // 
      this.columnHeaderOutgoingId.Text = "Order ID";
      this.columnHeaderOutgoingId.Width = 277;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(552, 23);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(136, 18);
      this.label2.TabIndex = 24;
      this.label2.Text = "Vehicles to Assemble:";
      // 
      // FormMain
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
      this.ClientSize = new System.Drawing.Size(876, 235);
      this.Controls.Add(this.listViewVehiclesToAssemble);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.listViewPartsSchedule);
      this.Name = "FormMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "ASAP Parts Scheduling System";
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

    private void HandleOrder(WorkOrder theWorkOrder)
    {
      // a WorkerOrder has arrived. Add three parts for it, with
      // hard-coded delivery dates

      if (theWorkOrder == null) return;

      // pretend the work order has three parts
      partsList.AddPart(theWorkOrder, "Part 1", DateTime.Now.AddSeconds(3));
      partsList.AddPart(theWorkOrder, "Part 2", DateTime.Now.AddSeconds(6));
      partsList.AddPart(theWorkOrder, "Part 3", DateTime.Now.AddSeconds(9));
    }

    private void timerUpdatePartsScheduled_Tick(object sender, System.EventArgs e)
    {
      DisplayScheduledParts();
      ShowVehiclesReadyForAssembly();
    }

    int scheduledPartsDisplayed = 0;

    private void DisplayScheduledParts()
    {
      if (removingPartsFromPartsList)
        return; // can't display the list while it's being changed

      if (scheduledPartsDisplayed == partsList.TotalNumberOfScheduledParts)
        return;

      listViewPartsSchedule.Items.Clear();

      foreach (ArrayList parts in partsList.List.Values)
      {
        foreach (ScheduledPart part in parts)
        {
          ListViewItem item = new ListViewItem(part.workOrder.Id);
          item.SubItems.Add(part.part);
          item.SubItems.Add(part.deliveryDate.ToString("yyyy-MM-dd HH:mm:ss"));
          listViewPartsSchedule.Items.Add(item);
        }
        scheduledPartsDisplayed = partsList.TotalNumberOfScheduledParts;
      }
    }

    int vehiclesToAssembleDisplayed = 0;

    void ShowVehiclesReadyForAssembly()
    {
      System.Messaging.Message[] messages = router.GetVehicleAssemblyMessages();

      if (vehiclesToAssembleDisplayed == messages.Length)
        return;
      
      System.Messaging.XmlMessageFormatter formatter;
      formatter = new System.Messaging.XmlMessageFormatter(new Type[] {typeof(WorkOrder)});
      
      listViewVehiclesToAssemble.Items.Clear();

      foreach (System.Messaging.Message message in messages)
      {
        message.Formatter = formatter;
        WorkOrder workOrder = message.Body as WorkOrder;
        ListViewItem item = new ListViewItem(workOrder.Id);
        listViewVehiclesToAssemble.Items.Add(item);
      }
      vehiclesToAssembleDisplayed = messages.Length;
    }
  }
}
