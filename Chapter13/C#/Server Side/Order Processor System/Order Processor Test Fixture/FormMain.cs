using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Asap.Cars.OrderProcessor;
using Asap.Cars.CommonTypes;

namespace Asap.Cars.OrderProcessor.TestFixture
{
	/// <summary>
	/// Summary description for FormMain.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
    #region Controls
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button buttonSubmitOrder;
    private System.Windows.Forms.Button buttonGetModels;
    private System.Windows.Forms.Button buttonGetStyles;
    private System.Windows.Forms.Button buttonGetColors;
    private System.Windows.Forms.TextBox textBoxOptions;
    private System.Windows.Forms.ComboBox comboBoxModels;
    private System.Windows.Forms.ComboBox comboBoxStyles;
    private System.Windows.Forms.ComboBox comboBoxColors;
    private System.Windows.Forms.Button buttonGetOptions;
		private System.ComponentModel.Container components = null;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button buttonClearQueue;
    private System.Windows.Forms.ListView listViewQueuedMessages;
    private System.Windows.Forms.ColumnHeader columnHeaderModel;
    private System.Windows.Forms.ColumnHeader columnHeaderStyle;
    private System.Windows.Forms.ColumnHeader columnHeaderOptions;
    private System.Windows.Forms.Button buttonRefreshList;
    private System.Windows.Forms.ColumnHeader columnHeaderColor;
    #endregion

    OrderSystem orderSystem = new OrderSystem();

		public FormMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

      comboBoxColors.Items.Add("White");
      comboBoxColors.SelectedIndex = 0;

      columnHeaderOptions.Width = -2;  // auto size last column

