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
namespace Ringff.Winform.Core.Util
{
    public sealed class FormUtil
    {
        private FormUtil() { }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TMainForm">The Application.Run form type</typeparam>
        public static void CloseMainForm<TMainForm>()
        {
            if (Application.OpenForms == null || Application.OpenForms.Count == 0)
            {
                return;
            }

            foreach (Form fm in Application.OpenForms)
            {
                if (fm is TMainForm)
                {
                    fm.Close();
                    break;
                }
            }
        }
    }
}