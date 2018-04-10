using SSData.control;
using SSData.gui;
using SSData.object1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSData
{
    public partial class FrmSSDataAdd : Form
    {
        Form par;
        SSDataControl sC;
        String encoding = "Windows-874";

        int colId = 0, colssdid = 1, colsplitno = 2, colsplitstartdt = 3, coldatestart = 4, coldateend = 5, colstatusprocess = 6;
        int colCnt=7;

        public FrmSSDataAdd(SSDataControl sc, Form par1)
        {
            InitializeComponent();
            initConfig(sc, par1);
        }
        private void initConfig(SSDataControl sc, Form par1)
        {
            String monthId = "";
            TabPrepare.Text = "เตรียมข้อมูล";
            TabGen.Text = "gen Text";
            TabRetrive.Text = "ดึงข้อมูล";
            //TabPrepare.
            monthId = System.DateTime.Now.Month.ToString("00");
            sC = sc;
            par = par1;
            txtTimeCurrent.Text = sC.setTimeCurrent();
            txtTimeCurrentRet.Text = txtTimeCurrent.Text;
            timer1.Interval = 1000 * 60;
            timer1.Start();
            pB1.Hide();
            //txtSplit.min
            //pB2.Hide();
            sC.setCboMonth(cboMonth);
            sC.setCboYear(cboYear);
            sC.setCboMonth(cboMonthRet);
            sC.setCboYear(cboYearRet);
            sC.setCboMonth(cboMonthGen);
            sC.setCboYear(cboYearGen);
            cboMonth.SelectedValue = monthId;
            cboMonthRet.SelectedValue = monthId;
            txtPath.Value = sc.iniC.pathFile;
            txtFileNameBD.Text = sc.iniC.FileNameBillDisp+DateTime.Now.ToString("yyyyMMdd")+".TXT";
            txtFileNameBT.Text = sc.iniC.FileNameBillTran + DateTime.Now.ToString("yyyyMMdd") + ".TXT";
            txtFileNameOPS.Text = sc.iniC.FileNameOPServices + DateTime.Now.ToString("yyyyMMdd") + ".TXT";
            txtHCODE.Text = sc.iniC.HCODE;
            txtSSOPBIL.Text = sc.iniC.SSOPBIL;
            txtPeriod.Value = "1001";
            txtPeriodSub.Value = "01";
            txtEmailSSOPBIL.Value = sc.iniC.EmailSSOPBIL;
            //txtHName.Value = sc.iniC.HNAME;

            Encoding iso = Encoding.GetEncoding(encoding);
            Encoding utf8 = Encoding.UTF8;
            byte[] utfBytes = utf8.GetBytes("โรงพยาบาล บางนา5");
            byte[] isoBytes = Encoding.Convert(utf8, iso, utfBytes);
            string msg = iso.GetString(isoBytes);
            txtHName.Value = msg;
            genFileName();
            setChkSplit();
            setTxtSplit();
            setGrdViewH();
            setGrdViewRetH();
            setSplitNum();
        }
        private String genFileName()
        {
            DateTime dt1 = DateTime.Now;
            String dt = "";
            dt = dt1.ToString("yyyyMMddTHH:mm:ss") + ".txt";
            txtFileName.Value = txtHCODE.Text + "_" + txtSSOPBIL.Text + "_" + txtPeriod.Text + "_" + txtPeriodSub.Text + "_" + dt1.ToString("yyyyMMdd-HHmmss") + ".zip";
            return dt;
        }

        private void FrmSSDataAdd_Load(object sender, EventArgs e)
        {
            
        }

        private void FrmSSDataAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            par.Show();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            String chk = sC.mHisDB.ssdDB.selectIDByYearMonth(cboYear.Text, cboMonth.SelectedValue.ToString());
            if (!chk.Equals(""))
            {


                MessageBox.Show("พบข้อมูล ได้มีการนำเข้า เรียบร้อยแล้ว\n ถ้าต้องการนำเข้าใหม่ ต้องยกเลิก รายการเดิมก่อน ", "พบข้อมูล ได้มีการนำเข้า เรียบร้อยแล้ว");
            }
            else
            {
                sC.lSplit.Clear();
                for (int i = 0; i < grdView.Sheets[0].Rows.Count; i++)
                {
                    TSsdataSplit sp = new TSsdataSplit();
                    sp.split_no = grdView.Sheets[0].Cells[i, colsplitno].Value.ToString();
                    sp.date_time_start =  grdView.Sheets[0].Cells[i, coldatestart].Value.ToString();
                    sp.date_time_end = grdView.Sheets[0].Cells[i, coldateend].Value.ToString();
                    sp.status_process = grdView.Sheets[0].Cells[i, colstatusprocess].Value.ToString();
                    sp.split_start_date_time = txtAutoStart.Text;
                    sC.lSplit.Add(sp);
                }
                sC.mHisDB.createTSSData(sC.iniC.HCODE, sC.iniC.branchId, cboYear.Text, cboMonth.SelectedValue.ToString(), sC.lSplit);
                //sC.mHisDB.insertTSSSplit(sC.lSplit);
                //foreach (TSsdataSplit sp in sC.lSplit)
                //{
                //    //sp.ssdata_id = ssd.ssdata_id;
                //    spDB.insert(sp);
                //}
                //sC.mHisDB.insertTSSData(sC.iniC.HCODE, sC.iniC.branchId, cboYear.Text, cboMonth.SelectedValue.ToString(), pB1, label12, label13, this, sC.lSplit, "new");
            }
        }

        private void btnOpenBT_Click(object sender, EventArgs e)
        {
            FrmSSDataTextEdit frm = new FrmSSDataTextEdit(txtPath.Value.ToString()+"\\"+txtFileNameBT.Text);
            frm.ShowDialog(this);
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();
            //string tempPath = "";
            browser.SelectedPath = sC.iniC.pathFile;
            if (browser.ShowDialog() == DialogResult.OK)
            {
                txtPath.Value = browser.SelectedPath; // 
            }
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
            FarPoint.Win.Spread.CellType.TextCellType objTextCell = new FarPoint.Win.Spread.CellType.TextCellType();

            grdView.Sheets[0].ColumnCount = colCnt;
            grdView.Sheets[0].RowCount = 1;

            grdView.Sheets[0].Columns[colId].CellType = objTextCell;
            grdView.Sheets[0].Columns[colssdid].CellType = objTextCell;
            grdView.Sheets[0].Columns[colsplitno].CellType = objTextCell;
            grdView.Sheets[0].Columns[colsplitstartdt].CellType = objTextCell;
            grdView.Sheets[0].Columns[coldatestart].CellType = objTextCell;
            grdView.Sheets[0].Columns[coldateend].CellType = objTextCell;
            grdView.Sheets[0].Columns[colstatusprocess].CellType = objTextCell;
            //grdView.Sheets[0].Columns[colId].CellType = objTextCell;

            grdView.Sheets[0].Columns[colId].Visible = false;
            grdView.Sheets[0].Columns[colssdid].Visible = false;

            grdView.Sheets[0].Columns[colsplitno].Width = 30;
            grdView.Sheets[0].Columns[colsplitstartdt].Width = 40;
            grdView.Sheets[0].Columns[coldatestart].Width = 80;
            grdView.Sheets[0].Columns[coldateend].Width = 80;
            grdView.Sheets[0].Columns[colstatusprocess].Width = 50;
            //grdView.Sheets[0].Columns[colstatusprocess].Width = 100;

            grdView.Sheets[0].ColumnHeader.Cells[0, colsplitno].Text = "no";
            grdView.Sheets[0].ColumnHeader.Cells[0, colsplitstartdt].Text = "start";
            grdView.Sheets[0].ColumnHeader.Cells[0, coldatestart].Text = "start";
            grdView.Sheets[0].ColumnHeader.Cells[0, coldateend].Text = "end";
            grdView.Sheets[0].ColumnHeader.Cells[0, colstatusprocess].Text = "status";
            //grdView.Sheets[0].ColumnHeader.Cells[0, colinvno].Text = "invno";
        }
        private void setGrdViewRetH()
        {
            FarPoint.Win.Spread.EnhancedInterfaceRenderer outlinelook = new FarPoint.Win.Spread.EnhancedInterfaceRenderer();
            outlinelook.RangeGroupBackgroundColor = Color.LightGreen;
            outlinelook.RangeGroupButtonBorderColor = Color.Red;
            outlinelook.RangeGroupLineColor = Color.Blue;
            grdViewRet.InterfaceRenderer = outlinelook;
            grdViewRet.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            grdViewRet.BorderStyle = BorderStyle.None;
            FarPoint.Win.Spread.CellType.TextCellType objTextCell = new FarPoint.Win.Spread.CellType.TextCellType();

            grdViewRet.Sheets[0].ColumnCount = colCnt;
            grdViewRet.Sheets[0].RowCount = 1;

            grdViewRet.Sheets[0].Columns[colId].CellType = objTextCell;
            grdViewRet.Sheets[0].Columns[colssdid].CellType = objTextCell;
            grdViewRet.Sheets[0].Columns[colsplitno].CellType = objTextCell;
            grdViewRet.Sheets[0].Columns[colsplitstartdt].CellType = objTextCell;
            grdViewRet.Sheets[0].Columns[coldatestart].CellType = objTextCell;
            grdViewRet.Sheets[0].Columns[coldateend].CellType = objTextCell;
            grdViewRet.Sheets[0].Columns[colstatusprocess].CellType = objTextCell;
            //grdViewRet.Sheets[0].Columns[colStart].CellType = objTextCell;

            grdViewRet.Sheets[0].Columns[colId].Visible = false;
            grdViewRet.Sheets[0].Columns[colssdid].Visible = false;

            grdViewRet.Sheets[0].Columns[colsplitno].Width = 30;
            grdViewRet.Sheets[0].Columns[colsplitstartdt].Width = 40;
            grdViewRet.Sheets[0].Columns[coldatestart].Width = 80;
            grdViewRet.Sheets[0].Columns[coldateend].Width = 80;
            grdViewRet.Sheets[0].Columns[colstatusprocess].Width = 50;
            //grdView.Sheets[0].Columns[colstatusprocess].Width = 100;

            grdViewRet.Sheets[0].ColumnHeader.Cells[0, colsplitno].Text = "no";
            grdViewRet.Sheets[0].ColumnHeader.Cells[0, colsplitstartdt].Text = "start";
            grdViewRet.Sheets[0].ColumnHeader.Cells[0, coldatestart].Text = "start";
            grdViewRet.Sheets[0].ColumnHeader.Cells[0, coldateend].Text = "end";
            grdViewRet.Sheets[0].ColumnHeader.Cells[0, colstatusprocess].Text = "status";
            //grdViewRet.Sheets[0].ColumnHeader.Cells[0, colStart].Text = "start";
        }
        private void setGrdViewRet()
        {
            if (txtSplitNum.Value.ToString().Equals("")) return;

            int i = 0;
            DataTable dt = new DataTable();
            grdViewRet.Sheets[0].Rows.Clear();
            

            String startDate = "", endDate = "", yearId = "", monthId = "", period = "", ssdId="";

            yearId = cboYearRet.Text;
            monthId = cboMonthRet.SelectedValue.ToString();
            DateTime dateEnd = new DateTime(int.Parse(yearId), int.Parse(monthId) + 1, 1);

            ssdId = sC.mHisDB.ssdDB.selectIDByYearMonth(yearId, monthId);
            dt = sC.mHisDB.sspDB.selectBySsdId(ssdId);
            grdViewRet.Sheets[0].RowCount = dt.Rows.Count;
            foreach (DataRow row in dt.Rows)
            {
                grdViewRet.Sheets[0].Cells[i, colId].Value = row[sC.mHisDB.sspDB.ssP.ssdata_split_id].ToString();
                grdViewRet.Sheets[0].Cells[i, colssdid].Value = row[sC.mHisDB.sspDB.ssP.ssdata_id].ToString();
                grdViewRet.Sheets[0].Cells[i, colsplitno].Value = row[sC.mHisDB.sspDB.ssP.split_no].ToString();
                grdViewRet.Sheets[0].Cells[i, coldatestart].Value = row[sC.mHisDB.sspDB.ssP.date_time_start].ToString();
                grdViewRet.Sheets[0].Cells[i, coldateend].Value = row[sC.mHisDB.sspDB.ssP.date_time_end].ToString();
                grdViewRet.Sheets[0].Cells[i, colstatusprocess].Value = row[sC.mHisDB.sspDB.ssP.status_process].ToString();
                grdViewRet.Sheets[0].Cells[i, colsplitstartdt].Value = row[sC.mHisDB.sspDB.ssP.split_start_date_time].ToString();
                if (i % 2 != 0)
                {
                    grdViewRet.Sheets[0].Cells[i, 0, i, colCnt - 1].BackColor = System.Drawing.Color.FromArgb(235, 241, 222);
                }
                i++;
            }
        }
        private void setGrdView()
        {
            grdView.Sheets[0].Rows.Clear();
            grdView.Sheets[0].RowCount = int.Parse(txtSplitNum.Value.ToString());

            String startDate = "", endDate = "", yearId = "", monthId = "", period = "";

            yearId = cboYear.Text;
            monthId = cboMonth.SelectedValue.ToString();
            DateTime dateEnd = new DateTime(int.Parse(yearId), int.Parse(monthId) + 1, 1);
            int num = 0, aa=0;
            dateEnd = dateEnd.AddDays(-1);
            
            if (int.Parse(txtSplit.Value.ToString()) > 0)
            {
                num = dateEnd.Day / int.Parse(txtSplit.Value.ToString());
                aa = dateEnd.Day % int.Parse(txtSplit.Value.ToString());
                num = aa >= 1 ? num++ : num;
                for (int i = 0; i < int.Parse(txtSplitNum.Value.ToString()); i++)
                {
                    DateTime dateEnd1;
                    if (i == 0)
                    {
                        startDate = yearId + "-" + monthId + "-01";
                        if (int.Parse(txtSplitNum.Value.ToString()) == 1)
                        {
                            endDate = dateEnd.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            DateTime dateStart = new DateTime(int.Parse(startDate.Substring(0, 4)), int.Parse(startDate.Substring(5, 2)), int.Parse(startDate.Substring(startDate.Length - 2)));
                            dateEnd1 = dateStart.AddDays(int.Parse(txtSplit.Value.ToString())-1);
                            endDate = dateEnd1.ToString("yyyy-MM-dd");
                        }
                    }
                    else
                    {
                        DateTime dateStart = new DateTime(int.Parse(startDate.Substring(0,4)), int.Parse(startDate.Substring(5, 2)), int.Parse(startDate.Substring(startDate.Length - 2)));
                        dateStart = dateStart.AddDays(int.Parse(txtSplit.Value.ToString()));
                        startDate = dateStart.ToString("yyyy-MM-dd");
                        dateEnd1 = dateStart.AddDays(int.Parse(txtSplit.Value.ToString())-1);
                        if (dateEnd.CompareTo(dateEnd1) < 0)
                        {
                            dateEnd1 = dateEnd;
                        }
                        endDate = dateEnd1.ToString("yyyy-MM-dd");
                    }
                    grdView.Sheets[0].Cells[i, colsplitno].Value = (i + 1);
                    grdView.Sheets[0].Cells[i, coldatestart].Value = startDate;
                    grdView.Sheets[0].Cells[i, coldateend].Value = endDate;
                    grdView.Sheets[0].Cells[i, colstatusprocess].Value = "0";
                    if (i % 2 != 0)
                    {
                        grdView.Sheets[0].Cells[i, 0, i, colCnt - 1].BackColor = System.Drawing.Color.FromArgb(235, 241, 222);
                    }
                }
            }
        }
        private void btnGenFileName_Click(object sender, EventArgs e)
        {
            genFileName();
        }

        private void btnGenBT_Click(object sender, EventArgs e)
        {
            String re= sC.genTextBillTran(txtHName.Text, txtPath.Value.ToString(), txtFileNameBT.Text, txtHCODE.Text, txtSSOPBIL.Text, txtPeriod.Text, txtPeriodSub.Text, cboYearGen.Text, cboMonthGen.SelectedValue.ToString(), pB2);
            if (re.Equals("1"))
            {
                btnGenBT.BackColor = Color.Green;
            }
        }

        private void btnGenBD_Click(object sender, EventArgs e)
        {
            String re = sC.genTextBillDisp(txtHName.Text, txtPath.Value.ToString(), txtFileNameBD.Text, txtHCODE.Text, txtSSOPBIL.Text, txtPeriod.Text, txtPeriodSub.Text, cboYearGen.Text, cboMonthGen.SelectedValue.ToString(), pB2);
            if (re.Equals("1"))
            {
                btnGenBD.BackColor = Color.Green;
            }
        }
        private void btnGenOpS_Click(object sender, EventArgs e)
        {
            String re = sC.genTextOPservice(txtHName.Text, txtPath.Value.ToString(), txtFileNameOPS.Text, txtHCODE.Text, txtSSOPBIL.Text, txtPeriod.Text, txtPeriodSub.Text, cboYearGen.Text, cboMonthGen.SelectedValue.ToString(), pB2);
            if (re.Equals("1"))
            {
                btnGenOpS.BackColor = Color.Green;
            }
        }

        private void btnOpenBD_Click(object sender, EventArgs e)
        {
            FrmSSDataTextEdit frm = new FrmSSDataTextEdit(txtPath.Value.ToString() + "\\" + txtFileNameBD.Text);
            frm.ShowDialog(this);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            sC.yearId = cboYear.Text;
            sC.monthId = cboMonth.SelectedValue.ToString();
            FrmSSDataView frm = new FrmSSDataView(sC, this);
            frm.ShowDialog(this);
        }

        private void btnZip_Click(object sender, EventArgs e)
        {
            genFileName();
            sC.genZipFile(txtPath.Text, sC.iniC.pathFileZip + "\\" + txtFileName.Text);
        }

        private void cboMonthRet_SelectedIndexChanged(object sender, EventArgs e)
        {
            setGrdViewRet();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtTimeCurrent.Text = sC.setTimeCurrent();
            txtTimeCurrentRet.Text = txtTimeCurrent.Text;
            if (txtTimeCurrent.Text.Equals(txtAutoStartRet.Text))
            {
                //txtTimeStart.Text = sC.setTimeCurrent();
                //DateTime startDate = Convert.ToDateTime(System.DateTime.Now).AddDays(-1);
                btnRet_Click(null,null);
                //selectCar(startDate.Year.ToString() + "-" + startDate.ToString("MM-dd"), startDate.Year.ToString() + "-" + startDate.ToString("MM-dd"));
                //txtTimeEnd.Text = tdsC.setTimeCurrent();
            }
        }

        private void btnRet_Click(object sender, EventArgs e)
        {
            //String chk = sC.mHisDB.ssdDB.selectIDByYearMonth(cboYear.Text, cboMonth.SelectedValue.ToString());
            String chk = sC.mHisDB.sspDB.selectStatusProcessBySspId(txtSspId.Text);
            if (chk.Equals("1"))
            {
                MessageBox.Show("พบข้อมูล ได้มีการนำเข้า เรียบร้อยแล้ว\n ถ้าต้องการนำเข้าใหม่ ต้องยกเลิก รายการเดิมก่อน ", "พบข้อมูล ได้มีการนำเข้า เรียบร้อยแล้ว");
            }
            else
            {
                //sC.lSplit.Clear();
                //for (int i = 0; i < grdView.Sheets[0].Rows.Count; i++)
                //{
                //    TSsdataSplit sp = new TSsdataSplit();
                //    sp.split_no = grdView.Sheets[0].Cells[i, colsplitno].Value.ToString();
                //    sp.date_time_start = grdView.Sheets[0].Cells[i, coldatestart].Value.ToString();
                //    sp.date_time_end = grdView.Sheets[0].Cells[i, coldateend].Value.ToString();
                //    sp.status_process = grdView.Sheets[0].Cells[i, colstatusprocess].Value.ToString();
                //    sC.lSplit.Add(sp);
                //}
                //DateTime dateEnd = new 
                //DateTime dateStart = DateTime.Parse(txtDateStart.Value.ToString("yyyy-MM-dd"));
                sC.mHisDB.insertTSSData(sC.iniC.HCODE, sC.iniC.branchId, txtDateStart.Value.ToString("yyyy-MM-dd"), txtDateEnd.Value.ToString("yyyy-MM-dd")
                    , pB1, label12, label13, this, txtSsdId.Text, txtSspId.Text);
            }
        }

        private void grdViewRet_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            txtSsdId.Value = grdViewRet.Sheets[0].Cells[e.Row, colssdid].Value.ToString();
            txtSspId.Value = grdViewRet.Sheets[0].Cells[e.Row, colId].Value.ToString();
            txtDateStart.Value = DateTime.Parse(grdViewRet.Sheets[0].Cells[e.Row, coldatestart].Value.ToString());
            txtDateEnd.Value = DateTime.Parse(grdViewRet.Sheets[0].Cells[e.Row, coldateend].Value.ToString());
            txtAutoStartRet.Text = grdViewRet.Sheets[0].Cells[e.Row, colsplitstartdt].Value.ToString();
        }
        
        private void setChkSplit()
        {
            if (chkSplit.Checked)
            {
                txtSplit.Enabled = true;
            }
            else
            {
                txtSplit.Enabled = false;
            }
        }
        private void setTxtSplit()
        {
            String re = "";
            if (cboYear.Text.Equals("")) return;

            String startDate = "", endDate = "", yearId = "", monthId = "", period = "";
            yearId = cboYear.Text;
            monthId = cboMonth.SelectedValue.ToString();
            if (monthId.Equals("12"))
            {
                yearId = String.Concat(int.Parse(yearId) + 1);
                monthId = "01";
                DateTime dateEnd = new DateTime(int.Parse(yearId), int.Parse(monthId), 1);
                dateEnd = dateEnd.AddDays(-1);
                re = dateEnd.Day.ToString();
            }
            else
            {
                DateTime dateEnd = new DateTime(int.Parse(yearId), int.Parse(monthId) + 1, 1);
                dateEnd = dateEnd.AddDays(-1);
                re = dateEnd.Day.ToString();
            }

            txtSplit.Value = re;
        }
        private void setSplitNum()
        {
            String startDate = "", endDate = "", yearId = "", monthId = "", period = "";
            yearId = cboYear.Text;
            monthId = cboMonth.SelectedValue.ToString();
            DateTime dateEnd = new DateTime(int.Parse(yearId), int.Parse(monthId) + 1, 1);
            DateTime day = new DateTime();
            
            period = txtSplit.Value.ToString();

            dateEnd = dateEnd.AddDays(-1);
            //startDate = yearId + "-" + monthId + "-01";
            //endDate = yearId + "-" + dateEnd.Month.ToString("00") + "-" + dateEnd.Day.ToString("00");

            //DateTime econvertedDate = Convert.ToDateTime(dateEnd);
            //DateTime sconvertedDate = Convert.ToDateTime(startDate);
            int num = 0;
            int aa = 0;
            if (int.Parse(txtSplit.Value.ToString()) > 0)
            {
                num = dateEnd.Day / int.Parse(txtSplit.Value.ToString());
                aa = dateEnd.Day % int.Parse(txtSplit.Value.ToString());
                if (aa >= 1)
                {
                    num++;
                }
            }
            
            //TimeSpan age = econvertedDate.Subtract(sconvertedDate);
            txtSplitNum.Value = num;
            setGrdView();
        }
        private void chkSplit_CheckedChanged(object sender, EventArgs e)
        {
            setChkSplit();            
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            setTxtSplit();
        }

        private void txtSplit_ValueChanged(object sender, EventArgs e)
        {
            setSplitNum();
            setGrdView();
        }
    }
}
