using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/************************************************************************   
 * Version :  v1.0.0.0  
 * Description :      
 * Author :  Eric Zhao 
************************************************************************/
namespace Ringff.Common.Object.Config
{
    public class RFUpdateConfig : BaseEntiry
    {
        public static readonly String DATA_KEY = "config";

        [JsonProperty(PropertyName = "mssql_conn_str")]
        public String MSSqlConnStr
        {
            get;
            set;
        }
    }
}