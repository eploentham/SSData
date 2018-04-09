using SSData.control;
using SSData.object1;
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
    public partial class FrmSSDataBTi : Form
    {
        BillTran bt;
        BillTranItems btI;
        SSDataControl sC;

        int colId = 0, colbtid = 1, colinvno = 2, colsvdate = 3, colbillmuad = 4, collccode = 5, colstdcode = 6;
        int coldesc1 = 7, colqty = 8, colup = 9, colchargeamt = 10, colclaimup = 11, colsvrefid = 12, colclaimcat = 13;
        int colEdit =14, colClaimamount=15;
        int colCnt = 16;
        Font fEdit;

        public FrmSSDataBTi(SSDataControl sc)
        {
            InitializeComponent();
            initConfig(sc);
        }
        private void initConfig(SSDataControl sc)
        {
            sC = sc;
            bt = new BillTran();
            btI = new BillTranItems();
            fEdit = grdView.Font;
            fEdit = new Font(fEdit, FontStyle.Bold);
            //setGrdViewH();
            setGrdView();
        }
        private void setGrdViewH()
        {
            FarPoint.Win.Spread.EnhancedInterfaceRenderer outlinelook = new FarPoint.Win.Spread.EnhancedInterfaceRenderer();
            outlinelook.RangeGroupBackgroundColor = Color.LightGreen;
            outlinelook.RangeGroupButtonBorderColor = Color.Red;
            outlinelook.RangeGroupLineColor = Color.Blue;
            grdView.InterfaceRenderer = outlinelook;
            grdView.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;

            grdView.BorderStyle = BorderStyle.None;
            grdView.Sheets[0].Columns[0, 2].AllowAutoFilter = true;
            grdView.Sheets[0].Columns[0, 2].AllowAutoSort = true;
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
            ctest.SetCalculatorText("Accept", "Cancel");
            FarPoint.Win.Spread.CellType.TextCellType objTextCell = new FarPoint.Win.Spread.CellType.TextCellType();

            //grdView.sheet
            //grdView.Height = 330;
            //grdView.Width = 765;
            grdView.Sheets[0].ColumnCount = colCnt;
            grdView.Sheets[0].RowCount = 1;


            //grdView.Sheets[0].ColumnHeader.Cells[0, 0].Text = "Check #";
            grdView.Sheets[0].Columns[colId].CellType = objTextCell;
            grdView.Sheets[0].Columns[colbtid].CellType = objTextCell;
            grdView.Sheets[0].Columns[colinvno].CellType = objTextCell;
            grdView.Sheets[0].Columns[colsvdate].CellType = objTextCell;
            grdView.Sheets[0].Columns[colbillmuad].CellType = objTextCell;
            grdView.Sheets[0].Columns[collccode].CellType = objTextCell;
            grdView.Sheets[0].Columns[colstdcode].CellType = objTextCell;
            grdView.Sheets[0].Columns[coldesc1].CellType = objTextCell;
            grdView.Sheets[0].Columns[colqty].CellType = objTextCell;
            grdView.Sheets[0].Columns[colup].CellType = objTextCell;
            grdView.Sheets[0].Columns[colchargeamt].CellType = objTextCell;
            grdView.Sheets[0].Columns[colclaimup].CellType = objTextCell;
            grdView.Sheets[0].Columns[colsvrefid].CellType = objTextCell;
            grdView.Sheets[0].Columns[colclaimcat].CellType = objTextCell;
            grdView.Sheets[0].Columns[colEdit].CellType = objTextCell;
            grdView.Sheets[0].Columns[colClaimamount].CellType = objTextCell;

            grdView.Sheets[0].Columns[colId].Visible = false;
            grdView.Sheets[0].Columns[colbtid].Visible = false;
            grdView.Sheets[0].Columns[colEdit].Visible = false;

            grdView.Sheets[0].SheetName = "BillTran Items";

            grdView.Sheets[0].Columns[colinvno].Width = 100;
            grdView.Sheets[0].Columns[colsvdate].Width = 120;
            grdView.Sheets[0].Columns[colbillmuad].Width = 50;
            grdView.Sheets[0].Columns[collccode].Width = 50;
            grdView.Sheets[0].Columns[colstdcode].Width = 50;
            grdView.Sheets[0].Columns[coldesc1].Width = 250;
            grdView.Sheets[0].Columns[colqty].Width = 50;
            grdView.Sheets[0].Columns[colup].Width = 80;
            grdView.Sheets[0].Columns[colchargeamt].Width = 60;
            grdView.Sheets[0].Columns[colclaimup].Width = 50;
            grdView.Sheets[0].Columns[colsvrefid].Width = 80;
            grdView.Sheets[0].Columns[colclaimcat].Width = 50;
            grdView.Sheets[0].Columns[colClaimamount].Width = 50;

            grdView.Sheets[0].ColumnHeader.Cells[0, colinvno].Text = "invno";
            grdView.Sheets[0].ColumnHeader.Cells[0, colsvdate].Text = "svdate";
            grdView.Sheets[0].ColumnHeader.Cells[0, colbillmuad].Text = "billmuad";
            grdView.Sheets[0].ColumnHeader.Cells[0, collccode].Text = "lccode";
            grdView.Sheets[0].ColumnHeader.Cells[0, colstdcode].Text = "stdcode";
            grdView.Sheets[0].ColumnHeader.Cells[0, coldesc1].Text = "description";
            grdView.Sheets[0].ColumnHeader.Cells[0, colqty].Text = "qty";
            grdView.Sheets[0].ColumnHeader.Cells[0, colup].Text = "up";
            grdView.Sheets[0].ColumnHeader.Cells[0, colchargeamt].Text = "chargeamt";
            grdView.Sheets[0].ColumnHeader.Cells[0, colclaimup].Text = "claimup";
            grdView.Sheets[0].ColumnHeader.Cells[0, colsvrefid].Text = "svrefid";
            grdView.Sheets[0].ColumnHeader.Cells[0, colclaimcat].Text = "claimcat";
            grdView.Sheets[0].ColumnHeader.Cells[0, colClaimamount].Text = "claimamount";

            grdView.Sheets[0].RestrictRows = true;

        }
        private void setGrdView()
        {
            DataTable dt = new DataTable();
            int i = 0;
            dt = sC.mHisDB.btIDB.selectByBTId(sC.btID);
            grdView.Sheets[0].Rows.Clear();
            setGrdViewH();
            grdView.Sheets[0].RowCount = dt.Rows.Count;
            foreach (DataRow row in dt.Rows)
            {
                grdView.Sheets[0].Cells[i, colinvno].Value = row[sC.mHisDB.btIDB.btI.invno].ToString();
                grdView.Sheets[0].Cells[i, colsvdate].Value = row[sC.mHisDB.btIDB.btI.svdate].ToString();
                grdView.Sheets[0].Cells[i, colbillmuad].Value = row[sC.mHisDB.btIDB.btI.billmuad].ToString();
                grdView.Sheets[0].Cells[i, collccode].Value = row[sC.mHisDB.btIDB.btI.lccode].ToString();
                grdView.Sheets[0].Cells[i, colstdcode].Value = row[sC.mHisDB.btIDB.btI.stdcode].ToString();
                grdView.Sheets[0].Cells[i, coldesc1].Value = row[sC.mHisDB.btIDB.btI.desc1].ToString();
                grdView.Sheets[0].Cells[i, colqty].Value = row[sC.mHisDB.btIDB.btI.qty].ToString();
                grdView.Sheets[0].Cells[i, colup].Value = row[sC.mHisDB.btIDB.btI.up].ToString();
                grdView.Sheets[0].Cells[i, colchargeamt].Value = row[sC.mHisDB.btIDB.btI.chargeamt].ToString();
                grdView.Sheets[0].Cells[i, colclaimup].Value = row[sC.mHisDB.btIDB.btI.claimup].ToString();
                grdView.Sheets[0].Cells[i, colsvrefid].Value = row[sC.mHisDB.btIDB.btI.svrefid].ToString();
                grdView.Sheets[0].Cells[i, colclaimcat].Value = row[sC.mHisDB.btIDB.btI.claimcat].ToString();
                grdView.Sheets[0].Cells[i, colId].Value = row[sC.mHisDB.btIDB.btI.billtran_items_id].ToString();
                grdView.Sheets[0].Cells[i, colbtid].Value = row[sC.mHisDB.btIDB.btI.billtran_id].ToString();
                grdView.Sheets[0].Cells[i, colClaimamount].Value = row[sC.mHisDB.btIDB.btI.claimamount].ToString();
                grdView.Sheets[0].Cells[i, colEdit].Value = "0";
                if (i % 2 == 0)
                {
                    grdView.Sheets[0].Cells[i, 0, i, colCnt - 1].BackColor = System.Drawing.Color.FromArgb(235, 241, 222);
                }
                i++;
            }
        }
        private void grdView_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            grdView.Sheets[0].Cells[e.Row, colEdit].Value = "1";
            grdView.Sheets[0].Cells[e.Row, e.Column].Font = fEdit;
            grdView.Sheets[0].Cells[e.Row, e.Column].ForeColor = Color.Red;
        }
        private void grdView_EditError(object sender, FarPoint.Win.Spread.EditErrorEventArgs e)
        {
            
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            grdView.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.Normal;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            for(int i = 0;i < grdView.Sheets[0].RowCount; i++)
            {
                String edit = "";
                edit = grdView.Sheets[0].Cells[i, colEdit].Value.ToString();
                if (edit.Equals("1"))
                {
                    BillTranItems bti = new BillTranItems();
                    btI.billmuad = grdView.Sheets[0].Cells[i, colbillmuad].Value.ToString();
                    btI.billtran_id = grdView.Sheets[0].Cells[i, colbtid].Value.ToString();
                    btI.billtran_items_id = grdView.Sheets[0].Cells[i, colId].Value.ToString();
                    btI.chargeamt = grdView.Sheets[0].Cells[i, colchargeamt].Value.ToString();
                    btI.claimamount = grdView.Sheets[0].Cells[i, colClaimamount].Value.ToString();
                    btI.claimcat = grdView.Sheets[0].Cells[i, colclaimcat].Value.ToString();
                    btI.claimup = grdView.Sheets[0].Cells[i, colclaimup].Value.ToString();
                    btI.desc1 = grdView.Sheets[0].Cells[i, coldesc1].Value.ToString();
                    btI.invno = grdView.Sheets[0].Cells[i, colinvno].Value.ToString();
                    btI.lccode = grdView.Sheets[0].Cells[i, collccode].Value.ToString();
                    btI.qty = grdView.Sheets[0].Cells[i, colqty].Value.ToString();
                    btI.stdcode = grdView.Sheets[0].Cells[i, colstdcode].Value.ToString();
                    btI.svdate = grdView.Sheets[0].Cells[i, colsvdate].Value.ToString();
                    btI.svrefid = grdView.Sheets[0].Cells[i, colsvrefid].Value.ToString();
                    btI.up = grdView.Sheets[0].Cells[i, colup].Value.ToString();
                    String re = sC.mHisDB.btIDB.update(btI);
                    if (re.Equals("1"))
                    {
                        grdView.Sheets[0].Cells[i, 0, i, colCnt - 1].BackColor = Color.GreenYellow;
                    }
                }
            }
        }
        private void FrmSSDataBTi_Load(object sender, EventArgs e)
        {

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
    }
}
