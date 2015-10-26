using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * USER REGISTRATION for Online Banking
 */
namespace Business
{
    class Y_015
    {
        Int32 txnPvga = 1;
        Int32 usrPvga = 1;
        Int32 txnPvgb = 5;
        Entity.Pendtxn pendTxn;
        Cp_Txnm tx;
        Data.Dber dberr;
        String result;
        public String resultP
        {
            get
            {
                return this.result;
            }
            set
            {
                this.result = value;
            }
        }
        String TXID;
        String cusNo;
        Boolean newInitiator = false; 
        Privilege pvg;
        Boolean error = false;
        
        public Y_015(String txid, String connectionString, String acc_no, String loginAc)
        {
            this.TXID = txid;
            dberr = new Data.Dber();
            this.cusNo = loginAc;
            if (!acc_no.Equals(loginAc))
            {
                newInitiator = true;
            }
            if (processTransaction(connectionString, acc_no, loginAc) != 0)
            {
                this.error = true;
            }
            //processTransaction(connectionString);
        }
        private int processTransaction(String connectionString, String acct, String loginAc)
        {
            this.tx = new Cp_Txnm(connectionString, TXID, dberr);
            // Check if TXNM fetch for transaction type "010" is successful. Return if error encountered
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            // Fetch data from CSTM. if CS_ACCESS = 'N', registration can be done, else fail txn
            Entity.Cstm cstm = Data.CstmD.Read(connectionString, this.cusNo, dberr);
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            if (!cstm.cs_access.Equals("N"))
            {
                dberr.setError(Mnemonics.DbErrorCodes.TXERR_EXISTING_USER);
                return -1;
            }
            pvg = new Privilege(this.txnPvga, this.usrPvga, this.txnPvgb);
            if (!pvg.verifyInitPrivilege(dberr))
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            if (!pvg.verifyApprovePrivilege())
            {
                String inData = this.TXID + "|" + "0"/*acct.actmP.ac_no*/ + "0" + "0"/*this.changeAmount.ToString()*/;
                if (pvg.writeToPendingTxns(
                    connectionString,               /* connection string */
                    "0", //acct.actmP.ac_no,               /* account 1 */
                    "0",                            /* account 2 */
                    "0", //initCustomer,                   /* customer number */
                    tx.txnmP.tran_pvgb.ToString(),  /* transaction approve privilege */
                    tx.txnmP.tran_desc,             /* transaction description */
                    "0", //initEmpNumber,                  /* initiating employee number */
                    0,                              /* debit amount */
                    0, //this.changeAmount,              /* credit amount */
                    tx.txnmP.tran_id,               /* transaction id (not tran code) */
                    inData,                         /* incoming transaction string in XSwitch */
                    dberr                           /* error tracking object */
                    ) != 0)
                {
                    resultP = dberr.getErrorDesc(connectionString);
                    return -1;
                }
                resultP = Mnemonics.DbErrorCodes.MSG_SENT_FOR_AUTH;
                return 0;
            }
            /*
                if (pvg.isPending)
                {
                    Entity.Pendtxn pending = new Entity.Pendtxn(0, "0", this.cusNo, "0",
                        Convert.ToString(this.txnPvgb), this.cusNo, "0", 0, this.tx.txnmP.tran_desc, this.tx.txnmP.tran_id);
                    Data.PendtxnD.Create(connectionString, pending);
                    if (dberr.ifError())
                    {
                        result = dberr.getErrorDesc(connectionString);
                        return -1;
                    }
                    else
                    {
                        dberr.setError(Mnemonics.TxnCodes.TX_SENT_TO_APPROVER);
                        return -1;
                    }
                }
                else
                {
                    result = dberr.getErrorDesc(connectionString);
                    return -1;
                }
            }*/
            if (tx.txnmP.tran_fin_type.Equals("Y"))
            {
                // Write to FINHIST table
                Entity.Finhist fhist = new Entity.Finhist(cstm.cs_no, "0", this.tx.txnmP.tran_desc,
                    0, 0, "0", "0", "0", "0");
                Data.FinhistD.Create(connectionString, fhist, dberr);
            }
            else
            {
                // Write to NFINHIST table
                Entity.Nfinhist nFhist = new Entity.Nfinhist(cstm.cs_no, "0", this.tx.txnmP.tran_desc, "0", "0", "0");
                Data.NfinhistD.Create(connectionString, nFhist, dberr);
            }
            resultP = "Successful!";
            return 0;
        }
    }
}
