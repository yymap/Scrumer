using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Collections.Generic;
using Ringff.Updater.Util;
using System.Net;
namespace Ringff.Updater
{

	public class frmFileInfo : Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btFileContent;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btClose;
		private System.Windows.Forms.TextBox txtFileName;
		private System.Windows.Forms.TextBox txtFilePath;
		private System.Windows.Forms.TextBox txtVersion;
		private System.Windows.Forms.Label lbID;
		private System.Windows.Forms.Button btOk;
		private System.Windows.Forms.CheckBox cbContinue;
	
		public delegate void SaveDelegate(DownloadFile obj);
		public event SaveDelegate SaveHandle;
	
		private System.ComponentModel.Container components = null;

		public frmFileInfo()
		{
			InitializeComponent();
		}
	
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Generated code
		/// <summary>
		/// Generated code, should not modify the code 
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFileInfo));
            this.label1 = new System.Windows.Forms.Label();
            this.lbID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.btFileContent = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbContinue = new System.Windows.Forms.CheckBox();
            this.btOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PrimaryKey";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbID
            // 
            this.lbID.Location = new System.Drawing.Point(67, 22);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(86, 16);
            this.lbID.TabIndex = 0;
            this.lbID.Text = "PrimaryKey";
            this.lbID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "FileName";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(81, 48);
            this.txtFileName.MaxLength = 50;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(238, 20);
            this.txtFileName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "RelativePath";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(81, 78);
            this.txtFilePath.MaxLength = 100;
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(238, 20);
            this.txtFilePath.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Version";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtVision
            // 
            this.txtVersion.Location = new System.Drawing.Point(81, 107);
            this.txtVersion.MaxLength = 20;
            this.txtVersion.Name = "txtVision";
            this.txtVersion.Size = new System.Drawing.Size(238, 20);
            this.txtVersion.TabIndex = 1;
            this.txtVersion.Text = "Scrumer1.0";
            // 
            // btFileContent
            // 
            this.btFileContent.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btFileContent.BackgroundImage")));
            this.btFileContent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btFileContent.Location = new System.Drawing.Point(341, 19);
            this.btFileContent.Name = "btFileContent";
            this.btFileContent.Size = new System.Drawing.Size(93, 127);
            this.btFileContent.TabIndex = 2;
            this.btFileContent.Click += new System.EventHandler(this.btFileContent_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(263, 15);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(63, 21);
            this.btClose.TabIndex = 4;
            this.btClose.Text = "Close";
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFileName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtFilePath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtVersion);
            this.groupBox1.Location = new System.Drawing.Point(7, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 141);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Base Info";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbContinue);
            this.groupBox2.Controls.Add(this.btClose);
            this.groupBox2.Controls.Add(this.btOk);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 45);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // cbContinue
            // 
            this.cbContinue.Location = new System.Drawing.Point(57, 15);
            this.cbContinue.Name = "cbContinue";
            this.cbContinue.Size = new System.Drawing.Size(102, 22);
            this.cbContinue.TabIndex = 5;
            this.cbContinue.Text = "Continue Input";
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(177, 15);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(62, 21);
            this.btOk.TabIndex = 4;
            this.btOk.Text = "Save";
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // frmInfo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(434, 223);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btFileContent);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 400);
            this.MinimumSize = new System.Drawing.Size(293, 245);
            this.Name = "frmInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Input";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region Variables
		private UpdateHelper updateHelper = new UpdateHelper();
		private IList<DownloadFile> fileList = null;
		private EditType editType = EditType.None;
		private bool isFileNameSame = true;
		#endregion 
		
		public EditType EditType
		{
			get
			{
				return editType;
			}
			set
			{
				editType = value;
			}
		}
		
		public int SetDownloadFile(DownloadFile file)
		{
            fileList = new List<DownloadFile>();
			this.lbID.Text = "" + file.ID;
			this.txtFileName.Text = file.FileName;
			this.txtFilePath.Text = file.LocalDir;
			this.txtVersion.Text = file.FileVersion;

			fileList.Add(file); 
			return 1;
		}
		
		private void Clear()
		{
			this.txtFileName.Text = "";
//			this.txtFilePath.Text = "";
//			this.txtVision.Text = "";
			fileList = null;
		}

		/// <summary>
		/// select file to upload
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btFileContent_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog selectFileDlg=new OpenFileDialog();

            fileList = new List<DownloadFile>();
			
			if(this.EditType == EditType.Add)
			{
				selectFileDlg.Multiselect  = true;
			}
			else
			{
				selectFileDlg.Multiselect = false;
			}

			if (selectFileDlg.ShowDialog()==DialogResult.OK)
			{
                Stream fs;
				foreach(string fullFileName in selectFileDlg.FileNames)
				{
                    DateTime now = DateTime.Now;
					
                    int fileShortNamePosition = fullFileName.LastIndexOf("\\");
					if(fileShortNamePosition == -1)
					{
						fileShortNamePosition = 0;
					}

					#region get base info
                    DownloadFile fileToSave = new DownloadFile();
					if(this.EditType == EditType.Add)
					{
						fileToSave.FileName = fullFileName.Substring(fileShortNamePosition+1);
						fileToSave.LocalDir = this.txtFilePath.Text;
						fileToSave.FileVersion = this.txtVersion.Text;
                        fileToSave.CreateDate = now;
						if(txtFileName.Text.Length == 0)
						{
							txtFileName.Text = fileToSave.FileName;
						}
						else
						{
							txtFileName.Text += " " + fileToSave.FileName;
						}
					}
					else if(this.EditType == EditType.Modify)
					{
						if(fullFileName.Substring(fileShortNamePosition+1) != txtFileName.Text)
						{
							isFileNameSame = false;
							MessageBox.Show("The file name is different with loaded file." ,"Warning",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
								return ;
						}
						else
						{
							isFileNameSame = true;
						}
						fileToSave.FileName = this.txtFileName.Text;
						fileToSave.LocalDir = this.txtFilePath.Text;
						fileToSave.FileVersion = this.txtVersion.Text;
                        fileToSave.ID = int.Parse(this.lbID.Text);
					}

                    if (EditType == Updater.EditType.Add)
                    {
                        fileToSave.CreateDate = now;
                    }
                    fileToSave.UpdateBy = Dns.GetHostName();
                    fileToSave.UpdateDate = now;
					#endregion 

					#region  Get file content
					OpenFileDialog fileToReadDlg = new OpenFileDialog();
					fileToReadDlg.FileName = fullFileName;
					if ((fs=fileToReadDlg.OpenFile())!=null)
					{
						byte[] fileContent = null;
						if(fs.Length == 0)
						{
							fileContent = new byte[1];
							fileContent[0] = 32;
						}
						else
						{
							fileContent = new byte[fs.Length];
                            int n = fs.Read(fileContent, 0, fileContent.Length);
							fs.Close();
						}
						fileToSave.FileContent = fileContent;
					}
					#endregion 

					fileList.Add(fileToSave);
				}//foreach
			}
		}
		
		private bool ValidState(IList<DownloadFile> list)
		{
            
			foreach(DownloadFile obj in list)
			{
				if(obj.FileName.Length >50)
				{
					MessageBox.Show("File name length is too long(less than 50).");
					this.txtFileName.Focus();
					return false;
				}
				if(obj.LocalDir.Length >100)
				{
					MessageBox.Show("Path name is too long(less than 100).");
					this.txtFilePath.Focus();
					return false;
				}
				if(obj.LocalDir == null ||obj.LocalDir.Length == 0 )
				{
					if(txtFilePath.Text.Length == 0)
					{
						MessageBox.Show("Please enter file path.");
						this.txtFilePath.Focus();
						return false;
					}
					else
					{
						obj.LocalDir = txtFilePath.Text;
					}
				}
				if(obj.FileVersion.Length >20)
				{
					MessageBox.Show("Version name is too long(less than 20).");
					this.txtVersion.Focus();
					return false;
				}
				if(obj.FileContent == null)
				{
					MessageBox.Show("Please select file to load.");
					return false;
				}
			}
			return true;
		}
		
		private DownloadFile GetDownloadFile()
		{
			DownloadFile obj = new DownloadFile();
            obj.ID = int.Parse(this.lbID.Text);
			obj.FileName = this.txtFileName.Text;
			obj.FileVersion = this.txtVersion.Text;
			obj.LocalDir = this.txtFilePath.Text;
            DateTime now = DateTime.Now;
            if (EditType == Updater.EditType.Add)
            {
                obj.CreateDate = now;
            }
            obj.UpdateDate = now;
            obj.UpdateBy = System.Net.Dns.GetHostName();
			return obj;
		}

		private void btClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		
		private int SaveDownloadFile(DownloadFile fileInfo)
		{
			try
			{
				int result = updateHelper.IsSameFileExists(fileInfo);
				if(result == -1)
				{
					MessageBox.Show("Fail to query duplicate file in same directory.");
					return -1;
				}
				if(result == 1)
				{
					MessageBox.Show("There is duplicate file in the same directory.");
					return -1;
				}
                
				if(EditType == EditType.Add)
				{
                    fileInfo.ID = DataAccessor.Instance.Add(fileInfo);
                    return fileInfo.ID;
				}
				else if(EditType == EditType.Modify)
				{
                    return DataAccessor.Instance.Modify(fileInfo);
				}
                MessageBox.Show("Edit type is noe correct.");
                return -1;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				return -1;
			}
		}

		private void btOk_Click(object sender, System.EventArgs e)
		{
			SaveSingleFile();
		}

		/// <summary>
		///Save single file
		/// </summary>
		private void SaveSingleFile()
		{
			if(!isFileNameSame)
			{
				MessageBox.Show("The file to modify is different with loaded file, please load file again.");
				return;
			}

			if(fileList == null)
			{
				MessageBox.Show("Please select file to save.");
				return;
			}

			if(!ValidState(fileList))
			{
				return;
			}

			foreach(DownloadFile fileObj in fileList)
			{
				fileObj.LocalDir = this.txtFilePath.Text;
				if(SaveDownloadFile(fileObj) <= 0)
				{
					MessageBox.Show("Save failed.");
					return;
				}
				SaveHandle(fileObj);
			}

            if(cbContinue.Checked)
			{
				this.Clear();
                this.lbID.Text = "";
			}
			else
			{
				this.Close();
			}
		}
	}
}
