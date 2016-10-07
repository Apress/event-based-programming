using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SystemBrowser
{
	/// <summary>
	/// FormAbout is a simple Help About form.
	/// </summary>
	public class FormAbout : System.Windows.Forms.Form
	{
    #region Controls
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button buttonClose;
    private System.Windows.Forms.PictureBox pictureBox1;
		private System.ComponentModel.Container components = null;
    #endregion

		public FormAbout()
		{
			//
			// Required for Windows Form Designer support
			//
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormAbout));
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.buttonClose = new System.Windows.Forms.Button();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(61, 22);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(344, 108);
      this.label1.TabIndex = 0;
      this.label1.Text = @"SystemBrowser is a simple application that demonstrates how to build a UI program using Workers, Coordinators, Builders and Binders. By using an event-based architecture, most classes are completely decoupled form others, and can be tested independently with a test fixture.";
      // 
      // label2
      // 
      this.label2.Font = new System.Drawing.Font("Tahoma", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label2.Location = new System.Drawing.Point(12, 144);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(140, 28);
      this.label2.TabIndex = 1;
      this.label2.Text = "Ted Faison - Nov 2005";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // buttonClose
      // 
      this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.buttonClose.Location = new System.Drawing.Point(300, 145);
      this.buttonClose.Name = "buttonClose";
      this.buttonClose.Size = new System.Drawing.Size(74, 29);
      this.buttonClose.TabIndex = 2;
      this.buttonClose.Text = "Close";
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
      this.pictureBox1.Location = new System.Drawing.Point(14, 22);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(32, 33);
      this.pictureBox1.TabIndex = 3;
      this.pictureBox1.TabStop = false;
      // 
      // FormAbout
      // 
      this.AcceptButton = this.buttonClose;
      this.AutoScaleBaseSize = new System.Drawing.Size(7, 17);
      this.ClientSize = new System.Drawing.Size(414, 189);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.buttonClose);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.DockPadding.Left = 13;
      this.DockPadding.Right = 13;
      this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "FormAbout";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "About this program";
      this.ResumeLayout(false);

    }
		#endregion

	}
}
