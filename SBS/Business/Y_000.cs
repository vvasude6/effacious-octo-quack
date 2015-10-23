using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class Y_000
    {
        Entity.Cstm cstm;
        String TXID;
        String userid;
        String pwd;
        Data.Dber dberr;
        String result;
        Boolean error;
        public Boolean errorGet
        {
            get
            {
                return this.error;
            }
        }
        public Y_000(String txid, String connectionString, String usr, String pwd)
        {
            this.error = false;
            this.TXID = txid;
            this.userid = usr;
            this.pwd = pwd;
            this.dberr = new Data.Dber();
            this.result = " ";
        }
        private int processTransaction(String connectionString, String usr, String pwd)
        {
            /*
             * initiate select query on CSTM, to fetch cus_no for the usr and pwd combination
             * "select cus_no from CSTM where user = usr and pwd = pwd"
             * Using the retrieved cus_no, fetch all account numbers from cstm, and store the retrieved acc nos. 
             * as "|" delimited string in result. For errors, update error with "true"
            */
            return 0;
        }
        public String getOutput()
        {
            return this.result;
        }
    }
}
