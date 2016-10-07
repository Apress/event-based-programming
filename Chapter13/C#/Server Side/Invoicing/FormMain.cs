using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Asap.Cars.CommonTypes;

namespace Asap.Cars.Invoicing
{
	/// <summary>
	/// Summary description for FormMain.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
    #region Controls
		private System.ComponentModel.Container components = null;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label labelInvoicesGenerated;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label labelModel;
    private System.Windows.Forms.Label labelStyle;
    private System.Windows.Forms.Label labelColor;
    private System.Windows.Forms.Label labelOptions;
    #endregion

    // manages connections to incoming and outgoing message queues
    Router router;
    
    public FormMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
      System.Threading.Thread.CurrentThread.Name = "User Interface";

      router = new Router();
      router.OnMessage += new Router.MessageHandler(HandleOrder);
    }

    delegate void WorkOrderHandler(WorkOrder theWorkOrder);
    private void HandleOrder(WorkOrder theWorkOrder)
    {
      // process order on the UI thread
      this.Invoke(new WorkOrderHandler(DoHandleOrder), new object[] {theWorkOrder});
    }

    int invoiceCount = 0;
    private void DoHandleOrder(WorkOrder theWorkOrder)
    {
      // just update the displayed info
      invoiceCount++;
      labelInvoicesGenerated.Text = invoiceCount.ToString();
      labelModel.Text = theWorkOrder.Model;
      labelStyle.Text = theWorkOrder.Style;
      labelColor.Text = theWorkOrder.Color;

      string options = string.Empty;
      for (int i = 0; i < theWorkOrder.Options.Length; i++)
        options += string.Format("{0};", theWorkOrder.Options[i].Name);
      labelOptions.Text = options;
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
      this.labelInvoicesGenerated = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.labelOptions = new System.Windows.Forms.Label();
      this.labelColor = new System.Windows.Forms.Label();
      this.labelStyle = new System.Windows.Forms.Label();
      this.labelModel = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(30, 32);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(158, 16);
      this.label1.TabIndex = 0;
      this.label1.Text = "Number of invoices generated:";
      // 
      // labelInvoicesGenerated
      // 
      this.labelInvoicesGenerated.AutoSize = true;
      this.labelInvoicesGenerated.Location = new System.Drawing.Point(182, 32);
      this.labelInvoicesGenerated.Name = "labelInvoicesGenerated";
      this.labelInvoicesGenerated.Size = new System.Drawing.Size(10, 16);
      this.labelInvoicesGenerated.TabIndex = 1;
      this.labelInvoicesGenerated.Text = "0";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.labelOptions);
      this.groupBox1.Controls.Add(this.labelColor);
      this.groupBox1.Controls.Add(this.labelStyle);
      this.groupBox1.Controls.Add(this.labelModel);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Location = new System.Drawing.Point(30, 68);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(282, 138);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Details for last invoice generated";
      // 
      // labelOptions
      // 
      this.labelOptions.Location = new System.Drawing.Point(60, 90);
      this.labelOptions.Name = "labelOptions";
      this.labelOptions.Size = new System.Drawing.Size(208, 38);
      this.labelOptions.TabIndex = 7;
      this.labelOptions.Text = "<options>";
      // 
      // labelColor
      // 
      this.labelColor.AutoSize = true;
      this.labelColor.Location = new System.Drawing.Point(60, 70);
      this.labelColor.Name = "labelColor";
      this.labelColor.Size = new System.Drawing.Size(42, 16);
      this.labelColor.TabIndex = 6;
      this.labelColor.Text = "<color>";
      // 
      // labelStyle
      // 
      this.labelStyle.AutoSize = true;
      this.labelStyle.Location = new System.Drawing.Point(60, 50);
      this.labelStyle.Name = "labelStyle";
      this.labelStyle.Size = new System.Drawing.Size(41, 16);
      this.labelStyle.TabIndex = 5;
      this.labelStyle.Text = "<style>";
      // 
      // labelModel
      // 
      this.labelModel.AutoSize = true;
      this.labelModel.Location = new System.Drawing.Point(60, 30);
      this.labelModel.Name = "labelModel";
      this.labelModel.Size = new System.Drawing.Size(48, 16);
      this.labelModel.TabIndex = 4;
      this.labelModel.Text = "<model>";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(10, 90);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(46, 16);
      this.label5.TabIndex = 3;
      this.label5.Text = "Options:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(22, 70);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(34, 16);
      this.label4.TabIndex = 2;
      this.label4.Text = "Color:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(23, 50);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(33, 16);
      this.label3.TabIndex = 1;
      this.label3.Text = "Style:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(18, 30);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(38, 16);
      this.label2.TabIndex = 0;
      this.label2.Text = "Model:";
      // 
      // FormMain
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(340, 228);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.labelInvoicesGenerated);
      this.Controls.Add(this.label1);
      this.Name = "FormMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Invoicing";
      this.groupBox1.ResumeLayout(false);
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
	}
}
