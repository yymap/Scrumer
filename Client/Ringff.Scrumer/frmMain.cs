using MetroFramework.Components;
using MetroFramework.Forms;
using Ringff.Common.Object.Scrumer;
using Ringff.Scrumer.Poker;
using Ringff.Scrumer.Story;
using Ringff.Winform.Core;
using Ringff.Winform.Core.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ringff.Scrumer
{
    public partial class frmMain : Ringff.Winform.Core.frmBase
    {
       

        private static UserLogin currentLogin;

        public static UserLogin CurrentLogin
        {
            get
            {
                return currentLogin;
            }
            set
            {
                currentLogin = value;
            }
        }

        public frmMain()
        {
            InitializeComponent();
            
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        protected override void InitForm()
        {
            base.InitForm();
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            this.WindowState = FormWindowState.Maximized;
            tsItemPoker.Enabled = false;
            ChangeBackgroundColr();

            this.Text += String.Format(" Welcome, {0}!",CurrentLogin.Name);
        }

        private void ChangeBackgroundColr()
        {
            this.BackColor = Color.LightGreen;
            foreach(MdiClient c in  this.Controls.OfType<MdiClient>()){
                (c as MdiClient).BackColor = this.BackColor;
            }
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {            
            Close();
        }

        private bool ConfirmClose()
        {
            if (ShowAlertYesNoMessageBox("Are you sure to exit system?") != System.Windows.Forms.DialogResult.Yes)
            {
                return false;
            }
            return true;
        }

        protected virtual DialogResult ShowAlertYesNoMessageBox(String msg)
        {
            return MessageBox.Show(msg, "Alert", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
        }

        
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ConfirmClose())
            {
                e.Cancel = true;
                return;
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormUtil.CloseMainForm<frmLogin>();
        }

        private void tsItemStory_Click(object sender, EventArgs e)
        {
            ShowStoryForm();
        }

        private void ShowStoryForm()
        {
            if (this.MdiChildren != null)
            {
                foreach (Form fm in this.MdiChildren)
                {
                    if (fm is frmStoryMain)
                    {
                        fm.Show();
                        fm.BringToFront();
                        return;
                    }
                }
            }
            frmStoryMain form = new frmStoryMain();
            form.MdiParent = this;
            form.Show();
            //form.BringToFront();
        }

        private void tsItemPoker_Click(object sender, EventArgs e)
        {
            ShowPokerForm();
        }

        private void ShowPokerForm()
        {
            if (this.MdiChildren != null)
            {
                foreach (Form fm in this.MdiChildren)
                {
                    if (fm is frmPokerMain)
                    {
                        fm.Show();
                        fm.BringToFront();
                        return;
                    }
                }
            }
            frmPokerMain form = new frmPokerMain();
            form.MdiParent = this;
            form.Show();
            //form.BringToFront();
        }

    }
}
