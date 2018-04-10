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
            bt.ssdata_split_id = "ssdata_split_id";

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
                bt.vercode + "," + bt.ssdata_split_id + " " +
                ") " +
                "Values('" + p.amount + "','" + p.authcode + "','" + p.billno + "','" +
                p.claimamt + "','" + p.otherpay + "','" +
                p.dttran + "','" + p.hcode + "','" + p.hmain + "','" +
                p.hn + "','" + p.invno + "','" + p.memberno + "','" +
                p.name.Replace("'", "''") + "','" + p.otherpayplan + "','" + p.paid + "','" +
                p.payplan + "','" + p.pid + "','" + p.ssdata_id + "','" +
                p.ssdata_visit_id + "','" + p.station + "','" + p.tflag + "','" +
                p.vercode + "','" + p.ssdata_split_id + "' " +
                ") ";
            re = conn.ExecuteNonQueryNoClose(conn.connSSDataNoClose, sql);

            return re;
        }
        public String update(BillTran p)
        {
            String re = "";
            String sql = "";
            sql = "Update " + bt.table + " Set " +
                bt.amount + "='" + p.amount + "'" +
                "," + bt.authcode + "='" + p.authcode + "'" +
                "," + bt.billno + "='" + p.billno + "'" +                
                "," + bt.claimamt + "='" + p.claimamt + "'" +
                "," + bt.dttran + "='" + p.dttran + "'" +
                "," + bt.hcode + "='" + p.hcode + "'" +
                "," + bt.hmain + "='" + p.hmain + "'" +
                "," + bt.hn + "='" + p.hn + "'" +
                "," + bt.invno + "='" + p.invno + "'" +
                "," + bt.memberno + "='" + p.memberno + "'" +
                "," + bt.name + "='" + p.name + "'" +
                "," + bt.otherpayplan + "='" + p.otherpayplan + "'" +
                "," + bt.paid + "='" + p.paid + "'" +
                "," + bt.payplan + "='" + p.payplan + "'" +
                "," + bt.pid +"='" + p.pid + "'" +
                "," + bt.otherpay + "='" + p.otherpay + "'" +
                //"," + bt.ssdata_id + "='" + p.ssdata_id + "'" +
                //"," + bt.ssdata_visit_id + "='" + p.ssdata_visit_id + "'" +
                "," + bt.station + "='" + p.station + "'" +
                "," + bt.tflag + "='" + p.tflag + "'" +
                "," + bt.vercode + "='" + p.vercode + "' " +
                "Where " + bt.billtran_id + "='" + p.billtran_id + "'";

            re = conn.ExecuteNonQuery1(conn.connSSData, sql);

            return re;
        }
        public DataTable selectByYearMonth(String yearId, String monthId)
        {
            DataTable dt = new DataTable();
            String sql = "select bt.* " +
                "From " + bt.table + " bt " +
                "Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bt." + bt.ssdata_visit_id +" " +
                "Left Join t_ssdata ss On ss.ssdata_id = ssv.ssdata_id "+
                "Where ss.year_id ='"+yearId+ "' and ss.month_id ='"+monthId+"' and ssv.active = '1' " +
                "Order By bt."+bt.billtran_id;
            dt = conn.selectData(conn.connSSData, sql);
            return dt;
        }
        public DataTable selectByssvID(String ssvId)
        {
            DataTable dt = new DataTable();
            String sql = "select bt.* " +
                "From " + bt.table + " bt " +
                "Left Join t_ssdata ssd On ssd.ssdata_id = bt.ssdata_id " +
                "Where bt."+bt.ssdata_id+" ='" + ssvId + "' " +
                "Order By bt."+bt.dttran;
            dt = conn.selectData(conn.connSSData, sql);
            return dt;
        }
        public DataTable selectByPk(String btId)
        {
            DataTable dt = new DataTable();
            String sql = "select bt.* " +
                "From " + bt.table + " bt " +
                "Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bt.ssdata_visit_id " +
                "Where bt." + bt.billtran_id + " ='" + btId + "' " +
                "Order By bt." + bt.dttran;
            dt = conn.selectData(conn.connSSData, sql);
            return dt;
        }
        public BillTran selectByPk1(String btId)
        {
            BillTran bt1 = new BillTran();
            DataTable dt = new DataTable();
            String sql = "select bt.* " +
                "From " + bt.table + " bt " +
                "Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bt.ssdata_visit_id " +
                "Where bt." + bt.billtran_id + " ='" + btId + "' " +
                "Order By bt." + bt.dttran;
            dt = conn.selectData(conn.connSSData, sql);
            bt1 = setBT(dt);
            return bt1;
        }
        private BillTran setBT(DataTable dt)
        {
            BillTran bt1 = new BillTran();
            if (dt.Rows.Count > 0)
            {
                bt1.amount = dt.Rows[0][bt.amount].ToString();
                bt1.authcode = dt.Rows[0][bt.authcode].ToString();
                bt1.billno = dt.Rows[0][bt.billno].ToString();
                bt1.billtran_id = dt.Rows[0][bt.billtran_id].ToString();
                bt1.claimamt = dt.Rows[0][bt.claimamt].ToString();
                bt1.dttran = dt.Rows[0][bt.dttran].ToString();
                bt1.hcode = dt.Rows[0][bt.hcode].ToString();
                bt1.hmain = dt.Rows[0][bt.hmain].ToString();
                bt1.hn = dt.Rows[0][bt.hn].ToString();
                bt1.invno = dt.Rows[0][bt.invno].ToString();
                bt1.memberno = dt.Rows[0][bt.memberno].ToString();
                bt1.name = dt.Rows[0][bt.name].ToString();
                bt1.otherpayplan = dt.Rows[0][bt.otherpayplan].ToString();
                bt1.paid = dt.Rows[0][bt.paid].ToString();
                bt1.payplan = dt.Rows[0][bt.payplan].ToString();
                bt1.pid = dt.Rows[0][bt.pid].ToString();
                bt1.otherpay = dt.Rows[0][bt.otherpay].ToString();
                bt1.ssdata_id = dt.Rows[0][bt.ssdata_id].ToString();
                bt1.ssdata_visit_id = dt.Rows[0][bt.ssdata_visit_id].ToString();
                bt1.station = dt.Rows[0][bt.station].ToString();
                bt1.tflag = dt.Rows[0][bt.tflag].ToString();
                bt1.vercode = dt.Rows[0][bt.vercode].ToString();
            }            

            return bt1;
        }
    }
}
