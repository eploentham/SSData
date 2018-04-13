using SSData.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.objdb
{
    public class FinanceM01DB
    {
        public FinanceM01 fm01;
        ConnectDB conn;

        public FinanceM01DB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            fm01 = new FinanceM01();
            fm01.MNC_FN_CD = "MNC_FN_CD";
            fm01.MNC_FN_CTL_CD = "MNC_FN_CTL_CD";
            fm01.MNC_FN_DSCT = "MNC_FN_DSCT";
            fm01.MNC_FN_DSCE = "MNC_FN_DSCE";
            fm01.MNC_FN_GRP = "MNC_FN_GRP";
            fm01.MNC_FN_STS = "MNC_FN_STS";
            fm01.MNC_FN_SP = "";
            fm01.MNC_FN_DS = "";
            fm01.MNC_FN_DS1 = "";
            fm01.MNC_FN_SS = "";
            fm01.MNC_FN_SERP = "";
            fm01.MNC_FN_SERV = "";
            fm01.MNC_FN_SEP_FLG = "";
            fm01.MNC_FN_SEP_CD = "";
            fm01.MNC_MULT_PR_FLG = "";
            fm01.MNC_FN_SERP_I = "";
            fm01.MNC_FN_SERV_I = "";
            fm01.MNC_AC_CD = "";
            fm01.MNC_SUB_O = "";
            fm01.MNC_SUB_I = "";
            fm01.MNC_SUB_H = "";
            fm01.MNC_SUB_P = "";
            fm01.CHRGITEM = "";
            fm01.REP_GRP = "";
            fm01.MNC_OVR_FLG = "";
            fm01.MNC_GRP_SS = "";
            fm01.MNC_DEC_CD = "";
            fm01.MNC_DEC_NO = "";
            fm01.MNC_SIMB_CD = "";
            fm01.MNC_STAMP_DAT = "";
            fm01.MNC_STAMP_TIM = "";
            fm01.MNC_USR_ADD = "";
            fm01.MNC_USR_UPD = "";
            fm01.MNC_FN_DF_STS = "";
            fm01.MNC_CHARGE_CD = "";
            fm01.MNC_SUB_CHARGE_CD = "";
            fm01.MNC_CAL_NURSE_FLG = "";
            fm01.MNC_NURSE_FN_CD = "";
            fm01.MNC_NURSE_PERCNT = "";
            fm01.MNC_NURSE_MIN_AMT = "";
            fm01.MNC_NURSE_MAX_AMT = "";
            fm01.MNC_IO_STS = "";
            fm01.MNC_ENTRY_STS = "";
            fm01.MNC_NURSE_LOCK_STS = "";
            fm01.MNC_MAP_FN_STS = "";
            fm01.MNC_INCOME_OTH_STS = "";
            fm01.MNC_INCOME_OTH_AMT = "";
            fm01.MNC_INCOME_OTH_UPD_STS = "";
            fm01.MNC_SUB_RO = "";
            fm01.MNC_SUB_RI = "";
            fm01.MNC_SUB_RH = "";
            fm01.MNC_UNLOCK_DSC = "";
            fm01.MNC_UNIT = "";
            fm01.MNC_UNIT_E = "";
            fm01.MNC_ACC_NO = "";
            fm01.mnc_grp_ss1 = "mnc_grp_ss1";
            fm01.MNC_GRP_SS2 = "MNC_GRP_SS2";
            fm01.MNC_GRP_SS2_DSC = "MNC_GRP_SS2_DSC";

            fm01.MNC_FN_GRP_DES = "MNC_FN_GRP_DES";

            fm01.table = "finance_m01";
            fm01.pkField = "MNC_FN_CD";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select fm01.*, fm06.MNC_FN_GRP_DSC as MNC_FN_GRP_DES, fm20.MNC_GRP_SS2_DSC " +
                "From " + fm01.table + " fm01 " +
                "Left Join finance_m06 fm06 On fm01."+ fm01.MNC_FN_GRP + " = fm06.MNC_FN_GRP_CD " +
                "Left Join finance_m20 fm20 On fm01.MNC_GRP_SS2 = fm20.MNC_GRP_SS2 " +
                "Where fm01." + fm01.MNC_FN_STS + " ='Y' ";
            dt = conn.selectData(conn.connMainHIS, sql);
            
            return dt;
        }
        public String updateSS2(String code, String ss2)
        {
            String re = "", sql="";

            sql = "Update "+fm01.table +" Set " +
                " "+fm01.MNC_GRP_SS2+"='"+ss2+"' " +
                "Where "+fm01.MNC_FN_CD+"='"+code+"'";
            re = conn.ExecuteNonQuery1(conn.connMainHIS, sql);

            return re;
        }
        public String updateSS2ByM06(String code, String ss2)
        {
            String re = "", sql = "";

            sql = "Update " + fm01.table + " Set " +
                " " + fm01.MNC_GRP_SS2 + "='" + ss2 + "' " +
                "Where " + fm01.MNC_FN_GRP + "='" + code + "'";
            re = conn.ExecuteNonQuery1(conn.connMainHIS, sql);

            return re;
        }
    }
}
