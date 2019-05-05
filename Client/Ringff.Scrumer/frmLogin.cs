using Ringff.Common.Object.Common;
using Ringff.Common.Object.Scrumer;
using Ringff.Scrumer.Operator;
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
    public partial class frmLogin : frmScrumerBase
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }

        protected override void InitForm()
        {
            base.InitForm();
            this.BringToFront();
            this.Activate();
            this.Select(true, true);
            txtName.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Login())
            {
                this.Hide();

                frmMain mainForm = new frmMain();
                mainForm.Show();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowSignupForm();
            
        }

        private bool Login()
        {
            if (!ValidInput())
            {
                return false;
            }

            RFHttpResponse<UserLogin> ret = UserLoginOperator.Login(txtName.Text.Trim(), txtPwd.Text.Trim());

            if (!ret.Header.IsSuccess)
            {
                ShowError(ret.Header.Message);
                return false;
            }

            frmMain.CurrentLogin = ret.Data[UserLogin.DATA_KEY];

            return true;
        }

        private bool ValidInput()
        {
            if (String.IsNullOrWhiteSpace(txtName.Text))
            {
                ShowError("Please enter name/mobile.");
                txtName.Focus();
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtPwd.Text))
            {
                ShowError("Please enter password.");
                txtPwd.Focus();
                return false;
            }
            return true;
        }

        private void ShowSignupForm()
        {
            frmSignup signUpForm = new frmSignup();
            signUpForm.Show();
        }

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnLogin_Click(sender, e);
            }
        }

    }
}
