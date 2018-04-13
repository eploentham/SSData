using SSData.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.objdb
{
    public class FinanceM06DB
    {
        public FinanceM06 fm06;
        ConnectDB conn;

        public FinanceM06DB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            fm06 = new FinanceM06();
            fm06.MNC_FN_GRP_CD = "MNC_FN_GRP_CD";
            fm06.MNC_FN_GRP_DSC = "MNC_FN_GRP_DSC";
            fm06.MNC_GRP_REP_CD = "MNC_GRP_REP_CD";
            fm06.MNC_STAMP_DAT = "MNC_STAMP_DAT";
            fm06.MNC_STAMP_TIM = "MNC_STAMP_TIM";
            fm06.MNC_USR_ADD = "MNC_USR_ADD";
            fm06.MNC_USR_UPD = "MNC_USR_UPD";
            fm06.MNC_FN_GRP_STS = "MNC_FN_GRP_STS";
            fm06.MNC_COL_NO_OPD = "MNC_COL_NO_OPD";
            fm06.MNC_COL_NO_IPD = "MNC_COL_NO_IPD";

            fm06.table = "finance_m06";
            fm06.pkField = "MNC_FN_GRP_CD";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select fm06.* " +
                "From " + fm06.table + " fm06 ";
            dt = conn.selectData(conn.connMainHIS, sql);

            return dt;
        }
    }
}