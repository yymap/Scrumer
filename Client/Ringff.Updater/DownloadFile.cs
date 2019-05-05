using System;

namespace Ringff.Updater
{
	
	public class DownloadFile
	{
		public DownloadFile()
		{
            CreateDate = DateTime.Now;
		}
        public Int32 ID
        {
            get;
            set;
        }
        public String FileName
        {
            get;
            set;
        }
        public String LocalDir
        {
            get;
            set;
        }
        public String FileVersion
        {
            get;
            set;
        }
        public byte[] FileContent
        {
            get;
            set;
        }
        public System.DateTime CreateDate
        {
            get;
            set;
        }
        public System.DateTime UpdateDate
        {
            get;
            set;
        }
        public String UpdateBy
        {
            get;
            set;
        }     
	}

	public enum EditType
	{
		None,
		Modify,
		Add,
		Delete
	}
}
