using SSData.control;
using SSData.gui;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            pB2.Hide();
            sC.setCboMonth(cboMonth);
            sC.setCboYear(cboYear);
            cboMonth.SelectedValue = monthId;
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
            sC.mHisDB.insertTSSData(sC.iniC.HCODE, sC.iniC.branchId, cboYear.Text, cboMonth.SelectedValue.ToString(), pB1, label12, label13);
        }

        private void btnOpenBT_Click(object sender, EventArgs e)
        {
            FrmSSDataTextEdit frm = new FrmSSDataTextEdit();
            frm.ShowDialog(this);
        }
    }
}
