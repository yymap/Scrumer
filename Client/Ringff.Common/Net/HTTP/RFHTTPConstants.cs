using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/************************************************************************   
 * Version :  v1.0.0.0  
 * Description :      
 * Author :  Eric Zhao 
************************************************************************/
namespace Ringff.Common.Net.HTTP
{
    public sealed class RFHTTPConstants
    {
        public static readonly String HTTP_METHOD_GET = "GET";
        public static readonly String HTTP_METHOD_POST = "POST";
        public static readonly String HTTP_METHOD_PUT = "PUT";
        public static readonly String HTTP_METHOD_DELETE = "DELETE";

        private const String CHARSET_UTF8 = "charset=UTF-8";
        public static readonly String HTTP_CONTENT_TYPE_JSON = "application/json;" + CHARSET_UTF8;
    }
}