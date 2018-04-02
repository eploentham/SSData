using SSData.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.objdb
{
    public class TSsdataVisitBillDispItemsDB
    {
        public TSsdataVisitBillDispItems ssdvBI;
        ConnectDB conn;
        public TSsdataVisitBillDispItemsDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            ssdvBI = new TSsdataVisitBillDispItems();
            ssdvBI.active = "active";
            ssdvBI.billmuad = "billmuad";
            ssdvBI.chargeamt = "chargeamt";
            ssdvBI.claimamount = "claimamount";
            ssdvBI.claimcat = "claimcat";
            ssdvBI.claimup = "claimup";
            ssdvBI.desc1 = "desc1";
            ssdvBI.invno = "invno";
            ssdvBI.llcode = "llcode";
            ssdvBI.qty = "qty";
            ssdvBI.ssdata_id = "ssdata_id";
            ssdvBI.ssdata_visit_id = "ssdata_visit_id";
            ssdvBI.ssdata_visit_items_id = "ssdata_visit_billdisp_items_id";
            ssdvBI.stdcode = "stdcode";
            ssdvBI.svdate = "svdate";
            ssdvBI.svrefid = "svrefid";
            ssdvBI.up = "up";
            ssdvBI.row_no = "row_no";
            ssdvBI.ssdata_billdisp_id = "ssdata_billdisp_id";

            ssdvBI.table = "t_ssdata_visit_billdisp_items";
            ssdvBI.pkField = "ssdata_visit_billdisp_items_id";
        }
        public String insert(TSsdataVisitBillDispItems p)
        {
            String re = "";
            String sql = "";
            p.active = "1";

            sql = "Insert Into " + ssdvBI.table + "(" + ssdvBI.active + "," + ssdvBI.billmuad + "," + ssdvBI.chargeamt + "," +
                ssdvBI.claimamount + "," + ssdvBI.claimcat + "," + ssdvBI.claimup + "," +
                ssdvBI.desc1 + "," + ssdvBI.invno + "," + ssdvBI.llcode + "," +
                ssdvBI.qty + "," + ssdvBI.ssdata_id + "," + ssdvBI.ssdata_visit_id + "," +
                ssdvBI.stdcode + "," + ssdvBI.svdate + "," + ssdvBI.svrefid + "," +
                ssdvBI.up  + "," + ssdvBI.row_no + "," + ssdvBI.ssdata_billdisp_id +
                ") " +
                "Values('" + p.active + "','" + p.billmuad + "','" + p.chargeamt + "','" +
                p.claimamount + "','" + p.claimcat + "','" + p.claimup + "','" +
                p.desc1 + "','" + p.invno + "','" + p.llcode + "','" +
                p.qty + "','" + p.ssdata_id + "','" + p.ssdata_visit_id + "','" +
                p.stdcode + "','" + p.svdate + "','" + p.svrefid + "','" +
                p.up+ "','" + p.row_no + "','" + p.ssdata_billdisp_id +
                "') ";
            re = conn.ExecuteNonQueryNoClose(conn.connSSDataNoClose, sql);

            return re;
        }
    }
}
