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
    public class RFHttpResponse<T> : BaseResponse<T>
    {
        public RFHttpResponse()
        {
            Header = new ResponseHeader();
        }

        public const String Field_header = "header";

        [JsonProperty(PropertyName = "header",Order=1)]
        public ResponseHeader Header
        {
            get;
            set;
        }
    }
}