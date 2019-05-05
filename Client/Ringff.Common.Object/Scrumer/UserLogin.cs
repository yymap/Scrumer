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
    public sealed class UserLogin : BaseEntiry
    {
        public static readonly String DATA_KEY = "user";

        [JsonProperty(PropertyName="id")]
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

        [JsonProperty(PropertyName = "mobile")]
        public String Mobile
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "password")]
        public String Password
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "sub_password")]
        public String SubPassword
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

        [JsonProperty(PropertyName = "update_date")]
        public DateTime UpdateDate
        {
            get;
            set;
        }
    }
}