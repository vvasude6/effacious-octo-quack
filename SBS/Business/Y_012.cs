using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class Y_012
    {
        String TXID = Mnemonics.TX_CREDIT;
        String error;
        Dber dberr;
        Actm acct;
        Txnm tx;
        Privilege pvg;
        Sequence seq;
        public Y_012(String acc_no)
        {
            try
            {
                dberr = new Dber();
                processTransaction(acc_no);
                pvg = new Privilege();
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
            if (dberr.ifError())
            {
                return dberr.getErrorDesc();
            }
            else
            {
                return Convert.ToString(acct.getBalance());
            }
        }
    }
}
