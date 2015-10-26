using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Business
{
    class Cp_Pendtxn
    {
        DataSet pending;
        public DataSet pendingP
        {
            get
            {
                return this.pending;
            }
            set
            {
                this.pending = value;
            }
        }
        public Cp_Pendtxn(String connectionString, int pvg, Data.Dber dberr)
        {
            pendingP = Data.PendtxnD.GetAccessiblePendingTransactions(connectionString, pvg.ToString(), dberr);
        }
    }
}
