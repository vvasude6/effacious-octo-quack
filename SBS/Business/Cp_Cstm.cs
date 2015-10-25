using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class Cp_Cstm
    {
        Entity.Cstm cstm;
        public Entity.Cstm cstmP
        {
            get
            {
                return this.cstm;
            }
            set
            {
                this.cstm = value;
            }
        }
        public Cp_Cstm(string connectionString, String usr, String pwd, Data.Dber dberr)
        {
            // fetch all details for ac_no = acno.
            cstmP = Data.CstmD.Read(connectionString, usr, pwd, dberr);
        }
    }
}
