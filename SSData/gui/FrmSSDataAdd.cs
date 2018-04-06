using SSData.control;
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
        }
        private String genFileName()
        {
            DateTime dt1 = DateTime.Now;
            String dt = "";
            dt = dt1.ToString("yyyyMMddTHH:mm:ss") + ".txt";
            txtFileName.Value = txtHCODE.Text + "_" + txtSSOPBIL.Text + "_" + txtPeriod.Text + "_" + txtPeriodSub.Text + "_" + dt1.ToString("yyyyMMdd-HHmmss") + ".txt";
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
                sC.mHisDB.insertTSSData(sC.iniC.HCODE, sC.iniC.branchId, cboYear.Text, cboMonth.SelectedValue.ToString(), pB1, label12, label13);
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
    }
}
