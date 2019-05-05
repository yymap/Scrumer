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
namespace Ringff.Common.Object.Common
{
    public class ResponseHeader
    {
        [JsonProperty(PropertyName = "status")]
        public String Status
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "message")]
        public String Message
        {
            get;
            set;
        }

        public bool IsSuccess
        {
            get
            {
                if (String.IsNullOrEmpty(Status))
                {
                    return false;
                }
                return Status.Equals("Success",StringComparison.InvariantCultureIgnoreCase);
            }
        }
    }
}