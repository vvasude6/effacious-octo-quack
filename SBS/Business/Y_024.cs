using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class Y_024
    {
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
        Boolean error = false;
        public Y_024(String txid, String connectionString, String cus_no, String pwd)
        {
            dberr = new Data.Dber();
            this.TXID = txid;
            processTransaction(connectionString, cus_no, pwd, dberr);

        }
        private int processTransaction(String connectionString, String cus_no, String pwd, Data.Dber dberr)
        {
            Cp_Txnm tx = new Cp_Txnm(connectionString, TXID, dberr);
            // Check if TXNM fetch for transaction type "010" is successful. Return if error encountered
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            Cp_Cstm cstm = new Cp_Cstm(connectionString, cus_no, dberr);
            cstm.updatePassword(connectionString, cus_no, pwd, dberr);
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            //------------------------------
            //Entity.Cstm cstm = Data.CstmD.Read(connectionString, acct.actmP.cs_no1, dberr);
            String mailResponse = "";
            if (!Security.OTPUtility.SendMail("SBS", "group2csefall2015@gmail.com",
                cstm.cstmP.cs_fname + cstm.cstmP.cs_mname + cstm.cstmP.cs_lname, cstm.cstmP.cs_email,
                "Update from SBS: Password updated via transaction: ", tx.txnmP.tran_desc))
            {
                mailResponse = "Mail sent.";
            }
            //-------------------------------
            resultP = "Successful!" + mailResponse;
            //resultP = "Password Updated Successfully!";
            return 0;
        }
    }
}
