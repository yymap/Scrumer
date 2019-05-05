using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Ringff.Updater
{
	
	public class frmPassword : Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPwd;
		private System.Windows.Forms.Button btnEnter; 
		
		private System.ComponentModel.Container components = null;

		public frmPassword()
		{
			InitializeComponent();
		}

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

		#region Windows Genereated Code
		
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Password";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(78, 7);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(93, 20);
            this.txtPwd.TabIndex = 1;
            this.txtPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(192, 7);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(54, 22);
            this.btnEnter.TabIndex = 2;
            this.btnEnter.Text = "Confirm";
            this.btnEnter.Click += new System.EventHandler(this.btEnter_Click);
            // 
            // frmPassword
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(290, 40);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter Password";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmPassword_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        public bool passwordIsRight = false;


        public bool PasswordIsRight
        {
            get
            {
                return this.passwordIsRight;
            }
            set
            {
                this.passwordIsRight = value;
            }
        }

        private int maxTryCount = 3;


        private int MaxTryCount
        {
            get
            {
                return maxTryCount;
            }
            set
            {
                maxTryCount = value;
            }
        }

		private void btEnter_Click(object sender, System.EventArgs e)
		{
			string strPassWord = UpdateHelper.GetAppConfig("Pwd");

            if (this.txtPwd.Text == strPassWord)
			{
				PasswordIsRight = true;
				this.Visible =false; 
			}
			else 
			{
				MaxTryCount--; 
				
				if(MaxTryCount <= 0)
				{
					PasswordIsRight = false;
					this.Visible =false;  
				}
				else 
				{
					MessageBox.Show("Invalid password, enter again:");
					this.Text = "You have " + MaxTryCount.ToString() +" times to try.";
					this.txtPwd.Focus();
				}
			}
			
		}

		private void frmPassword_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(Visible)
			{
				PasswordIsRight = false;
			}
			this.Visible = false;
		}

		private void txtPassword_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyData == Keys.Enter)
			{
				btEnter_Click(new object(),new EventArgs());
			}
		}
	}
}
