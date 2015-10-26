using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Pendtxn
    {
        private static String DATE_FORMAT = "en-US";
        public Decimal cr_amt { get; set; }
        public String ref_no { get; set; }
        public String tran_date { get; set; }
        public String ac_no { get; set; }
        public String ac_no2 { get; set; }
        public String tran_pvgb { get; set; }
        public String tran_desc { get; set; }
        public String init_empid { get; set; }
        public String init_csno { get; set; }
        public Decimal dr_amt { get; set; }
        public int tran_id { get; set; }
        public string tran_data { get; set; }
        public Pendtxn()
        { }
        public Pendtxn(Decimal cr, String refno, String ac1, String ac2,
            String pvb, String initcsno, String initemp, Decimal dr,String tran_desc, String txid)
        {
            DateTime dt = DateTime.Now;
            this.cr_amt = cr;
            this.ref_no = refno;
            this.tran_date = dt.ToString();
            this.ac_no = ac1;
            this.ac_no2 = ac2;
            this.tran_pvgb = pvb;
            this.tran_desc = tran_desc;
            this.init_empid = initemp;
            this.dr_amt = dr;
            this.init_csno = initcsno;
            this.tran_id = Convert.ToInt32(txid);
        }
    }
}