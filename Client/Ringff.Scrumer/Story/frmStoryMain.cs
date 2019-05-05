using Ringff.Common.Object.Common;
using Ringff.Common.Object.Scrumer;
using Ringff.Scrumer.Operator;
using Ringff.Winform.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/************************************************************************   
 * Version :  v1.0.0.0  
 * Description :      
 * Author :  Eric Zhao 
************************************************************************/
namespace Ringff.Scrumer.Story
{
    public partial class frmStoryMain : frmBase
    {
        public frmStoryMain()
        {
            InitializeComponent();
        }

       

        protected override void InitForm()
        {
            base.InitForm();
            this.Shadow = false;
            this.ControlBox = false;
            this.MaximizedBounds = this.MdiParent.DesktopBounds;
            this.WindowState = FormWindowState.Maximized;
            
        }

        private void frmStoryMain_Load(object sender, EventArgs e)
        {
            Application.DoEvents();
            LoadData();
        }
        private List<StoryEntity> dataList = null;
        private BindingList<StoryEntity> bindingDataList = null;
        private void LoadData()
        {
            RFHttpResponse<List<StoryEntity>> res = StoryOperator.GetAll();
            if (!res.Header.IsSuccess)
            {
                return;
            }
            dataList = res.Data[StoryEntity.DATA_KEY];
            if (dataList == null || dataList.Count == 0)
            {
                btnModify.Enabled = false;
                return;
            }
            bindingDataList = new BindingList<StoryEntity>(dataList);
            dgvMain.DataSource = bindingDataList;
            btnModify.Enabled = true;

        }

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowItemForm(null);
        }

        private void ShowItemForm(StoryEntity objToEdit)
        {
            frmStoryItem fm = new frmStoryItem();
            fm.EditStory = objToEdit;

            if (fm.EditStory == null)
            {
                fm.AddHandle +=fm_AddHandle;
            }
            else
            {
                fm.ModifyHandle +=fm_ModifyHandle;
            }
            
            fm.ShowDialog();
        }

        private void fm_AddHandle(Ringff.Common.Object.Scrumer.StoryEntity obj)
        {
            HandleAddResult(obj);
        }

        private void fm_ModifyHandle(Ringff.Common.Object.Scrumer.StoryEntity obj)
        {
            HandleModifyResult(obj);
        }

        private void HandleAddResult(StoryEntity obj)
        {
            //List<StoryEntity> list = dgvMain.DataSource as List<StoryEntity>;
            //list.Add(obj);
            //dgvMain.DataSource = list;
            bindingDataList.Add(obj);
        }

        private void HandleModifyResult(StoryEntity obj)
        {
            //List<StoryEntity> list = dgvMain.DataSource as List<StoryEntity>;
            //StoryEntity oldObj = list.Find(item => obj.ID == item.ID);
            //oldObj = obj;

            StoryEntity oldObj = dgvMain.CurrentRow.DataBoundItem as StoryEntity;
            RefershRowData(oldObj, obj);
        }

        private void RefershRowData(StoryEntity rowData, StoryEntity changedData)
        {
            if (rowData.Name != changedData.Name)
            {
                rowData.Name = changedData.Name;
            }

            if (rowData.ProjectId != changedData.ProjectId)
            {
                rowData.ProjectId = changedData.ProjectId;
            }
            if (rowData.LinkUrl != changedData.LinkUrl)
            {
                rowData.LinkUrl = changedData.LinkUrl;
            }
            if (rowData.Content != changedData.Content)
            {
                rowData.Content = changedData.Content;
            }
            if (rowData.Developer != changedData.Developer)
            {
                rowData.Developer = changedData.Developer;
            }
            if (rowData.QA != changedData.QA)
            {
                rowData.QA = changedData.QA;
            }
            if (rowData.Point != changedData.Point)
            {
                rowData.Point = changedData.Point;
            }
            if (rowData.DevPlanTime != changedData.DevPlanTime)
            {
                rowData.DevPlanTime = changedData.DevPlanTime;
            }
            if (rowData.DevSpendTime != changedData.DevSpendTime)
            {
                rowData.DevSpendTime = changedData.DevSpendTime;
            }
            if (rowData.QAPlanTime != changedData.QAPlanTime)
            {
                rowData.QAPlanTime = changedData.QAPlanTime;
            }

            if (rowData.QASpendTime != changedData.QASpendTime)
            {
                rowData.QASpendTime = changedData.QASpendTime;
            }

            if (rowData.ISDCount != changedData.ISDCount)
            {
                rowData.ISDCount = changedData.ISDCount;
            }

            rowData.UpdateDate = changedData.UpdateDate;
            rowData.UpdateBy = changedData.UpdateBy;
            
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (!checkBeforeModify())
            {
                return;
            }

            StoryEntity objToEdit = dgvMain.CurrentRow.DataBoundItem as StoryEntity;
            ShowItemForm(objToEdit);
        }

        private bool checkBeforeModify()
        {
            if (dgvMain.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select the row to modify.");
                return false;
            }
            
            return true;
        }

        private void tsBtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnModify_Click(sender, e);
        }
    }
}
