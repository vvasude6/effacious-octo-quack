using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Business
{
    public class Actm
    {
        
        public String ac_no { get; set; }
        public String cs_no1 { get; set; }
        public String cs_no2 { get; set; }
        public String ac_type { get; set; }
        public Decimal ac_bal { get; set; }
        public Decimal ac_hold { get; set; }
        public Int32 ac_pvg { get; set; }
        public String ac_dr_flag { get; set; }
        public String ac_cr_flag { get; set; }
        public String ac_open_dt { get; set; }
    }
}
