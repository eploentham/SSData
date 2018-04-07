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

        private void FrmSSDataBD_Load(object sender, EventArgs e)
        {

        }
    }
}
