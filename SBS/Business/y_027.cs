using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class Y_027
    {
        String TXID;
        Data.Dber dberr = new Data.Dber();
        String result;
        public String resultP
        {
            get { return result; }
            set { this.result = value; }
        }
        public Y_027(String connectionString, String txid, String empCusId, String loginAc)
        {
            processTransaction(connectionString, empCusId, dberr);
        }
        private int processTransaction(String connectionString, String empCusId, Data.Dber dberr)
        {
            Data.CstmD.deactivateCustomer(connectionString, empCusId, "-1", dberr);
            if (dberr.ifError())
            {
                dberr = new Data.Dber();
                if (!Data.EmpmD.deactivateEmployee(connectionString, empCusId, "-1", dberr))
                {
                    resultP = dberr.getErrorDesc(connectionString);
                    return -1;
                }
            }
            resultP = "Transaction Succeessfuly";
            return 0;
        }
    }
}
