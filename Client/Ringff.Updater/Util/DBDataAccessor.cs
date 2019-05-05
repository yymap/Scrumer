using Ringff.Common.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ringff.Common.DB.Extentions;

/************************************************************************   
 * Version :  v1.0.0.0  
 * Description : Get data via DB access
 * Author :  Eric Zhao 
************************************************************************/
namespace Ringff.Updater.Util
{
    public sealed class DBDataAccessor : DataAccessor
    {
        private static readonly String SQL_INSERT = @"INSERT INTO DOWNLOAD_FILE ([FILE_NAME],LOCAL_DIR,FILE_VERSION,FILE_CONTENT,CREATE_DATE,UPDATE_DATE,UPDATE_BY)
                                OUTPUT inserted.ID
                                VALUES(@FileName,@LocalDir,@FileVersion,@FileContent,@CreateDate,@UpdateDate,@UpdateBy)";

        private static readonly String SQL_UPDATE_BY_ID = @"UPDATE DOWNLOAD_FILE 
                                SET FILE_NAME = @FileName,LOCAL_DIR = @LocalDir,FILE_VERSION=@FileVersion,FILE_CONTENT=@FileContent,UPDATE_DATE=@UpdateDate,UPDATE_BY=@UpdateBy
                                WHERE ID = @ID";

        private static readonly String SQL_SELECT = @" SELECT ID,FILE_NAME,LOCAL_DIR,FILE_VERSION,FILE_CONTENT,CREATE_DATE,UPDATE_DATE,UPDATE_BY FROM DOWNLOAD_FILE WHERE 1=1 ";

        private static readonly String SQL_LIGHT_SELECT = @" SELECT ID,FILE_NAME,LOCAL_DIR,FILE_VERSION,CREATE_DATE,UPDATE_DATE,UPDATE_BY FROM DOWNLOAD_FILE WHERE 1=1 ";

        private static readonly String SQL_DELETE_ALL = " DELETE FROM DOWNLOAD_FILE WHERE 1=1 ";

        /// <summary>
        /// Add file
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns>Return the new data id</returns>
        public override int Add(DownloadFile fileInfo)
        {
            return (int)SQLHelper.Instance.ExecuteScalar(CommandType.Text, SQL_INSERT, buildParameters(fileInfo));
        }

        public override int Modify(DownloadFile fileInfo)
        {
            return SQLHelper.Instance.ExecuteNonQuery(CommandType.Text, SQL_UPDATE_BY_ID, buildParameters(fileInfo));
        }

        public override List<DownloadFile> GetList(DownloadFileCriteria criteria)
        {
            StringBuilder sqlWhere = new StringBuilder();
            List<IDbDataParameter> paramList = new List<IDbDataParameter>();

            PutWhereAndParameter(sqlWhere, paramList, criteria);

            String sql = (criteria.IsLight ? SQL_LIGHT_SELECT : SQL_SELECT) + sqlWhere.ToString() + " ORDER BY UPDATE_DATE DESC ";

            List<DownloadFile> result = null;
            using (DbDataReader rdr = SQLHelper.Instance.ExecuteReader(CommandType.Text, sql, paramList.ToArray()))
            {
                result = new List<DownloadFile>();
                while(rdr.Read()){
                    result.Add(buildDownloadFile(rdr));
                }
            }
            return result;
        }

