using Ringff.Common.Constants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;


/************************************************************************   
 * Version :  v1.0.0.0  
 * Description : Http RESTFul client class.
 * Author :  Eric Zhao 
************************************************************************/
namespace Ringff.Common.Net.HTTP
{
    public sealed class RFHttpRestClient
    {
        public static String GetJson(String restUrl)
        {
            return CallHttp(restUrl, RFHTTPConstants.HTTP_METHOD_GET);
        }

        public static T Get<T>(String restUrl)
        {
            String json = CallHttp(restUrl, RFHTTPConstants.HTTP_METHOD_GET);

            return JsonConvert.DeserializeObject<T>(json);
        }

        public static T Post<T>(String restUrl, String json)
        {
            HttpWebRequest request = GetHttpWebRequest(restUrl, RFHTTPConstants.HTTP_METHOD_POST, RFHTTPConstants.HTTP_CONTENT_TYPE_JSON);

            return CallHttp<T>(restUrl, json, RFHTTPConstants.HTTP_METHOD_POST);
        }

        public static T Put<T>(String restUrl, String json)
        {
            HttpWebRequest request = GetHttpWebRequest(restUrl, RFHTTPConstants.HTTP_METHOD_PUT, RFHTTPConstants.HTTP_CONTENT_TYPE_JSON);

            return CallHttp<T>(restUrl, json, RFHTTPConstants.HTTP_METHOD_PUT);
        }

        public static bool Delete(String restUrl)
        {
            String json = CallHttp(restUrl, RFHTTPConstants.HTTP_METHOD_DELETE);

            return json.Equals("success");
        }

        private static String CallHttp(String restUrl,String httpMethod)
        {
            HttpWebRequest request = GetHttpWebRequest(restUrl, httpMethod, RFHTTPConstants.HTTP_CONTENT_TYPE_JSON);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            return ReadString(response);
        }

        private static T CallHttp<T>(String restUrl, String json, String httpMethod)
        {
            HttpWebRequest request = GetHttpWebRequest(restUrl, httpMethod, RFHTTPConstants.HTTP_CONTENT_TYPE_JSON);
            WriteString(request, json);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            String resultJson = ReadString(response);
            return JsonConvert.DeserializeObject<T>(resultJson);
        }
        
        private static void WriteString(HttpWebRequest request, String json){
            using (var writer = new StreamWriter(request.GetRequestStream(),Encoding.GetEncoding(CommonConstants.CHARSET_UTF8)))
            {
                writer.Write(json);
                writer.Flush();
            }
        }

        private static string ReadString(HttpWebResponse response)
        {
            string str = null;
            using (var reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(CommonConstants.CHARSET_UTF8)))
            {
                str = reader.ReadToEnd();
            }
            return str;
        }

        private static HttpWebRequest GetHttpWebRequest(String restUrl, String method, String contentType)
        {
            HttpWebRequest request = WebRequest.Create(restUrl) as HttpWebRequest;
            request.Method = method;
            request.ContentType = contentType;

            return request;
        }
    }//class
}