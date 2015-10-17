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
        Byte noInstance = 0;
        String error;
        Dber dberr;
        Actm acct;
        Txnm tx;
        public Y_010(String acc_no)
        {
            try
            {
                dberr = new Dber();
                noInstance++;
                processTransaction(acc_no);
            }
            catch(Exception e)
            {
                error = e.ToString();
            }
        }
        private int processTransaction(String acc_no)
        {
            this.tx = new Txnm(TXID, dberr);
            if (dberr.ifError()) 
                return -1;
            acct = new Actm(acc_no, dberr);
            if (dberr.ifError()) 
                return -1;
            if(acct.getPrivilegeLevel() < tx.getInitPrivilegeLevel()) 
            {
                dberr.setError(Mnemonics.ERR_PRIV);
                return -1;
            }
            return 0;
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
