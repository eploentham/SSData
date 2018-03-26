namespace SSData
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            C1.Win.C1Tile.PanelElement panelElement1 = new C1.Win.C1Tile.PanelElement();
            C1.Win.C1Tile.ImageElement imageElement1 = new C1.Win.C1Tile.ImageElement();
            C1.Win.C1Tile.TextElement textElement1 = new C1.Win.C1Tile.TextElement();
            this.c1TileControl1 = new C1.Win.C1Tile.C1TileControl();
            this.group1 = new C1.Win.C1Tile.Group();
            this.tilSSDataView = new C1.Win.C1Tile.Tile();
            this.tilSSDataAdd = new C1.Win.C1Tile.Tile();
            this.tilExit = new C1.Win.C1Tile.Tile();
            this.c1ThemeController1 = new C1.Win.C1Themes.C1ThemeController();
            this.c1SuperTooltip1 = new C1.Win.C1SuperTooltip.C1SuperTooltip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1TileControl1
            // 
            this.c1TileControl1.AllowChecking = true;
            this.c1TileControl1.AllowRearranging = true;
            // 
            // 
            // 
            panelElement1.Alignment = System.Drawing.ContentAlignment.BottomLeft;
            panelElement1.Children.Add(imageElement1);
            panelElement1.Children.Add(textElement1);
            panelElement1.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.c1TileControl1.DefaultTemplate.Elements.Add(panelElement1);
            this.c1TileControl1.Groups.Add(this.group1);
            this.c1TileControl1.Location = new System.Drawing.Point(12, 12);
            this.c1TileControl1.Name = "c1TileControl1";
            this.c1TileControl1.Size = new System.Drawing.Size(340, 471);
            this.c1TileControl1.TabIndex = 0;
            this.c1TileControl1.Text = "โปรแกรม ประกันสังคม";
            // 
            // group1
            // 
            this.group1.Name = "group1";
            this.group1.Text = "หน้าจอใช้งาน";
            this.group1.Tiles.Add(this.tilSSDataView);
            this.group1.Tiles.Add(this.tilSSDataAdd);
            this.group1.Tiles.Add(this.tilExit);
            // 
            // tilSSDataView
            // 
            this.tilSSDataView.BackColor = System.Drawing.Color.LightCoral;
            this.tilSSDataView.Name = "tilSSDataView";
            this.tilSSDataView.Text = "ข้อมูลประจำเดือน";
            // 
            // tilSSDataAdd
            // 
            this.tilSSDataAdd.BackColor = System.Drawing.Color.Teal;
            this.tilSSDataAdd.Name = "tilSSDataAdd";
            this.tilSSDataAdd.Text = "ทำข้อมูลใหม่";
            // 
            // tilExit
            // 
            this.tilExit.BackColor = System.Drawing.Color.SteelBlue;
            this.tilExit.Name = "tilExit";
            this.tilExit.Text = "ออกจากโปรแกรม";
            this.tilExit.Click += new System.EventHandler(this.tilExit_Click);
            // 
            // c1ThemeController1
            // 
            this.c1ThemeController1.Theme = "Office2010Black";
            // 
            // c1SuperTooltip1
            // 
            this.c1SuperTooltip1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.c1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 495);
            this.Controls.Add(this.c1TileControl1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSSDataView";
            this.c1ThemeController1.SetTheme(this, "Office2010Black");
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmSSDataView_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmSSDataView_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmSSDataView_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1Tile.C1TileControl c1TileControl1;
        private C1.Win.C1Tile.Group group1;
        private C1.Win.C1Tile.Tile tilSSDataView;
        private C1.Win.C1Tile.Tile tilSSDataAdd;
        private C1.Win.C1Tile.Tile tilExit;
        private C1.Win.C1Themes.C1ThemeController c1ThemeController1;
        private C1.Win.C1SuperTooltip.C1SuperTooltip c1SuperTooltip1;
    }
}