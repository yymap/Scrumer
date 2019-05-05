using Newtonsoft.Json;
using Ringff.Common.Net.HTTP;
using Ringff.Common.Object.Common;
using Ringff.Common.Object.Scrumer;
using Ringff.Scrumer.Common;
using Ringff.Scrumer.Operator;
using Ringff.Winform.Core;
using Ringff.Winform.Core.Util;
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
    public partial class frmSignup : frmScrumerBase
    {
        public frmSignup()
        {
            InitializeComponent();
        }

        private void frmSignup_Load(object sender, EventArgs e)
        {
            
        }

        protected override void InitForm()
        {
            base.InitForm();
            this.Select(true, true);
            this.txtUserName.Focus();
        }
        

        private void btnSignup_Click(object sender, EventArgs e)
        {
            if (!ValidInput())
            {
                return;
            }

            if (Signup())
            {
                this.Close();
              

                frmMain mainForm = new frmMain();
                mainForm.Show();
                
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            FormUtil.CloseMainForm<frmLogin>();
        }

        private bool Signup()
        {
            UserLogin login = constructUserLogin();

            RFHttpResponse<UserLogin> ret = UserLoginOperator.Add(login);
            if (!ret.Header.IsSuccess)
            {

                ShowError("Sign up fail:" + ret.Header.Message);
                return false;
            }

            frmMain.CurrentLogin = ret.Data[UserLogin.DATA_KEY];
            return true;
        }

        private UserLogin constructUserLogin()
        {
            UserLogin obj = new UserLogin();
            obj.Name = txtUserName.Text.Trim();
            obj.Password = txtPwd.Text.Trim();
            obj.SubPassword = txtPwd.Text.Trim();
            DateTime now = DateTime.Now;
            obj.CreateDate = now;
            obj.UpdateDate = now;

            return obj;
        }

        private bool ValidInput()
        {
            if (String.IsNullOrWhiteSpace(txtUserName.Text))
            {
                ShowError("Please enter name or mobile.");
                txtUserName.Focus();
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtPwd.Text))
            {
                ShowError("Please enter password.");
                txtPwd.Focus();
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtPwdAgain.Text))
            {
                ShowError("Please enter password again.");
                txtPwdAgain.Focus();
                return false;
            }
            if (txtPwd.Text.Equals(txtPwdAgain.Text) == false)
            {
                ShowError("The two password are not same,please check.");
                txtPwdAgain.Focus();
                return false;
            }
            //TODO: check name is duplicate

            return true;
        }

    }//calss
}
