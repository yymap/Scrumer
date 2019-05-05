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
namespace Ringff.Scrumer.Common
{
    public sealed class URLContainer
    {
        public static readonly String SERVER_URL = Properties.Settings.Default.ServerUrl;

        public static readonly String URL_USER = String.Format("{0}/{1}", SERVER_URL, "user");

        public static readonly String URL_STORY = String.Format("{0}/{1}", SERVER_URL, "story");
    }
}