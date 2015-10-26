using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Business
{
    class Y_008
    {
        Cp_Pendtxn pend;
        int pvg;
        String TXID;
        DataSet resultSet;
        public DataSet resultSetP
        {
            get
            {
                return this.resultSet;
            }
            set
            {
                this.resultSet = value;
            }
        }
        Data.Dber dberr;
        String result;
        public Y_008(String connectionString, String txid, int pvg)
        {
            this.TXID = txid;
            this.pvg = pvg;
            this.dberr = new Data.Dber();
            processTransaction(connectionString, this.pvg);
        }
        public int processTransaction(String connectionString, int pvg)
        {
            pend = new Cp_Pendtxn(connectionString, pvg, dberr);
            resultSetP = pend.pendingP;
            if (dberr.ifError())
            {
                result = dberr.getErrorDesc(connectionString);
                return -1;
            }
            return 0;
        }
    }
}
