using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/************************************************************************   
 * Version :  v1.0.0.0  
 * Description :      
 * Author :  Eric Zhao 
************************************************************************/
namespace Ringff.Updater.Util
{
    public abstract class DataAccessor
    {
        private static readonly Object lockObj = new Object();

        private static DataAccessor instance = null;
        public static DataAccessor Instance
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
            if (ConfigurationManager.AppSettings["DataAccessor"].Equals("DB", StringComparison.InvariantCultureIgnoreCase))
            {
                instance = new DBDataAccessor();
            }
            else if (ConfigurationManager.AppSettings["DataAccessor"].Equals("API", StringComparison.InvariantCultureIgnoreCase))
            {
                instance = new APIDataAccessor();
            }
        }

        public abstract int Add(DownloadFile fileInfo);

        public abstract int Modify(DownloadFile fileInfo);

        public abstract int Delete(params int[] ids);

        public abstract DownloadFile GetOne(int id,bool isLight = false);

        public abstract List<DownloadFile> GetList(DownloadFileCriteria criteria);

        public abstract DataSet GetDataSet(DownloadFileCriteria criteria);

        public abstract DateTime GetServerDateTime();
    }//class
}