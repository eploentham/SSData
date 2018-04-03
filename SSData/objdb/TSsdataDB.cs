using SSData.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.objdb
{
    public class TSsdataDB
    {
        TSsdata ssd;
        ConnectDB conn;

        public TSsdataDB(ConnectDB c)
        {
            conn = c;
            ssd = new TSsdata();
            
            ssd.active = "active";
            ssd.branch_id = "branch_id";
            ssd.branch_visit_id = "branch_visit_id";
            ssd.cnt_hn = "cnt_hn";
            ssd.cnt_visit = "cnt_visit";
            ssd.month_id = "month_id";
            ssd.ssdata_id = "ssdata_id";
            ssd.year_id = "year_id";
            ssd.status_precess = "status_precess";

            ssd.table = "t_ssdata";
            ssd.pkField = "ssdata_id";
            
        }
        public String insert(TSsdata p)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            sql = "Insert Into "+ssd.table+"(" + ssd.active+","+ssd.branch_id+"," +
                ssd.branch_visit_id+","+ssd.cnt_hn+","+ssd.cnt_visit+","+
                ssd.month_id+","+ssd.year_id + "," + ssd.status_precess + ") "+
                "Values ('" + p.active + "','" + p.branch_id + "','" +
                p.branch_visit_id + "','" + p.cnt_hn + "','" + p.cnt_visit + "','" +
                p.month_id + "','" + p.year_id + "','" + p.status_precess + "') ";
            re = conn.ExecuteNonQueryNoClose(conn.connSSDataNoClose, sql);

            return re;
        }
    }
}
