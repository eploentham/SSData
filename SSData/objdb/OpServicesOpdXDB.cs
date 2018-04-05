using SSData.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.objdb
{
    public class OpServicesOpdXDB
    {
        public OpServicesOpdX opSX;
        ConnectDB conn;

        public OpServicesOpdXDB(ConnectDB c)
        {
            conn = c;

        }
        private void initConfig()
        {
            opSX = new OpServicesOpdX();
            opSX.class1 = "class1";
            opSX.code = "code";
            opSX.codeset = "codeset";
            opSX.desc1 = "desc1";
            opSX.opservices_id = "opservices_id";
            opSX.opservices_opdx_id = "opservices_opdx_id";
            opSX.sl = "sl";
            opSX.svid = "svid";

            opSX.table = "t_opservices_opdx";
            opSX.pkField = "opservices_opdx_id";
        }
        public String insert(OpServicesOpdX p)
        {
            String re = "";
            String sql = "";
            //p.active = "1";

            sql = "Insert Into " + opSX.table + "(" + opSX.class1 + "," + opSX.code + "," + opSX.codeset + "," +
                opSX.desc1 + "," + opSX.opservices_id + "," + opSX.sl + "," +
                opSX.svid +
                ") " +
                "Values('" + p.class1 + "','" + p.code + "','" + p.codeset + "','" +
                p.desc1.Replace("'","''") + "','" + p.opservices_id + "','" + p.sl + "','" +
                p.svid + 
                "') ";
            re = conn.ExecuteNonQueryNoClose(conn.connSSDataNoClose, sql);

            return re;
        }
    }
}
