using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/************************************************************************   
 * Version :  v1.0.0.0  
 * Description :      
 * Author :  Eric Zhao 
************************************************************************/
namespace Ringff.Common.Constants
{
    public sealed class CommonConstants
    {
        public const String CHARSET_UTF8 = "UTF-8";

        /// <summary>
        /// The nanoseconds (1 second = 1000 milliseconds, 1 millisecond = 1000 microsecond, 1 microsecond = 1000 nanoseconds)
        /// from UTC 1970-01-01T00:00:00
        /// </summary>
        public const Int64 NANO_SECOND_FROM_UTC_1970 = 621355968000000000;

        public const Int64 NANO_SECOND_PER_MICRO_SECOND = 1000;

        public static readonly Int64 NANO_SECOND_PER_MILLI_SECOND = NANO_SECOND_PER_MICRO_SECOND * 1000;

        public static readonly Int64 NANO_SECOND_PER_SECOND = NANO_SECOND_PER_MILLI_SECOND * 1000;
    }
}