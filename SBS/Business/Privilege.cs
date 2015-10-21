using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mnemonics;

namespace Business
{
    class Privilege
    {
        Int32 tx_pvga;
        Int32 tx_apprv;
        Int32 ac_pvga;
        
        private Cp_Pendtxn pending;
        public Privilege(Int32 a, Int32 b, Int32 c)
        {
            this.tx_pvga = a;
            this.tx_apprv = b;
            this.ac_pvga = c;
            pending = new Cp_Pendtxn();
        }
        public Boolean verifyPrivilege(String connectionString, Data.Dber dberr)
        {
            if(tx_pvga > ac_pvga)
            {
                dberr.setError(Mnemonics.DbErrorCodes.TXERR_INIT_PVG);
                return false;
            }
            if(this.tx_apprv == 0)
            {
                return true;
            }
            //Entity.Pendtxn pending = new Entity.Pendtxn();
            //Data.PendtxnD.Create(connectionString, pending);
            return false; // remove later
        }
        public Boolean verifyApprovePrivilege(Int32 current, Int32 required, Data.Dber dberr)
        {
            if (current < required)
            {
                // Write to PENDTXN table
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
