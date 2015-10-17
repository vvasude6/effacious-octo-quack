using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class Txnm
    {
        char[] delimiter = { '|' };
        String SPROC = Mnemonics.SP_TXNM_ALL;
        String tran_id;
        String tran_desc;
        Int32 tran_pvga;
        Int32 tran_pvgb;
        String tran_fin_type;
        String[] txnmParts;
        public Txnm(String tx_id, Dber dbr)
        {
            // fetch data from Txnm tabke for tran_id = tx_id
            Db fetch = new Db(SPROC, dbr);
            if (!dbr.ifError())
            {
                String db_data = fetch.getData();
                txnmParts = db_data.Split(delimiter);
            }
        }
        public Int32 getInitPrivilegeLevel()
        {
            return this.tran_pvga;
        }
    }
}
