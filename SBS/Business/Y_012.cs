using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mnemonics;

namespace Business
{
    class Y_012
    {
        String TXID = Mnemonics.TxnCodes.TX_CREDIT;
        String error;
        Data.Dber dberr;
        Cp_Actm acct;
        Cp_Txnm tx;
        Privilege pvg;
        Sequence seq;
        public Y_012(String acc_no)
        {
            try
            {
                dberr = new Data.Dber();
                processTransaction(acc_no);
                //pvg = new Privilege();
                // seq will generate and store transaction reference no.
                seq = new Sequence(TXID);
            }
            catch(Exception e)
            {
                error = e.ToString();
            }
        }
        private int processTransaction(String acc_no)
        {
            return 0; // remove later
        }
        public String getOutput()
        {
            return "";
            /*if (dberr.ifError())
            {
                return dberr.getErrorDesc();
            }
            else
            {
                return Convert.ToString(acct.getBalance());
            }*/
        }
    }
}
