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
namespace Ringff.Updater
{
    public sealed class DownloadFileCriteria
    {
        private bool isLight = false;
        private int id = 0;
        private String fileName = null;
        private String localDir = null;
        private String fileVersion = null;
        private DateTime updateDate = DateTime.MinValue;

        public bool IsLight
        {
            get
            {
                return this.isLight;
            }
            set
            {
                this.isLight = value;
            }
        }
        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public String FileName
        {
            get
            {
                return this.fileName;
            }
            set
            {
                this.fileName = value;
            }
        }

        public String LocalDir
        {
            get
            {
                return this.localDir;
            }
            set
            {
                this.localDir = value;
            }
        }

        public String FileVersion
        {
            get
            {
                return this.fileVersion;
            }
            set
            {
                this.fileVersion = value;
            }
        }

        public DateTime UpdateDate
        {
            get
            {
                return this.updateDate;
            }
            set
            {
                this.updateDate = value;
            }
        }

    }//class
}