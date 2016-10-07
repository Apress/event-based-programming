using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace HostEmulator
{
	/// <summary>
	/// Summary description for FormMain.
	/// </summary>
  public class FormMain : System.Windows.Forms.Form
  {
    #region Controls
    private System.Windows.Forms.Panel panelMain;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label labelActiveConnections;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label labelRequestsInProgress;
    private System.Windows.Forms.Label labelRequestsReceived;
    private System.Windows.Forms.Label label6;
    private System.ComponentModel.Container components = null;
    private System.Windows.Forms.Panel panelTop;
    private System.Windows.Forms.Panel panelCenter;
    private System.Windows.Forms.ListView listViewResponses;
    private System.Windows.Forms.ColumnHeader columnHeaderTimestamp;
    private System.Windows.Forms.ColumnHeader columnHeaderSequenceNumber;
    private System.Windows.Forms.ColumnHeader columnHeaderProcessingTime;
    private System.Windows.Forms.ColumnHeader columnHeaderResponse;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button buttonClearList;
    #endregion

    int numberOfActiveConnections;
    int numberOfRequestsReceived;
    int numberOfRequestsInProgress;

    CoordinatorIncomingTraffic incomingTraffic;

    public FormMain()
    {
      InitializeComponent();
      columnHeaderResponse.Width = -2;  // autosize last column
      ListenForRequests();
    }

    void ListenForRequests()
    {
      incomingTraffic = new CoordinatorIncomingTraffic(this);

      incomingTraffic.OnClientConnected += new CoordinatorIncomingTraffic.ClientConnectedHandler(ClientConnected);
      incomingTraffic.OnRequestStarted += new CoordinatorIncomingTraffic.RequestStartedHandler(RequestStarted);
      incomingTraffic.OnRequestProcessed += new CoordinatorIncomingTraffic.RequestProcessedHandler(RequestProcessed);

      incomingTraffic.Run();
    }

    private void ClientConnected()
    {
      numberOfActiveConnections++;
      labelActiveConnections.Text = numberOfActiveConnections.ToString();
    }

    public void RequestStarted()
    {
      numberOfRequestsReceived++;
      labelRequestsReceived.Text = numberOfRequestsReceived.ToString();

      numberOfRequestsInProgress++;
      labelRequestsInProgress.Text = numberOfRequestsInProgress.ToString() + " ms";
    }
      
    public void RequestProcessed(string theRequest, int theSequenceNumber, int theDuration, string theResponse)
    {
      numberOfRequestsInProgress--;
      labelRequestsInProgress.Text = numberOfRequestsInProgress.ToString();

      ListViewItem item = new ListViewItem(DateTime.Now.ToString("HH:mm:ss.fff"));
      item.SubItems.Add(theDuration.ToString());
      item.SubItems.Add(theSequenceNumber.ToString());
      item.SubItems.Add(theResponse);
      listViewResponses.Items.Add(item);
    }

    private void buttonClearList_Click(object sender, System.EventArgs e)
    {
      numberOfRequestsReceived = 0;
      labelRequestsReceived.Text = numberOfRequestsReceived.ToString();
      listViewResponses.Items.Clear();
    }

    private void FormMain_Resize(object sender, System.EventArgs e)
    {
      columnHeaderResponse.Width = -2;  // autosize last column
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
      this.panelMain = new System.Windows.Forms.Panel();
      this.panelCenter = new System.Windows.Forms.Panel();
      this.listViewResponses = new System.Windows.Forms.ListView();
      this.columnHeaderTimestamp = new System.Windows.Forms.ColumnHeader();
      this.columnHeaderProcessingTime = new System.Windows.Forms.ColumnHeader();
      this.columnHeaderSequenceNumber = new System.Windows.Forms.ColumnHeader();
      this.columnHeaderResponse = new System.Windows.Forms.ColumnHeader();
      this.panelTop = new System.Windows.Forms.Panel();
      this.label1 = new System.Windows.Forms.Label();
      this.labelActiveConnections = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.labelRequestsReceived = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.labelRequestsInProgress = new System.Windows.Forms.Label();
      this.buttonClearList = new System.Windows.Forms.Button();
      this.panelMain.SuspendLayout();
      this.panelCenter.SuspendLayout();
      this.panelTop.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelMain
      // 
      this.panelMain.Controls.Add(this.panelCenter);
      this.panelMain.Controls.Add(this.panelTop);
      this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelMain.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.panelMain.Location = new System.Drawing.Point(0, 0);
      this.panelMain.Name = "panelMain";
      this.panelMain.Size = new System.Drawing.Size(671, 383);
      this.panelMain.TabIndex = 1;
      // 
      // panelCenter
      // 
      this.panelCenter.Controls.Add(this.listViewResponses);
      this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelCenter.Location = new System.Drawing.Point(0, 121);
      this.panelCenter.Name = "panelCenter";
      this.panelCenter.Size = new System.Drawing.Size(671, 262);
      this.panelCenter.TabIndex = 9;
      // 
      // listViewResponses
      // 
      this.listViewResponses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                        this.columnHeaderTimestamp,
                                                                                        this.columnHeaderProcessingTime,
                                                                                        this.columnHeaderSequenceNumber,
                                                                                        this.columnHeaderResponse});
      this.listViewResponses.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listViewResponses.Location = new System.Drawing.Point(0, 0);
      this.listViewResponses.Name = "listViewResponses";
      this.listViewResponses.Size = new System.Drawing.Size(671, 262);
      this.listViewResponses.TabIndex = 1;
      this.listViewResponses.View = System.Windows.Forms.View.Details;
      // 
      // columnHeaderTimestamp
      // 
      this.columnHeaderTimestamp.Text = "Timestamp";
      this.columnHeaderTimestamp.Width = 100;
      // 
      // columnHeaderProcessingTime
      // 
      this.columnHeaderProcessingTime.Text = "Processing Time";
      this.columnHeaderProcessingTime.Width = 150;
      // 
      // columnHeaderSequenceNumber
      // 
      this.columnHeaderSequenceNumber.Text = "Sequence Number";
      this.columnHeaderSequenceNumber.Width = 150;
      // 
      // columnHeaderResponse
      // 
      this.columnHeaderResponse.Text = "Response";
      this.columnHeaderResponse.Width = 200;
      // 
      // panelTop
      // 
      this.panelTop.Controls.Add(this.label1);
      this.panelTop.Controls.Add(this.labelActiveConnections);
      this.panelTop.Controls.Add(this.label6);
      this.panelTop.Controls.Add(this.label4);
      this.panelTop.Controls.Add(this.labelRequestsReceived);
      this.panelTop.Controls.Add(this.label2);
      this.panelTop.Controls.Add(this.labelRequestsInProgress);
      this.panelTop.Controls.Add(this.buttonClearList);
      this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelTop.Location = new System.Drawing.Point(0, 0);
      this.panelTop.Name = "panelTop";
      this.panelTop.Size = new System.Drawing.Size(671, 121);
      this.panelTop.TabIndex = 8;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(8, 97);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(104, 20);
      this.label1.TabIndex = 8;
      this.label1.Text = "Responses Sent";
      // 
      // labelActiveConnections
      // 
      this.labelActiveConnections.AutoSize = true;
      this.labelActiveConnections.Location = new System.Drawing.Point(308, 12);
      this.labelActiveConnections.Name = "labelActiveConnections";
      this.labelActiveConnections.Size = new System.Drawing.Size(13, 20);
      this.labelActiveConnections.TabIndex = 1;
      this.labelActiveConnections.Text = "0";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label6.Location = new System.Drawing.Point(76, 66);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(198, 19);
      this.label6.TabIndex = 5;
      this.label6.Text = "Number of requests received:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label4.Location = new System.Drawing.Point(59, 39);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(215, 19);
      this.label4.TabIndex = 2;
      this.label4.Text = "Number of requests in progress:";
      // 
      // labelRequestsReceived
      // 
      this.labelRequestsReceived.AutoSize = true;
      this.labelRequestsReceived.Location = new System.Drawing.Point(308, 66);
      this.labelRequestsReceived.Name = "labelRequestsReceived";
      this.labelRequestsReceived.Size = new System.Drawing.Size(13, 20);
      this.labelRequestsReceived.TabIndex = 6;
      this.labelRequestsReceived.Text = "0";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label2.Location = new System.Drawing.Point(70, 12);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(203, 19);
      this.label2.TabIndex = 0;
      this.label2.Text = "Number of active connections:";
      // 
      // labelRequestsInProgress
      // 
      this.labelRequestsInProgress.AutoSize = true;
      this.labelRequestsInProgress.Location = new System.Drawing.Point(308, 39);
      this.labelRequestsInProgress.Name = "labelRequestsInProgress";
      this.labelRequestsInProgress.Size = new System.Drawing.Size(13, 20);
      this.labelRequestsInProgress.TabIndex = 3;
      this.labelRequestsInProgress.Text = "0";
      // 
      // buttonClearList
      // 
      this.buttonClearList.Location = new System.Drawing.Point(549, 87);
      this.buttonClearList.Name = "buttonClearList";
      this.buttonClearList.Size = new System.Drawing.Size(109, 28);
      this.buttonClearList.TabIndex = 7;
      this.buttonClearList.Text = "Clear List";
      this.buttonClearList.Click += new System.EventHandler(this.buttonClearList_Click);
      // 
      // FormMain
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(7, 17);
      this.ClientSize = new System.Drawing.Size(671, 383);
      this.Controls.Add(this.panelMain);
      this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.Name = "FormMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Pipelined HTTP Host Emulator";
      this.Resize += new System.EventHandler(this.FormMain_Resize);
      this.panelMain.ResumeLayout(false);
      this.panelCenter.ResumeLayout(false);
      this.panelTop.ResumeLayout(false);
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
