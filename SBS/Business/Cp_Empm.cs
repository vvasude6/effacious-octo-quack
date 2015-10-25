﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class Cp_Empm
    {
        Entity.Empm empm;
        public Entity.Empm empmP
        {
            get
            {
                return this.empm;
            }
            set
            {
                this.empm = value;
            }
        }
        public Cp_Empm(string connectionString, String usr, String pwd, Data.Dber dberr)
        {
            // fetch all details for ac_no = acno.
            empmP = Data.EmpmD.Read(connectionString, usr, pwd, dberr);
        }
    }
}
