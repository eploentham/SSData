using C1.Win.C1Input;
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
    public partial class FrmSSDataOPs : Form
    {
        OpServices opS;
        SSDataControl sC;
        Color bg, fc;
        Font ff, ffB;
        public FrmSSDataOPs(SSDataControl sc)
        {
            InitializeComponent();
            initConfig(sc);
            setEnable(false);
            setFocus();

            bg = txtCareAccount.BackColor;
            fc = txtCareAccount.ForeColor;
            ff = txtCareAccount.Font;
        }
        private void initConfig(SSDataControl sc)
        {
            sC = sc;
            opS = new OpServices();
            setControl(); 
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = Color.DarkCyan;
            a.Font = new Font(ff, FontStyle.Bold);
            //a.ForeColor = Color.Black;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = bg;
            a.ForeColor = fc;
            a.Font = new Font(ff, FontStyle.Regular);
        }
        private void setFocus()
        {
            this.txtCareAccount.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCareAccount.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtClaimCat.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtClaimCat.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtClass1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtClass1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtClinic.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtClinic.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtCodeSet.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCodeSet.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtCompletion.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCompletion.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtDegDt.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtDegDt.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtDtAppoint.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtDtAppoint.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtEndDt.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtEndDt.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtHCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtHCode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtHN.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtHN.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtInvNo.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtInvNo.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtLcCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtLcCode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPid.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPid.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtStdCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtStdCode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtSvId.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtSvId.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtSvpId.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtSvpId.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtSvtxCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtSvtxCode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtSvCharge.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtSvCharge.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtTypeIn.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtTypeIn.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtTypeOut.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtTypeOut.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtTypeServ.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtTypeServ.Enter += new System.EventHandler(this.textBox_Enter);
        }
        private void setControl()
        {
            opS = sC.mHisDB.opSDB.selectByssvID1(sC.opsID);
            txtCareAccount.Value = opS.careaccount;
            txtClaimCat.Value = opS.claimcat;
            txtClass1.Value = opS.class1;
            txtClinic.Value = opS.clinic;
            txtCodeSet.Value = opS.codeset;
            txtCompletion.Value = opS.completion;
            txtDegDt.Value = opS.degdt;
            txtDtAppoint.Value = opS.dtappoint;
            txtEndDt.Value = opS.enddt;
            txtHCode.Value = opS.hcode;
            txtHN.Value = opS.hn;
            txtInvNo.Value = opS.invno;
            txtLcCode.Value = opS.lccode;
            txtPid.Value = opS.pid;
            txtId.Value = opS.opservices_id;
            txtStdCode.Value = opS.stdcode;
            txtSvId.Value = opS.svid;
            txtSvpId.Value = opS.svpid;
            txtSvtxCode.Value = opS.svtxcode;
            txtSvCharge.Value = opS.svcharge;
            txtTypeIn.Value = opS.typein;
            txtTypeOut.Value = opS.typeout;
            txtTypeServ.Value = opS.typeserv;
        }
        private void setOPs()
        {
            opS.careaccount = txtCareAccount.Value.ToString();
            opS.claimcat = txtClaimCat.Value.ToString();
            opS.class1 = txtClass1.Value.ToString();
            opS.clinic = txtClinic.Value.ToString();
            opS.codeset = txtCodeSet.Value.ToString();
            opS.completion = txtCompletion.Value.ToString();
            opS.degdt = txtDegDt.Value.ToString();
            opS.dtappoint  = txtDtAppoint.Value.ToString();
            opS.enddt = txtEndDt.Value.ToString();
            opS.hcode = txtHCode.Value.ToString();
            opS.hn = txtHN.Value.ToString();
            opS.invno = txtInvNo.Value.ToString();
            opS.lccode = txtLcCode.Value.ToString();
            opS.pid = txtPid.Value.ToString();
            opS.opservices_id = txtId.Value.ToString();
            opS.stdcode = txtStdCode.Value.ToString();
            opS.svid = txtSvId.Value.ToString();
            opS.svpid = txtSvpId.Value.ToString();
            opS.svtxcode = txtSvtxCode.Value.ToString();
            opS.svcharge = txtSvCharge.Value.ToString();
            opS.typein  = txtTypeIn.Value.ToString();
            opS.typeout = txtTypeOut.Value.ToString();
            opS.typeserv = txtTypeServ.Value.ToString();
        }
        private void setEnable(Boolean flag)
        {
            txtCareAccount.Enabled = flag;
            txtClaimCat.Enabled = flag;
            txtClass1.Enabled = flag;
            txtClinic.Enabled = flag;
            txtCodeSet.Enabled = flag;
            txtCompletion.Enabled = flag;
            txtDegDt.Enabled = flag;
            txtDtAppoint.Enabled = flag;
            txtEndDt.Enabled = flag;
            txtHCode.Enabled = flag;
            txtHN.Enabled = flag;
            txtInvNo.Enabled = flag;
            txtLcCode.Enabled = flag;
            txtPid.Enabled = flag;
            //txtId.Enabled = opS.opservices_id;
            txtStdCode.Enabled = flag;
            txtSvId.Enabled = flag;
            txtSvpId.Enabled = flag;
            txtSvtxCode.Enabled = flag;
            txtSvCharge.Enabled = flag;
            txtTypeIn.Enabled = flag;
            txtTypeOut.Enabled = flag;
            txtTypeServ.Enabled = flag;
        }

        private void FrmSSDataOPs_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                setOPs();
                String re = sC.mHisDB.opSDB.update(opS);
                if (re.Equals("1"))
                {
                    setEnable(false);
                }
            }
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            setEnable(true);
        }
    }
}
