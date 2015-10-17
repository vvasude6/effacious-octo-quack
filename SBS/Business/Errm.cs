using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class Errm
    {
        /* 
         *          Error Codes
         * -----------------------------------------------
         * 000: System Error (to be thrown for errors not in ERRM table)
         * 010: Low privilege
         * 011: Account not found
         */
        // ****** if error not found in ERRM, return some text instead of error code ******
        String SPROC = Mnemonics.SP_ERRM_ALL;
        String err_id;
        String err_desc;
        public Errm(String errCode)
        {
            Db fetch = new Db(SPROC);
        }
        public String getData()
        {
            return this.err_desc;
        }
    }
}
