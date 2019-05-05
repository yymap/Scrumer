using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/************************************************************************   
 * Version :  v1.0.0.0  
 * Description :      
 * Author :  Eric Zhao 
************************************************************************/
namespace Ringff.Winform.Core.Control
{
    public class RFTextBox : MetroFramework.Controls.MetroTextBox
    {
        public RFTextBox()
        {

        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (PasswordChar == null)
            {
                return;
            }
            sbOriginalText.Clear();
            sbOriginalText.Append(this.Text);

        }

        private void RFTextBox_TextChanged(object sender, EventArgs e)
        {
            if (PasswordChar == null)
            {
                return;
            }
            sbOriginalText.Clear();
            sbOriginalText.Append(this.Text);
            this.Text.Replace(this.Text, PasswordChar);
        }

        private StringBuilder sbOriginalText = new StringBuilder();

        private String passwordChar = null;
        public String PasswordChar
        {
            get
            {
                return this.passwordChar;
            }
            set
            {
                this.passwordChar = value;
            }
        }

        
    }
}