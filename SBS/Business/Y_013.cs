using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mnemonics;

namespace Business
{
    class Y_013
    {
        String TXID = Mnemonics.TxnCodes.TX_FUNDS_TRANSFER;
        String error;
        Cp_Actm acct;
        Cp_Txnm tx;
        //Privilege pvg;
        Sequence seq;
        Data.Dber dberr;

        public Y_013(string connectionString, String acc_no1, String acc_no2)
        {
            try
            {
                dberr = new Data.Dber();
                processTransaction(connectionString, acc_no1, acc_no2);
                
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
            //pvg = new Privilege();

            return 0; // remove later
        }
        public String getOutput()
        {
            return "";
            /*if (dberr.ifError())
            {
                return dberr.getErrorDesc(connectionString);
            }
            else
            {
                return Convert.ToString(acct.getBalance());
            }*/
        }
    }
}
