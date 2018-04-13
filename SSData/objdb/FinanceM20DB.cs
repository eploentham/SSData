using SSData.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.objdb
{
    public class FinanceM20DB
    {
        public FinanceM20 fm20;
        ConnectDB conn;

        public FinanceM20DB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            fm20 = new FinanceM20();
            fm20.MNC_DAY_FLG = "MNC_DAY_FLG";
            fm20.MNC_GRP_SS2 = "MNC_GRP_SS2";
            fm20.MNC_GRP_SS2_DSC = "MNC_GRP_SS2_DSC";

            fm20.table = "finance_m20";
            fm20.pkField = "MNC_GRP_SS2";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select fm20.* " +
                "From " + fm20.table + " fm20 ";
            dt = conn.selectData(conn.connMainHIS, sql);

            return dt;
        }
    }
}
