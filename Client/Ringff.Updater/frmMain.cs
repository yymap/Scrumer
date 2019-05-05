using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Diagnostics;
using System.Text;
using Ringff.Updater;
using Ringff.Updater.Util;
using System.Collections.Generic;
using Ringff.Common.Util;
using System.Net;
using Ringff.Common.PInvoke;
namespace Ringff.Updater
{
	
	public class frmMain : Form
	{
		private System.ComponentModel.IContainer components;

		public frmMain()
		{
			InitializeComponent();
		}
	
		protected override void Dispose( bool disposing )
		{
			if(disposing)
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}

		#region Windows Generated code.
		
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolBarMain = new System.Windows.Forms.ToolBar();
            this.tbAdd = new System.Windows.Forms.ToolBarButton();
            this.tbModify = new System.Windows.Forms.ToolBarButton();
            this.tbDelete = new System.Windows.Forms.ToolBarButton();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuDeletAll = new System.Windows.Forms.MenuItem();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.tbExport = new System.Windows.Forms.ToolBarButton();
            this.tbPrint = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.tbExit = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridMain = new System.Windows.Forms.DataGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbQuery = new System.Windows.Forms.CheckBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtClientFilePath = new System.Windows.Forms.TextBox();
            this.txtUpdater = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileVersion = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMain)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBarMain
            // 
            this.toolBarMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBarMain.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbAdd,
            this.tbModify,
            this.tbDelete,
            this.toolBarButton1,
            this.tbExport,
            this.tbPrint,
            this.toolBarButton2,
            this.tbExit});
            this.toolBarMain.DropDownArrows = true;
            this.toolBarMain.ImageList = this.imageList1;
            this.toolBarMain.Location = new System.Drawing.Point(0, 0);
            this.toolBarMain.Name = "toolBarMain";
            this.toolBarMain.ShowToolTips = true;
            this.toolBarMain.Size = new System.Drawing.Size(880, 66);
            this.toolBarMain.TabIndex = 1;
            this.toolBarMain.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBarMain_ButtonClick);
            // 
            // tbAdd
            // 
            this.tbAdd.ImageIndex = 0;
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Text = "Add";
            // 
            // tbModify
            // 
            this.tbModify.ImageIndex = 5;
            this.tbModify.Name = "tbModify";
            this.tbModify.Text = "Modify";
            // 
            // tbDelete
            // 
            this.tbDelete.DropDownMenu = this.contextMenu1;
            this.tbDelete.ImageIndex = 4;
            this.tbDelete.Name = "tbDelete";
            this.tbDelete.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            this.tbDelete.Text = "Delete";
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuDeletAll});
            // 
            // menuDeletAll
            // 
            this.menuDeletAll.Index = 0;
            this.menuDeletAll.Text = "Delete All";
            this.menuDeletAll.Click += new System.EventHandler(this.menuDeletAll_Click);
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbExport
            // 
            this.tbExport.ImageIndex = 12;
            this.tbExport.Name = "tbExport";
            this.tbExport.Text = "Export";
            // 
            // tbPrint
            // 
            this.tbPrint.ImageIndex = 13;
            this.tbPrint.Name = "tbPrint";
            this.tbPrint.Text = "Print";
            this.tbPrint.Visible = false;
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbExit
            // 
            this.tbExit.ImageIndex = 11;
            this.tbExit.Name = "tbExit";
            this.tbExit.Text = "Exit";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "add.png");
            this.imageList1.Images.SetKeyName(1, "check.png");
            this.imageList1.Images.SetKeyName(2, "close.png");
            this.imageList1.Images.SetKeyName(3, "data.png");
            this.imageList1.Images.SetKeyName(4, "delete.png");
            this.imageList1.Images.SetKeyName(5, "edit.png");
            this.imageList1.Images.SetKeyName(6, "fail.png");
            this.imageList1.Images.SetKeyName(7, "lock.png");
            this.imageList1.Images.SetKeyName(8, "prompt.png");
            this.imageList1.Images.SetKeyName(9, "search.png");
            this.imageList1.Images.SetKeyName(10, "user01.png");
            this.imageList1.Images.SetKeyName(11, "exit.png");
            this.imageList1.Images.SetKeyName(12, "export.png");
            this.imageList1.Images.SetKeyName(13, "print.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridMain);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(880, 500);
            this.panel1.TabIndex = 2;
            // 
            // dataGridMain
            // 
            this.dataGridMain.AlternatingBackColor = System.Drawing.Color.White;
            this.dataGridMain.BackColor = System.Drawing.Color.White;
            this.dataGridMain.BackgroundColor = System.Drawing.Color.Ivory;
            this.dataGridMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataGridMain.CaptionBackColor = System.Drawing.Color.LightCyan;
            this.dataGridMain.CaptionForeColor = System.Drawing.Color.Lavender;
            this.dataGridMain.DataMember = "";
            this.dataGridMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridMain.FlatMode = true;
            this.dataGridMain.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dataGridMain.ForeColor = System.Drawing.Color.Black;
            this.dataGridMain.GridLineColor = System.Drawing.Color.Wheat;
            this.dataGridMain.HeaderBackColor = System.Drawing.Color.MediumSpringGreen;
            this.dataGridMain.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGridMain.HeaderForeColor = System.Drawing.Color.Black;
            this.dataGridMain.LinkColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGridMain.Location = new System.Drawing.Point(0, 45);
            this.dataGridMain.Name = "dataGridMain";
            this.dataGridMain.ParentRowsBackColor = System.Drawing.Color.Ivory;
            this.dataGridMain.ParentRowsForeColor = System.Drawing.Color.Black;
            this.dataGridMain.SelectionBackColor = System.Drawing.Color.Wheat;
            this.dataGridMain.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGridMain.Size = new System.Drawing.Size(880, 455);
            this.dataGridMain.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.cbQuery);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.txtFileName);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.txtClientFilePath);
            this.groupBox1.Controls.Add(this.txtUpdater);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFileVersion);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(880, 45);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // cbQuery
            // 
            this.cbQuery.Location = new System.Drawing.Point(180, 15);
            this.cbQuery.Name = "cbQuery";
            this.cbQuery.Size = new System.Drawing.Size(67, 22);
            this.cbQuery.TabIndex = 5;
            this.cbQuery.Text = "Query";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(67, 15);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(106, 20);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // txtFileName
            // 
            this.txtFileName.BackColor = System.Drawing.Color.LightCyan;
            this.txtFileName.Location = new System.Drawing.Point(300, 17);
            this.txtFileName.Multiline = true;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(121, 19);
            this.txtFileName.TabIndex = 2;
            this.txtFileName.Text = "File Name";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.LightCyan;
            this.txtID.Location = new System.Drawing.Point(247, 17);
            this.txtID.Multiline = true;
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(47, 19);
            this.txtID.TabIndex = 2;
            this.txtID.Text = "ID";
            // 
            // txtClientFilePath
            // 
            this.txtClientFilePath.BackColor = System.Drawing.Color.LightCyan;
            this.txtClientFilePath.Location = new System.Drawing.Point(427, 17);
            this.txtClientFilePath.Multiline = true;
            this.txtClientFilePath.Name = "txtClientFilePath";
            this.txtClientFilePath.ReadOnly = true;
            this.txtClientFilePath.Size = new System.Drawing.Size(228, 19);
            this.txtClientFilePath.TabIndex = 2;
            this.txtClientFilePath.Text = "Client Relative Path";
            // 
            // txtUpdater
            // 
            this.txtUpdater.BackColor = System.Drawing.Color.LightCyan;
            this.txtUpdater.Location = new System.Drawing.Point(782, 17);
            this.txtUpdater.Name = "txtUpdater";
            this.txtUpdater.ReadOnly = true;
            this.txtUpdater.Size = new System.Drawing.Size(86, 20);
            this.txtUpdater.TabIndex = 2;
            this.txtUpdater.Text = "Update By";
            this.txtUpdater.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "File Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFileVersion
            // 
            this.txtFileVersion.BackColor = System.Drawing.Color.LightCyan;
            this.txtFileVersion.Location = new System.Drawing.Point(661, 17);
            this.txtFileVersion.Multiline = true;
            this.txtFileVersion.Name = "txtFileVersion";
            this.txtFileVersion.ReadOnly = true;
            this.txtFileVersion.Size = new System.Drawing.Size(102, 19);
            this.txtFileVersion.TabIndex = 2;
            this.txtFileVersion.Text = "File Version";
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(880, 566);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolBarMain);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Manager";
            this.Activated += new System.EventHandler(this.frmManager_Activated);
            this.Load += new System.EventHandler(this.frmManager_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMain)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private System.Windows.Forms.ToolBar toolBarMain;
		private System.Windows.Forms.ToolBarButton tbAdd;
		private System.Windows.Forms.ToolBarButton tbModify;
		private System.Windows.Forms.ToolBarButton tbDelete;
		private System.Windows.Forms.ToolBarButton tbExport;
		private System.Windows.Forms.ToolBarButton tbPrint;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBarButton tbExit;
		private System.Windows.Forms.ToolBarButton tbSeparator1;
		private System.Windows.Forms.ToolBarButton tbSeparator;
		private System.Windows.Forms.Panel panel1;

		#region Variables
		
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuDeletAll;
		private System.Windows.Forms.DataGrid dataGridMain;
		private System.Windows.Forms.TextBox txtFileName;
		private System.Windows.Forms.TextBox txtClientFilePath;
		private System.Windows.Forms.TextBox txtFileVersion;
        
		private System.Windows.Forms.TextBox txtUpdater;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtSearch;

		private System.Windows.Forms.GroupBox groupBox1;
		
		private System.Windows.Forms.CheckBox cbQuery;
		private System.Windows.Forms.TextBox txtID;
		
		#endregion 

        private UpdateHelper updateHelper = new UpdateHelper();

        private UpdateHelper UpdateHelper
        {
            get
            {
                return this.updateHelper;
            }
        }

        private System.Data.DataView dv;
        private System.Data.DataSet ds = null;
        private EditType editType = EditType.None;
        private ToolBarButton toolBarButton1;
        private ToolBarButton toolBarButton2;
        private bool IsVisible = true;

		private enum TableColumns
		{
            [Description("ID")]
			ID = 0 ,
            [Description("FileName")]
			FILE_NAME,
            [Description("LocalDir")]
			LOCAL_DIR,
            [Description("FileVersion")]
			FILE_VERSION ,
            [Description("UpdateBy")]
			UPDATE_BY ,
            [Description("UpdateDate")]
			UPDATE_DATE
		}

        private bool SyncSystemTime()
        {
            try
            {
                UpdateHelper.WaitingForm.lblTip.Text = "Sync system time.....";
                DateTime serverTime = DataAccessor.Instance.GetServerDateTime();

                SystemTime systimeToSet = new SystemTime();
                systimeToSet.wDay = (ushort)serverTime.Day;
                systimeToSet.wMonth = (ushort)serverTime.Month;
                systimeToSet.wYear = (ushort)serverTime.Year;
                systimeToSet.wHour = (ushort)serverTime.Hour;
                systimeToSet.wMinute = (ushort)serverTime.Minute;
                systimeToSet.wSecond = (ushort)(serverTime.Second);
                //Kerner32Invoke.SetSystemTime(ref systimeToSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to sync time:" + ex.Message);
                CloseForm();
                return false;
            }
            return true;
        }

        private bool Upgrade()
        {
            IsVisible = false;
            UpdateHelper.WaitingForm.lblTip.Text = "Querying files to download.....";
            if (UpdateHelper.UpgradeFiles() != -1)
            {
                UpdateHelper.WriteAppConfig("UpdateTime", System.DateTime.Now.ToString());

            }
            else
            {
                MessageBox.Show("Fail to upgrade:" + UpdateHelper.ErrorMessage);
                CloseForm();
                return false;
            }
            
            return true;
        }

        private bool OpenTargetApp()
        {
            System.Windows.Forms.Application.Exit();
            string appFilePath = Application.StartupPath + UpdateHelper.GetAppConfig("AppFilePath");
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.FileName = appFilePath;

            if (System.IO.File.Exists(appFilePath))
            {
                UpdateHelper.WaitingForm.lblTip.Text = "Starting App...";

                System.Windows.Forms.Application.Exit();

                UpdateHelper.WaitingForm.Refresh();
                Process p = new Process();
                p.StartInfo = processInfo;
                p.Start();
            }
            else
            {
                MessageBox.Show("Not find file:" + appFilePath);
                return false;
            }
            return true;
        }

        private bool VerifyPassword()
        {
            UpdateHelper.WaitingForm.lblTip.Text = "Checking password...";
            Application.DoEvents();
            frmPassword frmPwd = new frmPassword();
            frmPwd.ShowDialog();
            if (!frmPwd.PasswordIsRight)
            {
                frmPwd.Close();
                CloseForm();
                return false;
            }
            frmPwd.Close();
            return true;
        }

        private void ClearControlContent()
        {
            txtID.Text = "";
            txtFileName.Text = "";
            txtClientFilePath.Text = "";
            txtUpdater.Text = "";
            txtFileVersion.Text = "";
        }

        private void ShowWaitingForm()
        {
            UpdateHelper.WaitingForm.StartPosition = FormStartPosition.CenterScreen;
            UpdateHelper.WaitingForm.Show();
            System.Windows.Forms.Application.DoEvents();
            UpdateHelper.WaitingForm.Refresh();
        }

		private void frmManager_Load(object sender, System.EventArgs e)
		{
			try
			{
                ShowWaitingForm();

				if(!UpdateHelper.TestConnectDB())
				{
					MessageBox.Show(UpdateHelper.ErrorMessage);
					CloseForm();
					return ;
				}

                if (!SyncSystemTime())
                {
                    return;
                }

                //Upgrade mode
				if(UpdateHelper.GetAppConfig("Download") == "1")
				{
                    if (!Upgrade())
                    {
                        return;
                    }

                    if (!OpenTargetApp())
                    {
                        return;
                    }
				}
                else//Maintain mode
				{
                    if (!VerifyPassword())
                    {
                        return;
                    }

                    ClearControlContent();

                    LoadData();
				}

				UpdateHelper.WaitingForm.Hide(); 
			}
			catch(Exception ex)
			{
				UpdateHelper.WaitingForm.Hide();
				MessageBox.Show(ex.Message);
				this.CloseForm();
			}
		}


        private void LoadData()
        {
			UpdateHelper.WaitingForm.lblTip.Text ="Querying data...";
			Application.DoEvents();

            DownloadFileCriteria criteria = new DownloadFileCriteria();
            criteria.IsLight = true;
            ds = DataAccessor.Instance.GetDataSet(criteria);

			if(ds == null || ds.Tables.Count ==0)
			{
				MessageBox.Show("Fail to get download files.");
				this.CloseForm();
				return ;
			}

			CreateKeys(ds.Tables[0]);

			dv = new DataView(ds.Tables[0]);
            
			dv.AllowEdit = false;

            //this.txtID.DataBindings.Add("Text", dv, EnumHelper.GetDesc(TableColumns.ID));
            //this.txtFileName.DataBindings.Add("Text", dv, EnumHelper.GetDesc(TableColumns.FILE_NAME));
            //this.txtClientFilePath.DataBindings.Add("Text", dv, EnumHelper.GetDesc(TableColumns.LOCAL_DIR));
            //this.txtFileVersion.DataBindings.Add("Text", dv, EnumHelper.GetDesc(TableColumns.FILE_VERSION));
            //this.txtUpdater.DataBindings.Add("Text", dv, EnumHelper.GetDesc(TableColumns.UPDATE_BY));

            this.txtID.DataBindings.Add("Text", dv, TableColumns.ID.ToString());
            this.txtFileName.DataBindings.Add("Text", dv, TableColumns.FILE_NAME.ToString());
            this.txtClientFilePath.DataBindings.Add("Text", dv, TableColumns.LOCAL_DIR.ToString());
            this.txtFileVersion.DataBindings.Add("Text", dv, TableColumns.FILE_VERSION.ToString());
            this.txtUpdater.DataBindings.Add("Text", dv, TableColumns.UPDATE_BY.ToString());
			this.dataGridMain.DataSource = dv;

            if (dv.Table.Rows.Count == 0)
            {
                this.tbModify.Enabled = false;
                this.tbDelete.Enabled = false;
            }
            dataGridMain.CaptionVisible = true;
			this.dataGridMain.ReadOnly = true;
        }
		
		public void CloseForm()
		{
			this.Close();
		}
		
	
		private void toolBarMain_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if(e.Button == this.tbAdd)
			{
				AddFile();
			}
			else if(e.Button == this.tbModify)
			{
				ModifyFile();
			}
			else if(e.Button == this.tbDelete)
			{
				Delete();
			}
			else if(e.Button == this.tbExport)
			{
				Export();
			}
			else if(e.Button == this.tbPrint)
			{
	            //TODO:
			}
			else if(e.Button == this.tbExit)
			{
				System.Windows.Forms.Application.Exit();
			}
		}

		private void AddFile()
		{
			editType = EditType.Add;
			
			frmFileInfo frm = new frmFileInfo();
			frm.SaveHandle +=new frmFileInfo.SaveDelegate(frm_SaveHandle);
			frm.EditType = EditType.Add; 
			frm.ShowDialog();
		}

		private void ModifyFile()
		{
			editType = EditType.Modify;
		
			#region Get info
            DownloadFile obj = DataAccessor.Instance.GetOne(int.Parse(this.txtID.Text), true);
            if (obj == null)
            {
                MessageBox.Show("Not found the file on server.", "Alert", MessageBoxButtons.OK);
                return;
            }
            obj.UpdateDate = DateTime.Now;
            obj.UpdateBy = Dns.GetHostName();
			#endregion 

			frmFileInfo frm = new frmFileInfo();
			frm.SetDownloadFile(obj);
			frm.EditType = EditType.Modify; 
			frm.SaveHandle +=new frmFileInfo.SaveDelegate(frm_SaveHandle);
			frm.ShowDialog();
		}
		
		private void Delete()
		{		
			if(this.ds.Tables.Count == 0 && this.ds.Tables[0].Rows.Count == 0) 
			{
				return ;
			}
			if(MessageBox.Show("Delete file "+ txtFileName.Text + ",the operation can't recover,continue?","Warning",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Warning) == DialogResult.No)
			{
				return ;
			}
           
            int result = DataAccessor.Instance.Delete(int.Parse(this.txtID.Text));
			if(result <= 0)
			{
				MessageBox.Show("Fail to delete data:" + UpdateHelper.ErrorMessage);
			}
			else
			{
				object[] keys = new object[]{this.txtID.Text};
				DataRow row = ds.Tables[0].Rows.Find(keys);
				this.ds.Tables[0].Rows.Remove(row);
				ds.AcceptChanges();
				MessageBox.Show("Delete success.");
			}
		}
		
		private void Export()
		{
			
			try
			{
				if(txtFileName.Text == "")
				{
					MessageBox.Show("Please slelect file to export.");
					return ;
				}
				SaveFileDialog saveFileDlg = new SaveFileDialog();
			
				saveFileDlg.Filter = "*|*.*";
				saveFileDlg.FileName =txtFileName.Text;

				saveFileDlg.Title = "Export data.";
				if(saveFileDlg.ShowDialog()==DialogResult.OK)
				{
                    if (UpdateHelper.ExportFile(int.Parse(this.txtID.Text), saveFileDlg.FileName) == 1)
					{
						MessageBox.Show(txtFileName.Text + "Export success.");
					}
				}
			}
			catch(Exception ee)
			{
				MessageBox.Show(ee.Message);
			}
		}

		private void frm_SaveHandle(DownloadFile obj)
		{
			if(editType == EditType.Add)
			{
				DataRow row = ds.Tables[0].NewRow();
				
				SetRow(obj, row);
				ds.Tables[0].Rows.Add(row);
			}
			else if(editType == EditType.Modify)
			{
				object[] keys = new object[]{obj.ID};
				DataRow row = ds.Tables[0].Rows.Find(keys);
				if(row == null)
				{
					MessageBox.Show("Fail to get result.");
					return;
				}
				else
				{
					SetRow(obj, row);
				}
			}
			ds.Tables[0].AcceptChanges();
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.tbModify.Enabled = true;
                this.tbDelete.Enabled = true;
            }
		}

		private void CreateKeys(DataTable table )
		{
			DataColumn[] keys = new DataColumn[]{table.Columns[TableColumns.ID.ToString()]};
			table.PrimaryKey = keys;
		}

		
		private void SetRow(DownloadFile obj, DataRow row)
		{
			row[TableColumns.ID.ToString()] = obj.ID;
            row[TableColumns.FILE_NAME.ToString()] = obj.FileName;
            row[TableColumns.LOCAL_DIR.ToString()] = obj.LocalDir;
            row[TableColumns.FILE_VERSION.ToString()] = obj.FileVersion;

            row["CREATE_DATE"] = obj.CreateDate;
            row[TableColumns.UPDATE_BY.ToString()] = obj.UpdateBy;
            row[TableColumns.UPDATE_DATE.ToString()] = obj.UpdateDate;
		}
		private void frmManager_Activated(object sender, System.EventArgs e)
		{
			this.Visible = IsVisible;
		}

		private void menuDeletAll_Click(object sender, System.EventArgs e)
		{
			if(this.ds.Tables.Count ==0 ||this.ds.Tables[0].Rows.Count == 0)
			{
				return ;
			}
			
			if(MessageBox.Show("It can NOT recover once you delete all data,continue?","Warning",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Warning) == DialogResult.No)
			{
				return ;
			}

            int i = DataAccessor.Instance.Delete();
			if(i <= 0)
			{
				MessageBox.Show("Fail to delete all data:" + UpdateHelper.ErrorMessage);
			}
			else
			{
				ds.Tables[0].Clear();
				ds.AcceptChanges();
				MessageBox.Show("Delete success.");
			}
		}

		private void txtSearch_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(this.cbQuery.Checked)
				{
					dv.RowFilter = TableColumns.FILE_NAME.ToString() + " like '%" + txtSearch.Text.Trim() + "%'";
				}
				else
				{
					dv.RowFilter = TableColumns.FILE_NAME.ToString() + " like '" + txtSearch.Text.Trim() + "%'";
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
