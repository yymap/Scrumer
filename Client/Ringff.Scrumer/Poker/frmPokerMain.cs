using Ringff.Winform.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/************************************************************************   
 * Version :  v1.0.0.0  
 * Description :      
 * Author :  Eric Zhao 
************************************************************************/
namespace Ringff.Scrumer.Poker
{
    public partial class frmPokerMain : frmBase
    {
        public frmPokerMain()
        {
            InitializeComponent();
        }

        private void frmPokerMain_Load(object sender, EventArgs e)
        {

        }

        protected override void InitForm()
        {
            base.InitForm();

            this.Shadow = false;
            this.ControlBox = false;
            this.MaximizedBounds = this.MdiParent.DesktopBounds;
            this.WindowState = FormWindowState.Maximized;
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void tsBtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
