using SSData.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.objdb
{
    public class OpServicesOpdXDB
    {
        public OpServicesOpdX opDX;
        ConnectDB conn;

        public OpServicesOpdXDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            opDX = new OpServicesOpdX();
            opDX.class1 = "class1";
            opDX.code = "code";
            opDX.codeset = "codeset";
            opDX.desc1 = "desc1";
            opDX.opservices_id = "opservices_id";
            opDX.opservices_opdx_id = "opservices_opdx_id";
            opDX.sl = "sl";
            opDX.svid = "svid";

            opDX.table = "t_opservices_opdx";
            opDX.pkField = "opservices_opdx_id";
        }
        public String insert(OpServicesOpdX p)
        {
            String re = "";
            String sql = "";
            //p.active = "1";

            sql = "Insert Into " + opDX.table + "(" + opDX.class1 + "," + opDX.code + "," + opDX.codeset + "," +
                opDX.desc1 + "," + opDX.opservices_id + "," + opDX.sl + "," +
                opDX.svid +
                ") " +
                "Values('" + p.class1 + "','" + p.code + "','" + p.codeset + "','" +
                p.desc1.Replace("'","''") + "','" + p.opservices_id + "','" + p.sl + "','" +
                p.svid + 
                "') ";
            re = conn.ExecuteNonQueryNoClose(conn.connSSDataNoClose, sql);

            return re;
        }
        public String update(OpServicesOpdX p)
        {
            String re = "";
            String sql = "";

            sql = "Update " + opDX.table + " Set " +
                "," + opDX.class1 + "='" + p.class1 + "'" +
                "," + opDX.code + "='" + p.code + "'" +
                "," + opDX.codeset + "='" + p.codeset + "'" +
                "," + opDX.desc1 + "='" + p.desc1.Replace("'","''") + "'" +
                "," + opDX.sl + "='" + p.sl + "'" +
                "," + opDX.svid + "='" + p.svid + "'" +
                "Where "+opDX.opservices_opdx_id+"='"+p.opservices_opdx_id+"'";

            re = conn.ExecuteNonQuery1(conn.connSSData, sql);

            return re;
        }
        public DataTable selectByOpSId(String opsId)
        {
            DataTable dt = new DataTable();
            String sql = "select opdx.* " +
                "From " + opDX.table + " opdx " +
                //"Left Join t_billtran bt On bti.billtran_id = bt.billtran_id " +
                "Where opdx." + opDX.opservices_id + " ='" + opsId + "' ";
            dt = conn.selectData(conn.connSSData, sql);
            return dt;
        }
        public DataTable selectBySSdId(String ssDId)
        {
            DataTable dt = new DataTable();
            String sql = "select opdx.* " +
                "From " + opDX.table + " opdx " +
                "Left Join t_opservices ops On opdx.opservices_id = ops.opservices_id " +
                "Where ops.ssdata_id ='" + ssDId + "' ";
            dt = conn.selectData(conn.connSSData, sql);
            return dt;
        }
    }
}