        private void PutWhereAndParameter(StringBuilder sqlWhere, List<IDbDataParameter> paramList, DownloadFileCriteria criteria)
        {
            if (criteria.ID > 0)
            {
                sqlWhere.Append(" AND ID = @ID");
                paramList.Add(new SqlParameter("@ID", criteria.ID));
            }
            if (!String.IsNullOrEmpty(criteria.FileName))
            {
                //sqlWhere.Append(String.Format(" AND FILE_NAME LIKE %{0}%",fileName));
                sqlWhere.Append(" AND FILE_NAME LIKE @FileName");
                paramList.Add(new SqlParameter("@FileName", string.Format("%{0}%", criteria.FileName)));
            }
            if (!String.IsNullOrEmpty(criteria.LocalDir))
            {
                //sqlWhere.Append(String.Format(" AND LOCAL_DIR LIKE %{0}%", localDir));
                sqlWhere.Append(" AND LOCAL_DIR LIKE @LocalDir");
                paramList.Add(new SqlParameter("@LocalDir", string.Format("%{0}%", criteria.LocalDir)));
            }
            if (!String.IsNullOrEmpty(criteria.FileVersion))
            {
                //sqlWhere.Append(String.Format(" AND FILE_VERSION LIKE %{0}%", fileVersion));
                sqlWhere.Append(" AND FILE_VERSION LIKE @FileVersion");
                paramList.Add(new SqlParameter("@FileVersion", string.Format("%{0}%", criteria.FileVersion)));
            }

            if (criteria.UpdateDate > DateTime.MinValue)
            {
                sqlWhere.Append(" AND UPDATE_DATE > @UpdateDate ");
                paramList.Add(new SqlParameter("@UpdateDate", criteria.UpdateDate));
            }
        }

        private DownloadFile buildDownloadFile(IDataReader rdr)
        {
            DownloadFile obj = new DownloadFile();
            obj.ID = (int)rdr["ID"];
            obj.FileName = (String)rdr["FILE_NAME"];
            obj.LocalDir = (String)rdr["LOCAL_DIR"];

            if (rdr["FILE_VERSION"] != DBNull.Value)
            {
                obj.FileVersion = (String)rdr["FILE_VERSION"];
            }

            if (rdr.HasColumn("FILE_CONTENT") && rdr["FILE_CONTENT"] != DBNull.Value)
            {
                obj.FileContent = (byte[])rdr["FILE_CONTENT"];
            }
            
            obj.CreateDate = (DateTime)rdr["CREATE_DATE"];
            obj.UpdateDate = (DateTime)rdr["UPDATE_DATE"];
            obj.UpdateBy = (String)rdr["UPDATE_BY"];

            return obj;
        }

        private SqlParameter[] buildParameters(DownloadFile fileInfo)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@ID", fileInfo.ID));
            list.Add(new SqlParameter("@FileName", fileInfo.FileName));
            list.Add(new SqlParameter("@LocalDir", fileInfo.LocalDir));
            list.Add(new SqlParameter("@FileVersion", fileInfo.FileVersion));
            list.Add(new SqlParameter("@FileContent", fileInfo.FileContent));
            list.Add(new SqlParameter("@CreateDate", fileInfo.CreateDate));
            list.Add(new SqlParameter("@UpdateDate", fileInfo.UpdateDate));
            list.Add(new SqlParameter("@UpdateBy", fileInfo.UpdateBy));

            return list.ToArray();
        }

        public override DateTime GetServerDateTime()
        {
             return (DateTime)SQLHelper.Instance.ExecuteScalar(CommandType.Text, "SELECT GETDATE()", null);
        }

        public override DataSet GetDataSet(DownloadFileCriteria criteria)
        {
            StringBuilder sqlWhere = new StringBuilder();
            List<IDbDataParameter> paramList = new List<IDbDataParameter>();

            PutWhereAndParameter(sqlWhere, paramList, criteria);

            String sql = (criteria.IsLight ? SQL_LIGHT_SELECT : SQL_SELECT) + sqlWhere.ToString() + " ORDER BY UPDATE_DATE DESC ";

            return SQLHelper.Instance.ExecuteDataSet(CommandType.Text, sql, paramList.ToArray());
        }

        public override int Delete(params int[] ids)
        {
            StringBuilder sqlWhere = new StringBuilder();
            if (ids != null && ids.Length > 0)
            {
                sqlWhere.Append(String.Format(" AND ID IN ({0})", String.Join(",", ids)));
            }

            String sql = SQL_DELETE_ALL + sqlWhere.ToString();

            return SQLHelper.Instance.ExecuteNonQuery(CommandType.Text, sql, null);
        }

        public override DownloadFile GetOne(int id, bool isLight = false)
        {
            DownloadFileCriteria criteria = new DownloadFileCriteria();
            criteria.ID = id;
            criteria.IsLight = isLight;

            List<DownloadFile> list = GetList(criteria);
            if (list == null || list.Count == 0)
            {
                return null;
            }
            return list[0];
        }
    }//class

}