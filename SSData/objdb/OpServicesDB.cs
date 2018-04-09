using SSData.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.objdb
{
    public class OpServicesDB
    {
        ConnectDB conn;
        public OpServices opS;

        public OpServicesDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            opS = new OpServices();
            opS.careaccount = "careaccount";
            opS.claimcat = "claimcat";
            opS.class1 = "class1";
            opS.clinic = "clinic";
            opS.codeset = "codeset";
            opS.completion = "completion";
            opS.degdt = "degdt";
            opS.dtappoint = "dtappoint";
            opS.enddt = "enddt";
            opS.hcode = "hcode";
            opS.hn = "hn";
            opS.invno = "invno";
            opS.lccode = "lccode";
            opS.opservices_id = "opservices_id";
            opS.pid = "pid";
            opS.ssdata_id = "ssdata_id";
            opS.stdcode = "stdcode";
            opS.svcharge = "svcharge";
            opS.svid = "svid";
            opS.svpid = "svpid";
            opS.svtxcode = "svtxcode";
            opS.typein = "typein";
            opS.typeout = "typeout";
            opS.typeserv = "typeserv";
            opS.ssdata_visit_id = "ssdata_visit_id";

            opS.table = "t_opservices";
            opS.pkField = "opservices_id";
        }
        public String insert(OpServices p)
        {
            String re = "";
            String sql = "";
            //p.active = "1";

            sql = "Insert Into " + opS.table + "(" + opS.careaccount + "," + opS.claimcat + "," + opS.class1 + "," +
                opS.clinic + "," + opS.codeset + "," + opS.completion + "," +
                opS.degdt + "," + opS.dtappoint + "," + opS.enddt + "," +
                opS.hcode + "," + opS.hn + "," + opS.invno + "," +
                opS.lccode + "," + opS.pid + "," + opS.ssdata_id + "," +
                opS.stdcode + "," + opS.svcharge + "," + opS.svid + "," +
                opS.svpid + "," + opS.svtxcode + "," + opS.typein + "," +
                opS.typeout + "," + opS.typeserv + ", " + opS.ssdata_visit_id + " " +
                ") " +
                "Values('" + p.careaccount + "','" + p.claimcat + "','" + p.class1 + "','" +
                p.clinic + "','" + p.codeset + "','" + p.completion + "','" +
                p.degdt + "','" + p.dtappoint + "','" + p.enddt + "','" +
                p.hcode + "','" + p.hn + "','" + p.invno + "','" +
                p.lccode + "','" + p.pid + "','" + p.ssdata_id + "','" +
                p.stdcode + "','" + p.svcharge + "','" + p.svid + "','" +
                p.svpid + "','" + p.svtxcode + "','" + p.typein + "','" +
                p.typeout + "','" + p.typeserv + "','" + p.ssdata_visit_id + "' " +
                ") ";
            re = conn.ExecuteNonQueryNoClose(conn.connSSDataNoClose, sql);

            return re;
        }
        public String update(OpServices p)
        {
            String re = "";
            String sql = "";
            sql = "Update " + opS.table + " Set " +
                " " + opS.careaccount + "='"+p.careaccount+"'" +
                "," + opS.claimcat + "='" + p.claimcat + "'" +
                "," + opS.class1 + "='" + p.class1 + "'" +
                "," + opS.clinic + "='" + p.clinic + "'" +
                "," + opS.codeset + "='" + p.codeset + "'" +
                "," + opS.completion + "='" + p.completion + "'" +
                "," + opS.degdt + "='" + p.degdt + "'" +
                "," + opS.dtappoint + "='" + p.dtappoint + "'" +
                "," + opS.enddt + "='" + p.enddt + "'" +
                "," + opS.hcode + "='" + p.hcode + "'" +
                "," + opS.hn + "='" + p.hn + "'" +
                "," + opS.invno + "='" + p.invno + "'" +
                "," + opS.lccode + "='" + p.lccode + "'" +
                "," + opS.pid + "='" + p.pid + "'" +
                "," + opS.stdcode + "='" + p.stdcode + "'" +
                "," + opS.svcharge + "='" + p.svcharge + "'" +
                "," + opS.svid + "='" + p.svid + "'" +
                "," + opS.svpid + "='" + p.svpid + "'" +
                "," + opS.svtxcode + "='" + p.svtxcode + "'" +
                "," + opS.typein + "='" + p.typein + "'" +
                "," + opS.typeout + "='" + p.typeout + "'" +
                "," + opS.typeserv + "='" + p.typeserv + "'" +
                "Where "+opS.pkField+"='"+p.opservices_id+"'";

            re = conn.ExecuteNonQuery1(conn.connSSData, sql);

            return re;
        }
        public DataTable selectByssvID(String ssvId)
        {
            DataTable dt = new DataTable();
            String sql = "select ops.* " +
                "From " + opS.table + " ops " +
                "Left Join t_ssdata ssd On ssd.ssdata_id = ops.ssdata_id " +
                "Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = ops." + opS.ssdata_visit_id + " " +
                "Where ops." + opS.ssdata_id + " ='" + ssvId + "' " +
                "Order By ssv.visit_date, ssv.visit_time";
            dt = conn.selectData(conn.connSSData, sql);
            
            return dt;
        }
        public OpServices selectByssvID1(String opsId)
        {
            OpServices opS1 = new OpServices();
            DataTable dt = new DataTable();
            String sql = "select ops.* " +
                "From " + opS.table + " ops " +
                "Left Join t_ssdata ssd On ssd.ssdata_id = ops.ssdata_id " +
                "Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = ops." + opS.ssdata_visit_id + " " +
                "Where ops." + opS.opservices_id + " ='" + opsId + "' ";
            dt = conn.selectData(conn.connSSData, sql);
            opS1 = setOPs(dt);
            return opS1;
        }
        private OpServices setOPs(DataTable dt)
        {
            OpServices opS1 = new OpServices();
            if (dt.Rows.Count > 0)
            {
                opS1.careaccount = dt.Rows[0][opS.careaccount].ToString();
                opS1.claimcat = dt.Rows[0][opS.claimcat].ToString();
                opS1.class1 = dt.Rows[0][opS.class1].ToString();
                opS1.clinic = dt.Rows[0][opS.clinic].ToString();
                opS1.codeset = dt.Rows[0][opS.codeset].ToString();
                opS1.completion = dt.Rows[0][opS.completion].ToString();
                opS1.degdt = dt.Rows[0][opS.degdt].ToString();
                opS1.dtappoint = dt.Rows[0][opS.dtappoint].ToString();
                opS1.enddt = dt.Rows[0][opS.enddt].ToString();
                opS1.hcode = dt.Rows[0][opS.hcode].ToString();
                opS1.hn = dt.Rows[0][opS.hn].ToString();
                opS1.invno = dt.Rows[0][opS.invno].ToString();
                opS1.lccode = dt.Rows[0][opS.lccode].ToString();
                opS1.opservices_id = dt.Rows[0][opS.opservices_id].ToString();
                opS1.pid = dt.Rows[0][opS.pid].ToString();
                opS1.ssdata_id = dt.Rows[0][opS.ssdata_id].ToString();
                opS1.ssdata_visit_id = dt.Rows[0][opS.ssdata_visit_id].ToString();
                opS1.stdcode = dt.Rows[0][opS.stdcode].ToString();
                opS1.svcharge = dt.Rows[0][opS.svcharge].ToString();
                opS1.svid = dt.Rows[0][opS.svid].ToString();
                opS1.svpid = dt.Rows[0][opS.svpid].ToString();
                opS1.svtxcode = dt.Rows[0][opS.svtxcode].ToString();
                opS1.typein = dt.Rows[0][opS.typein].ToString();
                opS1.typeout = dt.Rows[0][opS.typeout].ToString();
                opS1.typeserv = dt.Rows[0][opS.typeserv].ToString();
            }           

            return opS1;
        }
    }
}
