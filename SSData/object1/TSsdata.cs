using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.object1
{
    public class TSsdata:Persistent
    {
        public string ssdata_id { get; set; }
        public string year_id { get; set; }
        public string month_id { get; set; }
        public string branch_id { get; set; }
        public string branch_visit_id { get; set; }
        public string active { get; set; }
        public string cnt_hn { get; set; }
        public string cnt_visit { get; set; }
        public string status_precess { get; set; }
        public string date_start { get; set; }
        public string date_end { get; set; }
    }
}