      DisplayQueuedMessages();
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
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.buttonSubmitOrder = new System.Windows.Forms.Button();
      this.textBoxOptions = new System.Windows.Forms.TextBox();
      this.comboBoxModels = new System.Windows.Forms.ComboBox();
      this.comboBoxStyles = new System.Windows.Forms.ComboBox();
      this.comboBoxColors = new System.Windows.Forms.ComboBox();
      this.buttonGetModels = new System.Windows.Forms.Button();
      this.buttonGetStyles = new System.Windows.Forms.Button();
      this.buttonGetColors = new System.Windows.Forms.Button();
      this.buttonGetOptions = new System.Windows.Forms.Button();
      this.label5 = new System.Windows.Forms.Label();
      this.buttonClearQueue = new System.Windows.Forms.Button();
      this.listViewQueuedMessages = new System.Windows.Forms.ListView();
      this.columnHeaderModel = new System.Windows.Forms.ColumnHeader();
      this.columnHeaderStyle = new System.Windows.Forms.ColumnHeader();
      this.columnHeaderColor = new System.Windows.Forms.ColumnHeader();
      this.columnHeaderOptions = new System.Windows.Forms.ColumnHeader();
      this.buttonRefreshList = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(46, 20);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(38, 16);
      this.label1.TabIndex = 0;
      this.label1.Text = "Model:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(51, 52);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(33, 16);
      this.label2.TabIndex = 1;
      this.label2.Text = "Style:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(50, 80);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(34, 16);
      this.label3.TabIndex = 2;
      this.label3.Text = "Color:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(38, 112);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(46, 16);
      this.label4.TabIndex = 3;
      this.label4.Text = "Options:";
      // 
      // buttonSubmitOrder
      // 
      this.buttonSubmitOrder.Location = new System.Drawing.Point(114, 200);
      this.buttonSubmitOrder.Name = "buttonSubmitOrder";
      this.buttonSubmitOrder.Size = new System.Drawing.Size(86, 23);
      this.buttonSubmitOrder.TabIndex = 4;
      this.buttonSubmitOrder.Text = "Submit Order";
      this.buttonSubmitOrder.Click += new System.EventHandler(this.buttonSubmitOrder_Click);
      // 
      // textBoxOptions
      // 
      this.textBoxOptions.Location = new System.Drawing.Point(86, 110);
      this.textBoxOptions.Multiline = true;
      this.textBoxOptions.Name = "textBoxOptions";
      this.textBoxOptions.Size = new System.Drawing.Size(168, 60);
      this.textBoxOptions.TabIndex = 8;
      this.textBoxOptions.Text = "Option1\r\nOption2";
      // 
      // comboBoxModels
      // 
      this.comboBoxModels.Location = new System.Drawing.Point(86, 16);
      this.comboBoxModels.Name = "comboBoxModels";
      this.comboBoxModels.Size = new System.Drawing.Size(168, 21);
      this.comboBoxModels.TabIndex = 9;
      this.comboBoxModels.Text = "Safari";
      // 
      // comboBoxStyles
      // 
      this.comboBoxStyles.Location = new System.Drawing.Point(86, 48);
      this.comboBoxStyles.Name = "comboBoxStyles";
      this.comboBoxStyles.Size = new System.Drawing.Size(168, 21);
      this.comboBoxStyles.TabIndex = 10;
      this.comboBoxStyles.Text = "4-door sedan";
      // 
      // comboBoxColors
      // 
      this.comboBoxColors.Location = new System.Drawing.Point(86, 78);
      this.comboBoxColors.Name = "comboBoxColors";
      this.comboBoxColors.Size = new System.Drawing.Size(168, 21);
      this.comboBoxColors.TabIndex = 11;
      // 
      // buttonGetModels
      // 
      this.buttonGetModels.Location = new System.Drawing.Point(266, 14);
      this.buttonGetModels.Name = "buttonGetModels";
      this.buttonGetModels.TabIndex = 12;
      this.buttonGetModels.Text = "Get Models";
      this.buttonGetModels.Click += new System.EventHandler(this.buttonGetModels_Click);
      // 
      // buttonGetStyles
      // 
      this.buttonGetStyles.Location = new System.Drawing.Point(266, 46);
      this.buttonGetStyles.Name = "buttonGetStyles";
      this.buttonGetStyles.TabIndex = 13;
      this.buttonGetStyles.Text = "Get Styles";
      this.buttonGetStyles.Click += new System.EventHandler(this.buttonGetStyles_Click);
      // 
      // buttonGetColors
      // 
      this.buttonGetColors.Location = new System.Drawing.Point(266, 78);
      this.buttonGetColors.Name = "buttonGetColors";
      this.buttonGetColors.TabIndex = 14;
      this.buttonGetColors.Text = "Get Colors";
      this.buttonGetColors.Click += new System.EventHandler(this.buttonGetColors_Click);
      // 
      // buttonGetOptions
      // 
      this.buttonGetOptions.Location = new System.Drawing.Point(266, 113);
      this.buttonGetOptions.Name = "buttonGetOptions";
      this.buttonGetOptions.TabIndex = 15;
      this.buttonGetOptions.Text = "Get Options";
      this.buttonGetOptions.Click += new System.EventHandler(this.buttonGetOptions_Click);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(388, 14);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(102, 16);
      this.label5.TabIndex = 17;
      this.label5.Text = "Queued Messages:";
      // 
      // buttonClearQueue
      // 
      this.buttonClearQueue.Location = new System.Drawing.Point(430, 186);
      this.buttonClearQueue.Name = "buttonClearQueue";
      this.buttonClearQueue.Size = new System.Drawing.Size(80, 23);
      this.buttonClearQueue.TabIndex = 18;
      this.buttonClearQueue.Text = "Clear Queue";
      this.buttonClearQueue.Click += new System.EventHandler(this.buttonClearQueue_Click);
      // 
      // listViewQueuedMessages
      // 
      this.listViewQueuedMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                             this.columnHeaderModel,
                                                                                             this.columnHeaderStyle,
                                                                                             this.columnHeaderColor,
                                                                                             this.columnHeaderOptions});
      this.listViewQueuedMessages.Location = new System.Drawing.Point(390, 30);
      this.listViewQueuedMessages.Name = "listViewQueuedMessages";
      this.listViewQueuedMessages.Size = new System.Drawing.Size(326, 142);
      this.listViewQueuedMessages.TabIndex = 19;
      this.listViewQueuedMessages.View = System.Windows.Forms.View.Details;
      // 
      // columnHeaderModel
      // 
      this.columnHeaderModel.Text = "Model";
      this.columnHeaderModel.Width = 69;
      // 
      // columnHeaderStyle
      // 
      this.columnHeaderStyle.Text = "Style";
      this.columnHeaderStyle.Width = 91;
      // 
      // columnHeaderColor
      // 
      this.columnHeaderColor.Text = "Color";
      // 
      // columnHeaderOptions
      // 
      this.columnHeaderOptions.Text = "Options";
      this.columnHeaderOptions.Width = 101;
      // 
      // buttonRefreshList
      // 
      this.buttonRefreshList.Location = new System.Drawing.Point(580, 186);
      this.buttonRefreshList.Name = "buttonRefreshList";
      this.buttonRefreshList.TabIndex = 20;
      this.buttonRefreshList.Text = "Refresh List";
      this.buttonRefreshList.Click += new System.EventHandler(this.buttonRefreshList_Click);
      // 
      // FormMain
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(726, 248);
      this.Controls.Add(this.buttonRefreshList);
      this.Controls.Add(this.listViewQueuedMessages);
      this.Controls.Add(this.buttonClearQueue);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.buttonGetOptions);
      this.Controls.Add(this.buttonGetColors);
      this.Controls.Add(this.buttonGetStyles);
      this.Controls.Add(this.buttonGetModels);
      this.Controls.Add(this.comboBoxColors);
      this.Controls.Add(this.comboBoxStyles);
      this.Controls.Add(this.comboBoxModels);
      this.Controls.Add(this.textBoxOptions);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.buttonSubmitOrder);
      this.Name = "FormMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Order Processor Test Fixture";
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

    private void buttonGetModels_Click(object sender, System.EventArgs e)
    {
      string[] models = orderSystem.GetModels();
      comboBoxModels.Items.Clear();
      if (models == null) return;

      foreach (string model in models)
        comboBoxModels.Items.Add(model);
      comboBoxModels.SelectedIndex = 0;
    }

    private void buttonGetStyles_Click(object sender, System.EventArgs e)
    {
      string[] styles = orderSystem.GetStyles(comboBoxModels.Text);
      comboBoxStyles.Items.Clear();
      if (styles == null) return;

      foreach (string style in styles)
        comboBoxStyles.Items.Add(style);
      comboBoxStyles.SelectedIndex = 0;
    }

    private void buttonGetColors_Click(object sender, System.EventArgs e)
    {
      Color[] colors = orderSystem.GetColors(comboBoxModels.Text, comboBoxStyles.Text);
      comboBoxColors.Items.Clear();
      if (colors == null) return;

      foreach (Color color in colors)
        comboBoxColors.Items.Add(color.Name);
      comboBoxColors.SelectedIndex = 0;
    }

    ArrayList options = new ArrayList();
    private void buttonGetOptions_Click(object sender, System.EventArgs e)
    {
      options = orderSystem.GetOptions(comboBoxModels.Text, comboBoxStyles.Text);
      textBoxOptions.Text = "";
      if (options == null) return;

      ArrayList items = new ArrayList();
      foreach (PricedItem[] pricedItems in options)
        foreach (PricedItem pricedItem in pricedItems)
          items.Add(pricedItem);

      // show options in the textbox
      string[] lines = new string[items.Count];
      for (int i = 0; i < items.Count; i++)
        lines[i] = (items[i] as PricedItem).Name;
      textBoxOptions.Lines = lines;
    }

    private void buttonSubmitOrder_Click(object sender, System.EventArgs e)
    {
      PricedItem[] requestedOptions;
      if (options.Count > 0)
      {

      // convert an array of PriceItem arrays into a PricedItem array
      ArrayList items = new ArrayList();
      foreach (PricedItem[] pricedItems in options)
        foreach (PricedItem pricedItem in pricedItems)
          items.Add(pricedItem);
        requestedOptions = items.ToArray(typeof(PricedItem)) as PricedItem[];
      }
      else
        requestedOptions = new PricedItem[] {new PricedItem("Option1", 11), new PricedItem("Option2", 22)};

      Color color = Color.FromName(comboBoxColors.Text);
      orderSystem.SubmitOrder(comboBoxModels.Text, comboBoxStyles.Text, color, requestedOptions);
      DisplayQueuedMessages();
    }

    private void DisplayQueuedMessages()
    {
      listViewQueuedMessages.Items.Clear();

      System.Messaging.Message[] messages = orderSystem.GetAllQueuedMessages();
      System.Messaging.XmlMessageFormatter formatter;
      formatter = new System.Messaging.XmlMessageFormatter(new Type[] {typeof(WorkOrder)});
      
      foreach (System.Messaging.Message message in messages)
      {
        message.Formatter = formatter;
        WorkOrder workOrder = message.Body as WorkOrder;
        ListViewItem item = new ListViewItem(workOrder.Model);
        item.SubItems.Add(workOrder.Style);
        item.SubItems.Add(workOrder.Color);
        string options = string.Empty;
        foreach (PricedItem option in workOrder.Options)
          options += option.Name + ";";
        item.SubItems.Add(options);
        listViewQueuedMessages.Items.Add(item);
      }
    }

    private void buttonClearQueue_Click(object sender, System.EventArgs e)
    {
      orderSystem.ClearQueuedMessages();
      DisplayQueuedMessages();
    }

    private void buttonRefreshList_Click(object sender, System.EventArgs e)
    {
      DisplayQueuedMessages();
    }
  }
}
