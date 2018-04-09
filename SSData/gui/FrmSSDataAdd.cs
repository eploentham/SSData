﻿using SSData.control;
using SSData.gui;
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

        public FrmSSDataAdd(SSDataControl sc, Form par1)
        {
            InitializeComponent();
            initConfig(sc, par1);
        }
        private void initConfig(SSDataControl sc, Form par1)
        {
            String monthId = "";
            monthId = System.DateTime.Now.Month.ToString("00");
            sC = sc;
            par = par1;
            txtTimeCurrent.Text = sC.setTimeCurrent();
            timer1.Interval = 1000 * 60;
            timer1.Start();
            pB1.Hide();
            //pB2.Hide();
            sC.setCboMonth(cboMonth);
            sC.setCboYear(cboYear);
            cboMonth.SelectedValue = monthId;
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
                sC.mHisDB.insertTSSData(sC.iniC.HCODE, sC.iniC.branchId, cboYear.Text, cboMonth.SelectedValue.ToString(), pB1, label12, label13, this);
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

        private void btnGenFileName_Click(object sender, EventArgs e)
        {
            genFileName();
        }

        private void btnGenBT_Click(object sender, EventArgs e)
        {
            String re= sC.genTextBillTran(txtHName.Text, txtPath.Value.ToString(), txtFileNameBT.Text, txtHCODE.Text, txtSSOPBIL.Text, txtPeriod.Text, txtPeriodSub.Text, cboYear.Text, cboMonth.SelectedValue.ToString(), pB1);
            if (re.Equals("1"))
            {
                btnGenBT.BackColor = Color.Green;
            }
        }

        private void btnGenBD_Click(object sender, EventArgs e)
        {
            String re = sC.genTextBillDisp(txtHName.Text, txtPath.Value.ToString(), txtFileNameBD.Text, txtHCODE.Text, txtSSOPBIL.Text, txtPeriod.Text, txtPeriodSub.Text, cboYear.Text, cboMonth.SelectedValue.ToString(), pB1);
            if (re.Equals("1"))
            {
                btnGenBD.BackColor = Color.Green;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtTimeCurrent.Text = sC.setTimeCurrent();
            if (txtTimeCurrent.Text.Equals(txtAutoStart.Text))
            {
                //txtTimeStart.Text = sC.setTimeCurrent();
                //DateTime startDate = Convert.ToDateTime(System.DateTime.Now).AddDays(-1);
                btnOk_Click(null,null);
                //selectCar(startDate.Year.ToString() + "-" + startDate.ToString("MM-dd"), startDate.Year.ToString() + "-" + startDate.ToString("MM-dd"));
                //txtTimeEnd.Text = tdsC.setTimeCurrent();
            }
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
            num = dateEnd.Day / int.Parse(txtSplit.Value.ToString());
            aa = dateEnd.Day % int.Parse(txtSplit.Value.ToString());
            if (aa >= 1)
            {
                num++;
            }
            //TimeSpan age = econvertedDate.Subtract(sconvertedDate);
            txtSplitNum.Value = num;
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
        }
    }
}
