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

        int colVId = 0, colVssdId = 1, colVBT = 2, colVBTi = 3, colVBD = 4, colVBDi = 5, colVOPs = 6, colVOPDx=7;
        int colVHn = 8, colVVn = 9, colVVisitDate = 10, colVName = 11;
        int colVCnt = 12;

        int colBTId = 0, colBTSheetName=1, colBTssdId = 2, colBTssvId = 3, colBTBi=4, colBTE=5, colBTS=6, colBTstation = 7, colBTauthcode = 8, colBTdttran = 9, colBThcode = 10;
        int colBTinvno = 11, colBTbillno = 12, colBThn = 13, colBTmemberno = 14, colBTamount = 15, colBTpaid = 16, colBTvercode = 17;
        int colBTtflag = 18, colBTpid = 19, colBTname = 20, colBThmain = 21, colBTpayplan = 22, colBTclaimamt = 23, colBTotherpayplan = 24;
        int colBTotherpay = 25, colBTCnt = 26;

        int colBDId = 0, colBDSheetName=1, colBDssdId = 2, colBDssvId = 3, colBDi=4, colBDE = 5, colBDS = 6, colBDproviderid = 7, colBDdispid = 8, colBDinvno = 9, colBDhn = 10;
        int colBDpid = 11, colBDprescdt = 12, colBDdispdt = 13, colBDprescb = 14, colBDitemcnt = 15, colBDchargeamt = 16, colBDclaimamt=17, colBDpaid = 18, colBDotherpay = 19;
        int colBDreimburser = 20, colBDbenefitplan = 21, colBDdispestat = 22, colBDsvid = 23, colBDdaycover = 24;
        int colBDCnt = 25;

        int colOPsId = 0, colOPsSheetName=1, colOPsssdId = 2, colOPsssvId = 3, colOPsI = 4, colOPsE = 5, colOPsS = 6, colOPsinvno = 7, colOPssvid = 8, colOPsclass1 = 9;
        int colOPshcode = 10, colOPshn = 11, colOPspid = 12, colOPscareaccount = 13, colOPstypeserv = 14, colOPstypein = 15, colOPstypeout = 16;
        int colOPsdtappoint = 17, colOPssvpid = 18, colclinic = 19, colOPsdegdt = 20, colOPsenddt = 21, colOPslccode = 22, colOPscodeset = 23;
        int colOPsstdcode = 24, colOPssvcharge = 25, colOPscompletion = 26, colOPssvtxcode = 27, colOPsclaimcat = 28;
        int colOPsCnt = 29;

        public FrmSSDataView(SSDataControl sc, Form par1)
        {
            InitializeComponent();
            initConfig(sc,par1);
        }
        private void grdView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            Boolean chk = false, chkBT = false, chkBD = false, chkOPs = false;
            String monthId = "", yearId="", ssId="";
            FarPoint.Win.Spread.SheetView sheet1 = grdView.ActiveSheet;
            if (sheet1.SheetName.Equals("SSData"))
            {
                //  add sheet visit
                monthId = grdView.Sheets[0].Cells[e.Row, colMonth].Value.ToString();
                yearId = grdView.Sheets[0].Cells[e.Row, colYear].Value.ToString();
                ssId = grdView.Sheets[0].Cells[e.Row, colId].Value.ToString();
                //grdView.Sheets.Add()
                // Create a new sheet.
                foreach (FarPoint.Win.Spread.SheetView sheet in grdView.Sheets)
                {
                    if (sheet.SheetName.Equals("visit" + yearId + monthId))
                    {
                        chk = true;
                        sheet1 = sheet;
                    }
                }
                if (!chk)
                {
                    FarPoint.Win.Spread.SheetView newsheet = new FarPoint.Win.Spread.SheetView();
                    newsheet.SheetName = "visit"+yearId + monthId;
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

                //  add sheet BT
                foreach (FarPoint.Win.Spread.SheetView sheet in grdView.Sheets)
                {
                    if (sheet.SheetName.Equals("BT" + yearId + monthId))
                    {
                        chkBT = true;
                        sheet1 = sheet;
                    }
                }
                if (!chkBT)
                {
                    FarPoint.Win.Spread.SheetView newsheet = new FarPoint.Win.Spread.SheetView();
                    newsheet.SheetName = "BT" + yearId + monthId;
                    newsheet.ColumnCount = 10;
                    newsheet.RowCount = 100;
                    // Add the new sheet to the component.
                    int index = grdView.Sheets.Add(newsheet);
                    setGrdViewHBT(index);
                    setGrdViewBT(index, ssId);
                    grdView.ActiveSheet = newsheet;
                }

                //  add sheet BD
                foreach (FarPoint.Win.Spread.SheetView sheet in grdView.Sheets)
                {
                    if (sheet.SheetName.Equals("BD" + yearId + monthId))
                    {
                        chkBD = true;
                        sheet1 = sheet;
                    }
                }
                if (!chkBD)
                {
                    FarPoint.Win.Spread.SheetView newsheet = new FarPoint.Win.Spread.SheetView();
                    newsheet.SheetName = "BD" + yearId + monthId;
                    newsheet.ColumnCount = 10;
                    newsheet.RowCount = 100;
                    // Add the new sheet to the component.
                    int index = grdView.Sheets.Add(newsheet);
                    setGrdViewHBD(index);
                    setGrdViewBD(index, ssId);
                    grdView.ActiveSheet = newsheet;
                }

                //  add sheet BD
                foreach (FarPoint.Win.Spread.SheetView sheet in grdView.Sheets)
                {
                    if (sheet.SheetName.Equals("OPs" + yearId + monthId))
                    {
                        chkOPs = true;
                        sheet1 = sheet;
                    }
                }
                if (!chkOPs)
                {
                    FarPoint.Win.Spread.SheetView newsheet = new FarPoint.Win.Spread.SheetView();
                    newsheet.SheetName = "OPs" + yearId + monthId;
                    newsheet.ColumnCount = 10;
                    newsheet.RowCount = 100;
                    // Add the new sheet to the component.
                    int index = grdView.Sheets.Add(newsheet);
                    setGrdViewHOPs(index);
                    setGrdViewOPs(index, ssId);
                    grdView.ActiveSheet = newsheet;
                }
            }
            else
            {
                String sh = "";
                sh = grdView.ActiveSheet.Cells[e.Row, 1].Value.ToString();
                if (sh.Equals("BT"))
                {
                    sC.btID = "";
                    sC.btID = grdView.ActiveSheet.Cells[e.Row, colBTId].Value.ToString();
                    if (!sC.btID.Equals(""))
                    {
                        FrmSSDataBT frm = new FrmSSDataBT(sC);
                        frm.ShowDialog(this);
                    }
                    else
                    {
                        MessageBox.Show("ไม่พบ primary key", "");
                    }
                    
                }
                else if (sh.Equals("BD"))
                {
                    sC.bdID = "";
                    sC.bdID = grdView.ActiveSheet.Cells[e.Row, colBDId].Value.ToString();
                    FrmSSDataBD frm = new FrmSSDataBD(sC);
                    frm.ShowDialog(this);
                }
                else if (sh.Equals("OPs"))
                {
                    sC.opsID = "";
                    sC.opsID = grdView.ActiveSheet.Cells[e.Row, colOPsId].Value.ToString();
                    FrmSSDataOPDx frm = new FrmSSDataOPDx(sC);
                    frm.ShowDialog(this);
                }
            }
        }
        private void grdView_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {

            //Boolean chk = false;
            //String monthId = "", yearId = "", ssId = "";
            FarPoint.Win.Spread.SheetView sheet1 = grdView.ActiveSheet;
            if (sheet1.SheetName.Equals("SSData"))
            {
                //    if (e.Column == colVBT)
                //    {
                //        Boolean chkBT = false;
                //        FarPoint.Win.Spread.SheetView sheetBT = new FarPoint.Win.Spread.SheetView();
                //        foreach (FarPoint.Win.Spread.SheetView sheet in grdView.Sheets)
                //        {
                //            if (sheet.SheetName.Equals("BT" + yearId + monthId))
                //            {
                //                chkBT = true;
                //                sheetBT = sheet;
                //            }
                //        }
                //        if (!chkBT)
                //        {
                //            ssId = sheet1.Cells[e.Row, colVssdId].Value.ToString();
                //            FarPoint.Win.Spread.SheetView newsheetbt = new FarPoint.Win.Spread.SheetView();
                //            newsheetbt.SheetName = "BT" + yearId + monthId;
                //            newsheetbt.ColumnCount = 10;
                //            newsheetbt.RowCount = 100;
                //            // Add the new sheet to the component.
                //            int index = grdView.Sheets.Add(newsheetbt);
                //            setGrdViewHBT(index);
                //            setGrdViewBT(index, ssId);
                //            grdView.ActiveSheet = newsheetbt;
                //        }
                //    }
            }
            else
            {
                String sh = "";
                sh = grdView.ActiveSheet.Cells[e.Row, 1].Value.ToString();
                if (sh.Equals("BT"))
                {
                    int col = e.Column;
                    if (col == colBTBi)
                    {
                        sC.btID = grdView.ActiveSheet.Cells[e.Row, colBTId].Value.ToString();
                        FrmSSDataBTi frm = new FrmSSDataBTi(sC);
                        frm.ShowDialog(this);
                    }
                }
                else if (sh.Equals("BD"))
                {
                    int col = e.Column;
                    if (col == colBDi)
                    {
                        sC.bdID = grdView.ActiveSheet.Cells[e.Row, colBDId].Value.ToString();
                        FrmSSDataBDi frm = new FrmSSDataBDi(sC);
                        frm.ShowDialog(this);
                    }
                }
                else if (sh.Equals("OPs"))
                {
                    int col = e.Column;
                    if (col == colOPsI)
                    {
                        sC.opsID = grdView.ActiveSheet.Cells[e.Row, colOPsId].Value.ToString();
                        FrmSSDataOPs frm = new FrmSSDataOPs(sC);
                        frm.ShowDialog(this);
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
            grdView.Sheets[index].OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;

            grdView.Sheets[index].Columns[colVId].Width = 50;
            grdView.Sheets[index].Columns[colVssdId].Width = 50;
            grdView.Sheets[index].Columns[colVBT].Width = 50;
            grdView.Sheets[index].Columns[colVBTi].Width = 50;
            grdView.Sheets[index].Columns[colVBD].Width = 50;
            grdView.Sheets[index].Columns[colVBDi].Width = 60;
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
            grdView.Sheets[index].Columns[colVBDi].CellType = buttencell;
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
            grdView.Sheets[index].ColumnHeader.Cells[0, colVBDi].Text = "DispItems";
            grdView.Sheets[index].ColumnHeader.Cells[0, colVOPs].Text = "OPs";
            grdView.Sheets[index].ColumnHeader.Cells[0, colVOPDx].Text = "OPDx";
            grdView.Sheets[index].ColumnHeader.Cells[0, colVHn].Text = "HN";
            grdView.Sheets[index].ColumnHeader.Cells[0, colVVn].Text = "VN";
            grdView.Sheets[index].ColumnHeader.Cells[0, colVVisitDate].Text = "Visit Date";            
            grdView.Sheets[index].ColumnHeader.Cells[0, colVName].Text = "Patient Name";

            grdView.Sheets[index].Columns[colVId].Visible = false;
            grdView.Sheets[index].Columns[colVssdId].Visible = false;

            grdView.Sheets[index].Columns[colVBT].Visible = false;
            grdView.Sheets[index].Columns[colVBTi].Visible = false;
            grdView.Sheets[index].Columns[colVBD].Visible = false;
            grdView.Sheets[index].Columns[colVBDi].Visible = false;
            grdView.Sheets[index].Columns[colVOPs].Visible = false;
            grdView.Sheets[index].Columns[colVOPDx].Visible = false;
        }
        private void setGrdViewHOPs(int index)
        {
            FarPoint.Win.Spread.CellType.TextCellType objTextCell = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttencell = new FarPoint.Win.Spread.CellType.ButtonCellType();

            grdView.Sheets[index].AutoFilterMode = FarPoint.Win.Spread.AutoFilterMode.EnhancedContextMenu;
            grdView.Sheets[index].ColumnCount = colOPsCnt;
            grdView.Sheets[index].RowCount = 1;
            grdView.Sheets[index].OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;

            grdView.Sheets[index].Columns[colOPsId].Width = 50;
            grdView.Sheets[index].Columns[colOPsssdId].Width = 50;
            grdView.Sheets[index].Columns[colOPsssvId].Width = 50;
            grdView.Sheets[index].Columns[colOPsI].Width = 50;
            grdView.Sheets[index].Columns[colOPsE].Width = 50;
            grdView.Sheets[index].Columns[colOPsS].Width = 50;
            grdView.Sheets[index].Columns[colOPsinvno].Width = 50;
            grdView.Sheets[index].Columns[colOPssvid].Width = 50;
            grdView.Sheets[index].Columns[colOPsclass1].Width = 50;
            grdView.Sheets[index].Columns[colOPshcode].Width = 50;

            grdView.Sheets[index].Columns[colOPshn].Width = 50;
            grdView.Sheets[index].Columns[colOPspid].Width = 50;
            grdView.Sheets[index].Columns[colOPscareaccount].Width = 50;
            grdView.Sheets[index].Columns[colOPstypeserv].Width = 50;
            grdView.Sheets[index].Columns[colOPstypein].Width = 50;
            grdView.Sheets[index].Columns[colOPstypeout].Width = 50;
            grdView.Sheets[index].Columns[colOPsdtappoint].Width = 50;
            grdView.Sheets[index].Columns[colOPssvpid].Width = 50;
            grdView.Sheets[index].Columns[colclinic].Width = 50;
            grdView.Sheets[index].Columns[colOPsdegdt].Width = 50;

            grdView.Sheets[index].Columns[colOPsenddt].Width = 50;
            grdView.Sheets[index].Columns[colOPslccode].Width = 50;
            grdView.Sheets[index].Columns[colOPscodeset].Width = 50;
            grdView.Sheets[index].Columns[colOPsstdcode].Width = 50;
            grdView.Sheets[index].Columns[colOPssvcharge].Width = 50;
            grdView.Sheets[index].Columns[colOPscompletion].Width = 50;
            grdView.Sheets[index].Columns[colOPssvtxcode].Width = 50;
            grdView.Sheets[index].Columns[colOPsclaimcat].Width = 50;
            //grdView.Sheets[index].Columns[colBDId].Width = 50;
            //grdView.Sheets[index].Columns[colBDId].Width = 50;

            grdView.Sheets[index].Columns[colOPsId].CellType = objTextCell;
            grdView.Sheets[index].Columns[colOPsssdId].CellType = objTextCell;
            grdView.Sheets[index].Columns[colOPsssvId].CellType = objTextCell;
            grdView.Sheets[index].Columns[colOPsI].CellType = buttencell;
            grdView.Sheets[index].Columns[colOPsE].CellType = buttencell;
            grdView.Sheets[index].Columns[colOPsS].CellType = buttencell;
            grdView.Sheets[index].Columns[colOPsinvno].CellType = objTextCell;
            grdView.Sheets[index].Columns[colOPssvid].CellType = objTextCell;
            grdView.Sheets[index].Columns[colOPsclass1].CellType = objTextCell;
            grdView.Sheets[index].Columns[colOPshcode].CellType = objTextCell;

            grdView.Sheets[index].Columns[colOPshn].CellType = objTextCell;
            grdView.Sheets[index].Columns[colOPspid].CellType = objTextCell;
            grdView.Sheets[index].Columns[colOPscareaccount].CellType = objTextCell;
            grdView.Sheets[index].Columns[colOPstypeserv].CellType = objTextCell;
            grdView.Sheets[index].Columns[colOPstypein].CellType = objTextCell;
            grdView.Sheets[index].Columns[colOPstypeout].CellType = objTextCell;
            grdView.Sheets[index].Columns[colOPsdtappoint].CellType = objTextCell;
            grdView.Sheets[index].Columns[colOPssvpid].CellType = objTextCell;
            grdView.Sheets[index].Columns[colclinic].CellType = objTextCell;
            grdView.Sheets[index].Columns[colOPsdegdt].CellType = objTextCell;

            grdView.Sheets[index].Columns[colOPsenddt].CellType = objTextCell;
            grdView.Sheets[index].Columns[colOPslccode].CellType = objTextCell;
            grdView.Sheets[index].Columns[colOPscodeset].CellType = objTextCell;
            grdView.Sheets[index].Columns[colOPsstdcode].CellType = objTextCell;
            grdView.Sheets[index].Columns[colOPssvcharge].CellType = objTextCell;
            grdView.Sheets[index].Columns[colOPscompletion].CellType = objTextCell;
            grdView.Sheets[index].Columns[colOPssvtxcode].CellType = objTextCell;
            grdView.Sheets[index].Columns[colOPsclaimcat].CellType = objTextCell;
            //grdView.Sheets[index].Columns[colBDId].CellType = objTextCell;

            grdView.Sheets[index].ColumnHeader.Cells[0, colOPsId].Text = "id";
            grdView.Sheets[index].ColumnHeader.Cells[0, colOPsssdId].Text = "ssdip";
            grdView.Sheets[index].ColumnHeader.Cells[0, colOPsssvId].Text = "ssvid";
            grdView.Sheets[index].ColumnHeader.Cells[0, colOPsI].Text = "items";
            grdView.Sheets[index].ColumnHeader.Cells[0, colOPsE].Text = "Edit";
            grdView.Sheets[index].ColumnHeader.Cells[0, colOPsS].Text = "Save";
            grdView.Sheets[index].ColumnHeader.Cells[0, colOPsinvno].Text = "invno";
            grdView.Sheets[index].ColumnHeader.Cells[0, colOPssvid].Text = "svid";
            grdView.Sheets[index].ColumnHeader.Cells[0, colOPsclass1].Text = "class";
            grdView.Sheets[index].ColumnHeader.Cells[0, colOPshcode].Text = "hcode";

            grdView.Sheets[index].ColumnHeader.Cells[0, colOPshn].Text = "hn";
            grdView.Sheets[index].ColumnHeader.Cells[0, colOPspid].Text = "pid";
            grdView.Sheets[index].ColumnHeader.Cells[0, colOPscareaccount].Text = "careaccount";
            grdView.Sheets[index].ColumnHeader.Cells[0, colOPstypeserv].Text = "typeserv";
            grdView.Sheets[index].ColumnHeader.Cells[0, colOPstypein].Text = "typein";
            grdView.Sheets[index].ColumnHeader.Cells[0, colOPstypeout].Text = "typeout";
            grdView.Sheets[index].ColumnHeader.Cells[0, colOPsdtappoint].Text = "dtappoint";
            grdView.Sheets[index].ColumnHeader.Cells[0, colOPssvpid].Text = "svpid";
            grdView.Sheets[index].ColumnHeader.Cells[0, colclinic].Text = "clinic";
            grdView.Sheets[index].ColumnHeader.Cells[0, colOPsdegdt].Text = "degdt";

            grdView.Sheets[index].ColumnHeader.Cells[0, colOPsenddt].Text = "enddt";
            grdView.Sheets[index].ColumnHeader.Cells[0, colOPslccode].Text = "lccode";
            grdView.Sheets[index].ColumnHeader.Cells[0, colOPscodeset].Text = "codeset";
            grdView.Sheets[index].ColumnHeader.Cells[0, colOPsstdcode].Text = "stdcode";
            grdView.Sheets[index].ColumnHeader.Cells[0, colOPssvcharge].Text = "svcharge";
            grdView.Sheets[index].ColumnHeader.Cells[0, colOPscompletion].Text = "completion";
            grdView.Sheets[index].ColumnHeader.Cells[0, colOPssvtxcode].Text = "svtxcode";
            grdView.Sheets[index].ColumnHeader.Cells[0, colOPsclaimcat].Text = "claimcat";

            grdView.Sheets[index].Columns[colOPsId].Visible = false;
            grdView.Sheets[index].Columns[colOPsssdId].Visible = false;
            grdView.Sheets[index].Columns[colOPsssvId].Visible = false;
            grdView.Sheets[index].Columns[colOPsSheetName].Visible = false;

        }
        private void setGrdViewHBD(int index)
        {
            FarPoint.Win.Spread.CellType.TextCellType objTextCell = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttencell = new FarPoint.Win.Spread.CellType.ButtonCellType();

            grdView.Sheets[index].AutoFilterMode = FarPoint.Win.Spread.AutoFilterMode.EnhancedContextMenu;
            grdView.Sheets[index].ColumnCount = colBDCnt;
            grdView.Sheets[index].RowCount = 1;
            grdView.Sheets[index].OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;

            grdView.Sheets[index].Columns[colBDId].Width = 50;
            grdView.Sheets[index].Columns[colBDssdId].Width = 50;
            grdView.Sheets[index].Columns[colBDssvId].Width = 50;
            grdView.Sheets[index].Columns[colBDE].Width = 50;
            grdView.Sheets[index].Columns[colBDS].Width = 50;

            grdView.Sheets[index].Columns[colBDproviderid].Width = 60;
            grdView.Sheets[index].Columns[colBDdispid].Width = 50;
            grdView.Sheets[index].Columns[colBDinvno].Width = 90;
            grdView.Sheets[index].Columns[colBDhn].Width = 50;
            grdView.Sheets[index].Columns[colBDpid].Width = 90;

            grdView.Sheets[index].Columns[colBDprescdt].Width = 120;
            grdView.Sheets[index].Columns[colBDdispdt].Width = 120;
            grdView.Sheets[index].Columns[colBDprescb].Width = 50;
            grdView.Sheets[index].Columns[colBDitemcnt].Width = 50;
            grdView.Sheets[index].Columns[colBDchargeamt].Width = 70;

            grdView.Sheets[index].Columns[colBDclaimamt].Width = 70;
            grdView.Sheets[index].Columns[colBDpaid].Width = 50;
            grdView.Sheets[index].Columns[colBDotherpay].Width = 50;
            grdView.Sheets[index].Columns[colBDreimburser].Width = 70;
            grdView.Sheets[index].Columns[colBDbenefitplan].Width = 70;
            grdView.Sheets[index].Columns[colBDhn].Width = 70;
            grdView.Sheets[index].Columns[colBDdispestat].Width = 70;
            grdView.Sheets[index].Columns[colBDsvid].Width = 50;
            grdView.Sheets[index].Columns[colBDdaycover].Width = 70;

            grdView.Sheets[index].Columns[colBDId].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBDssdId].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBDssvId].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBDE].CellType = buttencell;
            grdView.Sheets[index].Columns[colBDS].CellType = buttencell;
            grdView.Sheets[index].Columns[colBDi].CellType = buttencell;
            grdView.Sheets[index].Columns[colBDproviderid].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBDdispid].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBDinvno].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBDpid].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBDprescdt].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBDprescb].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBDitemcnt].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBDchargeamt].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBDclaimamt].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBDpaid].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBDotherpay].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBDreimburser].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBDbenefitplan].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBDdispestat].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBDsvid].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBDdaycover].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBDhn].CellType = objTextCell;
            grdView.Sheets[index].Columns[colBDdispdt].CellType = objTextCell;

            grdView.Sheets[index].ColumnHeader.Cells[0, colBDi].Text = "item";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBDE].Text = "edit";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBDS].Text = "save";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBDproviderid].Text = "providerid";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBDdispid].Text = "dispid";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBDinvno].Text = "invno";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBDpid].Text = "pid";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBDprescdt].Text = "prescdt";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBDprescb].Text = "prescd";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBDitemcnt].Text = "itemcnt";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBDchargeamt].Text = "chargeamt";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBDclaimamt].Text = "claimamt";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBDpaid].Text = "paid";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBDotherpay].Text = "otherpay";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBDreimburser].Text = "reimburser";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBDbenefitplan].Text = "benefitplan";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBDdispestat].Text = "dispestat";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBDsvid].Text = "svid";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBDdaycover].Text = "daycover";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBDhn].Text = "hn";
            grdView.Sheets[index].ColumnHeader.Cells[0, colBDdispdt].Text = "dispdt";

            grdView.Sheets[index].Columns[colBDId].Visible = false;
            grdView.Sheets[index].Columns[colBDssdId].Visible = false;
            grdView.Sheets[index].Columns[colBDssvId].Visible = false;
            grdView.Sheets[index].Columns[colBDSheetName].Visible = false;
        }
        private void setGrdViewHBT(int index)
        {
            FarPoint.Win.Spread.CellType.TextCellType objTextCell = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttencell = new FarPoint.Win.Spread.CellType.ButtonCellType();

            grdView.Sheets[index].AutoFilterMode = FarPoint.Win.Spread.AutoFilterMode.EnhancedContextMenu;
            grdView.Sheets[index].ColumnCount = colBTCnt;
            grdView.Sheets[index].RowCount = 1;
            grdView.Sheets[index].OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;

            grdView.Sheets[index].Columns[colBTId].Width = 50;
            grdView.Sheets[index].Columns[colBTssdId].Width = 50;
            grdView.Sheets[index].Columns[colBTssvId].Width = 50;

            grdView.Sheets[index].Columns[colBTBi].Width = 50;
            grdView.Sheets[index].Columns[colBTE].Width = 50;
            grdView.Sheets[index].Columns[colBTS].Width = 50;

            grdView.Sheets[index].Columns[colBTstation].Width = 50;
            grdView.Sheets[index].Columns[colBTauthcode].Width = 70;
            grdView.Sheets[index].Columns[colBTdttran].Width = 120;
            grdView.Sheets[index].Columns[colBThcode].Width = 50;
            grdView.Sheets[index].Columns[colBTinvno].Width = 120;
            grdView.Sheets[index].Columns[colBTbillno].Width = 80;

            grdView.Sheets[index].Columns[colBThn].Width = 80;
            grdView.Sheets[index].Columns[colBTmemberno].Width = 60;
            grdView.Sheets[index].Columns[colBTamount].Width = 80;
            grdView.Sheets[index].Columns[colBTpaid].Width = 80;
            grdView.Sheets[index].Columns[colBTvercode].Width = 50;
            grdView.Sheets[index].Columns[colBTtflag].Width = 50;
            grdView.Sheets[index].Columns[colBTpid].Width = 80;
            grdView.Sheets[index].Columns[colBTname].Width = 250;
            grdView.Sheets[index].Columns[colBThmain].Width = 80;
            grdView.Sheets[index].Columns[colBTpayplan].Width = 80;
            grdView.Sheets[index].Columns[colBTclaimamt].Width = 80;
            grdView.Sheets[index].Columns[colBTotherpayplan].Width = 80;
            grdView.Sheets[index].Columns[colBTotherpay].Width = 80;
            grdView.Sheets[index].Columns[colBTpid].Width = 120;
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
            //grdView.Sheets[index].Columns[colBTpid].CellType = objTextCell;


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
            grdView.Sheets[index].ColumnHeader.Cells[0, colBTpid].Text = "pid";

            grdView.Sheets[index].Columns[colBTId].Visible = false;
            grdView.Sheets[index].Columns[colBTssdId].Visible = false;
            grdView.Sheets[index].Columns[colBTssvId].Visible = false;
            grdView.Sheets[index].Columns[colBTSheetName].Visible = false;
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
                if (i % 2 == 0)
                {
                    grdView.Sheets[0].Cells[i, 0, i, colCnt - 1].BackColor = System.Drawing.Color.FromArgb(235, 241, 222);
                }
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

                //grdView.Sheets[index].bac
                if (i % 2 == 0)
                {
                    grdView.Sheets[index].Cells[i, 0, i, colVCnt - 1].BackColor = System.Drawing.Color.FromArgb(235, 241, 222);
                }
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
                grdView.Sheets[index].Cells[i, colBTSheetName].Value = "BT";

                grdView.Sheets[index].Cells[i, colBTId].Value = row[sC.mHisDB.btDB.bt.billtran_id].ToString();
                grdView.Sheets[index].Cells[i, colBTssdId].Value = row[sC.mHisDB.btDB.bt.ssdata_id].ToString();
                grdView.Sheets[index].Cells[i, colBTssvId].Value = row[sC.mHisDB.btDB.bt.ssdata_visit_id].ToString();

                grdView.Sheets[index].Cells[i, colBTstation].Value = row[sC.mHisDB.btDB.bt.station].ToString();
                grdView.Sheets[index].Cells[i, colBTauthcode].Value = row[sC.mHisDB.btDB.bt.authcode].ToString();
                grdView.Sheets[index].Cells[i, colBTdttran].Value = row[sC.mHisDB.btDB.bt.dttran].ToString();
                grdView.Sheets[index].Cells[i, colBThcode].Value = row[sC.mHisDB.btDB.bt.hcode].ToString();
                grdView.Sheets[index].Cells[i, colBTinvno].Value = row[sC.mHisDB.btDB.bt.invno].ToString();
                grdView.Sheets[index].Cells[i, colBTbillno].Value = row[sC.mHisDB.btDB.bt.billno].ToString();
                grdView.Sheets[index].Cells[i, colBThn].Value = row[sC.mHisDB.btDB.bt.hn].ToString();
                grdView.Sheets[index].Cells[i, colBTmemberno].Value = row[sC.mHisDB.btDB.bt.memberno].ToString();
                grdView.Sheets[index].Cells[i, colBTamount].Value = row[sC.mHisDB.btDB.bt.amount].ToString();
                grdView.Sheets[index].Cells[i, colBTpaid].Value = row[sC.mHisDB.btDB.bt.paid].ToString();
                grdView.Sheets[index].Cells[i, colBTvercode].Value = row[sC.mHisDB.btDB.bt.vercode].ToString();
                grdView.Sheets[index].Cells[i, colBTtflag].Value = row[sC.mHisDB.btDB.bt.tflag].ToString();
                grdView.Sheets[index].Cells[i, colBTpid].Value = row[sC.mHisDB.btDB.bt.pid].ToString();
                grdView.Sheets[index].Cells[i, colBTname].Value = row[sC.mHisDB.btDB.bt.name].ToString();
                grdView.Sheets[index].Cells[i, colBThmain].Value = row[sC.mHisDB.btDB.bt.hmain].ToString();
                grdView.Sheets[index].Cells[i, colBTpayplan].Value = row[sC.mHisDB.btDB.bt.payplan].ToString();
                grdView.Sheets[index].Cells[i, colBTclaimamt].Value = row[sC.mHisDB.btDB.bt.claimamt].ToString();
                grdView.Sheets[index].Cells[i, colBTotherpayplan].Value = row[sC.mHisDB.btDB.bt.otherpayplan].ToString();
                grdView.Sheets[index].Cells[i, colBTotherpay].Value = row[sC.mHisDB.btDB.bt.otherpay].ToString();

                //grdView.Sheets[index].Cells[i, colVVisitDate].Value = row[sC.mHisDB.btDB.bt.visit_date].ToString() + " " + row[sC.mHisDB.ssdVDB.ssdV.visit_time].ToString();
                //grdView.Sheets[index].Cells[i, colVName].Value = row[sC.mHisDB.btDB.bt.prefix].ToString() + " " + row[sC.mHisDB.ssdVDB.ssdV.patient_fname].ToString() + " " + row[sC.mHisDB.ssdVDB.ssdV.patient_lname].ToString();
                if (i % 2 == 0)
                {
                    grdView.Sheets[index].Cells[i, 0, i, colBTCnt - 1].BackColor = System.Drawing.Color.FromArgb(235, 241, 222);
                }
                i++;
            }
        }
        private void setGrdViewBD(int index, String ssDid)
        {
            DataTable dt = new DataTable();
            int i = 0;
            dt = sC.mHisDB.bdDB.selectByssvID(ssDid);
            grdView.Sheets[index].Rows.Clear();
            //setGrdViewH();
            grdView.Sheets[index].RowCount = dt.Rows.Count;
            foreach (DataRow row in dt.Rows)
            {
                grdView.Sheets[index].Cells[i, colBDSheetName].Value = "BD";

                grdView.Sheets[index].Cells[i, colBDId].Value = row[sC.mHisDB.bdDB.bd.billdisp_id].ToString();
                grdView.Sheets[index].Cells[i, colBDssdId].Value = row[sC.mHisDB.bdDB.bd.ssdata_id].ToString();
                grdView.Sheets[index].Cells[i, colBDssvId].Value = row[sC.mHisDB.bdDB.bd.ssdata_visit_id].ToString();

                grdView.Sheets[index].Cells[i, colBDproviderid].Value = row[sC.mHisDB.bdDB.bd.providerid].ToString();
                grdView.Sheets[index].Cells[i, colBDdispid].Value = row[sC.mHisDB.bdDB.bd.dispid].ToString();
                grdView.Sheets[index].Cells[i, colBDinvno].Value = row[sC.mHisDB.bdDB.bd.invno].ToString();
                grdView.Sheets[index].Cells[i, colBDhn].Value = row[sC.mHisDB.bdDB.bd.hn].ToString();
                grdView.Sheets[index].Cells[i, colBDpid].Value = row[sC.mHisDB.bdDB.bd.pid].ToString();
                grdView.Sheets[index].Cells[i, colBDprescdt].Value = row[sC.mHisDB.bdDB.bd.prescdt].ToString();
                grdView.Sheets[index].Cells[i, colBDdispdt].Value = row[sC.mHisDB.bdDB.bd.dispdt].ToString();
                grdView.Sheets[index].Cells[i, colBDprescb].Value = row[sC.mHisDB.bdDB.bd.prescb].ToString();
                grdView.Sheets[index].Cells[i, colBDitemcnt].Value = row[sC.mHisDB.bdDB.bd.itemcnt].ToString();
                grdView.Sheets[index].Cells[i, colBDchargeamt].Value = row[sC.mHisDB.bdDB.bd.chargeamt].ToString();
                grdView.Sheets[index].Cells[i, colBDclaimamt].Value = row[sC.mHisDB.bdDB.bd.claimamt].ToString();
                grdView.Sheets[index].Cells[i, colBDpaid].Value = row[sC.mHisDB.bdDB.bd.paid].ToString();
                grdView.Sheets[index].Cells[i, colBDotherpay].Value = row[sC.mHisDB.bdDB.bd.otherpay].ToString();
                grdView.Sheets[index].Cells[i, colBDreimburser].Value = row[sC.mHisDB.bdDB.bd.reimburser].ToString();
                grdView.Sheets[index].Cells[i, colBDbenefitplan].Value = row[sC.mHisDB.bdDB.bd.benefitplan].ToString();
                grdView.Sheets[index].Cells[i, colBDdispestat].Value = row[sC.mHisDB.bdDB.bd.dispestat].ToString();
                grdView.Sheets[index].Cells[i, colBDsvid].Value = row[sC.mHisDB.bdDB.bd.svid].ToString();
                grdView.Sheets[index].Cells[i, colBDdaycover].Value = row[sC.mHisDB.bdDB.bd.daycover].ToString();
                //grdView.Sheets[index].Cells[i, colBTotherpay].Value = row[sC.mHisDB.btDB.bt.otherpay].ToString();

                //grdView.Sheets[index].Cells[i, colVVisitDate].Value = row[sC.mHisDB.btDB.bt.visit_date].ToString() + " " + row[sC.mHisDB.ssdVDB.ssdV.visit_time].ToString();
                //grdView.Sheets[index].Cells[i, colVName].Value = row[sC.mHisDB.btDB.bt.prefix].ToString() + " " + row[sC.mHisDB.ssdVDB.ssdV.patient_fname].ToString() + " " + row[sC.mHisDB.ssdVDB.ssdV.patient_lname].ToString();
                if (i % 2 == 0)
                {
                    grdView.Sheets[index].Cells[i, 0, i, colBDCnt - 1].BackColor = System.Drawing.Color.FromArgb(235, 241, 222);
                }
                i++;
            }
        }
        private void setGrdViewOPs(int index, String ssDid)
        {
            DataTable dt = new DataTable();
            int i = 0;
            dt = sC.mHisDB.opSDB.selectByssvID(ssDid);
            grdView.Sheets[index].Rows.Clear();
            //setGrdViewH();
            grdView.Sheets[index].RowCount = dt.Rows.Count;
            foreach (DataRow row in dt.Rows)
            {
                grdView.Sheets[index].Cells[i, colOPsSheetName].Value = "OPs";

                grdView.Sheets[index].Cells[i, colOPsId].Value = row[sC.mHisDB.opSDB.opS.opservices_id].ToString();
                grdView.Sheets[index].Cells[i, colOPsssdId].Value = row[sC.mHisDB.opSDB.opS.ssdata_id].ToString();
                grdView.Sheets[index].Cells[i, colOPsssvId].Value = row[sC.mHisDB.opSDB.opS.ssdata_visit_id].ToString();

                grdView.Sheets[index].Cells[i, colOPsinvno].Value = row[sC.mHisDB.opSDB.opS.invno].ToString();
                grdView.Sheets[index].Cells[i, colOPssvid].Value = row[sC.mHisDB.opSDB.opS.svid].ToString();
                grdView.Sheets[index].Cells[i, colOPsclass1].Value = row[sC.mHisDB.opSDB.opS.class1].ToString();
                grdView.Sheets[index].Cells[i, colOPshcode].Value = row[sC.mHisDB.opSDB.opS.hcode].ToString();
                grdView.Sheets[index].Cells[i, colOPshn].Value = row[sC.mHisDB.opSDB.opS.hn].ToString();
                grdView.Sheets[index].Cells[i, colOPspid].Value = row[sC.mHisDB.opSDB.opS.pid].ToString();
                grdView.Sheets[index].Cells[i, colOPscareaccount].Value = row[sC.mHisDB.opSDB.opS.careaccount].ToString();
                grdView.Sheets[index].Cells[i, colOPstypeserv].Value = row[sC.mHisDB.opSDB.opS.typeserv].ToString();
                grdView.Sheets[index].Cells[i, colOPstypein].Value = row[sC.mHisDB.opSDB.opS.typein].ToString();
                grdView.Sheets[index].Cells[i, colOPstypeout].Value = row[sC.mHisDB.opSDB.opS.typeout].ToString();
                grdView.Sheets[index].Cells[i, colOPsdtappoint].Value = row[sC.mHisDB.opSDB.opS.dtappoint].ToString();
                grdView.Sheets[index].Cells[i, colOPssvpid].Value = row[sC.mHisDB.opSDB.opS.svpid].ToString();
                grdView.Sheets[index].Cells[i, colclinic].Value = row[sC.mHisDB.opSDB.opS.clinic].ToString();
                grdView.Sheets[index].Cells[i, colOPsdegdt].Value = row[sC.mHisDB.opSDB.opS.degdt].ToString();
                grdView.Sheets[index].Cells[i, colOPsenddt].Value = row[sC.mHisDB.opSDB.opS.enddt].ToString();
                grdView.Sheets[index].Cells[i, colOPslccode].Value = row[sC.mHisDB.opSDB.opS.lccode].ToString();
                grdView.Sheets[index].Cells[i, colOPscodeset].Value = row[sC.mHisDB.opSDB.opS.codeset].ToString();
                grdView.Sheets[index].Cells[i, colOPsstdcode].Value = row[sC.mHisDB.opSDB.opS.stdcode].ToString();
                grdView.Sheets[index].Cells[i, colOPssvcharge].Value = row[sC.mHisDB.opSDB.opS.svcharge].ToString();
                grdView.Sheets[index].Cells[i, colOPscompletion].Value = row[sC.mHisDB.opSDB.opS.completion].ToString();
                grdView.Sheets[index].Cells[i, colOPssvtxcode].Value = row[sC.mHisDB.opSDB.opS.svtxcode].ToString();
                grdView.Sheets[index].Cells[i, colOPsclaimcat].Value = row[sC.mHisDB.opSDB.opS.claimcat].ToString();
                //grdView.Sheets[index].Cells[i, colBDdaycover].Value = row[sC.mHisDB.bdDB.bd.daycover].ToString();
                //grdView.Sheets[index].Cells[i, colBTotherpay].Value = row[sC.mHisDB.btDB.bt.otherpay].ToString();

                //grdView.Sheets[index].Cells[i, colVVisitDate].Value = row[sC.mHisDB.btDB.bt.visit_date].ToString() + " " + row[sC.mHisDB.ssdVDB.ssdV.visit_time].ToString();
                //grdView.Sheets[index].Cells[i, colVName].Value = row[sC.mHisDB.btDB.bt.prefix].ToString() + " " + row[sC.mHisDB.ssdVDB.ssdV.patient_fname].ToString() + " " + row[sC.mHisDB.ssdVDB.ssdV.patient_lname].ToString();
                if (i % 2 == 0)
                {
                    grdView.Sheets[index].Cells[i, 0, i, colOPsCnt - 1].BackColor = System.Drawing.Color.FromArgb(235, 241, 222);
                }
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
