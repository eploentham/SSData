using SSData.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.objdb
{
    public class BillDispDB
    {
        public BillDisp bd;
        ConnectDB conn;

        public BillDispDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            bd = new BillDisp();
            bd.benefitplan = "benefitplan";
            bd.billdisp_id = "billdisp_id";
            bd.chargeamt = "chargeamt";
            bd.claimamt = "claimamt";
            bd.daycover = "daycover";
            bd.dispdt = "dispdt";
            bd.dispestat = "dispestat";
            bd.dispid = "dispid";
            bd.hn = "hn";
            bd.invno = "invno";
            bd.itemcnt = "itemcnt";
            bd.otherpay = "otherpay";
            bd.paid = "paid";
            bd.pid = "pid";
            bd.prescb = "prescb";
            bd.prescdt = "prescdt";
            bd.providerid = "providerid";
            bd.reimburser = "reimburser";
            bd.ssdata_id = "ssdata_id";
            bd.ssdata_visit_id = "ssdata_visit_id";
            bd.svid = "svid";

            bd.table = "t_billdisp";
            bd.pkField = "billdisp_id";
        }
        public String insert(BillDisp p)
        {
            String re = "";
            String sql = "";
            //p.active = "1";

            sql = "Insert Into " + bd.table + "(" + bd.benefitplan + "," + bd.chargeamt + "," + bd.claimamt + "," +
                bd.daycover + "," + bd.dispdt + "," + bd.dispestat + "," +
                bd.dispid + "," + bd.hn + "," + bd.invno + "," +
                bd.itemcnt + "," + bd.otherpay + "," + bd.paid + "," +
                bd.pid + "," + bd.prescb + "," + bd.prescdt + "," +
                bd.providerid + "," + bd.reimburser + "," +
                bd.ssdata_id + "," + bd.ssdata_visit_id + "," + bd.svid + " " +                
                ") " +
                "Values('" + p.benefitplan + "','" + p.chargeamt + "','" + p.claimamt + "','" +
                p.daycover + "','" + p.dispdt + "','" + p.dispestat + "','" +
                p.dispid + "','" + p.hn + "','" + p.invno + "','" +
                p.itemcnt + "','" + p.otherpay + "','" + p.paid + "','" +
                p.pid + "','" + p.prescb + "','" + p.prescdt + "','" +
                p.providerid + "','" + p.reimburser + "','" +
                p.ssdata_id + "','" + p.ssdata_visit_id + "','" + p.svid + "' " +
                ") ";
            re = conn.ExecuteNonQueryNoClose(conn.connSSDataNoClose, sql);

            return re;
        }
    }
}
