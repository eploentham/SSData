using SSData.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.objdb
{
    public class BillTranDB
    {
        public BillTran bt;
        ConnectDB conn;

        public BillTranDB(ConnectDB c)
        {
            conn = c;
            bt = new BillTran();
            bt.amount = "amount";
            bt.authcode = "authcode";
            bt.billno = "billno";
            bt.billtran_id = "billtran_id";
            bt.claimamt = "claimamt";
            bt.dttran = "dttran";
            bt.hcode = "hcode";
            bt.hmain = "hmain";
            bt.hn = "hn";
            bt.invno = "invno";
            bt.memberno = "memberno";
            bt.name = "name";
            bt.otherpayplan = "otherpayplan";
            bt.paid = "paid";
            bt.payplan = "payplan";
            bt.pid = "pid";
            bt.otherpay = "otherpay";
            bt.ssdata_id = "ssdata_id";
            bt.ssdata_visit_id = "ssdata_visit_id";
            bt.station = "station";
            bt.tflag = "tflag";
            bt.vercode = "vercode";

            bt.table = "t_billtran";
            bt.pkField = "billtran_id";
        }
        public String insert(BillTran p)
        {
            String re = "";
            String sql = "";
            //p.active = "1";

            sql = "Insert Into " + bt.table + "(" + bt.amount + "," + bt.authcode + "," + bt.billno + "," +
                bt.claimamt + "," + bt.otherpay + ","+
                bt.dttran + "," + bt.hcode + "," + bt.hmain + "," +
                bt.hn + "," + bt.invno + "," + bt.memberno + "," +
                bt.name + "," + bt.otherpayplan + "," + bt.paid + "," +
                bt.payplan + "," + bt.pid + "," + bt.ssdata_id + "," +
                bt.ssdata_visit_id + "," + bt.station + "," + bt.tflag + "," +
                bt.vercode +
                ") " +
                "Values('" + p.amount + "','" + p.authcode + "','" + p.billno + "','" +
                p.claimamt + "','" + p.otherpay + "','" +
                p.dttran + "','" + p.hcode + "','" + p.hmain + "','" +
                p.hn + "','" + p.invno + "','" + p.memberno + "','" +
                p.name.Replace("'", "''") + "','" + p.otherpayplan + "','" + p.paid + "','" +
                p.payplan + "','" + p.pid + "','" + p.ssdata_id + "','" +
                p.ssdata_visit_id + "','" + p.station + "','" + p.tflag + "','" +
                p.vercode +
                "') ";
            re = conn.ExecuteNonQueryNoClose(conn.connSSDataNoClose, sql);

            return re;
        }
        public DataTable selectByYearMonth(String yearId, String monthId)
        {
            DataTable dt = new DataTable();
            String sql = "select bt.* " +
                "From " + bt.table + " bt " +
                "Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bt." + bt.ssdata_visit_id +" " +
                "Left Join t_ssdata ss On ss.ssdata_id = ssv.ssdata_id "+
                "Where ss.year_id ='"+yearId+ "' and ss.month_id ='"+monthId+"' and ssv.active = '1' ";
            dt = conn.selectData(conn.connSSData, sql);
            return dt;
        }
        public DataTable selectByssvID(String ssvId)
        {
            DataTable dt = new DataTable();
            String sql = "select bt.* " +
                "From " + bt.table + " bt " +
                "Left Join t_ssdata ssd On ssd.ssdata_id = bt.ssdata_id " +
                "Where bt."+bt.ssdata_id+" ='" + ssvId + "' ";
            dt = conn.selectData(conn.connSSData, sql);
            return dt;
        }
    }
}
