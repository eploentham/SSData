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
    public partial class FrmSSDataBD : Form
    {
        BillDisp bd;
        SSDataControl sC;
        Color bg, fc;
        Font ff, ffB;
        public FrmSSDataBD(SSDataControl sc)
        {
            InitializeComponent();
            initConfig(sc);
        }
        private void initConfig(SSDataControl sc)
        {
            sC = sc;
            bd = new BillDisp();
            setControl();
            setEnable(false);
            setFocus();

            bg = txtBenefitPlan.BackColor;
            fc = txtBenefitPlan.ForeColor;
            ff = txtBenefitPlan.Font;
        }
        private void setFocus()
        {
            this.txtBenefitPlan.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtBenefitPlan.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtChargeAmt.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtChargeAmt.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtClaimAmt.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtClaimAmt.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtDayCover.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtDayCover.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtDispDt.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtDispDt.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtDispestat.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtDispestat.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtDispId.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtDispId.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtHn.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtHn.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtInvNo.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtInvNo.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtItemCnt.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtItemCnt.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtOtherPay.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtOtherPay.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPaid.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPaid.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPid.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPid.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPrescb.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPrescb.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPrescdt.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPrescdt.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtProviderId.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtProviderId.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtReimburser.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtReimburser.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtSvId.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtSvId.Enter += new System.EventHandler(this.textBox_Enter);

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
        private void setControl()
        {
            bd = sC.mHisDB.bdDB.selectByPk1(sC.bdID);

            txtBenefitPlan.Value = bd.benefitplan;
            txtChargeAmt.Value = bd.chargeamt;
            txtClaimAmt.Value = bd.claimamt;
            txtDayCover.Value = bd.daycover;
            txtDispDt.Value = bd.dispdt;
            txtDispestat.Value = bd.dispestat;
            txtDispId.Value = bd.dispid;
            txtHn.Value = bd.hn;
            txtID.Value = bd.billdisp_id;
            txtInvNo.Value = bd.invno;
            txtItemCnt.Value = bd.itemcnt;
            txtOtherPay.Value = bd.otherpay;
            txtPaid.Value = bd.paid;
            txtPid.Value = bd.pid;
            txtPrescb.Value = bd.prescb;
            txtPrescdt.Value = bd.prescdt;
            txtProviderId.Value = bd.providerid;
            txtReimburser.Value = bd.reimburser;
            txtSvId.Value = bd.svid;
            
        }
        private void setBD()
        {
            bd.benefitplan = txtBenefitPlan.Value.ToString();
            bd.chargeamt = txtChargeAmt.Value.ToString();
            bd.claimamt = txtClaimAmt.Value.ToString();
            bd.daycover = txtDayCover.Value.ToString();
            bd.dispdt = txtDispDt.Value.ToString();
            bd.dispestat = txtDispestat.Value.ToString();
            bd.dispid = txtDispId.Value.ToString();
            bd.hn = txtHn.Value.ToString();
            bd.billdisp_id = txtID.Value.ToString();
            bd.invno = txtInvNo.Value.ToString();
            bd.itemcnt = txtItemCnt.Value.ToString();
            bd.otherpay = txtOtherPay.Value.ToString();
            bd.paid = txtPaid.Value.ToString();
            bd.pid = txtPid.Value.ToString();
            bd.prescb = txtPrescb.Value.ToString();
            bd.prescdt = txtPrescdt.Value.ToString();
            bd.providerid = txtProviderId.Value.ToString();
            bd.reimburser = txtReimburser.Value.ToString();
            bd.svid = txtSvId.Value.ToString();
        }
        private void setEnable(Boolean flag)
        {
            txtBenefitPlan.Enabled = flag;
            txtChargeAmt.Enabled = flag;
            txtClaimAmt.Enabled = flag;
            txtDayCover.Enabled = flag;
            txtDispDt.Enabled = flag;
            txtDispestat.Enabled = flag;
            txtDispId.Enabled = flag;
            txtHn.Enabled = flag;
            //txtID.Enabled = flag;
            txtInvNo.Enabled = flag;
            txtItemCnt.Enabled = flag;
            txtOtherPay.Enabled = flag;
            txtPaid.Enabled = flag;
            txtPid.Enabled = flag;
            txtPrescb.Enabled = flag;
            txtPrescdt.Enabled = flag;
            txtProviderId.Enabled = flag;
            txtReimburser.Enabled = flag;
            txtSvId.Enabled = flag;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            setEnable(true);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                setBD();
                String re = sC.mHisDB.bdDB.update(bd);
                if (re.Equals("1"))
                {
                    setEnable(false);
                }
            }
        }

        private void FrmSSDataBD_Load(object sender, EventArgs e)
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
