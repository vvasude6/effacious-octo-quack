using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    // Code for BALANE INQUIRY transaction
    class Y_010
    {
        String TXID = Mnemonics.TX_BALINQ;
        //Byte noInstance = 0;
        String error;
        //Dber dberr;
        Actm acct;
        Txnm tx;
        Privilege pvg;
        Sequence seq;
        Dber dberr;
        String result;
        public String resultP { get; set; }
        public Y_010(String acc_no)
        {
            try
            {
                dberr = new Dber(); // change to Data.Dber
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
            tx = new Txnm(TXID, dberr);
            // Check if TXNM fetch for transaction type "010" is successful. Return if error encountered
            if (dberr.ifError()) 
                return -1;
            acct = new Actm(acc_no, dberr);
            // Check if ACTM fetch for account number acc_no is successful. Return if error encountered
            if (dberr.ifError()) 
                return -1;
            //if (!pvg.verifyInitiatePrivilege(acct.eActm., tx.getInitPrivilegeLevel(), dberr))
            //{
            //    return -1;
            //}
            // Verify if transaction needs to be approved by some authority
            if (tx.getApprovePrivilegeLevel() != 0)
            {
                if (!pvg.verifyApprovePrivilege(acct.eActmg.ac_pvg, tx.txnmP.tran_pvga, dberr))
                {
                    return -1;
                }
                result = Convert.ToString(acct.eActmg.ac_bal);
            }
            // Update Account Balance, etc .....
            // this.updateTransactedData(dberr); // not required for Non Financial transactions

            // Store transaction in hisory table. Determine which history table to store in based on Txnm.getTranFinType()
            if(tx.getTranFinType())
            {
                // Write to FINHIST table
                Finhist fhist = new Finhist();
                fhist.insertIntoFinhist();
            }
            else
            {
                // Write to NFINHIST table
                Nfinhist nFHist = new Nfinhist();
                nFHist.insertIntoNonFinhist();
            }
            return 0;
        }
        private Boolean updateTransactedData()
        {
            return true;
        }
        public String getOutput()
        {
            if(dberr.ifError())
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
