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
        public FrmSSDataOPs(SSDataControl sc)
        {
            InitializeComponent();
            initConfig(sc);
        }
        private void initConfig(SSDataControl sc)
        {
            sC = sc;
            opS = new OpServices();
            setControl(); 
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

        private void FrmSSDataOPs_Load(object sender, EventArgs e)
        {

        }
    }
}
