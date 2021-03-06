﻿using SSData.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.objdb
{
    public class BillDispDB
    {
        public BillDisp bd;
        ConnectDB conn;

        public BillDispDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            bd = new BillDisp();
            bd.benefitplan = "benefitplan";
            bd.billdisp_id = "billdisp_id";
            bd.chargeamt = "chargeamt";
            bd.claimamt = "claimamt";
            bd.daycover = "daycover";
            bd.dispdt = "dispdt";
            bd.dispestat = "dispestat";
            bd.dispid = "dispid";
            bd.hn = "hn";
            bd.invno = "invno";
            bd.itemcnt = "itemcnt";
            bd.otherpay = "otherpay";
            bd.paid = "paid";
            bd.pid = "pid";
            bd.prescb = "prescb";
            bd.prescdt = "prescdt";
            bd.providerid = "providerid";
            bd.reimburser = "reimburser";
            bd.ssdata_id = "ssdata_id";
            bd.ssdata_visit_id = "ssdata_visit_id";
            bd.svid = "svid";
            bd.ssdata_split_id = "ssdata_split_id";

            bd.table = "t_billdisp";
            bd.pkField = "billdisp_id";
        }
        public String insert(BillDisp p)
        {
            String re = "";
            String sql = "";
            //p.active = "1";

            sql = "Insert Into " + bd.table + "(" + bd.benefitplan + "," + bd.chargeamt + "," + bd.claimamt + "," +
                bd.daycover + "," + bd.dispdt + "," + bd.dispestat + "," +
                bd.dispid + "," + bd.hn + "," + bd.invno + "," +
                bd.itemcnt + "," + bd.otherpay + "," + bd.paid + "," +
                bd.pid + "," + bd.prescb + "," + bd.prescdt + "," +
                bd.providerid + "," + bd.reimburser + "," +
                bd.ssdata_id + "," + bd.ssdata_visit_id + "," + bd.svid + "," +
                bd.ssdata_split_id + " " +
                ") " +
                "Values('" + p.benefitplan + "','" + p.chargeamt + "','" + p.claimamt + "','" +
                p.daycover + "','" + p.dispdt + "','" + p.dispestat + "','" +
                p.dispid + "','" + p.hn + "','" + p.invno + "','" +
                p.itemcnt + "','" + p.otherpay + "','" + p.paid + "','" +
                p.pid + "','" + p.prescb + "','" + p.prescdt + "','" +
                p.providerid + "','" + p.reimburser + "','" +
                p.ssdata_id + "','" + p.ssdata_visit_id + "','" + p.svid + "','" +
                p.ssdata_split_id + "' " +
                ") ";
            re = conn.ExecuteNonQueryNoClose(conn.connSSDataNoClose, sql);

            return re;
        }
        public String update(BillDisp p)
        {
            String re = "";
            String sql = "";

            sql = "Update " + bd.table + " Set " +
                " " + bd.benefitplan + "='" + p.benefitplan + "'" +
                "," + bd.chargeamt + "='" + p.chargeamt + "'" +
                "," + bd.claimamt + "='" + p.claimamt + "'" +
                "," + bd.daycover + "='" + p.daycover + "'" +
                "," + bd.dispdt + "='" + p.dispdt + "'" +
                "," + bd.dispestat + "='" + p.dispestat + "'" +
                "," + bd.dispid + "='" + p.dispid + "'" +
                "," + bd.hn + "='" + p.hn + "'" +
                "," + bd.invno + "='" + p.invno + "'" +
                "," + bd.itemcnt + "='" + p.itemcnt + "'" +
                "," + bd.otherpay + "='" + p.otherpay + "'" +
                "," + bd.paid + "='" + p.paid + "'" +
                "," + bd.pid + "='" + p.pid + "'" +
                "," + bd.prescb + "='" + p.prescb + "'" +
                "," + bd.prescdt + "='" + p.prescdt + "'" +
                "," + bd.providerid + "='" + p.providerid + "'" +
                "," + bd.reimburser + "='" + p.reimburser + "'" +
                "," + bd.svid + "='" + p.svid + "' " +
                "Where " + bd.billdisp_id + "='" + p.billdisp_id + "'";
            re = conn.ExecuteNonQuery1(conn.connSSData, sql);

            return re;
        }
        public DataTable selectByYearMonth(String yearId, String monthId)
        {
            DataTable dt = new DataTable();
            String sql = "select bd.* " +
                "From " + bd.table + " bd " +
                "Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd." + bd.ssdata_visit_id + " " +
                "Left Join t_ssdata ss On ss.ssdata_id = ssv.ssdata_id " +
                "Where ss.year_id ='" + yearId + "' and ss.month_id ='" + monthId + "' and ssv.active = '1' " +
                "Order By bd."+bd.billdisp_id;
            dt = conn.selectData(conn.connSSData, sql);
            return dt;
        }
        public DataTable selectByssvID(String ssvId)
        {
            DataTable dt = new DataTable();
            String sql = "select bd.* " +
                "From " + bd.table + " bd " +
                "Left Join t_ssdata ssd On ssd.ssdata_id = bd.ssdata_id " +
                "Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd." + bd.ssdata_visit_id + " " +
                "Where bd." + bd.ssdata_id + " ='" + ssvId + "' " +
                "Order By ssv.visit_date, ssv.visit_time";
            dt = conn.selectData(conn.connSSData, sql);
            return dt;
        }
        public DataTable selectByPk(String bdId)
        {
            DataTable dt = new DataTable();
            String sql = "select bd.* " +
                "From " + bd.table + " bd " +
                "Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bd." + bd.billdisp_id + " ='" + bdId + "' " ;
            dt = conn.selectData(conn.connSSData, sql);
            return dt;
        }
        public BillDisp selectByPk1(String bdId)
        {
            BillDisp bd1 = new BillDisp();
            DataTable dt = new DataTable();
            String sql = "select bd.* " +
                "From " + bd.table + " bd " +
                "Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bd." + bd.billdisp_id + " ='" + bdId + "' " ;
            dt = conn.selectData(conn.connSSData, sql);
            bd1 = setBD(dt);
            return bd1;
        }
        private BillDisp setBD(DataTable dt)
        {
            BillDisp bd1 = new BillDisp();
            if (dt.Rows.Count > 0)
            {
                bd1.benefitplan = dt.Rows[0][bd.benefitplan].ToString();
                bd1.billdisp_id = dt.Rows[0][bd.billdisp_id].ToString();
                bd1.chargeamt = dt.Rows[0][bd.chargeamt].ToString();
                bd1.claimamt = dt.Rows[0][bd.claimamt].ToString();
                bd1.daycover = dt.Rows[0][bd.daycover].ToString();
                bd1.dispdt = dt.Rows[0][bd.dispdt].ToString();
                bd1.dispestat = dt.Rows[0][bd.dispestat].ToString();
                bd1.dispid = dt.Rows[0][bd.dispid].ToString();
                bd1.hn = dt.Rows[0][bd.hn].ToString();
                bd1.invno = dt.Rows[0][bd.invno].ToString();
                bd1.itemcnt = dt.Rows[0][bd.itemcnt].ToString();
                bd1.otherpay = dt.Rows[0][bd.otherpay].ToString();
                bd1.paid = dt.Rows[0][bd.paid].ToString();
                bd1.pid = dt.Rows[0][bd.pid].ToString();
                bd1.prescb = dt.Rows[0][bd.prescb].ToString();
                bd1.prescdt = dt.Rows[0][bd.prescdt].ToString();
                bd1.providerid = dt.Rows[0][bd.providerid].ToString();
                bd1.reimburser = dt.Rows[0][bd.reimburser].ToString();
                bd1.ssdata_id = dt.Rows[0][bd.ssdata_id].ToString();
                bd1.ssdata_visit_id = dt.Rows[0][bd.ssdata_visit_id].ToString();
                bd1.svid = dt.Rows[0][bd.svid].ToString();
            }

            return bd1;
        }
    }
}
