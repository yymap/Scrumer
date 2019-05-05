using Ringff.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/************************************************************************   
 * Version :  v1.0.0.0  
 * Description :      
 * Author :  Eric Zhao 
************************************************************************/
namespace Ringff.Common.Date
{
    public sealed class RFDateTimeUtil
    {
        /// <summary>
        /// convert standard time stamp so that is can be used in various platforms.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static Int64 ToUTCMilliseconds(DateTime dt)
        {
            return (dt.ToUniversalTime().Ticks - CommonConstants.NANO_SECOND_FROM_UTC_1970) / Ringff.Common.Constants.CommonConstants.NANO_SECOND_PER_MILLI_SECOND;
        }

        public static DateTime FromUTCMilliseconds(Int64 utcMilliseconds)
        {
            return new DateTime(utcMilliseconds * CommonConstants.NANO_SECOND_PER_MILLI_SECOND);
        }
    }
}