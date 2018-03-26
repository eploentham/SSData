using C1.Win.C1Input;
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
            sC = sc;
            par = par1;
            pB1.Hide();
            pB2.Hide();
            sC.setCboMonth(cboYear);
            sC.setCboYear(cboMonth);
        }

        private void FrmSSDataAdd_Load(object sender, EventArgs e)
        {
            

        }

        private void FrmSSDataAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            par.Show();
        }
    }
}
