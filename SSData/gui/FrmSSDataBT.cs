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

        private void FrmSSDataBT_Load(object sender, EventArgs e)
        {

        }
    }
}
