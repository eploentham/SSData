using SSData.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.objdb
{
    public class TSsdataSplitDB
    {
        public TSsdataSplit ssP;
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
            ssP.date_start = "date_start";
            ssP.date_end = "date_end";
            ssP.cnt_visit_start = "cnt_visit_start";
            ssP.cnt_visit_end = "cnt_visit_end";

            ssP.table = "t_ssdata_split";
            ssP.pkField = "ssdata_split_id";
        }
        public String insert(TSsdataSplit p)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            sql = "Insert Into " + ssP.table + "(" + ssP.active + "," + ssP.date_time_end + "," +
                ssP.date_time_start + "," + ssP.split_no + "," + ssP.split_start_date_time + "," +
                ssP.ssdata_id + "," + ssP.status_process + ") " +
                "Values ('" + p.active + "','" + p.date_time_end + "','" +
                p.date_time_start + "','" + p.split_no + "','" + p.split_start_date_time + "','" +
                p.ssdata_id + "','" + p.status_process + "'  " +
                ")";
            re = conn.ExecuteNonQuery1(conn.connSSData, sql);

            return re;
        }
        public String updateDateStart(String sspId)
        {
            String sql = "", re = "";
            sql = "Update " + ssP.table + " Set " +
                ssP.date_start + "= convert(varchar, getdate(), 120) " +                           
                "Where " + ssP.pkField + "='" + sspId + "'";
            re = conn.ExecuteNonQuery1(conn.connSSData, sql);
            return re;
        }
        public String updateDateEnd(String sspId, String cntStart, String cntEnd)
        {
            String sql = "", re = "";
            sql = "Update " + ssP.table + " Set " +
                ssP.date_end + "= convert(varchar, getdate(), 120), " +
                ssP.cnt_visit_start + "='"+cntStart+"', " +
                ssP.cnt_visit_end + "='" + cntEnd + "', " +
                ssP.status_process+"='1' "+
                "Where " + ssP.pkField + "='" + sspId + "'";
            re = conn.ExecuteNonQuery1(conn.connSSData, sql);
            return re;
        }
        public DataTable selectBySsdId(String ssdId)
        {
            DataTable dt = new DataTable();
            String re = "";
            String sql = "select ssp.* " +
                "From " + ssP.table + " ssp " +
                //"LEft Join t_ssdata ssd" +
                "Where ssp."+ssP.ssdata_id+" ='" + ssdId + "' and active = '1' " +
                "Order By " + ssP.split_no + "  ";
            dt = conn.selectData(conn.connSSData, sql);
            
            return dt;
        }
        public String selectStatusProcessBySspId(String sspId)
        {
            DataTable dt = new DataTable();
            String re = "";
            String sql = "select ssp.* " +
                "From " + ssP.table + " ssp " +
                //"LEft Join t_ssdata ssd" +
                "Where ssp." + ssP.ssdata_id + " ='" + sspId + "' and active = '1' " +
                "Order By " + ssP.split_no + "  ";
            dt = conn.selectData(conn.connSSData, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0][ssP.status_process].ToString();
            }
            return re;
        }
    }
}
