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
    public partial class FrmSSDataView : Form
    {
        Form par;
        SSDataControl sC;
        String monthId = "", yearId = "";
        int colId = 0, colYear = 1, colMonth = 2, colBranchId = 3, colCntHn = 4, colCntVisit = 5, colStatusProcess = 6, colDateStart = 7, colDateEnd = 8;
        int colCnt = 9;
        int colVId = 0, colVssdId = 1, colVBT = 2, colVBTi = 3, colVBD = 4, colBDi = 5, colVOPs = 6, colVOPDx=7;
        int colVHn = 8, colVVn = 9, colVVisitDate = 10, colVName = 11;
        int colVCnt = 13;
        int colBTId = 0, colBTssdId = 1, colBTssvId = 2, colBTBi=3, colBTE=4, colBTS=5, colBTstation = 6, colBTauthcode = 7, colBTdttran = 8, colBThcode = 9;
        int colBTinvno = 10, colBTbillno = 11, colBThn = 12, colBTmemberno = 13, colBTamount = 14, colBTpaid = 15, colBTvercode = 16;
        int colBTtflag = 17, colBTpid = 18, colBTname = 19, colBThmain = 20, colBTpayplan = 21, colBTclaimamt = 22, colBTotherpayplan = 23;
        int colBTotherpay = 24, colBTCnt = 25;
        public FrmSSDataView(SSDataControl sc, Form par1)
        {
            InitializeComponent();
            initConfig(sc,par1);
        }
        private void grdView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            Boolean chk = false;
            String monthId = "", yearId="", ssId="";
            FarPoint.Win.Spread.SheetView sheet1 = grdView.ActiveSheet;
            if (sheet1.SheetName.Equals("SSData"))
            {
                monthId = grdView.Sheets[0].Cells[e.Row, colMonth].Value.ToString();
                yearId = grdView.Sheets[0].Cells[e.Row, colYear].Value.ToString();
                ssId = grdView.Sheets[0].Cells[e.Row, colId].Value.ToString();
                //grdView.Sheets.Add()
                // Create a new sheet.
                foreach (FarPoint.Win.Spread.SheetView sheet in grdView.Sheets)
                {
                    if (sheet.SheetName.Equals(yearId + monthId))
                    {
                        chk = true;
                        sheet1 = sheet;
                    }
                }
                if (!chk)
                {
                    FarPoint.Win.Spread.SheetView newsheet = new FarPoint.Win.Spread.SheetView();
                    newsheet.SheetName = yearId + monthId;
                    newsheet.ColumnCount = 10;
                    newsheet.RowCount = 100;
                    // Add the new sheet to the component.
                    int index = grdView.Sheets.Add(newsheet);
                    setGrdViewHssV(index);
                    setGrdViewssV(index, ssId);
                    grdView.ActiveSheet = newsheet;
                }
                else
                {
                    grdView.ActiveSheet = sheet1;
                }
            }
            else
            {
                if(e.Column== colVBT)
                {
                    Boolean chkBT = false;
                    FarPoint.Win.Spread.SheetView sheetBT = new FarPoint.Win.Spread.SheetView();
                    foreach (FarPoint.Win.Spread.SheetView sheet in grdView.Sheets)
                    {
                        if (sheet.SheetName.Equals("BT"+yearId + monthId))
                        {
                            chkBT = true;
                            sheetBT = sheet;
                        }
                    }
                    if (!chkBT)
                    {
                        FarPoint.Win.Spread.SheetView newsheetbt = new FarPoint.Win.Spread.SheetView();
                        newsheetbt.SheetName = "BT"+yearId + monthId;
                        newsheetbt.ColumnCount = 10;
                        newsheetbt.RowCount = 100;
                        // Add the new sheet to the component.
                        int index = grdView.Sheets.Add(newsheetbt);
                        setGrdViewHssV(index);
                        setGrdViewssV(index, ssId);
                        grdView.ActiveSheet = newsheetbt;
                    }
                }
            }            
            
        }
        private void grdView_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            Boolean chk = false;
            String monthId = "", yearId = "", ssId = "";
            FarPoint.Win.Spread.SheetView sheet1 = grdView.ActiveSheet;
            if (!sheet1.SheetName.Equals("SSData"))
            {
                if (e.Column == colVBT)
                {
                    Boolean chkBT = false;
                    FarPoint.Win.Spread.SheetView sheetBT = new FarPoint.Win.Spread.SheetView();
                    foreach (FarPoint.Win.Spread.SheetView sheet in grdView.Sheets)
                    {
                        if (sheet.SheetName.Equals("BT" + yearId + monthId))
                        {
                            chkBT = true;
                            sheetBT = sheet;
                        }
                    }
                    if (!chkBT)
                    {
                        ssId = sheet1.Cells[e.Row, colBTssdId].Value.ToString();
                        FarPoint.Win.Spread.SheetView newsheetbt = new FarPoint.Win.Spread.SheetView();
                        newsheetbt.SheetName = "BT" + yearId + monthId;
                        newsheetbt.ColumnCount = 10;
                        newsheetbt.RowCount = 100;
                        // Add the new sheet to the component.
                        int index = grdView.Sheets.Add(newsheetbt);
                        setGrdViewHBT(index);
                        setGrdViewssV(index, ssId);
                        grdView.ActiveSheet = newsheetbt;
                    }
                }
            }
        }
        private void initConfig(SSDataControl sc, Form par1)
        {
            sC = sc;
            par = par1;
            monthId = sc.monthId;
            yearId = sc.yearId;
            setGrdView();
        }
        private void setGrdViewHssV(int index)
        {
            FarPoint.Win.Spread.CellType.TextCellType objTextCell = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttencell = new FarPoint.Win.Spread.CellType.ButtonCellType();

            grdView.Sheets[index].AutoFilterMode = FarPoint.Win.Spread.AutoFilterMode.EnhancedContextMenu;
            grdView.Sheets[index].ColumnCount = colVCnt;
            grdView.Sheets[index].RowCount = 1;

            grdView.Sheets[index].Columns[colVId].Width = 50;
            grdView.Sheets[index].Columns[colVssdId].Width = 50;
            grdView.Sheets[index].Columns[colVBT].Width = 50;
            grdView.Sheets[index].Columns[colVBTi].Width = 50;
            grdView.Sheets[index].Columns[colVBD].Width = 50;
            grdView.Sheets[index].Columns[colBDi].Width = 60;
            grdView.Sheets[index].Columns[colVOPs].Width = 50;
            grdView.Sheets[index].Columns[colVOPDx].Width = 50;
            grdView.Sheets[index].Columns[colVHn].Width = 250;
            grdView.Sheets[index].Columns[colVVn].Width = 250;
            grdView.Sheets[index].Columns[colVVisitDate].Width = 250;            
            grdView.Sheets[index].Columns[colVName].Width = 250;

            grdView.Sheets[index].Columns[colVId].CellType = objTextCell;
            grdView.Sheets[index].Columns[colVssdId].CellType = objTextCell;
            grdView.Sheets[index].Columns[colVBT].CellType = buttencell;
            grdView.Sheets[index].Columns[colVBTi].CellType = buttencell;
            grdView.Sheets[index].Columns[colVBD].CellType = buttencell;
            grdView.Sheets[index].Columns[colBDi].CellType = buttencell;
            grdView.Sheets[index].Columns[colVOPs].CellType = buttencell;
            grdView.Sheets[index].Columns[colVOPDx].CellType = buttencell;
            grdView.Sheets[index].Columns[colVHn].CellType = objTextCell;
            grdView.Sheets[index].Columns[colVVn].CellType = objTextCell;
            grdView.Sheets[index].Columns[colVVisitDate].CellType = objTextCell;
            
            grdView.Sheets[index].Columns[colVName].CellType = objTextCell;

            grdView.Sheets[index].ColumnHeader.Cells[0, colVId].Text = "id";
            grdView.Sheets[index].ColumnHeader.Cells[0, colVssdId].Text = "ssdid";
            grdView.Sheets[index].ColumnHeader.Cells[0, colVBT].Text = "BillTran";
            grdView.Sheets[index].ColumnHeader.Cells[0, colVBTi].Text = "BillItems";
            grdView.Sheets[index].ColumnHeader.Cells[0, colVBD].Text = "BillDisp";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBDi].Text = "DispItems";
            grdView.Sheets[index].ColumnHeader.Cells[0, colVOPs].Text = "OPs";
            grdView.Sheets[index].ColumnHeader.Cells[0, colVOPDx].Text = "OPDx";
            grdView.Sheets[index].ColumnHeader.Cells[0, colVHn].Text = "HN";
            grdView.Sheets[index].ColumnHeader.Cells[0, colVVn].Text = "VN";
            grdView.Sheets[index].ColumnHeader.Cells[0, colVVisitDate].Text = "Visit Date";            
            grdView.Sheets[index].ColumnHeader.Cells[0, colVName].Text = "Patient Name";

            grdView.Sheets[index].Columns[colVId].Visible = false;
            grdView.Sheets[index].Columns[colVssdId].Visible = false;
        }
        private void setGrdViewHBT(int index)
        {
            FarPoint.Win.Spread.CellType.TextCellType objTextCell = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttencell = new FarPoint.Win.Spread.CellType.ButtonCellType();

            grdView.Sheets[index].AutoFilterMode = FarPoint.Win.Spread.AutoFilterMode.EnhancedContextMenu;
            grdView.Sheets[index].ColumnCount = colBTCnt;
            grdView.Sheets[index].RowCount = 1;

            grdView.Sheets[index].Columns[colBTId].Width = 50;
            grdView.Sheets[index].Columns[colBTssdId].Width = 50;
            grdView.Sheets[index].Columns[colBTssvId].Width = 50;
            grdView.Sheets[index].Columns[colBTBi].Width = 50;
            grdView.Sheets[index].Columns[colBTE].Width = 50;
            grdView.Sheets[index].Columns[colBTS].Width = 60;
            grdView.Sheets[index].Columns[colBTstation].Width = 50;
            grdView.Sheets[index].Columns[colBTauthcode].Width = 50;
            grdView.Sheets[index].Columns[colBTdttran].Width = 250;
            grdView.Sheets[index].Columns[colBThcode].Width = 250;
            grdView.Sheets[index].Columns[colBTinvno].Width = 250;
            grdView.Sheets[index].Columns[colBTbillno].Width = 250;

            grdView.Sheets[index].Columns[colBThn].Width = 250;
            grdView.Sheets[index].Columns[colBTmemberno].Width = 250;
            grdView.Sheets[index].Columns[colBTamount].Width = 250;
            grdView.Sheets[index].Columns[colBTpaid].Width = 250;
            grdView.Sheets[index].Columns[colBTvercode].Width = 250;
            grdView.Sheets[index].Columns[colBTtflag].Width = 250;
            grdView.Sheets[index].Columns[colBTpid].Width = 250;
            grdView.Sheets[index].Columns[colBTname].Width = 250;
            grdView.Sheets[index].Columns[colBThmain].Width = 250;
            grdView.Sheets[index].Columns[colBTpayplan].Width = 250;
            grdView.Sheets[index].Columns[colBTclaimamt].Width = 250;
            grdView.Sheets[index].Columns[colBTotherpayplan].Width = 250;
            grdView.Sheets[index].Columns[colBTotherpay].Width = 250;
            //grdView.Sheets[index].Columns[colBTbillno].Width = 250;



            grdView.Sheets[index].Columns[colBTId].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBTssdId].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBTssvId].CellType = objTextCell;

            grdView.Sheets[index].Columns[colBTBi].CellType = buttencell;
            grdView.Sheets[index].Columns[colBTE].CellType = buttencell;
            grdView.Sheets[index].Columns[colBTS].CellType = buttencell;

            grdView.Sheets[index].Columns[colBTstation].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBTauthcode].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBTdttran].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBThcode].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBTinvno].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBTbillno].CellType = objTextCell;

            grdView.Sheets[index].Columns[colBThn].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBTmemberno].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBTamount].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBTpaid].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBTvercode].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBTtflag].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBTpid].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBTname].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBThmain].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBTpayplan].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBTclaimamt].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBTotherpayplan].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBTotherpay].CellType = objTextCell;


            grdView.Sheets[index].ColumnHeader.Cells[0, colBTBi].Text = "items";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBTE].Text = "edit";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBTS].Text = "save";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBTstation].Text = "station";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBTauthcode].Text = "authencode";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBTdttran].Text = "dttran";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBThcode].Text = "hcode";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBTinvno].Text = "invno";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBTbillno].Text = "billno";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBThn].Text = "hn";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBTmemberno].Text = "memberno";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBTamount].Text = "amount";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBTpaid].Text = "paid";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBTvercode].Text = "vercode";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBTtflag].Text = "tflag";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBTname].Text = "name";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBThmain].Text = "hmain";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBTpayplan].Text = "payplan";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBTclaimamt].Text = "claimplan";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBTotherpayplan].Text = "otherpayplan";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBTotherpay].Text = "otherpay";

            grdView.Sheets[index].Columns[colBTId].Visible = false;
            grdView.Sheets[index].Columns[colBTssdId].Visible = false;
            grdView.Sheets[index].Columns[colBTssvId].Visible = false;
        }
        private void setGrdViewH()
        {
            FarPoint.Win.Spread.EnhancedInterfaceRenderer outlinelook = new FarPoint.Win.Spread.EnhancedInterfaceRenderer();
            outlinelook.RangeGroupBackgroundColor = Color.LightGreen;
            outlinelook.RangeGroupButtonBorderColor = Color.Red;
            outlinelook.RangeGroupLineColor = Color.Blue;
            grdView.InterfaceRenderer = outlinelook;

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
            grdView.Sheets[0].Columns[colId].Width = 250;
            grdView.Sheets[0].Columns[colYear].CellType = objTextCell;
            grdView.Sheets[0].Columns[colMonth].CellType = objTextCell;
            grdView.Sheets[0].Columns[colBranchId].CellType = objTextCell;
            grdView.Sheets[0].Columns[colCntHn].CellType = objTextCell;
            grdView.Sheets[0].Columns[colCntVisit].CellType = objTextCell;
            grdView.Sheets[0].Columns[colStatusProcess].CellType = objTextCell;
            grdView.Sheets[0].Columns[colDateStart].CellType = objTextCell;
            grdView.Sheets[0].Columns[colDateEnd].CellType = objTextCell;
            //grdView.Sheets[0].Columns[colCntHn].CellType = objTextCell;

            grdView.Sheets[0].Columns[colId].Visible = false;

            grdView.Sheets[0].SheetName = "SSData";

            grdView.Sheets[0].Columns[colYear].Width = 120;
            grdView.Sheets[0].Columns[colMonth].Width = 120;
            grdView.Sheets[0].Columns[colBranchId].Width = 80;
            grdView.Sheets[0].Columns[colCntHn].Width = 80;
            grdView.Sheets[0].Columns[colCntVisit].Width = 250;
            grdView.Sheets[0].Columns[colStatusProcess].Width = 250;
            grdView.Sheets[0].Columns[colDateStart].Width = 80;
            grdView.Sheets[0].Columns[colDateEnd].Width = 250;
            //grdView.Sheets[0].Columns[colStr].Width = 250;
            //grdView.Sheets[0].Columns[colCont].Width = 250;

            grdView.Sheets[0].ColumnHeader.Cells[0, colYear].Text = "Year";
            grdView.Sheets[0].ColumnHeader.Cells[0, colMonth].Text = "Month";
            grdView.Sheets[0].ColumnHeader.Cells[0, colBranchId].Text = "Branch";
            grdView.Sheets[0].ColumnHeader.Cells[0, colCntHn].Text = "cnt HN";
            grdView.Sheets[0].ColumnHeader.Cells[0, colCntVisit].Text = "cnt Visit";
            grdView.Sheets[0].ColumnHeader.Cells[0, colStatusProcess].Text = "status";
            grdView.Sheets[0].ColumnHeader.Cells[0, colDateStart].Text = "Start";
            grdView.Sheets[0].ColumnHeader.Cells[0, colDateEnd].Text = "End";

            grdView.Sheets[0].RestrictRows = true;


        }
        private void setGrdView()
        {
            DataTable dt = new DataTable();
            int i = 0;
            dt = sC.mHisDB.ssdDB.selectAll();
            grdView.Sheets[0].Rows.Clear();
            setGrdViewH();
            grdView.Sheets[0].RowCount = dt.Rows.Count;
            foreach (DataRow row in dt.Rows)
            {

                grdView.Sheets[0].Cells[i, colYear].Value = row[sC.mHisDB.ssdDB.ssd.year_id].ToString();
                grdView.Sheets[0].Cells[i, colMonth].Value = row[sC.mHisDB.ssdDB.ssd.month_id].ToString();
                grdView.Sheets[0].Cells[i, colBranchId].Value = row[sC.mHisDB.ssdDB.ssd.branch_id].ToString();
                grdView.Sheets[0].Cells[i, colCntHn].Value = row[sC.mHisDB.ssdDB.ssd.cnt_hn].ToString();
                grdView.Sheets[0].Cells[i, colCntVisit].Value = row[sC.mHisDB.ssdDB.ssd.cnt_visit].ToString();
                grdView.Sheets[0].Cells[i, colStatusProcess].Value = row[sC.mHisDB.ssdDB.ssd.status_precess].ToString();
                grdView.Sheets[0].Cells[i, colDateStart].Value = row[sC.mHisDB.ssdDB.ssd.date_start].ToString();
                grdView.Sheets[0].Cells[i, colDateEnd].Value = row[sC.mHisDB.ssdDB.ssd.date_end].ToString();
                grdView.Sheets[0].Cells[i, colId].Value = row[sC.mHisDB.ssdDB.ssd.ssdata_id].ToString();
                i++;
            }
        }
        private void setGrdViewssV(int index, String ssDid)
        {
            DataTable dt = new DataTable();
            int i = 0;
            dt = sC.mHisDB.ssdVDB.selectByssDId(ssDid);
            grdView.Sheets[index].Rows.Clear();
            //setGrdViewH();
            grdView.Sheets[index].RowCount = dt.Rows.Count;
            foreach (DataRow row in dt.Rows)
            {

                grdView.Sheets[index].Cells[i, colVId].Value = row[sC.mHisDB.ssdVDB.ssdV.ssdata_visit_id].ToString();
                grdView.Sheets[index].Cells[i, colVssdId].Value = row[sC.mHisDB.ssdVDB.ssdV.ssdata_id].ToString();
                grdView.Sheets[index].Cells[i, colVHn].Value = row[sC.mHisDB.ssdVDB.ssdV.hn_no].ToString();
                grdView.Sheets[index].Cells[i, colVVn].Value = row[sC.mHisDB.ssdVDB.ssdV.vn].ToString();
                grdView.Sheets[index].Cells[i, colVVisitDate].Value = row[sC.mHisDB.ssdVDB.ssdV.visit_date].ToString()+" "+ row[sC.mHisDB.ssdVDB.ssdV.visit_time].ToString();
                grdView.Sheets[index].Cells[i, colVName].Value = row[sC.mHisDB.ssdVDB.ssdV.prefix].ToString()+" "+row[sC.mHisDB.ssdVDB.ssdV.patient_fname].ToString()+" "+ row[sC.mHisDB.ssdVDB.ssdV.patient_lname].ToString();
                
                i++;
            }
        }
        private void setGrdViewBT(int index, String ssDid)
        {
            DataTable dt = new DataTable();
            int i = 0;
            dt = sC.mHisDB.btDB.selectByssvID(ssDid);
            grdView.Sheets[index].Rows.Clear();
            //setGrdViewH();
            grdView.Sheets[index].RowCount = dt.Rows.Count;
            foreach (DataRow row in dt.Rows)
            {

                grdView.Sheets[index].Cells[i, colBTinvno].Value = row[sC.mHisDB.btDB.bt.invno].ToString();
                //grdView.Sheets[index].Cells[i, colVssdId].Value = row[sC.mHisDB.btDB.bt.ssdata_id].ToString();
                //grdView.Sheets[index].Cells[i, colVHn].Value = row[sC.mHisDB.btDB.bt.hn_no].ToString();
                //grdView.Sheets[index].Cells[i, colVVn].Value = row[sC.mHisDB.btDB.bt.vn].ToString();
                //grdView.Sheets[index].Cells[i, colVVisitDate].Value = row[sC.mHisDB.btDB.bt.visit_date].ToString() + " " + row[sC.mHisDB.ssdVDB.ssdV.visit_time].ToString();
                //grdView.Sheets[index].Cells[i, colVName].Value = row[sC.mHisDB.btDB.bt.prefix].ToString() + " " + row[sC.mHisDB.ssdVDB.ssdV.patient_fname].ToString() + " " + row[sC.mHisDB.ssdVDB.ssdV.patient_lname].ToString();

                i++;
            }
        }
        private void setResize()
        {
            grdView.Width = this.Width - 50;
            grdView.Height = this.Height - 180;
            //groupBox1.Width = this.Width - 50;
            //pB1.Width = this.Width - 900;
        }

        private void FrmSSDataView_Load(object sender, EventArgs e)
        {

        }

        private void FrmSSDataView_FormClosing(object sender, FormClosingEventArgs e)
        {
            par.Show();
        }

        private void FrmSSDataView_Resize(object sender, EventArgs e)
        {
            setResize();
        }
    }
}
