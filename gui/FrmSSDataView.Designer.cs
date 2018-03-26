namespace SSData.gui
{
    partial class FrmSSDataView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSSDataView));
            this.grdView = new FarPoint.Win.Spread.FpSpread();
            this.grdView_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.cboYear = new C1.Win.C1List.C1Combo();
            this.cboMonth = new C1.Win.C1List.C1Combo();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.c1ThemeController1 = new C1.Win.C1Themes.C1ThemeController();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdView
            // 
            this.grdView.AccessibleDescription = "";
            this.grdView.Location = new System.Drawing.Point(12, 118);
            this.grdView.Name = "grdView";
            this.grdView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.grdView_Sheet1});
            this.grdView.Size = new System.Drawing.Size(776, 557);
            this.grdView.TabIndex = 0;
            // 
            // grdView_Sheet1
            // 
            this.grdView_Sheet1.Reset();
            this.grdView_Sheet1.SheetName = "Sheet1";
            // 
            // cboYear
            // 
            this.cboYear.AddItemSeparator = ';';
            this.cboYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboYear.Caption = "";
            this.cboYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cboYear.DeadAreaBackColor = System.Drawing.Color.White;
            this.cboYear.EditorBackColor = System.Drawing.Color.White;
            this.cboYear.EditorFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboYear.EditorForeColor = System.Drawing.Color.Black;
            this.cboYear.FlatStyle = C1.Win.C1List.FlatModeEnum.Flat;
            this.cboYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboYear.Images.Add(((System.Drawing.Image)(resources.GetObject("cboYear.Images"))));
            this.cboYear.Location = new System.Drawing.Point(78, 31);
            this.cboYear.MatchEntryTimeout = ((long)(2000));
            this.cboYear.MaxDropDownItems = ((short)(5));
            this.cboYear.MaxLength = 32767;
            this.cboYear.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cboYear.Name = "cboYear";
            this.cboYear.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cboYear.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cboYear.Size = new System.Drawing.Size(121, 19);
            this.cboYear.TabIndex = 1;
            this.cboYear.Text = "c1Combo1";
            this.c1ThemeController1.SetTheme(this.cboYear, "Office2010Red");
            this.cboYear.PropBag = resources.GetString("cboYear.PropBag");
            // 
            // cboMonth
            // 
            this.cboMonth.AddItemSeparator = ';';
            this.cboMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboMonth.Caption = "";
            this.cboMonth.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cboMonth.DeadAreaBackColor = System.Drawing.Color.White;
            this.cboMonth.EditorBackColor = System.Drawing.Color.White;
            this.cboMonth.EditorFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMonth.EditorForeColor = System.Drawing.Color.Black;
            this.cboMonth.FlatStyle = C1.Win.C1List.FlatModeEnum.Flat;
            this.cboMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMonth.Images.Add(((System.Drawing.Image)(resources.GetObject("cboMonth.Images"))));
            this.cboMonth.Location = new System.Drawing.Point(352, 31);
            this.cboMonth.MatchEntryTimeout = ((long)(2000));
            this.cboMonth.MaxDropDownItems = ((short)(5));
            this.cboMonth.MaxLength = 32767;
            this.cboMonth.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cboMonth.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cboMonth.Size = new System.Drawing.Size(121, 19);
            this.cboMonth.TabIndex = 2;
            this.cboMonth.Text = "c1Combo2";
            this.c1ThemeController1.SetTheme(this.cboMonth, "Office2010Red");
            this.cboMonth.PropBag = resources.GetString("cboMonth.PropBag");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.label1.Location = new System.Drawing.Point(24, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Year :";
            this.c1ThemeController1.SetTheme(this.label1, "Office2010Red");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.label2.Location = new System.Drawing.Point(294, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Month :";
            this.c1ThemeController1.SetTheme(this.label2, "Office2010Red");
            // 
            // FrmSSDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 687);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboMonth);
            this.Controls.Add(this.cboYear);
            this.Controls.Add(this.grdView);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.Name = "FrmSSDataView";
            this.Text = "FrmSSDataView";
            this.c1ThemeController1.SetTheme(this, "Office2010Red");
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSSDataView_FormClosing);
            this.Load += new System.EventHandler(this.FrmSSDataView_Load);
            this.Resize += new System.EventHandler(this.FrmSSDataView_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread grdView;
        private FarPoint.Win.Spread.SheetView grdView_Sheet1;
        private C1.Win.C1List.C1Combo cboYear;
        private C1.Win.C1List.C1Combo cboMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1Themes.C1ThemeController c1ThemeController1;
    }
}