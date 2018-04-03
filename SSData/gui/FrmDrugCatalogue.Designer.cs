namespace SSData.gui
{
    partial class FrmDrugCatalogue
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBrowe = new C1.Win.C1Input.C1Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new C1.Win.C1Input.C1Button();
            this.c1ThemeController1 = new C1.Win.C1Themes.C1ThemeController();
            this.excel = new C1.C1Excel.C1XLBook();
            this.pB1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView_Sheet1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdView
            // 
            this.grdView.AccessibleDescription = "";
            this.grdView.Location = new System.Drawing.Point(12, 121);
            this.grdView.Name = "grdView";
            this.grdView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.grdView_Sheet1});
            this.grdView.Size = new System.Drawing.Size(860, 595);
            this.grdView.TabIndex = 0;
            // 
            // grdView_Sheet1
            // 
            this.grdView_Sheet1.Reset();
            this.grdView_Sheet1.SheetName = "Sheet1";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(232)))), ((int)(((byte)(190)))));
            this.groupBox1.Controls.Add(this.pB1);
            this.groupBox1.Controls.Add(this.btnBrowe);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnOk);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(5)))));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(859, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.c1ThemeController1.SetTheme(this.groupBox1, "Office2010Green");
            // 
            // btnBrowe
            // 
            this.btnBrowe.Location = new System.Drawing.Point(79, 19);
            this.btnBrowe.Name = "btnBrowe";
            this.btnBrowe.Size = new System.Drawing.Size(48, 37);
            this.btnBrowe.TabIndex = 27;
            this.btnBrowe.Text = "...";
            this.c1ThemeController1.SetTheme(this.btnBrowe, "Office2010Green");
            this.btnBrowe.UseVisualStyleBackColor = true;
            this.btnBrowe.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.btnBrowe.Click += new System.EventHandler(this.btnBrowe_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(232)))), ((int)(((byte)(190)))));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(5)))));
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "นำเข้าข้อมูล :";
            this.c1ThemeController1.SetTheme(this.label1, "Office2010Green");
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(590, 19);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(118, 37);
            this.btnOk.TabIndex = 25;
            this.btnOk.Text = "นำเข้า";
            this.c1ThemeController1.SetTheme(this.btnOk, "Office2010Green");
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pB1
            // 
            this.pB1.Location = new System.Drawing.Point(6, 71);
            this.pB1.Name = "pB1";
            this.pB1.Size = new System.Drawing.Size(844, 23);
            this.pB1.TabIndex = 28;
            // 
            // FrmDrugCatalogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 728);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grdView);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(5)))));
            this.Name = "FrmDrugCatalogue";
            this.Text = "FrmDrugCatalogue";
            this.c1ThemeController1.SetTheme(this, "Office2010Green");
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDrugCatalogue_FormClosing);
            this.Load += new System.EventHandler(this.FrmDrugCatalogue_Load);
            this.Resize += new System.EventHandler(this.FrmDrugCatalogue_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView_Sheet1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread grdView;
        private FarPoint.Win.Spread.SheetView grdView_Sheet1;
        private System.Windows.Forms.GroupBox groupBox1;
        private C1.Win.C1Input.C1Button btnOk;
        private C1.Win.C1Themes.C1ThemeController c1ThemeController1;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1Button btnBrowe;
        private C1.C1Excel.C1XLBook excel;
        private System.Windows.Forms.ProgressBar pB1;
    }
}