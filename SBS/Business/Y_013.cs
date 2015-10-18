using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class Y_013
    {
        String TXID = Mnemonics.TX_FUNDS_TRANSFER;
        String error;
        Dber dberr;
        Actm acct;
        Txnm tx;
        Privilege pvg;
        Sequence seq;
        public Y_013(string connectionString, String acc_no1, String acc_no2)
        {
            try
            {
                dberr = new Dber();
                processTransaction(connectionString, acc_no1, acc_no2);
                pvg = new Privilege();
                // seq will generate and store transaction reference no.
                seq = new Sequence(TXID);
            }
            catch(Exception e)
            {
                error = e.ToString();
            }
        }
        private int processTransaction(string connectionString, String acc1, String acc2)
        {
            String result; // remove later
            Y_011 y011 = new Y_011(connectionString, acc1);
            result = y011.getOutput();

            Y_012 y012 = new Y_012(acc2);
            result = y012.getOutput();

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
