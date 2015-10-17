using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Actm
    {
        char[] delimiter = { '|' };
        String SPROC = Mnemonics.SP_ACTM_ALL;
        //static String errCode = "-DbErr";
        //------
        String ac_no;
        String cs_no1;
        String cs_no2;
        String ac_type;
        Decimal ac_bal;
        Decimal ac_hold;
        Int32 ac_pvg;
        String ac_dr_flag;
        String ac_cr_flag;
        String ac_open_dt;
        //------
        String[] actmParts;
        public Actm(String acno, Dber dbr)
        {
            // fetch all details for ac_no = acno.
            // call to specific stored procedure
            Db fetch = new Db(SPROC, dbr);
            if (dbr.ifError())
            {
                // store in ERRHIST
            }
            else
            {
                String db_data = fetch.getData();
                actmParts = db_data.Split(delimiter);
            }
        }
        public Int32 getPrivilegeLevel()
        {
            return this.ac_pvg;
        }
        public Decimal getBalance()
        {
            return this.ac_bal;
        }
    }
}
