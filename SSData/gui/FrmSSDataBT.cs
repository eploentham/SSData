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
    public partial class FrmSSDataBT : Form
    {
        BillTran bt;
        SSDataControl sC;
        Color bg, fc;
        Font ff, ffB;
        public FrmSSDataBT(SSDataControl sc)
        {
            InitializeComponent();
            initConfig(sc);
        }
        private void initConfig(SSDataControl sc)
        {
            sC = sc;
            bt = new BillTran();
            setControl();
            setEnable(false);
            setFocus();

            bg = txtAmount.BackColor;
            fc = txtAmount.ForeColor;
            ff = txtAmount.Font;
            //ffB = ff.Bold;
            
        }
        private void setFocus()
        {
            this.txtAmount.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtAmount.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtAuthenCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtAuthenCode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtBillNo.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtBillNo.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtClaimAmt.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtClaimAmt.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtDtTran.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtDtTran.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtHCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtHCode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtHMain.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtHMain.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtHN.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtHN.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtInvNo.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtInvNo.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtMemberNo.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtMemberNo.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtName.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtName.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtOtherPay.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtOtherPay.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtOtherPayPlan.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtOtherPayPlan.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPaid.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPaid.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPayPlan.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPayPlan.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPID.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPID.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtStation.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtStation.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtTFlag.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtTFlag.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtVerCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtVerCode.Enter += new System.EventHandler(this.textBox_Enter);
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
            bt = sC.mHisDB.btDB.selectByPk1(sC.btID);
            txtAmount.Value = bt.amount;
            txtAuthenCode.Value = bt.authcode;
            txtBillNo.Value = bt.billno;
            txtClaimAmt.Value = bt.claimamt;
            txtDtTran.Value = bt.dttran;
            txtHCode.Value = bt.hcode;
            txtHMain.Value = bt.hmain;
            txtHN.Value = bt.hn;
            txtId.Value = bt.billtran_id;
            txtInvNo.Value = bt.invno;
            txtMemberNo.Value = bt.memberno;
            txtName.Value = bt.name;
            txtOtherPay.Value = bt.otherpay;
            txtOtherPayPlan.Value = bt.otherpayplan;
            txtPaid.Value = bt.paid;
            txtPayPlan.Value = bt.payplan;
            txtPID.Value = bt.pid;
            txtStation.Value = bt.station;
            txtTFlag.Value = bt.tflag;
            txtVerCode.Value = bt.vercode;
        }
        private void setBT()
        {
            bt.amount = txtAmount.Value.ToString();
            bt.authcode = txtAuthenCode.Value.ToString();
            bt.billno = txtBillNo.Value.ToString();
            bt.claimamt = txtClaimAmt.Value.ToString();
            bt.dttran = txtDtTran.Value.ToString();
            bt.hcode = txtHCode.Value.ToString();
            bt.hmain = txtHMain.Value.ToString();
            bt.hn = txtHN.Value.ToString();
            bt.billtran_id = txtId.Value.ToString();
            bt.invno = txtInvNo.Value.ToString();
            bt.memberno = txtMemberNo.Value.ToString();
            bt.name = txtName.Value.ToString();
            bt.otherpay = txtOtherPay.Value.ToString();
            bt.otherpayplan = txtOtherPayPlan.Value.ToString();
            bt.paid = txtPaid.Value.ToString();
            bt.payplan = txtPayPlan.Value.ToString();
            bt.pid = txtPID.Value.ToString();
            bt.station = txtStation.Value.ToString();
            bt.tflag = txtTFlag.Value.ToString();
            bt.vercode = txtVerCode.Value.ToString(); 
        }
        private void setEnable(Boolean flag)
        {
            txtAmount.Enabled = flag;
            txtAuthenCode.Enabled = flag;
            txtBillNo.Enabled = flag;
            txtClaimAmt.Enabled = flag;
            txtDtTran.Enabled = flag;
            txtHCode.Enabled = flag;
            txtHMain.Enabled = flag;
            txtHN.Enabled = flag;
            //txtId.Enabled = flag;
            txtInvNo.Enabled = flag;
            txtMemberNo.Enabled = flag;
            txtName.Enabled = flag;
            txtOtherPay.Enabled = flag;
            txtOtherPayPlan.Enabled = flag;
            txtPaid.Enabled = flag;
            txtPayPlan.Enabled = flag;
            txtPID.Enabled = flag;
            txtStation.Enabled = flag;
            txtTFlag.Enabled = flag;
            txtVerCode.Enabled = flag;
        }        

        private void FrmSSDataBT_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                setBT();
                String re = sC.mHisDB.btDB.update(bt);
                if (re.Equals("1"))
                {
                    setEnable(false);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            setEnable(true);
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
