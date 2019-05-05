using Ringff.Common.Object.Common;
using Ringff.Common.Object.Scrumer;
using Ringff.Scrumer.Operator;
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
    public partial class frmStoryItem : frmScrumerBase
    {
        public delegate void SaveDelegate(Ringff.Common.Object.Scrumer.StoryEntity obj);
        public event SaveDelegate AddHandle;
        public event SaveDelegate ModifyHandle;

        /// <summary>
        /// true: Add mode, false Modify mode
        /// Default is true.
        /// </summary>
        private bool IsAddMode
        {
            get
            {
                return this.EditStory == null;
            }

        }

        private StoryEntity editStory = null;
        public StoryEntity EditStory
        {
            get
            {
                return this.editStory;
            }
            set
            {
                this.editStory = value;
            }
        }

        public frmStoryItem()
        {
            InitializeComponent();
        }

        private void frmStoryItem_Load(object sender, EventArgs e)
        {

        }

        protected override void InitForm()
        {
            base.InitForm();
            this.ControlBox = false;

            if (!IsAddMode)
            {
                FillFormField();
            }

            this.txtName.Focus();
        }

        private void FillFormField()
        {
            txtName.Text = EditStory.Name;
            txtLinkUrl.Text = EditStory.LinkUrl;
            txtContent.Text = EditStory.Content;
            txtDeveloper.Text = EditStory.Developer;
            txtQA.Text = EditStory.QA;
            txtPoint.Text = EditStory.Point.ToString();
            txtDevPlanTime.Text = EditStory.DevPlanTime.ToString();
            txtDevSpendTime.Text = EditStory.DevSpendTime.ToString();
            txtQAPlanTime.Text = EditStory.QAPlanTime.ToString();
            txtQASpendTime.Text = EditStory.QASpendTime.ToString();
            txtISDCount.Text = EditStory.ISDCount.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Close();
            }
        }

        private void btnSaveAddAnother_Click(object sender, EventArgs e)
        {
            SaveAddAnother();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool ValidInput()
        {
            if (String.IsNullOrWhiteSpace(txtName.Text))
            {
                ShowError("Name is required.");
                txtName.Focus();
                return false;
            }

            return true;
        }

        private Ringff.Common.Object.Scrumer.StoryEntity ConstructStory()
        {
            Ringff.Common.Object.Scrumer.StoryEntity obj = new Ringff.Common.Object.Scrumer.StoryEntity();
            if (!IsAddMode)
            {
                obj.ID = EditStory.ID;
            }
            obj.Name = txtName.Text;
            obj.LinkUrl = txtLinkUrl.Text;
            obj.Content = txtContent.Text;
            obj.Developer = txtDeveloper.Text;
            if (!String.IsNullOrWhiteSpace(txtDevPlanTime.Text))
            {
                obj.DevPlanTime = float.Parse(txtDevPlanTime.Text);
            }
            if (!String.IsNullOrWhiteSpace(txtDevSpendTime.Text))
            {
                obj.DevSpendTime = float.Parse(txtDevSpendTime.Text);
            }
            obj.QA = txtQA.Text;
            if (!String.IsNullOrWhiteSpace(txtQAPlanTime.Text))
            {
                obj.QAPlanTime = float.Parse(txtQAPlanTime.Text);
            }
            if (!String.IsNullOrWhiteSpace(txtQASpendTime.Text))
            {
                obj.QASpendTime = float.Parse(txtQASpendTime.Text);
            }

            if (!String.IsNullOrEmpty(txtPoint.Text))
            {
                obj.Point = int.Parse(txtPoint.Text);
            }

            if (!String.IsNullOrWhiteSpace(txtISDCount.Text))
            {
                obj.ISDCount = int.Parse(txtISDCount.Text);
            }

            DateTime now = DateTime.Now;
            if (IsAddMode)
            {
                obj.CreateDate = now;
                obj.CreateBy = frmMain.CurrentLogin.Name;
            }
            obj.UpdateDate = now;
            obj.UpdateBy = frmMain.CurrentLogin.Name;

            return obj;
        }

        private bool Save()
        {
            if (!ValidInput())
            {
                return false;
            }
            HideError();

            StoryEntity obj = ConstructStory();
            RFHttpResponse<int> res = IsAddMode ? StoryOperator.Add(obj) : StoryOperator.Modify(obj);

            if (!res.Header.IsSuccess)
            {
                ShowError(res.Header.Message);
                return false;
            }

            if (IsAddMode)
            {
                obj.ID = res.Data["id"];
            }
            

            if (IsAddMode)
            {
                AddHandle(obj);
            }
            else
            {
                ModifyHandle(obj);
            }
            
            return true;
        }

        private void SaveAddAnother()
        {
            if (!Save())
            {
                return;
            }

            ClearInput();
            txtName.Focus();
        }

        private void ClearInput()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBoxBase)
                {
                    (c as TextBoxBase).Clear();
                }
            }
        }

    }//class
}
