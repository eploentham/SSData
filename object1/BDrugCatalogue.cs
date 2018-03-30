using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.object1
{
    public class BDrugCatalogue:Persistent
    {
        public String drugcat_id { get; set; }
        public String drugcat_code { get; set; }
        public String hospdrugcode { get; set; }
        public String productcat { get; set; }
        public String tmtid { get; set; }
        public String specprep { get; set; }
        public String genericname { get; set; }
        public String tradename { get; set; }
        public String dfscode { get; set; }
        public String dosageform { get; set; }
        public String strength { get; set; }
        public String content1 { get; set; }
        public String distributor { get; set; }
        public String manufactrer { get; set; }
        public String ised { get; set; }
        public String ndc24 { get; set; }
        public String unitsize { get; set; }
        public String unitprice { get; set; }
        public String updateflag { get; set; }
        public String datechange { get; set; }
        public String dateupdate { get; set; }
        public String dateeffect { get; set; }
        public String status_his_ok { get; set; }
    }
}
