using SSData.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.objdb
{
    public class BillDispItemsDB
    {
        public BillDispItems bdI;
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
        public String update(BillDispItems p)
        {
            String re = "";
            String sql = "";

            sql = "Update " + bdI.table + " Set " +
                    " " + bdI.chargeamt + "='" + p.chargeamt + "' " +
                    ", " + bdI.claimcat + "='" + p.claimcat + "' " +
                    ", " + bdI.claimcont + "='" + p.claimcont + "' " +
                    ", " + bdI.dfscode + "='" + p.dfscode + "' " +
                    ", " + bdI.dfstext + "='" + p.dfstext + "' " +
                    ", " + bdI.dispid + "='" + p.dispid + "' " +
                    ", " + bdI.drgid + "='" + p.drgid + "' " +
                    ", " + bdI.hospdrgid + "='" + p.hospdrgid + "' " +
                    ", " + bdI.multidisp + "='" + p.multidisp + "' " +
                    ", " + bdI.packsize + "='" + p.packsize + "' " +
                    ", " + bdI.prdcat + "='" + p.prdcat + "' " +
                    ", " + bdI.prdsecode + "='" + p.prdsecode + "' " +
                    ", " + bdI.quantity + "='" + p.quantity + "' " +
                    ", " + bdI.reimbamt + "='" + p.reimbamt + "' " +
                    ", " + bdI.reimbprice + "='" + p.reimbprice + "' " +
                    ", " + bdI.sigcode + "='" + p.sigcode + "' " +
                    ", " + bdI.sigtext + "='" + p.sigtext + "' " +
                    ", " + bdI.supplyfor + "='" + p.supplyfor + "' " +
                    ", " + bdI.unitprice + "='" + p.unitprice + "' " +
                    "Where " + bdI.pkField + "='"+p.billdisp_items_id+"'";

            re = conn.ExecuteNonQuery1(conn.connSSData, sql);

            return re;
        }
        public DataTable selectBySSdId(String ssDId)
        {
            DataTable dt = new DataTable();
            String sql = "select bdi.* " +
                "From " + bdI.table + " bdi " +
                "Left Join t_billdisp bd On bdi.billdisp_id = bd.billdisp_id " +
                "Where bd.ssdata_id ='" + ssDId + "' ";
            dt = conn.selectData(conn.connSSData, sql);
            return dt;
        }
        public DataTable selectByBdId(String bDId)
        {
            DataTable dt = new DataTable();
            String sql = "select bdi.* " +
                "From " + bdI.table + " bdi " +
                "Where bdi."+bdI.billdisp_id+" ='" + bDId + "' ";
            dt = conn.selectData(conn.connSSData, sql);
            return dt;
        }
    }
}
