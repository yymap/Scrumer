using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/************************************************************************   
 * Version :  v1.0.0.0  
 * Description :      
 * Author :  Eric Zhao 
************************************************************************/
namespace Ringff.Common.DB.Extentions
{
    public static class IDataReaderExtention
    {

        public static bool HasColumn(this IDataReader rdr, String columnName)
        {
            rdr.GetSchemaTable().DefaultView.RowFilter = string.Format("ColumnName = '{0}'",columnName);
            return rdr.GetSchemaTable().DefaultView.Count > 0;
        }

    }//class
}