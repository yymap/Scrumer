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
    public abstract class BaseResponse<T>
    {
        public const String Field_data = "data";

        protected System.Collections.Generic.Dictionary<String, T> data;

        public BaseResponse()
        {
            data = new Dictionary<string, T>();
        }

        public void putData(String dataItemName, T dataItem)
        {
            this.data.Add(dataItemName, dataItem);
        }

        /// <summary>
        /// The data is a map
        /// </summary>
        [JsonProperty(PropertyName = Field_data,Order=2)]
        public Dictionary<String, T> Data
        {
            get
            {
                return data;
            }
        }

    }
}