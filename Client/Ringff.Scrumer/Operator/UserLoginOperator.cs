using Newtonsoft.Json;
using Ringff.Common.Net.HTTP;
using Ringff.Common.Object.Common;
using Ringff.Common.Object.Scrumer;
using Ringff.Scrumer.Common;
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
namespace Ringff.Scrumer.Operator
{

    public class UserLoginOperator
    {
        public static RFHttpResponse<UserLogin> Add(UserLogin obj)
        {
            RFHttpResponse<UserLogin> res = null;
            try
            {
                String json = JsonConvert.SerializeObject(obj);
                res = RFHttpRestClient.Post<RFHttpResponse<UserLogin>>(URLContainer.URL_USER, json);
            }
            catch (Exception)
            {
                res = new RFHttpResponse<UserLogin>();
                res.Header.Status = "Error";
                res.Header.Message = "Add Error,please contact admin.";
            }
            return res;
        }

        public static RFHttpResponse<UserLogin> Login(String name, String pwd)
        {
            RFHttpResponse<UserLogin> res = null;
            String getUrl = string.Format("{0}?name={1}&pwd={2}", URLContainer.URL_USER,name,pwd);
            try
            {
                res = RFHttpRestClient.Get<RFHttpResponse<UserLogin>>(getUrl);
            }
            catch (Exception)
            {
                res = new RFHttpResponse<UserLogin>();
                res.Header.Status = "Error";
                res.Header.Message = "Login Error,please contact admin.";
            }
            return res;
        }
    }
}