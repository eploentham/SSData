using SSData.object1;
using System;
using System.Collections.Generic;
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
            bt.ptherpay = "ptherpay";
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
                 bt.claimamt + "," + 
                bt.dttran + "," + bt.hcode + "," + bt.hmain + "," +
                bt.hn + "," + bt.invno + "," + bt.memberno + "," +
                bt.name + "," + bt.otherpayplan + "," + bt.paid + "," +
                bt.payplan + "," + bt.pid + "," + bt.ssdata_id + "," +
                bt.ssdata_visit_id + "," + bt.station + "," + bt.tflag + "," +
                bt.vercode +
                ") " +
                "Values('" + p.amount + "','" + p.authcode + "','" + p.billno + "','" +
                p.claimamt + "','" + 
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
    }
}
