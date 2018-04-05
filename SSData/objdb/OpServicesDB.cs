using SSData.object1;
using System;
using System.Collections.Generic;
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

            opS.table = "t_opservice";
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
                opS.typeout + "," + opS.typeserv + "," +                
                ") " +
                "Values('" + p.careaccount + "','" + p.claimcat + "','" + p.class1 + "','" +
                p.clinic + "','" + p.codeset + "','" + p.completion + "','" +
                p.degdt + "','" + p.dtappoint + "','" + p.enddt + "','" +
                p.hcode + "','" + p.hn + "','" + p.invno + "','" +
                p.lccode + "','" + p.pid + "','" + p.ssdata_id + "','" +
                p.stdcode + "','" + p.svcharge + "','" + p.svid + "','" +
                p.svpid + "','" + p.svtxcode + "','" + p.typein + "','" +
                p.typeout + "','" + p.typeserv + "','" +                
                "') ";
            re = conn.ExecuteNonQueryNoClose(conn.connSSDataNoClose, sql);

            return re;
        }
    }
}
