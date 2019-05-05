using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Ringff.Common.Object.Config;
using Ringff.Common.Net.HTTP;
using Newtonsoft.Json;
using Ringff.Common.Object.Common;
using System.Configuration;
using Ringff.Common.DB;
using Ringff.Updater.Util;
using System.Collections.Generic;
namespace Ringff.Updater
{
	
	public class UpdateHelper
	{
        public UpdateHelper() { }

        private frmWaiting waitingForm = new frmWaiting();

        public frmWaiting WaitingForm
        {
            get
            {
                return waitingForm;
            }
        }

        SqlCommand sqlCmd = new SqlCommand();

        public String ErrorMessage
        {
            get;
            set;
        }
		
		public int ExportFile(int id,string FileName)
		{
            DownloadFile fileToDownload = DataAccessor.Instance.GetOne(id, false);

            if (fileToDownload == null)
			{
				ErrorMessage = "Fail to get update file.";
				return -1;
			}
			
			#region download file
			WaitingForm.lblTip.Text = "Downloading .....";

            try
            {
                byte[] fileContent = fileToDownload.FileContent;

                CheckOrCreateDir(FileName);

                string LocalFileName = FileName;
                if (File.Exists(LocalFileName))
                {
                    System.IO.File.SetAttributes(LocalFileName, System.IO.FileAttributes.Normal);
                }
                FileStream fs = new FileStream(LocalFileName, System.IO.FileMode.Create);

                fs.Write(fileContent, 0, fileContent.Length);
                fs.Close();
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
                return -1;
            }
			#endregion  

			return 1;
		}

        private void EnsureCloseTargetApp()
        {
            Process[] proc = Process.GetProcessesByName(CommonInfo.START_APP_NAME);
            if (proc.Length >= 1)
            {
                if (MessageBox.Show("The App is running.\n You have to close it to update the app.Do you want to close it?", "Info", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    for (int i = 0; i < proc.Length; i++)
                    {
                        proc[i].Kill();
                    }
                }
                else
                {
                    Application.Exit();
                }
            }
        }
		
		public int UpgradeFiles()
		{
            EnsureCloseTargetApp();

			WaitingForm.lblTip.Text = "Querying data.....";
			System.Windows.Forms.Application.DoEvents();
			WaitingForm.Refresh();

            string lastUpdateTime = GetAppConfig("UpdateTime");
            DownloadFileCriteria criteria = new DownloadFileCriteria();
            criteria.IsLight = false;
            criteria.UpdateDate = DateTime.Parse(lastUpdateTime);
            List<DownloadFile> files = DataAccessor.Instance.GetList(criteria);

            if (files == null)
			{
				ErrorMessage = "Fail to query update file.";
				return -1;
			}

            if (files.Count == 0)
			{
				return 1;
			}
			
			WaitingForm.lblTip.Text = "Downloading£¬please wait....";
			System.Windows.Forms.Application.DoEvents();
			WaitingForm.Refresh();
            WaitingForm.progressBar1.Maximum = files.Count;
			WaitingForm.progressBar1.Minimum = 0;

			#region download file 
            string appStartupPath = Application.StartupPath;
            String convertedLocalDir = null;

			foreach(DownloadFile file in files)
			{
                convertedLocalDir = ConvertPath(file.LocalDir); 

                WaitingForm.lblTip.Text = "Downloading" + file.FileName;
				WaitingForm.lblTip.Refresh();
				WaitingForm.progressBar1.Value ++;
				WaitingForm.progressBar1.Refresh();
				System.Windows.Forms.Application.DoEvents();

				try
				{
                    byte[] fileContent = file.FileContent;
                    CheckOrCreateDir(appStartupPath + convertedLocalDir);

                    string LocalFileName = appStartupPath + convertedLocalDir + file.FileName;
					if(File.Exists(LocalFileName))
					{
						System.IO.File.SetAttributes(LocalFileName,System.IO.FileAttributes.Normal);
					}
					FileStream fs = new FileStream(LocalFileName,System.IO.FileMode.Create);
                    fs.Write(fileContent, 0, fileContent.Length);
					fs.Close();
				}
				catch(Exception ex)
				{
					this.ErrorMessage = ex.Message;
					return -1;
				}
			}
			
			#endregion  

			return 1;
		}
		
		public bool CheckOrCreateDir(string localFileName)
		{
			string dirPath;
			int slashPosition;

			//Path should be: d:\temp\test\filename.ext OR .\test\filename.ext. BUT should NOT be ..\test\filename.ext    
            if (String.IsNullOrEmpty(localFileName))
            {
                return true;
            }

			slashPosition = localFileName.LastIndexOf("\\");
			if( slashPosition <= 0) 
			{
				return true;
			}

			dirPath = localFileName.Substring(0,slashPosition);

            if (String.IsNullOrEmpty(dirPath))
            {
                return true;
            }

            if (Directory.Exists(dirPath))
            {
                return true;
            }
			
			Directory.CreateDirectory(dirPath);                
			return true;
		}
		
		private string ConvertPath(string filePath)
		{
			filePath = filePath.Replace("/",@"\");
			if(filePath.Length ==0)
			{
				return @"\";
			}
			if(filePath.Substring(filePath.Length -1 ,1)  != @"\")
			{ 
		
				filePath += @"\";
			}
			if(filePath.Substring(0,1) != @"\")
			{
				filePath = @"\" +filePath;
			}
			return filePath;
		}

		
		public int IsSameFileExists(DownloadFile obj )
		{
            DownloadFileCriteria criteria = new DownloadFileCriteria();
            criteria.IsLight = true;
            criteria.FileName = obj.FileName;
            criteria.LocalDir = obj.LocalDir;

            List<DownloadFile> list = DataAccessor.Instance.GetList(criteria);
            if (list == null)
			{
				this.ErrorMessage = "Fail to check same files in directory.";
				return -1;
			}

            if (list.Count == 0)
			{
				return 0;
			}

            foreach(DownloadFile tmpFile in list){
                if(tmpFile.ID != obj.ID){
                    return 1;
                }
            }

            return 0;
		}
	
		
		public void SetTrans(SqlTransaction Trans) 
		{
			try 
			{
				sqlCmd.Transaction=Trans;
			}
			catch(Exception ex) 
			{
				this.ErrorMessage="Set transaction error:" +ex.Message;
			}
		}

        public static string GetAppConfig(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
		
		
		/// <summary>
		/// Write config file
		/// </summary>
		/// <param name="key"></param>
		/// <param name="keyvalues"></param>
		public  void  WriteAppConfig(string key ,string keyvalues)
		{
            bool isModify = ConfigurationManager.AppSettings[key] != null;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (isModify)
            {
                config.AppSettings.Settings.Remove(key);
            }
            config.AppSettings.Settings.Add(key, keyvalues);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
		}
		
		public bool TestConnectDB()
		{
			WaitingForm.lblTip.Text = "Connecting to db.....";
			System.Windows.Forms.Application.DoEvents();
			WaitingForm.Refresh();

            String connResult  = SQLHelper.Instance.TestConnect();
            if (!String.IsNullOrEmpty(connResult))
            {
                this.ErrorMessage = "Fail to connect db: " + connResult;
                return false;
            }
            return true;
		}


        private RFUpdateConfig getRFUpdateConfig()
        {
            RFHttpResponse<RFUpdateConfig> ret = RFHttpRestClient.Get<RFHttpResponse<RFUpdateConfig>>(CommonInfo.URL_GET_CONFIG);

            return ret.Data[RFUpdateConfig.DATA_KEY];
        }
	}
}
