using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.object1
{
    public class TSsdataVisitItems:Persistent
    {
        public String ssdata_visit_items_id { get; set; }
        public String ssdata_visit_id { get; set; }
        public String ssdata_id { get; set; }
        public String invno { get; set; }
        public String svdate { get; set; }
        public String billmuad { get; set; }
        public String llcode { get; set; }
        public String stdcode { get; set; }
        public String desc1 { get; set; }
        public String qty { get; set; }
        public String up { get; set; }
        public String chargeamt { get; set; }
        public String claimup { get; set; }
        public String claimamount { get; set; }
        public String svrefid { get; set; }
        public String claimcat { get; set; }
        public String active { get; set; }
    }
}
