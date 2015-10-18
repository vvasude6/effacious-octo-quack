using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Pendtxn
    {
        public Decimal cr_amt {get; set;}
        public String ref_no { get; set; }
        public String tran_date { get; set; }
        public String ac_no { get; set; }
        public String tran_pvgb { get; set; }
        public String tran_desc { get; set; }
        public String init_empid { get; set; }
        public Decimal dr_amt { get; set; }
    }
}
