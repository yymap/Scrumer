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
    public sealed class StoryOperator
    {
        public static RFHttpResponse<int> Add(StoryEntity obj)
        {
            RFHttpResponse<int> res = null;
            try
            {
                String json = JsonConvert.SerializeObject(obj);
                res = RFHttpRestClient.Post<RFHttpResponse<int>>(URLContainer.URL_STORY, json);
            }
            catch (Exception)
            {
                res = new RFHttpResponse<int>();
                res.Header.Status = "Error";
                res.Header.Message = "Add Error,please contact admin.";
            }
            return res;
        }

        public static RFHttpResponse<int> Modify(StoryEntity obj)
        {
            RFHttpResponse<int> res = null;
            try
            {
                String json = JsonConvert.SerializeObject(obj);
                res = RFHttpRestClient.Put<RFHttpResponse<int>>(URLContainer.URL_STORY, json);
            }
            catch (Exception)
            {
                res = new RFHttpResponse<int>();
                res.Header.Status = "Error";
                res.Header.Message = "Modify error,please contact admin.";
            }
            return res;
        }

        public static RFHttpResponse<List<StoryEntity>> GetAll()
        {
            return GetList("","");
        }

        public static RFHttpResponse<List<StoryEntity>> GetList(String name, String developer)
        {
            RFHttpResponse<List<StoryEntity>> res = null;
            try
            {
                String getUrl = string.Format("{0}?id=0&name={1}&developer={2}", URLContainer.URL_STORY, name, developer);
                res = RFHttpRestClient.Get<RFHttpResponse<List<StoryEntity>>>(getUrl);
            }
            catch (Exception)
            {
                res = new RFHttpResponse<List<StoryEntity>>();
                res.Header.Status = "Error";
                res.Header.Message = "Query error,please contact admin.";
            }
            return res;
        } 
    }
}