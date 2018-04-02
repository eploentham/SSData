using SSData.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.objdb
{
    public class TSsdataVisitBillDispDB
    {
        public TSsdataVisitBillDisp ssdvB;
        ConnectDB conn;
        public TSsdataVisitBillDispDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            ssdvB = new TSsdataVisitBillDisp();
            ssdvB.benefitplan = "benefitplan";
            ssdvB.chargeamt = "chargeamt";
            ssdvB.claimamt = "claimamt";
            ssdvB.daycover = "daycover";
            ssdvB.dispdt = "dispdt";
            ssdvB.dispestat = "dispestat";
            ssdvB.dispid = "dispid";
            ssdvB.hn = "hn";
            ssdvB.invno = "invno";
            ssdvB.itemcnt = "itemcnt";
            ssdvB.otherpay = "otherpay";
            ssdvB.paid = "paid";
            ssdvB.pid = "pid";
            ssdvB.prescb = "prescb";
            ssdvB.prescdt = "prescdt";
            ssdvB.providerid = "providerid";
            ssdvB.reimburser = "reimburser";
            ssdvB.ssdata_billdisp_id = "ssdata_billdisp_id";
            ssdvB.ssdata_id = "ssdata_id";
            ssdvB.ssdata_visit_id = "ssdata_visit_id";
            ssdvB.svid = "svid";
            ssdvB.active = "active";

            ssdvB.table = "t_ssdata_visit_billdisp";
            ssdvB.pkField = "ssdata_billdisp_id";
        }
        public String insert(TSsdataVisitBillDisp p)
        {
            String re = "";
            String sql = "";
            p.active = "1";

            sql = "Insert Into " + ssdvB.table + "(" + ssdvB.benefitplan + "," + ssdvB.chargeamt + "," + ssdvB.claimamt + "," +
                ssdvB.daycover + "," + ssdvB.dispdt + "," + ssdvB.dispestat + "," +
                ssdvB.dispid + "," + ssdvB.hn + "," + ssdvB.invno + "," +
                ssdvB.itemcnt + "," + ssdvB.otherpay + "," + ssdvB.paid + "," +
                ssdvB.pid + "," + ssdvB.prescb + "," + ssdvB.prescdt + "," +
                ssdvB.providerid + "," + ssdvB.reimburser + ","  +
                ssdvB.ssdata_id + "," + ssdvB.ssdata_visit_id + "," + ssdvB.svid + "," +
                ssdvB.active +
                ") " +
                "Values('" + p.benefitplan + "','" + p.chargeamt + "','" + p.claimamt + "','" +
                p.daycover + "','" + p.dispdt + "','" + p.dispestat + "','" +
                p.dispid + "','" + p.hn + "','" + p.invno + "','" +
                p.itemcnt + "','" + p.otherpay + "','" + p.paid + "','" +
                p.pid + "','" + p.prescb + "','" + p.prescdt + "','" +
                p.providerid + "','" + p.reimburser + "','" +
                p.ssdata_id + "','" + p.ssdata_visit_id + "','" + p.svid + "','" +
                p.active +
                "') ";
            re = conn.ExecuteNonQueryNoClose(conn.connSSDataNoClose, sql);

            return re;
        }
    }
}
