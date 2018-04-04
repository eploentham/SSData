using SSData.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.objdb
{
    public class BillDispItemsDB
    {
        BillDispItems bdI;
        ConnectDB conn;

        public BillDispItemsDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            bdI = new BillDispItems();
            bdI.billdisp_id = "billdisp_id";
            bdI.billdisp_items_id = "billdisp_items_id";
            bdI.chargeamt = "chargeamt";
            bdI.claimcat = "claimcat";
            bdI.claimcont = "claimcont";
            bdI.dfscode = "dfscode";
            bdI.dfstext = "dfstext";
            bdI.dispid = "dispid";
            bdI.drgid = "drgid";
            bdI.hospdrgid = "hospdrgid";
            bdI.multidisp = "multidisp";
            bdI.packsize = "packsize";
            bdI.prdcat = "prdcat";
            bdI.prdsecode = "prdsecode";
            bdI.quantity = "quantity";
            bdI.reimbamt = "reimbamt";
            bdI.reimbprice = "reimbprice";
            bdI.sigcode = "sigcode";
            bdI.sigtext = "sigtext";
            bdI.supplyfor = "supplyfor";
            bdI.unitprice = "unitprice";

            bdI.table = "t_billdisp_items";
            bdI.pkField = "billdisp_items_id";
        }
        public String insert(BillDispItems p)
        {
            String re = "";
            String sql = "";
            //p.active = "1";

            sql = "Insert Into " + bdI.table + "(" + bdI.billdisp_id + "," + bdI.chargeamt + "," + bdI.claimcat + "," +
                bdI.claimcont + "," + bdI.dfscode + "," + bdI.dfstext + "," +
                bdI.dispid + "," + bdI.drgid + "," + bdI.hospdrgid + "," +
                bdI.multidisp + "," + bdI.packsize + "," + bdI.prdcat + "," +
                bdI.prdsecode + "," + bdI.quantity + "," + bdI.reimbamt + "," +
                bdI.reimbprice + "," + bdI.sigcode + "," +
                bdI.sigtext + "," + bdI.supplyfor + "," + bdI.unitprice + " " +                
                ") " +
                "Values('" + p.billdisp_id + "','" + p.chargeamt + "','" + p.claimcat + "','" +
                p.claimcont + "','" + p.dfscode + "','" + p.dfstext.Replace("'","''") + "','" +
                p.dispid + "','" + p.drgid + "','" + p.hospdrgid + "','" +
                p.multidisp + "','" + p.packsize + "','" + p.prdcat + "','" +
                p.prdsecode + "','" + p.quantity + "','" + p.reimbamt + "','" +
                p.reimbprice + "','" + p.sigcode + "','" +
                p.sigtext.Replace("'", "''") + "','" + p.supplyfor + "','" + p.unitprice + "'" +                
                ") ";
            re = conn.ExecuteNonQueryNoClose(conn.connSSDataNoClose, sql);

            return re;
        }
    }
}
