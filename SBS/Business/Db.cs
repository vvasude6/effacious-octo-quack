using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class Db
    {
        String data;
        public Db(String sproc_code) // only used for ERRM fetch, because already have a well-formed Dber object
        {
            // execute stored procedure with proc_code. Store result in data
            // ****** if query fails call dbr.setError() ******
        }
        public Db(String sproc_code, Dber dbr)
        {
            // execute stored procedure with proc_code. Store result in data
            // ****** if query fails call dbr.setError() ******
        }
        public String getData()
        {
            return this.data;
        }
    }
}
