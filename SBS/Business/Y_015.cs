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
        String TXID;
        String cusNo;
        Privilege pvg;
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
        public Y_015(String txid, String connectionString, String loginAc)
        {
            this.TXID = txid;
            dberr = new Data.Dber();
            this.cusNo = loginAc;
            processTransaction(connectionString);
        }
        private int processTransaction(String connectionString)
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
            if (!pvg.verifyPrivilege(connectionString, dberr))
            {
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
            }
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
