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
    public partial class FrmSSDataOPDx : Form
    {
        OpServices op;
        OpServicesOpdX opdX;
        SSDataControl sC;
        int colId = 0, colOpId = 1, colclass = 2, colsvid = 3, colsl = 4, colcodeset = 5, colcode = 6, coldesc = 7, coledit = 8;
        int colCnt = 9;

        Font fEdit;

        public FrmSSDataOPDx(SSDataControl sc)
        {
            InitializeComponent();
            initConfig(sc);
        }
        private void initConfig(SSDataControl sc)
        {
            sC = sc;
            op = new OpServices();
            opdX = new OpServicesOpdX();
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

            FarPoint.Win.Spread.CellType.TextCellType objTextCell = new FarPoint.Win.Spread.CellType.TextCellType();
            grdView.Sheets[0].ColumnCount = colCnt;
            grdView.Sheets[0].RowCount = 1;

            grdView.Sheets[0].Columns[colId].CellType = objTextCell;
            grdView.Sheets[0].Columns[colOpId].CellType = objTextCell;
            grdView.Sheets[0].Columns[colclass].CellType = objTextCell;
            grdView.Sheets[0].Columns[colsvid].CellType = objTextCell;
            grdView.Sheets[0].Columns[colcodeset].CellType = objTextCell;
            grdView.Sheets[0].Columns[colcode].CellType = objTextCell;
            grdView.Sheets[0].Columns[coldesc].CellType = objTextCell;
            grdView.Sheets[0].Columns[coledit].CellType = objTextCell;

            grdView.Sheets[0].Columns[colId].Visible = false;
            grdView.Sheets[0].Columns[colOpId].Visible = false;

            grdView.Sheets[0].SheetName = "OPDX";

            grdView.Sheets[0].Columns[colclass].Width = 100;
            grdView.Sheets[0].Columns[colsl].Width = 100;
            grdView.Sheets[0].Columns[colsvid].Width = 100;
            grdView.Sheets[0].Columns[colcodeset].Width = 100;
            grdView.Sheets[0].Columns[colcode].Width = 100;
            grdView.Sheets[0].Columns[coldesc].Width = 100;
            //grdView.Sheets[0].Columns[colinvno].Width = 100;

            grdView.Sheets[0].ColumnHeader.Cells[0, colclass].Text = "class";
            grdView.Sheets[0].ColumnHeader.Cells[0, colsl].Text = "sl";
            grdView.Sheets[0].ColumnHeader.Cells[0, colsvid].Text = "svid";
            grdView.Sheets[0].ColumnHeader.Cells[0, colcodeset].Text = "codeset";
            grdView.Sheets[0].ColumnHeader.Cells[0, colcode].Text = "code";
            grdView.Sheets[0].ColumnHeader.Cells[0, coldesc].Text = "description";

            grdView.Sheets[0].RestrictRows = true;
        }
        private void setGrdView()
        {
            DataTable dt = new DataTable();
            int i = 0;
            dt = sC.mHisDB.opdXDB.selectByOpSId(sC.opsID);
            grdView.Sheets[0].Rows.Clear();
            setGrdViewH();
            grdView.Sheets[0].RowCount = dt.Rows.Count;
            foreach (DataRow row in dt.Rows)
            {
                grdView.Sheets[0].Cells[i, colclass].Value = row[sC.mHisDB.opdXDB.opDX.class1].ToString();
                grdView.Sheets[0].Cells[i, colsl].Value = row[sC.mHisDB.opdXDB.opDX.sl].ToString();
                grdView.Sheets[0].Cells[i, colsvid].Value = row[sC.mHisDB.opdXDB.opDX.svid].ToString();
                grdView.Sheets[0].Cells[i, colcodeset].Value = row[sC.mHisDB.opdXDB.opDX.codeset].ToString();
                grdView.Sheets[0].Cells[i, colcode].Value = row[sC.mHisDB.opdXDB.opDX.code].ToString();
                grdView.Sheets[0].Cells[i, coldesc].Value = row[sC.mHisDB.opdXDB.opDX.desc1].ToString();
                grdView.Sheets[0].Cells[i, colId].Value = row[sC.mHisDB.opdXDB.opDX.opservices_opdx_id].ToString();
                //grdView.Sheets[0].Cells[i, coldesc].Value = row[sC.mHisDB.opSXDB.opDX.desc1].ToString();

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
                    OpServicesOpdX opdx = new OpServicesOpdX();
                    opdx.class1 = grdView.Sheets[0].Cells[i, colclass].Value.ToString();
                    opdx.sl = grdView.Sheets[0].Cells[i, colsl].Value.ToString();
                    opdx.svid = grdView.Sheets[0].Cells[i, colsvid].Value.ToString();
                    opdx.codeset = grdView.Sheets[0].Cells[i, colcodeset].Value.ToString();
                    opdx.code = grdView.Sheets[0].Cells[i, colcode].Value.ToString();
                    opdx.desc1 = grdView.Sheets[0].Cells[i, coldesc].Value.ToString();
                    opdx.opservices_opdx_id = grdView.Sheets[0].Cells[i, colId].Value.ToString();
                    
                    String re = sC.mHisDB.opdXDB.update(opdx);
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
        private void FrmSSDataOPDx_Load(object sender, EventArgs e)
        {

        }
    }
}
