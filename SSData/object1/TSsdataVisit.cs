using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.object1
{
    public class TSsdataVisit:Persistent
    {
        public string ssdata_visit_id { get; set; }
        public string ssdata_id { get; set; }
        public string hn_no { get; set; }
        public string vn { get; set; }
        public string visit_date { get; set; }
        public string visit_time { get; set; }
        public string prefix { get; set; }
        public string patient_fname { get; set; }
        public string patient_lname { get; set; }
        public string sex { get; set; }
        public string vn_no { get; set; }
        public string vn_seq { get; set; }
        public string vn_sum { get; set; }
        public string pre_no { get; set; }
        public string birth_day { get; set; }
        public string hn_yr { get; set; }
        public string branch_id { get; set; }
        public string pid { get; set; }
        public string hcode { get; set; }
        public string hcode_owner { get; set; }
        public string active { get; set; }
        public string year_id { get; set; }
        public string month_id { get; set; }
        public string invno { get; set; }
        public string billno { get; set; }
        public string amount { get; set; }
        public string paid { get; set; }
        public string payplan { get; set; }
        public string claimamt { get; set; }
        public string otherpayplan { get; set; }
        public string otherpay { get; set; }
        public string prescdt { get; set; }
        public string dispdt { get; set; }
        public string itemcnt { get; set; }
        public string prescb { get; set; }
        public string svid { get; set; }
        public string ssdata_split_id { get; set; }
    }
}
