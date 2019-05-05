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
namespace Ringff.Updater
{
    public sealed class CommonInfo
    {
        private CommonInfo() { 
            
        }

        public static readonly String URL_GET_CONFIG = String.Format("{0}/{1}", Properties.Settings.Default.ServerUrl, "config/updater");
        public static readonly String START_APP_NAME = "Ringff.Scrumer";

        
    }
}