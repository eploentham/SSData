using SSData.control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSData.gui
{
    public partial class FrmBillMuad : Form
    {
        Form par;
        SSDataControl sC;
        int colE=0, colS=1, colCode = 2, colDesc = 3, colgrd=4, colGrpss2 = 5, coledit=6;
        int colCnt = 7;
        int colM06E = 0, colM06S = 1, colM06Code = 2, colM06Desc = 3, colM06Grpss2 = 4, colM06edit=5;
        int colM06Cnt = 6;

        int colBMedit = 0, colBMsave = 1, colBMCode = 2, colBMDesc = 3;

        

        int colBMCnt = 4;

        Font fEdit;

        public FrmBillMuad(SSDataControl sc, Form par1)
        {
            InitializeComponent();
            initConfig(sc, par1);
        }
        private void initConfig(SSDataControl sc, Form par1)
        {
            sC = sc;
            par = par1;
            fEdit = grdView.Font;
            fEdit = new Font(fEdit, FontStyle.Bold);
            grdView.Sheets.Count = 3;
            grdView.Height = 330;
            grdView.Width = 765;
            grdView.Sheets[0].SheetName = "Finance_M01";
            grdView.Sheets[1].SheetName = "Finance_M06";
            grdView.Sheets[2].SheetName = "Bill Muad";
            setGrdView();
            setGrdViewM06();
            setGrdViewM20();
        }
        private void setGrdViewH()
        {
            FarPoint.Win.Spread.EnhancedInterfaceRenderer outlinelook = new FarPoint.Win.Spread.EnhancedInterfaceRenderer();
            outlinelook.RangeGroupBackgroundColor = Color.LightGreen;
            outlinelook.RangeGroupButtonBorderColor = Color.Red;
            outlinelook.RangeGroupLineColor = Color.Blue;
            grdView.InterfaceRenderer = outlinelook;

            grdView.BorderStyle = BorderStyle.None;
            grdView.Sheets[0].Columns[2, colgrd].AllowAutoFilter = true;
            grdView.Sheets[0].Columns[2, colgrd].AllowAutoSort = true;
            grdView.Sheets[0].AutoFilterMode = FarPoint.Win.Spread.AutoFilterMode.EnhancedContextMenu;

            FarPoint.Win.Spread.CellType.NumberCellType objNumCell = new FarPoint.Win.Spread.CellType.NumberCellType();
            objNumCell.DecimalPlaces = 0;
            objNumCell.MinimumValue = 1;
            objNumCell.MaximumValue = 9999;
            objNumCell.ShowSeparator = false;

            FarPoint.Win.Spread.CellType.DateTimeCellType datecell = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            datecell.DateSeparator = " | ";
            datecell.TimeSeparator = ".";
            datecell.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDateWithTime;

            FarPoint.Win.Spread.CellType.CurrencyCellType ctest = new FarPoint.Win.Spread.CellType.CurrencyCellType();
            FarPoint.Win.Spread.CellType.TextCellType objTextCell = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttencell = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType combocell = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            combocell.Items = sC.mHisDB.fm20;

            //grdView.Sheets.Count = 1;
            grdView.Sheets[0].ColumnCount = colCnt;
            grdView.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;

            grdView.Sheets[0].ColumnHeader.Cells[0, colE].Text = "edit";
            grdView.Sheets[0].ColumnHeader.Cells[0, colS].Text = "save";
            grdView.Sheets[0].ColumnHeader.Cells[0, colCode].Text = "FN_CD";
            grdView.Sheets[0].ColumnHeader.Cells[0, colDesc].Text = "Description";
            grdView.Sheets[0].ColumnHeader.Cells[0, colGrpss2].Text = "grd_ss_2";
            grdView.Sheets[0].ColumnHeader.Cells[0, colgrd].Text = "GRD_CD";

            grdView.Sheets[0].Columns[colE].Width = 50;
            grdView.Sheets[0].Columns[colS].Width = 50;
            grdView.Sheets[0].Columns[colCode].Width = 80;
            grdView.Sheets[0].Columns[colDesc].Width = 250;
            grdView.Sheets[0].Columns[colGrpss2].Width = 250;
            grdView.Sheets[0].Columns[colgrd].Width = 300;

            grdView.Sheets[0].Columns[colE].CellType = buttencell;
            grdView.Sheets[0].Columns[colS].CellType = buttencell;
            grdView.Sheets[0].Columns[colCode].CellType = objTextCell;
            grdView.Sheets[0].Columns[colDesc].CellType = objTextCell;
            grdView.Sheets[0].Columns[colgrd].CellType = objTextCell;
            grdView.Sheets[0].Columns[colGrpss2].CellType = combocell;

            grdView.Sheets[0].Columns[coledit].Visible = false;
        }
        private void setGrdViewHM06()
        {
            FarPoint.Win.Spread.CellType.CurrencyCellType ctest = new FarPoint.Win.Spread.CellType.CurrencyCellType();
            FarPoint.Win.Spread.CellType.TextCellType objTextCell = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttencell = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType combocell = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            combocell.Items = sC.mHisDB.fm20;

            grdView.Sheets[1].ColumnCount = colM06Cnt;
            grdView.Sheets[1].OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;

            grdView.Sheets[1].ColumnHeader.Cells[0, colM06E].Text = "edit";
            grdView.Sheets[1].ColumnHeader.Cells[0, colM06S].Text = "save";
            grdView.Sheets[1].ColumnHeader.Cells[0, colM06Code].Text = "code";
            grdView.Sheets[1].ColumnHeader.Cells[0, colM06Desc].Text = "Description";
            grdView.Sheets[1].ColumnHeader.Cells[0, colM06Grpss2].Text = "grp_ss_2";

            grdView.Sheets[1].Columns[colM06E].Width = 50;
            grdView.Sheets[1].Columns[colM06S].Width = 50;
            grdView.Sheets[1].Columns[colM06Code].Width = 80;
            grdView.Sheets[1].Columns[colM06Desc].Width = 200;
            grdView.Sheets[1].Columns[colM06Grpss2].Width = 250;
            //grdView.Sheets[0].Columns[colE].Width = 50;

            grdView.Sheets[1].Columns[colM06E].CellType = buttencell;
            grdView.Sheets[1].Columns[colM06S].CellType = buttencell;
            grdView.Sheets[1].Columns[colM06Code].CellType = objTextCell;
            grdView.Sheets[1].Columns[colM06Desc].CellType = objTextCell;
            grdView.Sheets[1].Columns[colM06Grpss2].CellType = combocell;
            grdView.Sheets[1].Columns[colM06edit].CellType = objTextCell;

            grdView.Sheets[1].Columns[colM06edit].Visible = false;

        }
        private void setGrdViewHM20()
        {
            FarPoint.Win.Spread.CellType.CurrencyCellType ctest = new FarPoint.Win.Spread.CellType.CurrencyCellType();
            FarPoint.Win.Spread.CellType.TextCellType objTextCell = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttencell = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType combocell = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            combocell.Items =  sC.mHisDB.fm20;

            grdView.Sheets[2].ColumnCount = colBMCnt;
            grdView.Sheets[2].OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;

            grdView.Sheets[2].ColumnHeader.Cells[0, colBMedit].Text = "edit";
            grdView.Sheets[2].ColumnHeader.Cells[0, colBMsave].Text = "save";
            grdView.Sheets[2].ColumnHeader.Cells[0, colBMCode].Text = "code";
            grdView.Sheets[2].ColumnHeader.Cells[0, colBMDesc].Text = "Description";
            //grdView.Sheets[1].ColumnHeader.Cells[0, colM06Grpss2].Text = "edit";

            grdView.Sheets[2].Columns[colBMedit].Width = 50;
            grdView.Sheets[2].Columns[colBMsave].Width = 50;
            grdView.Sheets[2].Columns[colBMCode].Width = 80;
            grdView.Sheets[2].Columns[colBMDesc].Width = 200;
            //grdView.Sheets[1].Columns[colM06Grpss2].Width = 50;
            //grdView.Sheets[0].Columns[colE].Width = 50;

            grdView.Sheets[2].Columns[colBMedit].CellType = buttencell;
            grdView.Sheets[2].Columns[colBMsave].CellType = buttencell;
            grdView.Sheets[2].Columns[colBMCode].CellType = objTextCell;
            grdView.Sheets[2].Columns[colBMDesc].CellType = objTextCell;
            //grdView.Sheets[1].Columns[colM06Grpss2].CellType = objTextCell;

        }
        private void setGrdView()
        {
            DataTable dt = new DataTable();
            int i = 0;
            dt = sC.mHisDB.fm01DB.selectAll();
            grdView.Sheets[0].Rows.Clear();
            setGrdViewH();
            grdView.Sheets[0].RowCount = dt.Rows.Count;
            foreach (DataRow row in dt.Rows)
            {
                grdView.Sheets[0].Cells[i, colCode].Value = row[sC.mHisDB.fm01DB.fm01.MNC_FN_CD].ToString();
                grdView.Sheets[0].Cells[i, colDesc].Value = row[sC.mHisDB.fm01DB.fm01.MNC_FN_DSCT].ToString();
                grdView.Sheets[0].Cells[i, colgrd].Value = row[sC.mHisDB.fm01DB.fm01.MNC_FN_GRP_DES].ToString();
                grdView.Sheets[0].Cells[i, colGrpss2].Value = row[sC.mHisDB.fm01DB.fm01.MNC_GRP_SS2_DSC].ToString();                
                
                grdView.Sheets[0].Cells[i, coledit].Value = "0";
                if (i % 2 == 0)
                {
                    grdView.Sheets[0].Cells[i, 0, i, colCnt - 1].BackColor = System.Drawing.Color.FromArgb(235, 241, 222);
                }
                i++;
            }
        }
        private void setGrdViewM06()
        {
            DataTable dt = new DataTable();
            int i = 0;
            dt = sC.mHisDB.fm06DB.selectAll();
            grdView.Sheets[1].Rows.Clear();
            setGrdViewHM06();
            grdView.Sheets[1].RowCount = dt.Rows.Count;
            foreach (DataRow row in dt.Rows)
            {
                grdView.Sheets[1].Cells[i, colM06Code].Value = row[sC.mHisDB.fm06DB.fm06.MNC_FN_GRP_CD].ToString();
                grdView.Sheets[1].Cells[i, colM06Desc].Value = row[sC.mHisDB.fm06DB.fm06.MNC_FN_GRP_DSC].ToString();
                //grdView.Sheets[1].Cells[i, colM06Grpss2].Value = row[sC.mHisDB.fm06DB.fm06.MNC_GRP_SS2].ToString();
                //grdView.Sheets[1].Cells[i, colGrpss2].Value = row[sC.mHisDB.fm06DB.fm06.MNC_GRP_SS2].ToString();

                grdView.Sheets[1].Cells[i, colM06edit].Value = "0";
                if (i % 2 == 0)
                {
                    grdView.Sheets[1].Cells[i, 0, i, colM06Cnt - 1].BackColor = System.Drawing.Color.FromArgb(235, 241, 222);
                }
                i++;
            }
        }
        private void setGrdViewM20()
        {
            DataTable dt = new DataTable();
            int i = 0;
            dt = sC.mHisDB.fm20DB.selectAll();
            grdView.Sheets[2].Rows.Clear();
            setGrdViewHM20();
            grdView.Sheets[2].RowCount = dt.Rows.Count;
            foreach (DataRow row in dt.Rows)
            {
                grdView.Sheets[2].Cells[i, colBMCode].Value = row[sC.mHisDB.fm20DB.fm20.MNC_GRP_SS2].ToString();
                grdView.Sheets[2].Cells[i, colBMDesc].Value = row[sC.mHisDB.fm20DB.fm20.MNC_GRP_SS2_DSC].ToString();
                //grdView.Sheets[1].Cells[i, colM06Grpss2].Value = row[sC.mHisDB.fm06DB.fm06.MNC_GRP_SS2].ToString();
                //grdView.Sheets[1].Cells[i, colGrpss2].Value = row[sC.mHisDB.fm06DB.fm06.MNC_GRP_SS2].ToString();

                grdView.Sheets[2].Cells[i, colM06E].Value = "0";
                if (i % 2 == 0)
                {
                    grdView.Sheets[2].Cells[i, 0, i, colBMCnt - 1].BackColor = System.Drawing.Color.FromArgb(235, 241, 222);
                }
                i++;
            }
        }
        private void grdView_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            //FarPoint.Win.Spread.SheetView sheet1 = grdView.ActiveSheet;
            //sheet1.SheetName
            if (grdView.ActiveSheet.SheetName.Equals("Finance_M01"))
            {
                grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, coledit].Value = "1";
                grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, e.Column].Font = fEdit;
                grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, e.Column].ForeColor = Color.Red;
            }
            else if (grdView.ActiveSheet.SheetName.Equals("Finance_M06"))
            {
                grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, colM06edit].Value = "1";
                grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, e.Column].Font = fEdit;
                grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, e.Column].ForeColor = Color.Red;
            }


        }
        private void grdView_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (grdView.ActiveSheet.SheetName.Equals("Finance_M01"))
            {
                if (e.Column == colE)
                {
                    grdView.Sheets[grdView.ActiveSheet.SheetName].OperationMode = FarPoint.Win.Spread.OperationMode.Normal;
                    //grdView.Sheets[0].Rows.
                }
                else if (e.Column == colS)
                {
                    //for (int i = 0; i < grdView.Sheets[grdView.ActiveSheet.SheetName].RowCount; i++)
                    //{
                        String edit = "";
                        if(grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, coledit].Value.Equals("1"))
                        {
                            String code = "", grpss2 = "", codeBM="";
                            code = grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, colCode].Value.ToString().Trim();
                            grpss2 = grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, colGrpss2].Value.ToString().Trim();
                            codeBM = sC.mHisDB.getFM20Code(grpss2);
                            if (!codeBM.Equals(""))
                            {
                                String re = sC.mHisDB.fm01DB.updateSS2(code, codeBM);
                                if (re.Equals("1"))
                                {
                                    grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, 0, e.Row, colCnt - 1].BackColor = Color.GreenYellow;
                                }
                            }
                            
                        }
                    //}
                }
            }
            else if (grdView.ActiveSheet.SheetName.Equals("Finance_M06"))
            {
                if (e.Column == colE)
                {
                    grdView.Sheets[grdView.ActiveSheet.SheetName].OperationMode = FarPoint.Win.Spread.OperationMode.Normal;
                    //grdView.Sheets[0].Rows.
                }
                else if (e.Column == colM06S)
                {
                    if (grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, colM06edit].Value.Equals("1"))
                    {
                        String code = "", grpss2 = "", codeBM = "";
                        code = grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, colM06Code].Value.ToString().Trim();
                        grpss2 = grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, colM06Grpss2].Value.ToString().Trim();
                        codeBM = sC.mHisDB.getFM20Code(grpss2);
                        if (!codeBM.Equals(""))
                        {
                            String re = sC.mHisDB.fm01DB.updateSS2ByM06(code, codeBM);
                            int re1 = 0;
                            int.TryParse(re, out re1);
                            if (re1 > 0)
                            {
                                MessageBox.Show("บันทึกข้อมูล ทั้งหมด "+ re1.ToString()+" รายการ", "Save");
                                grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, 0, e.Row, colM06Cnt - 1].BackColor = Color.GreenYellow;
                            }
                        }
                    }
                }
            }


        }
        private void FrmBillMuad_FormClosing(object sender, FormClosingEventArgs e)
        {
            par.Show();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // ...
            if (keyData == (Keys.Escape))
            {
                //if (MessageBox.Show("ต้องการออกจากโปรแกรม", "ออกจากโปรแกรม", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                //{
                Close();
                return true;
                //}
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void FrmBillMuad_Load(object sender, EventArgs e)
        {

        }
    }
}
