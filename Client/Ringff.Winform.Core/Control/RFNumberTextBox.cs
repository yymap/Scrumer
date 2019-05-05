using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/************************************************************************   
 * Version :  v1.0.0.0  
 * Description :      
 * Author :  Eric Zhao 
************************************************************************/
namespace Ringff.Winform.Core.Control
{
    public class RFNumberTextBox : TextBox
    {
        private bool allowPoint = true;
        public bool AllowPoint
        {
            get
            {
                return this.allowPoint;
            }
            set
            {
                this.allowPoint = value;
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            //base.OnKeyPress(e);
            bool isInvalidChar = !Char.IsDigit(e.KeyChar)
                && (AllowPoint && e.KeyChar != 46);

            if (isInvalidChar)
            {
                e.Handled = true;
                return;
            }
            if (this.Text.StartsWith("."))
            {
                e.Handled = true;
                return;
            }
            base.OnKeyPress(e);
        }
    }
}