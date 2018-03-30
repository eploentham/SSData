using SSData.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.objdb
{
    public class BDrugCatalogueDB
    {
        public BDrugCatalogue dCL;
        ConnectDB conn;
        public BDrugCatalogueDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            dCL = new BDrugCatalogue();
            dCL.content1 = "content1";
            dCL.datechange = "datechange";

            dCL.dateeffect = "dateeffect";
            dCL.dateupdate = "dateupdate";
            dCL.dfscode = "dfscode";
            dCL.distributor = "distributor";
            dCL.dosageform = "dosageform";
            dCL.drugcat_code = "drugcat_code";
            dCL.drugcat_id = "drugcat_id";
            dCL.genericname = "genericname";
            dCL.hospdrugcode = "hospdrugcode";
            dCL.ised = "ised";

            dCL.manufactrer = "manufactrer";
            dCL.ndc24 = "ndc24";
            dCL.productcat = "productcat";
            dCL.specprep = "specprep";
            dCL.strength = "strength";
            dCL.tmtid = "tmtid";
            dCL.tradename = "tradename";
            dCL.unitprice = "unitprice";
            dCL.unitsize = "unitsize";
            dCL.updateflag = "updateflag";
            dCL.status_his_ok = "status_his_ok";

            dCL.table = "b_drugcatalogue";
            dCL.pkField = "drugcat_id";            
        }
        public DataTable selectAll()
        {
            String re = "", sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + dCL.table +" Order By drugcat_id";
            dt = conn.selectDataNoClose(conn.connSSDataNoClose, sql);

            return dt;
        }
        public String selectByCode(String code)
        {
            String re = "", sql = "";
            DataTable dt = new DataTable();
            sql = "Select "+dCL.drugcat_id+" From "+dCL.table + " Where "+dCL.drugcat_code+" = '"+code +"'";
            dt = conn.selectDataNoClose(conn.connSSDataNoClose, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0][dCL.drugcat_id].ToString();
            }

            return re;
        }
        public String selectByHospDrugCode(String hospdrugcode)
        {
            String re = "", sql = "";
            DataTable dt = new DataTable();
            sql = "Select " + dCL.drugcat_id + " From " + dCL.table + " Where " + dCL.hospdrugcode + " = '" + hospdrugcode + "'";
            dt = conn.selectDataNoClose(conn.connSSDataNoClose, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0][dCL.drugcat_id].ToString();
            }

            return re;
        }
        public String updateHospDrugCode(String drug_id, String hospdrugcode)
        {
            String re = "", sql = "";
            DataTable dt = new DataTable();
            sql = "Select mnc_ph_cd From pharmacy_m01 Where mnc_ph_cd = '"+hospdrugcode+"'";
            dt = conn.selectDataNoClose(conn.connMainHISNoClose, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0]["mnc_ph_cd"].ToString();
            }
            else
            {
                re = "";
            }
            if (!re.Equals(""))
            {
                sql = "Update " + dCL.table + " Set " +
                dCL.status_his_ok + "='1' " +
                "Where " + dCL.drugcat_id + "=" + drug_id;
                re = conn.ExecuteNonQueryNoCloseMainHIS(conn.connSSDataNoClose, sql);
            }
            
            return re;
        }
        public String insertDrugCatalogue(BDrugCatalogue p)
        {
            String re = "";
            re = selectByHospDrugCode(p.hospdrugcode);
            if (re.Equals(""))
            {
                re = insert(p);
            }
            else
            {
                p.drugcat_id = re;
                re = update(p);
            }
            return re;
        }
        public String update(BDrugCatalogue p)
        {
            String re = "";
            String sql = "";
            sql = "Update " + dCL.table + " Set " +
                dCL.content1 + "='" + p.content1.Replace("'", "''") + "'" +
                "," + dCL.datechange + "='" + p.datechange + "'" +
                "," + dCL.dateeffect + "='" + p.dateeffect + "'" +
                "," + dCL.dateupdate + "='" + p.dateupdate + "'" +
                "," + dCL.dfscode + "='" + p.dfscode + "'" +
                "," + dCL.distributor + "='" + p.distributor + "'" +
                "," + dCL.dosageform + "='" + p.dosageform.Replace("'", "''") + "'" +
                "," + dCL.drugcat_code + "='" + p.drugcat_code + "'" +
                "," + dCL.genericname + "='" + p.genericname.Replace("'", "''") + "'" +
                "," + dCL.hospdrugcode + "='" + p.hospdrugcode + "'" +
                "," + dCL.ised + "='" + p.ised + "'" +

                "," + dCL.manufactrer + "='" + p.manufactrer.Replace("'", "''") + "'" +
                "," + dCL.ndc24 + "='" + p.ndc24 + "'" +
                "," + dCL.productcat + "='" + p.productcat.Replace("'", "''") + "'" +
                "," + dCL.specprep + "='" + p.specprep + "'" +
                "," + dCL.strength + "='" + p.strength + "'" +
                "," + dCL.tmtid + "='" + p.tmtid + "'" +
                "," + dCL.tradename + "='" + p.tradename.Replace("'", "''") + "'" +
                "," + dCL.unitprice + "='" + p.unitprice + "'" +
                "," + dCL.unitsize + "='" + p.unitsize + "'" +
                "," + dCL.updateflag + "='" + p.updateflag + "' " +
                "Where " + dCL.drugcat_id + "=" + p.drugcat_id;

            re = conn.ExecuteNonQueryNoClose(conn.connSSDataNoClose, sql);
            re = p.drugcat_id;
            return re;
        }
        public String insert(BDrugCatalogue p)
        {
            String re = "";
            String sql = "";

            sql = "Insert Into " + dCL.table + "(" + dCL.content1 + "," + dCL.datechange + "," + dCL.dateeffect + "," +
                dCL.dateupdate + "," + dCL.dfscode + "," +
                dCL.distributor + "," + dCL.dosageform + "," + dCL.drugcat_code + "," +
                dCL.genericname + "," + dCL.hospdrugcode + "," + dCL.ised + "," +
                dCL.manufactrer + "," + dCL.ndc24 + "," + dCL.productcat + "," +
                dCL.specprep + "," + dCL.strength + "," + dCL.tmtid + "," +
                dCL.tradename + "," + dCL.unitprice + "," + dCL.unitsize + "," +
                dCL.updateflag  +
                ") " +
                "Values('" + p.content1.Replace("'","''") + "','" + p.datechange + "','" + p.dateeffect + "','" +
                p.dateupdate + "','" + p.dfscode + "','" +
                p.distributor + "','" + p.dosageform.Replace("'", "''") + "','" + p.drugcat_code + "','" +
                p.genericname.Replace("'", "''") + "','" + p.hospdrugcode + "','" + p.ised + "','" +
                p.manufactrer.Replace("'", "''") + "','" + p.ndc24 + "','" + p.productcat.Replace("'", "''") + "','" +
                p.specprep + "','" + p.strength + "','" + p.tmtid + "','" +
                p.tradename.Replace("'", "''") + "','" + p.unitprice + "','" + p.unitsize + "','" +
                p.updateflag + 
                "') ";
            re = conn.ExecuteNonQueryNoClose(conn.connSSDataNoClose, sql);

            return re;
        }
    }
}
