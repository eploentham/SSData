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
    public partial class FrmSSDataBDi : Form
    {
        BillDisp bd;
        BillDispItems bdI;
        SSDataControl sC;
        int colId = 0, colbdid = 1, coldispid = 2, colprdcat = 3, colhospdrgid = 4, coldrgid = 5, coldfscode = 6, coldfstext = 7;
        int colpacksize = 8, colsigcode = 9, colsigtext = 10, colquantity = 11, colunitprice = 12, colchargeamt = 13, colreimbprice = 14, colreimbamt = 15;
        int colprdsecode = 16, colclaimcont = 17, colclaimcat = 18, colmultidisp = 19, colsupplyfor = 20;
        int coledit=21,colCnt = 22;
        Font fEdit;

        public FrmSSDataBDi(SSDataControl sc)
        {
            InitializeComponent();
            initConfig(sc);
        }
        private void initConfig(SSDataControl sc)
        {
            sC = sc;
            bd = new BillDisp();
            bdI = new BillDispItems();
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

            FarPoint.Win.Spread.CellType.TextCellType objTextCell = new FarPoint.Win.Spread.CellType.TextCellType();
            grdView.Sheets[0].ColumnCount = colCnt;
            grdView.Sheets[0].RowCount = 1;
            grdView.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;

            grdView.Sheets[0].Columns[colId].CellType = objTextCell;
            grdView.Sheets[0].Columns[colbdid].CellType = objTextCell;
            grdView.Sheets[0].Columns[coldispid].CellType = objTextCell;
            grdView.Sheets[0].Columns[colprdcat].CellType = objTextCell;
            grdView.Sheets[0].Columns[colhospdrgid].CellType = objTextCell;
            grdView.Sheets[0].Columns[coldrgid].CellType = objTextCell;
            grdView.Sheets[0].Columns[coldfscode].CellType = objTextCell;
            grdView.Sheets[0].Columns[coldfstext].CellType = objTextCell;
            grdView.Sheets[0].Columns[colpacksize].CellType = objTextCell;
            grdView.Sheets[0].Columns[colsigcode].CellType = objTextCell;

            grdView.Sheets[0].Columns[colsigtext].CellType = objTextCell;
            grdView.Sheets[0].Columns[colquantity].CellType = objTextCell;
            grdView.Sheets[0].Columns[colunitprice].CellType = objTextCell;
            grdView.Sheets[0].Columns[colchargeamt].CellType = objTextCell;
            grdView.Sheets[0].Columns[colreimbprice].CellType = objTextCell;
            grdView.Sheets[0].Columns[colreimbamt].CellType = objTextCell;
            grdView.Sheets[0].Columns[colprdsecode].CellType = objTextCell;
            grdView.Sheets[0].Columns[colclaimcont].CellType = objTextCell;
            grdView.Sheets[0].Columns[colclaimcat].CellType = objTextCell;
            grdView.Sheets[0].Columns[colmultidisp].CellType = objTextCell;
            grdView.Sheets[0].Columns[colsupplyfor].CellType = objTextCell;
            grdView.Sheets[0].Columns[coledit].CellType = objTextCell;

            grdView.Sheets[0].Columns[colId].Visible = false;
            grdView.Sheets[0].Columns[coledit].Visible = false;
            grdView.Sheets[0].Columns[colbdid].Visible = false;

            grdView.Sheets[0].SheetName = "BillDips Items";

            grdView.Sheets[0].Columns[coldispid].Width = 100;
            grdView.Sheets[0].Columns[colprdcat].Width = 100;
            grdView.Sheets[0].Columns[colhospdrgid].Width = 100;
            grdView.Sheets[0].Columns[coldrgid].Width = 100;
            grdView.Sheets[0].Columns[coldfscode].Width = 100;
            grdView.Sheets[0].Columns[coldfstext].Width = 100;
            grdView.Sheets[0].Columns[colpacksize].Width = 100;
            grdView.Sheets[0].Columns[colsigcode].Width = 100;
            grdView.Sheets[0].Columns[colsigtext].Width = 100;
            grdView.Sheets[0].Columns[colquantity].Width = 100;

            grdView.Sheets[0].Columns[colunitprice].Width = 100;
            grdView.Sheets[0].Columns[colchargeamt].Width = 100;
            grdView.Sheets[0].Columns[colreimbprice].Width = 100;
            grdView.Sheets[0].Columns[colreimbamt].Width = 100;
            grdView.Sheets[0].Columns[colprdsecode].Width = 100;
            grdView.Sheets[0].Columns[colclaimcont].Width = 100;
            grdView.Sheets[0].Columns[colclaimcat].Width = 100;
            grdView.Sheets[0].Columns[colmultidisp].Width = 100;
            grdView.Sheets[0].Columns[colsupplyfor].Width = 100;
            //grdView.Sheets[0].Columns[colinvno].Width = 100;

            grdView.Sheets[0].ColumnHeader.Cells[0, coldispid].Text = "dispid";
            grdView.Sheets[0].ColumnHeader.Cells[0, colprdcat].Text = "prdcat";
            grdView.Sheets[0].ColumnHeader.Cells[0, colhospdrgid].Text = "hospdrgid";
            grdView.Sheets[0].ColumnHeader.Cells[0, coldrgid].Text = "drgid";
            grdView.Sheets[0].ColumnHeader.Cells[0, coldfscode].Text = "dfscode";
            grdView.Sheets[0].ColumnHeader.Cells[0, coldfstext].Text = "dfstext";
            grdView.Sheets[0].ColumnHeader.Cells[0, colpacksize].Text = "packsize";
            grdView.Sheets[0].ColumnHeader.Cells[0, colsigcode].Text = "sigcode";
            grdView.Sheets[0].ColumnHeader.Cells[0, colsigtext].Text = "sigtext";
            grdView.Sheets[0].ColumnHeader.Cells[0, colquantity].Text = "quantity";

            grdView.Sheets[0].ColumnHeader.Cells[0, colunitprice].Text = "unitprice";
            grdView.Sheets[0].ColumnHeader.Cells[0, colchargeamt].Text = "chargeamt";
            grdView.Sheets[0].ColumnHeader.Cells[0, colreimbprice].Text = "reimbprice";
            grdView.Sheets[0].ColumnHeader.Cells[0, colreimbamt].Text = "reimbamt";
            grdView.Sheets[0].ColumnHeader.Cells[0, colprdsecode].Text = "prdsecode";
            grdView.Sheets[0].ColumnHeader.Cells[0, colclaimcont].Text = "claimcont";
            grdView.Sheets[0].ColumnHeader.Cells[0, colclaimcat].Text = "claimcat";
            grdView.Sheets[0].ColumnHeader.Cells[0, colmultidisp].Text = "multidisp";
            grdView.Sheets[0].ColumnHeader.Cells[0, colsupplyfor].Text = "supplyfor";

            grdView.Sheets[0].RestrictRows = true;

        }
        private void setGrdView()
        {
            DataTable dt = new DataTable();
            int i = 0;
            dt = sC.mHisDB.bdIDB.selectByBdId(sC.bdID);
            grdView.Sheets[0].Rows.Clear();
            setGrdViewH();
            grdView.Sheets[0].RowCount = dt.Rows.Count;
            foreach (DataRow row in dt.Rows)
            {
                grdView.Sheets[0].Cells[i, coldispid].Value = row[sC.mHisDB.bdIDB.bdI.dispid].ToString();
                grdView.Sheets[0].Cells[i, colprdcat].Value = row[sC.mHisDB.bdIDB.bdI.prdcat].ToString();
                grdView.Sheets[0].Cells[i, colhospdrgid].Value = row[sC.mHisDB.bdIDB.bdI.hospdrgid].ToString();
                grdView.Sheets[0].Cells[i, coldrgid].Value = row[sC.mHisDB.bdIDB.bdI.drgid].ToString();
                grdView.Sheets[0].Cells[i, coldfscode].Value = row[sC.mHisDB.bdIDB.bdI.dfscode].ToString();
                grdView.Sheets[0].Cells[i, coldfstext].Value = row[sC.mHisDB.bdIDB.bdI.dfstext].ToString();
                grdView.Sheets[0].Cells[i, colpacksize].Value = row[sC.mHisDB.bdIDB.bdI.packsize].ToString();
                grdView.Sheets[0].Cells[i, colsigcode].Value = row[sC.mHisDB.bdIDB.bdI.sigcode].ToString();
                grdView.Sheets[0].Cells[i, colsigtext].Value = row[sC.mHisDB.bdIDB.bdI.sigtext].ToString();
                grdView.Sheets[0].Cells[i, colquantity].Value = row[sC.mHisDB.bdIDB.bdI.quantity].ToString();
                grdView.Sheets[0].Cells[i, colunitprice].Value = row[sC.mHisDB.bdIDB.bdI.unitprice].ToString();
                grdView.Sheets[0].Cells[i, colchargeamt].Value = row[sC.mHisDB.bdIDB.bdI.chargeamt].ToString();
                grdView.Sheets[0].Cells[i, colreimbprice].Value = row[sC.mHisDB.bdIDB.bdI.reimbprice].ToString();
                grdView.Sheets[0].Cells[i, colreimbamt].Value = row[sC.mHisDB.bdIDB.bdI.reimbamt].ToString();
                grdView.Sheets[0].Cells[i, colprdsecode].Value = row[sC.mHisDB.bdIDB.bdI.prdsecode].ToString();
                grdView.Sheets[0].Cells[i, colclaimcont].Value = row[sC.mHisDB.bdIDB.bdI.claimcont].ToString();
                grdView.Sheets[0].Cells[i, colclaimcat].Value = row[sC.mHisDB.bdIDB.bdI.claimcat].ToString();
                grdView.Sheets[0].Cells[i, colmultidisp].Value = row[sC.mHisDB.bdIDB.bdI.multidisp].ToString();
                grdView.Sheets[0].Cells[i, colsupplyfor].Value = row[sC.mHisDB.bdIDB.bdI.supplyfor].ToString();

                grdView.Sheets[0].Cells[i, colId].Value = row[sC.mHisDB.bdIDB.bdI.billdisp_items_id].ToString();
                grdView.Sheets[0].Cells[i, colbdid].Value = row[sC.mHisDB.bdIDB.bdI.billdisp_id].ToString();
                grdView.Sheets[0].Cells[i, coledit].Value = "0";
                if (i % 2 == 0)
                {
                    grdView.Sheets[0].Cells[i, 0, i, colCnt - 1].BackColor = System.Drawing.Color.FromArgb(235, 241, 222);
                }
                i++;
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grdView.Sheets[0].RowCount; i++)
            {
                String edit = "";
                edit = grdView.Sheets[0].Cells[i, coledit].Value.ToString();
                if (edit.Equals("1"))
                {
                    BillDispItems bdi = new BillDispItems();
                    bdi.dispid = grdView.Sheets[0].Cells[i, coldispid].Value.ToString();
                    bdi.prdcat = grdView.Sheets[0].Cells[i, colprdcat].Value.ToString();
                    bdi.hospdrgid = grdView.Sheets[0].Cells[i, colhospdrgid].Value.ToString();
                    bdi.drgid = grdView.Sheets[0].Cells[i, coldrgid].Value.ToString();
                    bdi.dfscode = grdView.Sheets[0].Cells[i, coldfscode].Value.ToString();
                    bdi.dfstext = grdView.Sheets[0].Cells[i, coldfstext].Value.ToString();
                    bdi.packsize = grdView.Sheets[0].Cells[i, colpacksize].Value.ToString();
                    bdi.sigcode = grdView.Sheets[0].Cells[i, colsigcode].Value.ToString();
                    bdi.sigtext = grdView.Sheets[0].Cells[i, colsigtext].Value.ToString();
                    bdi.quantity = grdView.Sheets[0].Cells[i, colquantity].Value.ToString();
                    bdi.unitprice = grdView.Sheets[0].Cells[i, colunitprice].Value.ToString();
                    bdi.chargeamt = grdView.Sheets[0].Cells[i, colchargeamt].Value.ToString();
                    bdi.reimbprice = grdView.Sheets[0].Cells[i, colreimbprice].Value.ToString();
                    bdi.reimbamt = grdView.Sheets[0].Cells[i, colreimbamt].Value.ToString();
                    bdi.prdsecode = grdView.Sheets[0].Cells[i, colprdsecode].Value.ToString();
                    bdi.claimcont = grdView.Sheets[0].Cells[i, colclaimcont].Value.ToString();
                    bdi.claimcat = grdView.Sheets[0].Cells[i, colclaimcat].Value.ToString();
                    bdi.multidisp = grdView.Sheets[0].Cells[i, colmultidisp].Value.ToString();
                    bdi.supplyfor = grdView.Sheets[0].Cells[i, colsupplyfor].Value.ToString();
                    bdi.billdisp_items_id = grdView.Sheets[0].Cells[i, colId].Value.ToString();
                    bdi.billdisp_id = grdView.Sheets[0].Cells[i, colbdid].Value.ToString();
                    String re = sC.mHisDB.bdIDB.update(bdi);
                    if (re.Equals("1"))
                    {
                        grdView.Sheets[0].Cells[i, 0, i, colCnt - 1].BackColor = Color.GreenYellow;
                    }
                }
            }
        }
        private void grdView_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            grdView.Sheets[0].Cells[e.Row, coledit].Value = "1";
            grdView.Sheets[0].Cells[e.Row, e.Column].Font = fEdit;
            grdView.Sheets[0].Cells[e.Row, e.Column].ForeColor = Color.Red;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            grdView.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.Normal;
        }

        private void FrmSSDataBDi_Load(object sender, EventArgs e)
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
