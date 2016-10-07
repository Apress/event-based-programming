using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SystemBrowser
{
	public class FormSplash : System.Windows.Forms.Form
	{
    #region Controls
    private System.Windows.Forms.Panel panelMain;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.ProgressBar progressBar1;
		private System.ComponentModel.Container components = null;
    #endregion

		public FormSplash()
		{
			InitializeComponent();
		}

    public void UpdateProgress(int thePercentComplete)
    {
      if (thePercentComplete < 0) thePercentComplete = 0;
      if (thePercentComplete > 100) thePercentComplete = 100;
      progressBar1.Value = thePercentComplete;
      progressBar1.Update();
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
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormSplash));
      this.panelMain = new System.Windows.Forms.Panel();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      this.panelMain.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelMain
      // 
      this.panelMain.BackColor = System.Drawing.Color.Honeydew;
      this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panelMain.Controls.Add(this.pictureBox1);
      this.panelMain.Controls.Add(this.label1);
      this.panelMain.Controls.Add(this.progressBar1);
      this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelMain.Location = new System.Drawing.Point(0, 0);
      this.panelMain.Name = "panelMain";
      this.panelMain.Size = new System.Drawing.Size(300, 98);
      this.panelMain.TabIndex = 0;
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
      this.pictureBox1.Location = new System.Drawing.Point(34, 26);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(34, 32);
      this.pictureBox1.TabIndex = 1;
      this.pictureBox1.TabStop = false;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(82, 36);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(165, 18);
      this.label1.TabIndex = 0;
      this.label1.Text = "Loading System Explorer...";
      // 
      // progressBar1
      // 
      this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.progressBar1.Location = new System.Drawing.Point(0, 82);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(298, 14);
      this.progressBar1.TabIndex = 1;
      // 
      // FormSplash
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
      this.ClientSize = new System.Drawing.Size(300, 98);
      this.Controls.Add(this.panelMain);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormSplash";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "FormSplash";
      this.panelMain.ResumeLayout(false);
      this.ResumeLayout(false);

    }
		#endregion
	}
}
