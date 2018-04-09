using SSData.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.objdb
{
    public class TSsdataSplitDB
    {
        TSsdataSplit ssP;
        ConnectDB conn;

        public TSsdataSplitDB(ConnectDB c)
        {
            conn = c;
            initConfig();
            
        }
        private void initConfig()
        {
            ssP = new TSsdataSplit();
            ssP.active = "active";
            ssP.date_time_end = "date_time_end";
            ssP.date_time_start = "date_time_start";
            ssP.split_no = "split_no";
            ssP.split_start_date_time = "split_start_date_time";
            ssP.ssdata_id = "ssdata_id";
            ssP.ssdata_split_id = "ssdata_split_id";
            ssP.status_process = "status_process";

            ssP.table = "t_ssdata_split";
            ssP.pkField = "ssdata_split_id";
        }
        public String insert(TSsdataSplit p)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            p.ssdata_id = "";
            sql = "Insert Into " + ssP.table + "(" + ssP.active + "," + ssP.date_time_end + "," +
                ssP.date_time_start + "," + ssP.split_no + "," + ssP.split_start_date_time + "," +
                ssP.ssdata_id + "," + ssP.status_process + ") " +
                "Values ('" + p.active + "','" + p.date_time_end + "','" +
                p.date_time_start + "','" + p.split_no + "','" + p.split_start_date_time + "','" +
                p.ssdata_id + "','" + p.status_process + "'" +
                ")";
            re = conn.ExecuteNonQueryNoClose(conn.connSSDataNoClose, sql);

            return re;
        }
    }
}
