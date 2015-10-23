using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Mnemonics;

namespace Business
{
    // Code for BALANE INQUIRY transaction
    class Y_010
    {
        String TXID;
        String error;
        Cp_Actm acct;
        Cp_Txnm tx;
        Privilege pvg;
        Sequence seq;
        Data.Dber dberr;
        String result;
        public String resultGet
        {
            get
            {
                return this.result;
            }
        }
        public String resultP { get; set; }
        public Y_010(String txid, String connectionString, String acc_no)
        {
            try
            {
                this.TXID = txid;
                dberr = new Data.Dber(); // change to Data.Dber
                processTransaction(connectionString, acc_no, dberr);
                // seq will generate and store transaction reference no.
                seq = new Sequence(TXID);
            }
            catch(Exception e)
            {
                error = e.ToString();
            }
        }
        private int processTransaction(string connectionString, String acc_no, Data.Dber dberr)
        {
            tx = new Cp_Txnm(connectionString, TXID, dberr);
            // Check if TXNM fetch for transaction type "010" is successful. Return if error encountered
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            acct = new Cp_Actm(connectionString, acc_no, dberr);
            // Check if ACTM fetch for account number acc_no is successful. Return if error encountered
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            // Verify if account has the privilege to execute the transaction
            pvg = new Privilege(tx.txnmP.tran_pvga, tx.txnmP.tran_pvgb, acct.actmP.ac_pvg);
            if(!pvg.verifyPrivilege(connectionString, dberr))
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            // Store transaction in hisory table. Determine which history table to store in based on tx.txnmP.tran_fin_type
            if (tx.txnmP.tran_fin_type.Equals('Y'))
            {
                // Write to FINHIST table
                Entity.Finhist fhist = new Entity.Finhist(this.acct.actmP.ac_no, "0", this.tx.txnmP.tran_desc,
                    0, 0, Convert.ToString(this.acct.actmP.ac_bal), "0", "0");
                Data.FinhistD.Create(connectionString, fhist, dberr);
            }
            else
            {
                // Write to NFINHIST table
                Entity.Nfinhist nFhist = new Entity.Nfinhist(this.acct.actmP.ac_no, "0", this.tx.txnmP.tran_desc, "0", "0");
                Data.NfinhistD.Create(connectionString, nFhist, dberr);
            }
            result = Convert.ToString(acct.actmP.ac_bal - acct.actmP.ac_hold);
            return 0;
        }
        private Boolean updateTransactedData()
        {
            return true;
        }
        public String getOutput()
        {
            return result;
            /*if(dberr.ifError())
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
