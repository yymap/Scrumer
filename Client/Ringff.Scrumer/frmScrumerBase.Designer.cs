namespace Ringff.Scrumer
{
    partial class frmScrumerBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblError = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.CustomBackground = false;
            this.lblError.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.lblError.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.lblError.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.lblError.Location = new System.Drawing.Point(18, 72);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(39, 19);
            this.lblError.Style = MetroFramework.MetroColorStyle.Red;
            this.lblError.StyleManager = null;
            this.lblError.TabIndex = 3;
            this.lblError.Text = "error";
            this.lblError.Theme = MetroFramework.MetroThemeStyle.Light;
            this.lblError.UseStyleColors = true;
            this.lblError.Visible = false;
            // 
            // frmScrumerBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 259);
            this.Controls.Add(this.lblError);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmScrumerBase";
            this.Text = "frmScrumerBase";
            this.Load += new System.EventHandler(this.frmScrumerBase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public MetroFramework.Controls.MetroLabel lblError;

    }
}