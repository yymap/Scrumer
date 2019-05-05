using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
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
    public abstract class SQLHelper
    {
        protected static readonly string ConnectionString = ConfigurationManager.AppSettings["SqlConnectionString"];

        private static readonly Object lockObj = new Object();

        private static SQLHelper instance = null;

        public static SQLHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                        {
                            initInstance();
                        }
                    }
                }
                return instance;
            }
        }

        private static void initInstance()
        {
            if (ConfigurationManager.AppSettings["DBType"] == null || ConfigurationManager.AppSettings["DBType"].Equals("MSSqlServer", StringComparison.InvariantCultureIgnoreCase))
            {
                instance = new MSSqlHelper();
            }
            else if (ConfigurationManager.AppSettings["DBType"].Equals("MySql", StringComparison.InvariantCultureIgnoreCase))
            {
                instance = new MySqlHelper();
            }
        }

        public abstract String TestConnect();
        public abstract int ExecuteNonQuery(CommandType cmdType, string cmdText, params IDbDataParameter[] commandParameters);
        public abstract int ExecuteNonQuery(IDbTransaction trans, CommandType cmdType, string cmdText, params IDbDataParameter[] commandParameters);
        public abstract DbDataReader ExecuteReader(CommandType cmdType, string cmdText, params IDbDataParameter[] commandParameters);
        public abstract object ExecuteScalar(CommandType cmdType, string cmdText, params IDbDataParameter[] commandParameters);
        public abstract object ExecuteScalar(IDbTransaction trans, CommandType cmdType, string cmdText, params IDbDataParameter[] commandParameters);
        public abstract DataSet ExecuteDataSet(CommandType cmdType, string cmdText, params IDbDataParameter[] commandParameters);
    }
}