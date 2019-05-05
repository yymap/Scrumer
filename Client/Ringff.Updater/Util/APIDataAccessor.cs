using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/************************************************************************   
 * Version :  v1.0.0.0  
 * Description :  Get data via calling web api.    
 * Author :  Eric Zhao 
************************************************************************/
namespace Ringff.Updater.Util
{
    public class APIDataAccessor : DataAccessor
    {

        public override int Add(DownloadFile fileInfo)
        {
            throw new NotImplementedException();
        }

        public override int Modify(DownloadFile fileInfo)
        {
            throw new NotImplementedException();
        }

        public override List<DownloadFile> GetList(DownloadFileCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public override DateTime GetServerDateTime()
        {
            throw new NotImplementedException();
        }

        public override System.Data.DataSet GetDataSet(DownloadFileCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public override int Delete(params int[] ids)
        {
            throw new NotImplementedException();
        }

        public override DownloadFile GetOne(int id,bool isLight = false)
        {
            throw new NotImplementedException();
        }
    }
}