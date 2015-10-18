using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class Y_011
    {
        String TXID = Mnemonics.TX_DEBIT;
        String error;
        Dber dberr;
        Actm acct;
        Txnm tx;
        Privilege pvg;
        Sequence seq;
        public Y_011(string connectionString, String acc_no)
        {
            try
            {
                dberr = new Dber();
                processTransaction(connectionString, acc_no);
                pvg = new Privilege();
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
            this.tx = new Txnm(connectionString, TXID, dberr);
            // Check if TXNM fetch for transaction type "010" is successful. Return if error encountered
            if (dberr.ifError())
                return -1;
            acct = new Actm(connectionString, acc_no, dberr);
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
            }
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
