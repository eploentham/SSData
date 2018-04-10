using SSData.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.objdb
{
    public class TSsdataDB
    {
        public TSsdata ssd;
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
            ssd.date_end = "date_end";
            ssd.date_start = "date_start";

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
                ssd.month_id+","+ssd.year_id + "," + ssd.status_precess + "," + ssd.date_start + ") "+
                "Values ('" + p.active + "','" + p.branch_id + "','" +
                p.branch_visit_id + "','" + p.cnt_hn + "','" + p.cnt_visit + "','" +
                p.month_id + "','" + p.year_id + "','" + p.status_precess + "',convert(varchar, getdate(), 120)) ";
            re = conn.ExecuteNonQuery(conn.connSSData, sql);

            return re;
        }
        public String updateDateEnd(String ssId)
        {
            String sql = "", re="";
            sql = "Update "+ssd.table+" Set " +                
                ssd.date_end+ "= convert(varchar, getdate(), 120) " +
                "Where "+ssd.pkField+"='"+ ssId + "'";
            re = conn.ExecuteNonQuery1(conn.connSSData, sql);
            return re;
        }
        public String selectIDByYearMonth(String yearId, String monthId)
        {
            DataTable dt = new DataTable();
            String re = "";
            String sql = "select * " +
                "From " + ssd.table + "  " +                
                "Where year_id ='" + yearId + "' and month_id ='" + monthId + "' and active = '1' " +
                "Order By "+ssd.pkField+" desc ";
            dt = conn.selectData(conn.connSSData, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0]["ssdata_id"].ToString();
            }
            return re;
        }
        public DataTable selectIDByYearMonth1(String yearId, String monthId)
        {
            DataTable dt = new DataTable();
            String re = "";
            String sql = "select * " +
                "From " + ssd.table + "  " +
                "Where year_id ='" + yearId + "' and month_id ='" + monthId + "' and active = '1' " +
                "Order By " + ssd.pkField + " desc ";
            dt = conn.selectData(conn.connSSData, sql);
            
            return dt;
        }
        public DataTable selectAll()
        {
            String re = "", sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + ssd.table + " " +
                "Where "+ssd.active+"='1' " +
                " Order By "+ssd.ssdata_id+" desc";
            dt = conn.selectData(conn.connSSData, sql);

            return dt;
        }
    }
}
