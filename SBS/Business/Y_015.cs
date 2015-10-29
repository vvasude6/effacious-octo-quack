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
        Int32 txnPvgb = 5;
        Entity.Pendtxn pendTxn;
        Entity.Empm empm;
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
        Boolean employee = false; 
        Privilege pvg;
        Boolean error = false;

        public Y_015(String txid, String connectionString, String a, String b, String c, String d, String e, String f,
            String g, String h, String i, String j, String k, String l, String m, String n, String o, String p, String q, String r,
            String s, String t, String u, String v, String w, String dummyAc, String dummyRef, String loginAc)
        {
            this.TXID = txid;
            dberr = new Data.Dber();
            //this.cusNo = loginAc;
            
            if (processTransaction(connectionString, a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p,
                q, r, s, t, u, v, w, dummyAc, dummyRef, loginAc) != 0)
            {
                this.error = true;
            }
            //processTransaction(connectionString);
        }
        private int processTransaction(String connectionString, String a, String b, String c, String d, String e, String f,
            String g, String j, String h, String i, String l, String m, String n, String k, String o, String p, String q, String r,
            String s, String t, String u, String v, String w, String dummyAc, String dummyRef, String loginAc)
        {
            int cusPvg = 0;
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
            cstm.cs_pass = u;

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
            empm = Data.EmpmD.Read(connectionString, loginAc, dberr);
            if (!dberr.ifError())
            {
                employee = true;
                dberr = new Data.Dber();
            }
            else
            {
                if (cstm.cs_type.Equals("A") || cstm.cs_type.Equals("1") || cstm.cs_type.Equals(" "))
                {
                    cusPvg = 1;
                }
                if (cstm.cs_type.Equals("B") || cstm.cs_type.Equals("2"))
                {
                    cusPvg = 2;
                }
            }
            if(employee)
            {
                pvg = new Privilege(this.txnPvga, this.txnPvgb, empm.emp_pvg);
            }
            else
            {
                pvg = new Privilege(this.txnPvga, this.txnPvgb, cusPvg);
            }
            if (!pvg.verifyInitPrivilege(dberr))
            {
                    result = dberr.getErrorDesc(connectionString);
                    return -1;
            }
            if (!pvg.verifyApprovePrivilege())
            {
                    String inData = this.TXID + "|" + a + "|" + b + "|" + c + "|" + d + "|" + e + "|" + f +
                        "|" + g + "|" + j + "|" + h + "|" + i + "|" + l + "|" + m + "|" + n + "|" + k + "|" + o +
                        "|" + p + "|" + q + "|" + r + "|" + s + "|" + t + "|" + u + "|" + v + "|" + w ;
                    if (pvg.writeToPendingTxns(
                        connectionString,               /* connection string */
                        "0",                            /* account 1 */
                        "0",                            /* account 2 */
                        "0",                            /* customer number */
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
            //else
            //{
            //int cstmId = Data.CstmD.Create(connectionString, cstm, dberr);

                // Insert new row in Customer table
            int data = Data.CstmD.Create(connectionString, cstm, dberr);
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
              // Write into history table
            
            //if (tx.txnmP.tran_fin_type.Equals("Y"))
            //{
            //        // Write to FINHIST table
            //     Entity.Finhist fhist = new Entity.Finhist(
            //       "0",                        /* Account Number */
            //        w,                          /* Reference Number */
            //        this.tx.txnmP.tran_desc,    /* Transaction Description */
            //        0,                          /* Debit Amount */
            //        0,                          /* Credit Amount */
            //        "0",                        /* Remaining Balance */
            //        "0",                        /* Initiating Employee Id */
            //         loginAc,                    /* Approve Employee Id */
            //        cstmId.ToString()                  /* Initiating Customer Number */
            //        );
            //     Data.FinhistD.Create(connectionString, fhist, dberr);
            //}
            //else
            //{
            //        // Write to NFINHIST table
            //    Entity.Nfinhist nFhist = new Entity.Nfinhist(
            //            "0",                        /* Account Number */
            //            w,                        /* Reference Number */
            //            this.tx.txnmP.tran_desc,    /* Transaction Description */
            //            "0",                        /* Initiating Employee Id */
            //            loginAc,                    /* Approve Employee Id */
            //            cstmId.ToString()           /* Initiating Customer Number */
            //            );
            //    Data.NfinhistD.Create(connectionString, nFhist, dberr);
            //}
            //if (dberr.ifError())
            //{
            //        result = dberr.getErrorDesc(connectionString);
            //        return -1;
            //}
                // Delete the Pending transaction
            if(!Data.PendtxnD.Delete(connectionString, dummyRef))
            {
                    dberr.setError(Mnemonics.DbErrorCodes.DBERR_PENDTXN_DELETE);
                    result = dberr.getErrorDesc(connectionString);
                    return -1;
            }
            //}
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            resultP = "Successful!";
            return 0;
        }
    }
}
