using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace Data
{
    public static class PendtxnD
    {
        public static Pendtxn Read(string connectionString, string ref_no)
        {
            try
            {
                var PendingTxnMasterObject = new Pendtxn();

                var query = string.Format("select * from Pendtxn where ref_no = {0}", ref_no);
                var data = DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);

                //assign the data object to Error master object
                if (data.Tables[0].Rows.Count > 0)
                {
                    PendingTxnMasterObject.init_empid = data.Tables[0].Rows[0]["ref_no"].ToString();
                    PendingTxnMasterObject.ref_no = data.Tables[0].Rows[0]["ref_no"].ToString();
                    PendingTxnMasterObject.tran_date = data.Tables[0].Rows[0]["ref_no"].ToString();
                    PendingTxnMasterObject.tran_desc = data.Tables[0].Rows[0]["ref_no"].ToString();
                    PendingTxnMasterObject.tran_pvgb = data.Tables[0].Rows[0]["ref_no"].ToString();
                    PendingTxnMasterObject.ac_no = data.Tables[0].Rows[0]["ref_no"].ToString();
                    PendingTxnMasterObject.cr_amt = Convert.ToDecimal(data.Tables[0].Rows[0]["ref_no"]);
                    PendingTxnMasterObject.dr_amt = Convert.ToDecimal(data.Tables[0].Rows[0]["ref_no"]);

                    return PendingTxnMasterObject;
                }

                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataSet ReadAll(string connectionString)
        {
            var query = string.Format("select * from Pendtxn");
            return DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);
        }
        public static int Create(string connectionString, Pendtxn dataObject)
        {
            throw new NotImplementedException();
        }
        public static bool Update(string connectionString, Pendtxn dataObject)
        {
            throw new NotImplementedException();
        }

        public static bool Delete(string connectionString, string id)
        {
            throw new NotImplementedException();
        }
    }
}
