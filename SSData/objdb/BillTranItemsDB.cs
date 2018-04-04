using SSData.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.objdb
{
    public class BillTranItemsDB
    {
        BillTranItems btI;
        ConnectDB conn;

        public BillTranItemsDB(ConnectDB c)
        {
            conn = c;
            btI = new BillTranItems();
            btI.billmuad = "billmuad";
            btI.billtran_id = "billtran_id";
            btI.billtran_items_id = "billtran_items_id";
            btI.chargeamt = "chargeamt";
            btI.claimamount = "claimamount";
            btI.claimcat = "claimcat";
            btI.claimup = "claimup";
            btI.desc1 = "desc1";
            btI.invno = "invno";
            btI.lccode = "lccode";
            btI.qty = "qty";
            btI.stdcode = "stdcode";
            btI.svdate = "svdate";
            btI.svrefid = "svrefid";
            btI.up = "up";

            btI.table = "t_billtran_items";
            btI.pkField = "billtran_items_id";
        }
        public String insert(BillTranItems p)
        {
            String re = "";
            String sql = "";
            //p.active = "1";

            sql = "Insert Into " + btI.table + "(" + btI.billmuad + "," + btI.billtran_id + "," + btI.chargeamt + "," +
                 btI.claimamount + "," + btI.claimcat + "," + btI.claimup + "," +
                btI.desc1 + "," + btI.invno + "," + btI.lccode + "," +
                btI.qty + "," + btI.stdcode + "," + btI.svdate + "," +
                btI.svrefid + "," + btI.up + 
                ") " +
                "Values('" + p.billmuad + "','" + p.billtran_id + "','" + p.chargeamt + "','" +
                p.claimamount + "','" + p.claimcat + "','" + p.claimup + "','" +
                p.desc1 + "','" + p.invno + "','" + p.lccode + "','" +
                p.qty + "','" + p.stdcode + "','" + p.svdate + "','" +
                p.svrefid + "','" + p.up +
                "') ";
            re = conn.ExecuteNonQueryNoClose(conn.connSSDataNoClose, sql);

            return re;
        }
    }
}
