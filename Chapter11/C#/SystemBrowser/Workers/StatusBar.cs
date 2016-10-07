using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace SystemBrowser
{
	/// <summary>
	/// StatusBar is a simple bar shown at the bottom
	/// of the application's main window.
	/// </summary>
	public class StatusBar : System.Windows.Forms.UserControl
	{
    private System.Windows.Forms.Label labelMessage;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public StatusBar()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

    public void Message(string theMessage)
    {
      labelMessage.Text = theMessage;
      labelMessage.Update();
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
      this.labelMessage = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // labelMessage
      // 
      this.labelMessage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelMessage.Location = new System.Drawing.Point(0, 0);
      this.labelMessage.Name = "labelMessage";
      this.labelMessage.Size = new System.Drawing.Size(421, 24);
      this.labelMessage.TabIndex = 0;
      this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // StatusBar
      // 
      this.Controls.Add(this.labelMessage);
      this.Name = "StatusBar";
      this.Size = new System.Drawing.Size(421, 24);
      this.ResumeLayout(false);

    }
		#endregion
	}
}
