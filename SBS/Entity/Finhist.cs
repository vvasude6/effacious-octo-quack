using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Finhist
    {
        public String ac_no { get; set; }
        public String ref_no { get; set; }
        public String tran_date { get; set; }
        public String tran_timestamp { get; set; }
        public String tran_desc { get; set; }
        public Decimal dr_amt { get; set; }
        public Decimal cr_amt { get; set; }
        public String rem_bal { get; set; }
        public String init_empid { get; set; }
        public String apprv_empid { get; set; }
    }
}
