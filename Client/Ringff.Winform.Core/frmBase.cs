using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/************************************************************************   
 * Version :  v1.0.0.0  
 * Description :      
 * Author :  Eric Zhao 
************************************************************************/
namespace Ringff.Winform.Core
{
    public partial class frmBase : MetroFramework.Forms.MetroForm
    {
        
        public frmBase()
        {
            InitializeComponent();
            
            
        }

        private void frmBase_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        protected virtual void InitForm()
        {
            this.Theme = MetroFramework.MetroThemeStyle.Light;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            
        }

    }
}
