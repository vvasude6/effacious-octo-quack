using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class Y_025
    {
        Cp_Txnm tx;
        Cp_Actm actm;
        Entity.Cstm cstm;
        Entity.Empm empm;
        Data.Dber dberr;
        String result;
        String loginAc;
        Privilege pvg;
        Boolean employee = false;

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
        Boolean error = false;
        public Y_025(String txid, String connectionString, String acType, String refNo, String loginAc)
        {
            dberr = new Data.Dber();
            this.TXID = txid;
            this.loginAc = loginAc;
            processTransaction(connectionString, loginAc, acType, refNo, dberr);
        }
        private int processTransaction(String connectionString, String loginAc, String acType, String refno, Data.Dber dberr)
        {
            tx = new Cp_Txnm(connectionString, TXID, dberr);
            // Check if TXNM fetch for transaction type "010" is successful. Return if error encountered
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            cstm = Data.CstmD.Read(connectionString, loginAc, dberr);
            if (dberr.ifError())
            {
                empm = Data.EmpmD.Read(connectionString, loginAc, dberr);
                if (dberr.ifError())
                {
                    result = dberr.getErrorDesc(connectionString);
                    return -1;
                }
                else
                {
                    employee = true;
                }
            }
            if (employee)
            {
                pvg = new Privilege(this.tx.txnmP.tran_pvga, this.tx.txnmP.tran_pvgb, Convert.ToInt32(this.empm.emp_pvg));
            }
            else
            {
                pvg = new Privilege(this.tx.txnmP.tran_pvga, this.tx.txnmP.tran_pvgb, Convert.ToInt32(this.cstm.cs_type));
            }
            if (!pvg.verifyInitPrivilege(dberr))
            {
                 result = dberr.getErrorDesc(connectionString);
                 return -1;
            }
            if (!pvg.verifyApprovePrivilege())
            {
                String inData = this.TXID + "|" + acType;
                    if (pvg.writeToPendingTxns(
                        connectionString,               /* connection string */
                        "0",                            /* account 1 */
                        "0",                            /* account 2 */
                        this.cstm.cs_no,                /* customer number */
                        tx.txnmP.tran_pvgb.ToString(),  /* transaction approve privilege */
                        tx.txnmP.tran_desc,             /* transaction description */
                        "0",                            /* initiating employee number */
                        0,                              /* debit amount */
                        0,                              /* credit amount */
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

            actm = new Cp_Actm(connectionString, loginAc, "0", acType, 0, 0, 1, "Y", "Y", DateTime.Now.ToString(), true);
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            int retCode = Data.ActmD.Create(connectionString, actm.actmP, dberr);
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            if (!Data.PendtxnD.Delete(connectionString, refno))
            {
                dberr.setError(Mnemonics.DbErrorCodes.DBERR_PENDTXN_DELETE);
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            return 0;
        }
    }
}
