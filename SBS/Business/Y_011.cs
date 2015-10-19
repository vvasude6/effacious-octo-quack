using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mnemonics;

namespace Business
{
    class Y_011
    {
        String TXID = Mnemonics.TxnCodes.TX_DEBIT;
        String error;
        Data.Dber dberr;
        Cp_Actm acct;
        Cp_Txnm tx;
        Privilege pvg;
        Sequence seq;
        public Y_011(string connectionString, String acc_no)
        {
            try
            {
                dberr = new Data.Dber();
                processTransaction(connectionString, acc_no);
                //pvg = new Privilege();
                // seq will generate and store transaction reference no.
                seq = new Sequence(TXID);
            }
            catch(Exception e)
            {
                error = e.ToString();
            }
        }
        private int processTransaction(string connectionString, String acc_no)
        {
            /*this.tx = new Cp_Txnm(connectionString, TXID, dberr);
            // Check if TXNM fetch for transaction type "010" is successful. Return if error encountered
            if (dberr.ifError())
                return -1;
            acct = new Cp_Actm(connectionString, acc_no, dberr);
            // Check if ACTM fetch for account number acc_no is successful. Return if error encountered
            if (dberr.ifError())
                return -1;
            if (!pvg.verifyInitiatePrivilege(acct.getPrivilegeLevel(), tx.getInitPrivilegeLevel(), dberr))
            {
                return -1;
            }
            // Verify if transaction needs to be approved by some authority
            if (tx.getApprovePrivilegeLevel() != 0)
            {
                if (!pvg.verifyApprovePrivilege(acct.getPrivilegeLevel(), tx.getInitPrivilegeLevel(), dberr))
                {
                    return -1;
                }
            }*/
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
