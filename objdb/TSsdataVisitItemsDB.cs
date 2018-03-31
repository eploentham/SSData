using SSData.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.objdb
{
    public class TSsdataVisitItemsDB
    {
        public TSsdataVisitItems ssdVI;
        ConnectDB conn;
        public TSsdataVisitItemsDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            ssdVI = new TSsdataVisitItems();
            ssdVI.active = "active";
            ssdVI.billmuad = "billmuad";
            ssdVI.chargeamt = "chargeamt";
            ssdVI.claimamount = "claimamount";
            ssdVI.claimcat = "claimcat";
            ssdVI.claimup = "claimup";
            ssdVI.desc1 = "desc1";
            ssdVI.invno = "invno";
            ssdVI.llcode = "llcode";
            ssdVI.qty = "qty";
            ssdVI.ssdata_id = "ssdata_id";
            ssdVI.ssdata_visit_id = "ssdata_visit_id";
            ssdVI.ssdata_visit_items_id = "ssdata_visit_items_id";
            ssdVI.stdcode = "stdcode";
            ssdVI.svdate = "svdate";
            ssdVI.svrefid = "svrefid";
            ssdVI.up = "up";

            ssdVI.table = "t_ssdata_visit_items";
            ssdVI.pkField = "ssdata_visit_items_id";
        }
    }
}
