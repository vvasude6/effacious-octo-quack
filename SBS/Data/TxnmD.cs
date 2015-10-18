using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class TxnmD
    {
        public static DataSet ReadAll()
        {
            try
            {
                var query = string.Format("select * from txnm");
                return DbAccess.ExecuteQuery(CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Create(Txnm txnmObject)
        {
            throw new NotImplementedException();
            try
            {
                var query = "";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Delete(string acc_no)
        {
            throw new NotImplementedException();
            try
            {
                var query = "";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Update(Txnm txnmObject)
        {
            throw new NotImplementedException();
            try
            {
                var query = "";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
