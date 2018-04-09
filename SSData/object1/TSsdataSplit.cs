using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.object1
{
    public class TSsdataSplit:Persistent
    {
        public String ssdata_split_id { get; set; }
        public String ssdata_id { get; set; }
        public String split_no { get; set; }
        public String split_start_date_time { get; set; }
        public String date_time_start { get; set; }
        public String date_time_end { get; set; }
        public String active { get; set; }
        public String status_process { get; set; }
    }
}
