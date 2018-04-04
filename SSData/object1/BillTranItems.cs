using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.object1
{
    public class BillTranItems:Persistent
    {
        public String billtran_items_id { get; set; }
        public String billtran_id { get; set; }
        public String invno { get; set; }
        public String svdate { get; set; }
        public String billmuad { get; set; }
        public String lccode { get; set; }
        public String stdcode { get; set; }
        public String desc1 { get; set; }
        public String qty { get; set; }
        public String up { get; set; }
        public String chargeamt { get; set; }
        public String claimup { get; set; }
        public String claimamount { get; set; }
        public String svrefid { get; set; }
        public String claimcat { get; set; }
    }
}
