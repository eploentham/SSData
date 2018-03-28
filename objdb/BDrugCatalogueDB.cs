using SSData.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.objdb
{
    public class BDrugCatalogueDB
    {
        BDrugCatalogue dCL;
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
                "Values('" + p.content1 + "','" + p.datechange + "','" + p.dateeffect + "','" +
                p.dateupdate + "','" + p.dfscode + "','" +
                p.distributor + "','" + p.dosageform + "','" + p.drugcat_code + "','" +
                p.genericname + "','" + p.hospdrugcode + "','" + p.ised + "','" +
                p.manufactrer + "','" + p.ndc24 + "','" + p.productcat + "','" +
                p.specprep + "','" + p.strength + "','" + p.tmtid + "','" +
                p.tradename + "','" + p.unitprice + "','" + p.unitsize + "','" +
                p.updateflag + 
                "') ";
            re = conn.ExecuteNonQueryNoClose(conn.connSSDataNoClose, sql);

            return re;
        }
    }
}
