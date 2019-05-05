using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


/************************************************************************   
 * Version :  v1.0.0.0  
 * Description :      
 * Author :  Eric Zhao 
************************************************************************/
namespace Ringff.Common.PInvoke
{
    /// <summary>
    /// Methods need to call in Kernel32.dll
    /// </summary>
    public sealed class Kerner32Invoke
    {
        /// <summary>
        /// Set current OS system time
        /// </summary>
        /// <param name="lpSystemTime"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int SetSystemTime(ref SystemTime lpSystemTime); 
        
    }//class
}