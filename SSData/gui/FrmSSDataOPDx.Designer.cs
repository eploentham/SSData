namespace SSData.gui
{
    partial class FrmSSDataOPDx
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
            this.grdView = new FarPoint.Win.Spread.FpSpread();
            this.grdView_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnOk = new C1.Win.C1Input.C1Button();
            this.btnEdit = new C1.Win.C1Input.C1Button();
            this.c1ThemeController1 = new C1.Win.C1Themes.C1ThemeController();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdView
            // 
            this.grdView.AccessibleDescription = "";
            this.grdView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdView.Location = new System.Drawing.Point(0, 67);
            this.grdView.Name = "grdView";
            this.grdView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.grdView_Sheet1});
            this.grdView.Size = new System.Drawing.Size(1086, 459);
            this.grdView.TabIndex = 1;
            this.grdView.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.grdView_EditChange);
            // 
            // grdView_Sheet1
            // 
            this.grdView_Sheet1.Reset();
            this.grdView_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.grdView_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.grdView_Sheet1.ColumnFooter.DefaultStyle.BackColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.ColumnFooter.DefaultStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.ColumnFooterSheetCornerStyle.BackColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.ColumnFooterSheetCornerStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.DefaultStyle.BackColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.DefaultStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.FilterBar.DefaultStyle.BackColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.FilterBar.DefaultStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.FilterBarHeaderStyle.BackColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.FilterBarHeaderStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(883, 24);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(118, 37);
            this.btnOk.TabIndex = 57;
            this.btnOk.Text = "บันทึกช้อมูล";
            this.c1ThemeController1.SetTheme(this.btnOk, "GreenHouse");
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(12, 24);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(118, 37);
            this.btnEdit.TabIndex = 56;
            this.btnEdit.Text = "แก้ไขช้อมูล";
            this.c1ThemeController1.SetTheme(this.btnEdit, "GreenHouse");
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // FrmSSDataOPDx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 526);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.grdView);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Name = "FrmSSDataOPDx";
            this.Text = "FrmOPDx";
            this.c1ThemeController1.SetTheme(this, "GreenHouse");
            this.Load += new System.EventHandler(this.FrmSSDataOPDx_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread grdView;
        private FarPoint.Win.Spread.SheetView grdView_Sheet1;
        private C1.Win.C1Input.C1Button btnOk;
        private C1.Win.C1Input.C1Button btnEdit;
        private C1.Win.C1Themes.C1ThemeController c1ThemeController1;
    }
}