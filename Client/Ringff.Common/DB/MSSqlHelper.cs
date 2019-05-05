using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
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
    public sealed class MSSqlHelper : SQLHelper
    {
        public override String TestConnect()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(ConnectionString);
                conn.Open();
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return null;
        }

        public override int ExecuteNonQuery(CommandType cmdType, string cmdText, params IDbDataParameter[] commandParameters)
        {
            return ExecuteNonQuery(ConnectionString, cmdType, cmdText, commandParameters);
        }

        public override int ExecuteNonQuery(IDbTransaction trans, CommandType cmdType, string cmdText, params IDbDataParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        private int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params IDbDataParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public override DbDataReader ExecuteReader(CommandType cmdType, string cmdText, params IDbDataParameter[] commandParameters)
        {
            return ExecuteReader(ConnectionString, cmdType, cmdText, commandParameters);
        }

        private DbDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params IDbDataParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);
           
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        public override object ExecuteScalar(CommandType cmdType, string cmdText, params IDbDataParameter[] commandParameters)
        {
            return ExecuteScalar(ConnectionString, cmdType, cmdText, commandParameters);
        }

        public override object ExecuteScalar(IDbTransaction trans, CommandType cmdType, string cmdText, params IDbDataParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        private object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params IDbDataParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public override DataSet ExecuteDataSet(CommandType cmdType, string cmdText, params IDbDataParameter[] commandParameters)
        {
            return ExecuteDataSet(ConnectionString, cmdType, cmdText, commandParameters);
        }

        private DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText, params IDbDataParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter();
                sqlAdapter.SelectCommand = cmd;

                DataSet ds = new DataSet();
                sqlAdapter.Fill(ds);
                cmd.Parameters.Clear();

                return ds;
            }
        }

        private void PrepareCommand(IDbCommand cmd, IDbConnection conn, IDbTransaction trans, CommandType cmdType, string cmdText, IDbDataParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;

            if (trans != null)
            {
                cmd.Transaction = trans;
            }

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }//PrepareCommand
        
    }//class
}