namespace SSData
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
            this.components = new System.ComponentModel.Container();
            C1.Win.C1Tile.PanelElement panelElement4 = new C1.Win.C1Tile.PanelElement();
            C1.Win.C1Tile.ImageElement imageElement4 = new C1.Win.C1Tile.ImageElement();
            C1.Win.C1Tile.TextElement textElement4 = new C1.Win.C1Tile.TextElement();
            this.c1TileControl1 = new C1.Win.C1Tile.C1TileControl();
            this.group1 = new C1.Win.C1Tile.Group();
            this.tile1 = new C1.Win.C1Tile.Tile();
            this.tile2 = new C1.Win.C1Tile.Tile();
            this.tile3 = new C1.Win.C1Tile.Tile();
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
            panelElement4.Alignment = System.Drawing.ContentAlignment.BottomLeft;
            panelElement4.Children.Add(imageElement4);
            panelElement4.Children.Add(textElement4);
            panelElement4.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.c1TileControl1.DefaultTemplate.Elements.Add(panelElement4);
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
            this.group1.Text = "รายการ";
            this.group1.Tiles.Add(this.tile1);
            this.group1.Tiles.Add(this.tile2);
            this.group1.Tiles.Add(this.tile3);
            // 
            // tile1
            // 
            this.tile1.BackColor = System.Drawing.Color.LightCoral;
            this.tile1.Name = "tile1";
            this.tile1.Text = "ข้อมูลประจำเดือน";
            // 
            // tile2
            // 
            this.tile2.BackColor = System.Drawing.Color.Teal;
            this.tile2.Name = "tile2";
            this.tile2.Text = "ทำข้อมูลใหม่";
            // 
            // tile3
            // 
            this.tile3.BackColor = System.Drawing.Color.SteelBlue;
            this.tile3.Name = "tile3";
            this.tile3.Text = "ออกจากโปรแกรม";
            this.tile3.Click += new System.EventHandler(this.tile3_Click);
            // 
            // c1ThemeController1
            // 
            this.c1ThemeController1.Theme = "Office2010Black";

            // 
            // FrmSSDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 495);
            this.Controls.Add(this.c1TileControl1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSSDataView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSSDataView";
            this.c1ThemeController1.SetTheme(this, "Office2010Black");
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSSDataView_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmSSDataView_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmSSDataView_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmSSDataView_MouseUp);
            this.Resize += new System.EventHandler(this.FrmSSDataView_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1Tile.C1TileControl c1TileControl1;
        private C1.Win.C1Tile.Group group1;
        private C1.Win.C1Tile.Tile tile1;
        private C1.Win.C1Tile.Tile tile2;
        private C1.Win.C1Tile.Tile tile3;
        private C1.Win.C1Themes.C1ThemeController c1ThemeController1;
        private C1.Win.C1SuperTooltip.C1SuperTooltip c1SuperTooltip1;
    }
}