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
        Entity.Txnm txnm;
        public Entity.Txnm txnmP { get; set; }
        public Txnm(String tx_id, Dber dbr)
        {
            // fetch data from Txnm tabke for tran_id = tx_id
            txnm = Data.TxnmD.Read(Mnemonics.CONN_STRING, tx_id);
            //Db fetch = new Db(SPROC, dbr);
            //if (!dbr.ifError())
            if(txnm==null)
            {
                dbr.setError("999");
                //String db_data = fetch.getData();
                //txnmParts = db_data.Split(delimiter);
            }
        }
        public Int32 getInitPrivilegeLevel()
        {
            return this.tran_pvga;
        }
        public Int32 getApprovePrivilegeLevel()
        {
            return this.tran_pvgb;
        }
        public Boolean getTranFinType()
        {
            if (this.tran_fin_type.Equals('Y'))
            {
                return true;
            }
            else return false;
        }
    }
}
