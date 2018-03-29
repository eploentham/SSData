﻿using SSData.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.objdb
{
    public class TSsdataVisitDB
    {
        TSsdataVisit ssdV;
        ConnectDB conn;

        public TSsdataVisitDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            ssdV = new TSsdataVisit();
            ssdV.birth_day = "birth_day";
            ssdV.branch_id = "branch_id";
            ssdV.hcode = "hcode";
            ssdV.hcode_owner = "hcode_owner";
            ssdV.hn_no = "hn_no";
            ssdV.hn_yr = "hn_yr";
            ssdV.pid = "pid";
            ssdV.patient_fname = "patient_fname";
            ssdV.patient_lname = "patient_lname";
            ssdV.prefix = "prefix";
            ssdV.pre_no = "pre_no";
            ssdV.sex = "sex";
            ssdV.ssdata_id = "ssdata_id";
            ssdV.ssdata_visit_id = "ssdata_visit_id";
            ssdV.visit_date = "visit_date";
            ssdV.visit_time = "visit_time";
            ssdV.vn = "vn";
            ssdV.vn_no = "vn_no";
            ssdV.vn_seq = "vn_seq";
            ssdV.vn_sum = "vn_sum";
            ssdV.active = "active";
            ssdV.year_id = "year_id";
            ssdV.month_id = "month_id";
            ssdV.invno = "month_id";
            ssdV.billno = "month_id";
            ssdV.amount = "month_id";
            ssdV.paid = "month_id";
            ssdV.payplan = "month_id";
            ssdV.claimamt = "month_id";
            ssdV.otherpayplan = "month_id";
            ssdV.otherpay = "month_id";

            ssdV.table = "t_ssdata_visit";
            ssdV.pkField = "ssdata_visit_id";
        }
        public String insert(TSsdataVisit p)
        {
            String re = "";
            String sql = "";
            p.active = "1";

            sql = "Insert Into "+ssdV.table+"("+ssdV.active+","+ssdV.birth_day+","+ssdV.branch_id+","+
                ssdV.hcode+","+ssdV.hcode_owner+","+ssdV.hn_no+","+
                ssdV.hn_yr+","+ssdV.pid+","+ssdV.patient_fname+","+
                ssdV.patient_lname+","+ssdV.prefix+","+ssdV.pre_no+","+
                ssdV.sex+","+ssdV.ssdata_id+","+ssdV.visit_date+","+
                ssdV.visit_time+"," + ssdV.vn + "," + ssdV.vn_no+","+
                ssdV.vn_seq+"," + ssdV.vn_sum + "," + ssdV.year_id + "," + 
                ssdV.month_id + "," + ssdV.invno + "," + ssdV.billno + "," +
                ssdV.amount + "," + ssdV.paid + "," + ssdV.payplan + "," +
                ssdV.claimamt + "," + ssdV.otherpayplan + "," + ssdV.otherpay +
                ") " +
                "Values('" + p.active + "','" + p.birth_day + "','" + p.branch_id + "','" +
                p.hcode + "','" + p.hcode_owner + "','" + p.hn_no + "','" +
                p.hn_yr + "','" + p.pid + "','" + p.patient_fname + "','" +
                p.patient_lname + "','" + p.prefix + "','" + p.pre_no + "','" +
                p.sex + "','" + p.ssdata_id + "','" + p.visit_date + "','" +
                p.visit_time + "','" + p.vn + "','" + p.vn_no + "','" +
                p.vn_seq + "','" + p.vn_sum + "','" + p.year_id + "','" + 
                p.month_id + "','" + p.paid + "','" + p.payplan + "','" +
                p.claimamt + "','" + p.otherpayplan + "','" + p.otherpay +
                "') ";
            re = conn.ExecuteNonQueryNoClose(conn.connSSDataNoClose, sql);

            return re;
        }
    }
}