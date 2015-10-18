using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class Privilege
    {
        private Pendtxn pending;
        public Privilege()
        {
            pending = new Pendtxn();
        }
        public Boolean verifyInitiatePrivilege(Int32 current, Int32 required, Dber dberr)
        {
            if(current < required)
            {
                dberr.setError(Mnemonics.ERR_PRIV);
                return false;
            }
            else
            {
                return true;
            }
        }
        public Boolean verifyApprovePrivilege(Int32 current, Int32 required, Dber dberr)
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
