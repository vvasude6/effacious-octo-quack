using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class Db
    {
        String data;
        public Db()
        { 
        }
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
        public Boolean executeSingleDML(String tableName, String field, String key, String[] dataString, Int32[] dataInt, Dber dbr)
        {
            /*String query = String.Format("update {0} set {1}={2} where {3}={4}", tableName, field, data1, key, data2);
            var outut = Data.DbAccess.ExecuteNonQuery(CommandType.Text, query);*/
            return true;
        }
        public String getData()
        {
            return this.data;
        }
    }
}
