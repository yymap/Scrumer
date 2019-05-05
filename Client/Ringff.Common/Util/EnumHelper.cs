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
namespace Ringff.Common.Util
{
    public sealed class EnumHelper
    {
        private EnumHelper() { }

        /// <summary>
        /// Get enum description
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetDesc(Enum enumValue)
        {
            string str = enumValue.ToString();
            System.Reflection.FieldInfo field = enumValue.GetType().GetField(str);

            object[] attrs = field.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
            if (attrs == null || attrs.Length == 0)
            {
                return str;
            }

            System.ComponentModel.DescriptionAttribute desc = (System.ComponentModel.DescriptionAttribute)attrs[0];
            return desc.Description;
        }
    }
}