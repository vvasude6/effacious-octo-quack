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
        Entity.Cstm cstm = new Entity.Cstm();
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

        public Y_015(String txid, String connectionString, String a, String b, String c, String d, String e, String f,
            String g, String h, String i, String j, String k, String l, String m, String n, String o, String p, String q, String r,
            String s, String t, String u, String v, String w)
        {
            this.TXID = txid;
            dberr = new Data.Dber();
            //this.cusNo = loginAc;
            
            if (processTransaction(connectionString, a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w) != 0)
            {
                this.error = true;
            }
            //processTransaction(connectionString);
        }
        private int processTransaction(String connectionString, String a, String b, String c, String d, String e, String f,
            String g, String j, String h, String i, String l, String m, String n, String k, String o, String p, String q, String r,
            String s, String t, String u, String v, String w)
        {
            this.tx = new Cp_Txnm(connectionString, TXID, dberr);
            // Check if TXNM fetch for transaction type "010" is successful. Return if error encountered
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            cstm.cs_no = a;
            cstm.cs_type = b;
            cstm.cs_fname = c;
            cstm.cs_mname = d;
            cstm.cs_lname = e;
            cstm.cs_addr1 = f;
            cstm.cs_addr2 = g;
            cstm.cs_city = h;
            cstm.cs_state = i;
            cstm.cs_zip = j;
            cstm.cs_branch = k;
            cstm.cs_phn = l;
            cstm.cs_email = m;
            cstm.cs_uid = n;
            cstm.cs_secq1 = o;
            cstm.cs_ans1 = p;
            cstm.cs_secq2 = q;
            cstm.cs_ans2 = r;
            cstm.cs_secq3 = s;
            cstm.cs_ans3 = t;
            cstm.cs_access = u;
            // Fetch data from CSTM. if CS_ACCESS = 'N', registration can be done, else fail txn
            //Entity.Cstm cstm = Data.CstmD.Read(connectionString, this.cusNo, dberr);
            //if (dberr.ifError())
            //{
            //    result = dberr.getErrorDesc(connectionString);
            //    return -1;
            //}
            //if (!cstm.cs_access.Equals("N"))
            //{
            //    dberr.setError(Mnemonics.DbErrorCodes.TXERR_EXISTING_USER);
            //    return -1;
            //}
            //pvg = new Privilege(this.txnPvga, this.usrPvga, this.txnPvgb);
            //if (!pvg.verifyInitPrivilege(dberr))
            //{
            //    result = dberr.getErrorDesc(connectionString);
            //    return -1;
            //}
            //if (!pvg.verifyApprovePrivilege())
            //{
            String inData = this.TXID + "|" + a + "|" + b + "|" + c + "|" + d + "|" + e + "|" + f +
                "|" + g + "|" + j + "|" + h + "|" + i + "|" + l + "|" + m + "|" + n + "|" + k + "|" + o + "|" + p + "|" + q + "|" + r
                + "|" + s + "|" + t + "|" + u + "|" + v + "|" + w;/*this.changeAmount.ToString()*/;
                if (pvg.writeToPendingTxns(
                    connectionString,               /* connection string */
                    "0",                            /* account 1 */
                    "0",                            /* account 2 */
                    a, //initCustomer,              /* customer number */
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
            //}
            var data = Data.CstmD.Create(connectionString, cstm, dberr);
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
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
            /*
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
            }*/
            resultP = "Successful!";
            return 0;
        }
    }
}
