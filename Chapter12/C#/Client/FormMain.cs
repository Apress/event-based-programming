using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Client
{
	/// <summary>
	/// Summary description for FormMain.
	/// </summary>
  public class FormMain : System.Windows.Forms.Form
  {
    #region Controls
    private System.Windows.Forms.Label labelRequestsInProgress;
    private System.Windows.Forms.Label label32;
    private System.Windows.Forms.ListView listViewResponses;
    private System.Windows.Forms.ColumnHeader columnHeaderTimestamp;
    private System.Windows.Forms.ColumnHeader columnHeadeResponseTime;
    private System.Windows.Forms.ColumnHeader columnHeaderSequenceNumber;
    private System.Windows.Forms.ColumnHeader columnHeaderResponseMessage;
    private System.Windows.Forms.Label label30;
    private System.Windows.Forms.Label label31;
    private System.Windows.Forms.Button buttonSend;
    private System.Windows.Forms.Button buttonClearList;
    private System.Windows.Forms.Panel panelTop;
	  private System.ComponentModel.Container components = null;
    private System.Windows.Forms.NumericUpDown numericUpDownNumberOfPipelinedRequests;
    #endregion

    Coordinator coordinator;
    int numberOfRequestsInProgress;

    public FormMain()
    {
      InitializeComponent();
      columnHeaderResponseMessage.Width = -2;  // auto size last column

      coordinator = new Coordinator(this);
      coordinator.OnRequestSent += new Coordinator.RequestSentHandler(RequestSent);
      coordinator.OnResponseReceived += new Coordinator.ResponseReceivedHandler(ResponseReceived);
    }

    private void RequestSent()
    {
      numberOfRequestsInProgress++;
      labelRequestsInProgress.Text = numberOfRequestsInProgress.ToString();
      labelRequestsInProgress.Update();
      Cursor = Cursors.WaitCursor;
    }

    private void ResponseReceived(int theSequenceNumber, string theResponse, TimeSpan theProcessingTime)
    {
      string s = DateTime.Now.ToString("HH:mm:ss.ffff");
      ListViewItem item = new ListViewItem(s);
      s = ((int)theProcessingTime.TotalMilliseconds).ToString();
      item.SubItems.Add(s + " ms");
      item.SubItems.Add(theSequenceNumber.ToString() );
      item.SubItems.Add(theResponse);

      listViewResponses.Items.Add(item);

      numberOfRequestsInProgress--;
      labelRequestsInProgress.Text = numberOfRequestsInProgress.ToString();
      if (numberOfRequestsInProgress == 0)
        Cursor = Cursors.Default;
    }
    
    private void FormMain_Resize(object sender, System.EventArgs e)
    {
      columnHeaderResponseMessage.Width = -2;  // auto size last column
    }

    private void buttonSend_Click(object sender, System.EventArgs e)
    {
      coordinator.Send((int) numericUpDownNumberOfPipelinedRequests.Value);
    }

    private void buttonClearList_Click(object sender, System.EventArgs e)
    {
      listViewResponses.Items.Clear();
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
      this.labelRequestsInProgress = new System.Windows.Forms.Label();
      this.label32 = new System.Windows.Forms.Label();
      this.listViewResponses = new System.Windows.Forms.ListView();
      this.columnHeaderTimestamp = new System.Windows.Forms.ColumnHeader();
      this.columnHeadeResponseTime = new System.Windows.Forms.ColumnHeader();
      this.columnHeaderSequenceNumber = new System.Windows.Forms.ColumnHeader();
      this.columnHeaderResponseMessage = new System.Windows.Forms.ColumnHeader();
      this.buttonClearList = new System.Windows.Forms.Button();
      this.numericUpDownNumberOfPipelinedRequests = new System.Windows.Forms.NumericUpDown();
      this.label30 = new System.Windows.Forms.Label();
      this.label31 = new System.Windows.Forms.Label();
      this.buttonSend = new System.Windows.Forms.Button();
      this.panelTop = new System.Windows.Forms.Panel();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfPipelinedRequests)).BeginInit();
      this.panelTop.SuspendLayout();
      this.SuspendLayout();
      // 
      // labelRequestsInProgress
      // 
      this.labelRequestsInProgress.AutoSize = true;
      this.labelRequestsInProgress.Location = new System.Drawing.Point(294, 53);
      this.labelRequestsInProgress.Name = "labelRequestsInProgress";
      this.labelRequestsInProgress.Size = new System.Drawing.Size(13, 20);
      this.labelRequestsInProgress.TabIndex = 61;
      this.labelRequestsInProgress.Text = "0";
      this.labelRequestsInProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label32
      // 
      this.label32.AutoSize = true;
      this.label32.Location = new System.Drawing.Point(134, 53);
      this.label32.Name = "label32";
      this.label32.Size = new System.Drawing.Size(141, 20);
      this.label32.TabIndex = 60;
      this.label32.Text = "Requests in progress:";
      this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // listViewResponses
      // 
      this.listViewResponses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                        this.columnHeaderTimestamp,
                                                                                        this.columnHeadeResponseTime,
                                                                                        this.columnHeaderSequenceNumber,
                                                                                        this.columnHeaderResponseMessage});
      this.listViewResponses.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listViewResponses.Location = new System.Drawing.Point(0, 114);
      this.listViewResponses.Name = "listViewResponses";
      this.listViewResponses.Size = new System.Drawing.Size(646, 291);
      this.listViewResponses.TabIndex = 59;
      this.listViewResponses.View = System.Windows.Forms.View.Details;
      // 
      // columnHeaderTimestamp
      // 
      this.columnHeaderTimestamp.Text = "Timestamp";
      this.columnHeaderTimestamp.Width = 100;
      // 
      // columnHeadeResponseTime
      // 
      this.columnHeadeResponseTime.Text = "Response Time";
      this.columnHeadeResponseTime.Width = 150;
      // 
      // columnHeaderSequenceNumber
      // 
      this.columnHeaderSequenceNumber.Text = "Sequence Number";
      this.columnHeaderSequenceNumber.Width = 150;
      // 
      // columnHeaderResponseMessage
      // 
      this.columnHeaderResponseMessage.Text = "Response Message";
      this.columnHeaderResponseMessage.Width = 200;
      // 
      // buttonClearList
      // 
      this.buttonClearList.Location = new System.Drawing.Point(526, 80);
      this.buttonClearList.Name = "buttonClearList";
      this.buttonClearList.Size = new System.Drawing.Size(98, 28);
      this.buttonClearList.TabIndex = 58;
      this.buttonClearList.Text = "Clear List";
      this.buttonClearList.Click += new System.EventHandler(this.buttonClearList_Click);
      // 
      // numericUpDownNumberOfPipelinedRequests
      // 
      this.numericUpDownNumberOfPipelinedRequests.Location = new System.Drawing.Point(297, 21);
      this.numericUpDownNumberOfPipelinedRequests.Maximum = new System.Decimal(new int[] {
                                                                                           200,
                                                                                           0,
                                                                                           0,
                                                                                           0});
      this.numericUpDownNumberOfPipelinedRequests.Minimum = new System.Decimal(new int[] {
                                                                                           1,
                                                                                           0,
                                                                                           0,
                                                                                           0});
      this.numericUpDownNumberOfPipelinedRequests.Name = "numericUpDownNumberOfPipelinedRequests";
      this.numericUpDownNumberOfPipelinedRequests.Size = new System.Drawing.Size(67, 24);
      this.numericUpDownNumberOfPipelinedRequests.TabIndex = 57;
      this.numericUpDownNumberOfPipelinedRequests.Value = new System.Decimal(new int[] {
                                                                                         1,
                                                                                         0,
                                                                                         0,
                                                                                         0});
      // 
      // label30
      // 
      this.label30.AutoSize = true;
      this.label30.Location = new System.Drawing.Point(17, 24);
      this.label30.Name = "label30";
      this.label30.Size = new System.Drawing.Size(245, 20);
      this.label30.TabIndex = 56;
      this.label30.Text = "Number of pipelined requests to send:";
      this.label30.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // label31
      // 
      this.label31.AutoSize = true;
      this.label31.Location = new System.Drawing.Point(8, 95);
      this.label31.Name = "label31";
      this.label31.Size = new System.Drawing.Size(76, 20);
      this.label31.TabIndex = 55;
      this.label31.Text = "Responses:";
      // 
      // buttonSend
      // 
      this.buttonSend.Location = new System.Drawing.Point(400, 19);
      this.buttonSend.Name = "buttonSend";
      this.buttonSend.Size = new System.Drawing.Size(105, 28);
      this.buttonSend.TabIndex = 54;
      this.buttonSend.Text = "Send";
      this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
      // 
      // panelTop
      // 
      this.panelTop.Controls.Add(this.numericUpDownNumberOfPipelinedRequests);
      this.panelTop.Controls.Add(this.buttonClearList);
      this.panelTop.Controls.Add(this.label32);
      this.panelTop.Controls.Add(this.labelRequestsInProgress);
      this.panelTop.Controls.Add(this.buttonSend);
      this.panelTop.Controls.Add(this.label31);
      this.panelTop.Controls.Add(this.label30);
      this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelTop.Location = new System.Drawing.Point(0, 0);
      this.panelTop.Name = "panelTop";
      this.panelTop.Size = new System.Drawing.Size(646, 114);
      this.panelTop.TabIndex = 62;
      // 
      // FormMain
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(7, 17);
      this.ClientSize = new System.Drawing.Size(646, 405);
      this.Controls.Add(this.listViewResponses);
      this.Controls.Add(this.panelTop);
      this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.Name = "FormMain";
      this.Text = "Client Test Fixture for Pipelined HTTP Service";
      this.Resize += new System.EventHandler(this.FormMain_Resize);
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfPipelinedRequests)).EndInit();
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
