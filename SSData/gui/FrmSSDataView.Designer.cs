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
            this.grdView = new FarPoint.Win.Spread.FpSpread();
            this.grdView_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.c1ThemeController1 = new C1.Win.C1Themes.C1ThemeController();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView_Sheet1)).BeginInit();
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
            this.grdView.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.grdView_CellDoubleClick);
            this.grdView.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.grdView_ButtonClicked);
            // 
            // grdView_Sheet1
            // 
            this.grdView_Sheet1.Reset();
            this.grdView_Sheet1.SheetName = "Sheet1";
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
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.ForeColor = System.Drawing.Color.Black;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(344, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            this.c1ThemeController1.SetTheme(this.comboBox1, "(default)");
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.White;
            this.comboBox2.ForeColor = System.Drawing.Color.Black;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(66, 38);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 6;
            this.c1ThemeController1.SetTheme(this.comboBox2, "(default)");
            // 
            // FrmSSDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 687);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread grdView;
        private FarPoint.Win.Spread.SheetView grdView_Sheet1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1Themes.C1ThemeController c1ThemeController1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}