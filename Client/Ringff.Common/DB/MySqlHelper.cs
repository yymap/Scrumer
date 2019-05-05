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
namespace Ringff.Common.DB
{
    public sealed class MySqlHelper : SQLHelper
    {
        public override int ExecuteNonQuery(System.Data.CommandType cmdType, string cmdText, params System.Data.IDbDataParameter[] commandParameters)
        {
            throw new NotImplementedException();
        }

        public override int ExecuteNonQuery(System.Data.IDbTransaction trans, System.Data.CommandType cmdType, string cmdText, params System.Data.IDbDataParameter[] commandParameters)
        {
            throw new NotImplementedException();
        }

        public override System.Data.Common.DbDataReader ExecuteReader(System.Data.CommandType cmdType, string cmdText, params System.Data.IDbDataParameter[] commandParameters)
        {
            throw new NotImplementedException();
        }

        public override object ExecuteScalar(System.Data.CommandType cmdType, string cmdText, params System.Data.IDbDataParameter[] commandParameters)
        {
            throw new NotImplementedException();
        }

        public override object ExecuteScalar(System.Data.IDbTransaction trans, System.Data.CommandType cmdType, string cmdText, params System.Data.IDbDataParameter[] commandParameters)
        {
            throw new NotImplementedException();
        }

        public override System.Data.DataSet ExecuteDataSet(System.Data.CommandType cmdType, string cmdText, params System.Data.IDbDataParameter[] commandParameters)
        {
            throw new NotImplementedException();
        }

        public override String TestConnect()
        {
            throw new NotImplementedException();
        }
    }
}