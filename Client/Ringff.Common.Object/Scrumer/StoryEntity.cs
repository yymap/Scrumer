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
namespace Ringff.Common.Object.Scrumer
{
    public sealed class StoryEntity : BaseEntiry
    {
        public static readonly String DATA_KEY = "story";

        [JsonProperty(PropertyName = "id")]
        public int ID
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "name")]
        public String Name
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "project_id")]
        public int ProjectId
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "link_url")]
        public String LinkUrl
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "content")]
        public String Content
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "developer")]
        public String Developer
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "qa")]
        public String QA
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "point")]
        public float Point
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "dev_plan_time")]
        public float DevPlanTime
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "dev_spend_time")]
        public float DevSpendTime
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "qa_plan_time")]
        public float QAPlanTime
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "qa_spend_time")]
        public float QASpendTime
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "isd_count")]
        public int ISDCount
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "create_date")]
        public DateTime CreateDate
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "create_by")]
        public String CreateBy
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "update_date")]
        public DateTime UpdateDate
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "update_by")]
        public String UpdateBy
        {
            get;
            set;
        }
    }
}