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
namespace Ringff.Scrumer
{
    public partial class frmScrumerBase : frmBase
    {
        public frmScrumerBase()
        {
            InitializeComponent();
        }

        private void frmScrumerBase_Load(object sender, EventArgs e)
        {
           
        }

        protected override void InitForm()
        {
            base.InitForm();
        }
        

        protected virtual void ShowError(String error)
        {
            lblError.Text = error;
            lblError.Visible = true;
        }

        protected virtual void HideError()
        {
            lblError.Visible = false;
        }

        private void lblError_Paint(object sender, PaintEventArgs e)
        {
            lblError.ForeColor = Color.Red;
        }

    }
}
