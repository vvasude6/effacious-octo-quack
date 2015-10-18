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

        public static Txnm Read(string tran_id)
        {
            try
            {
                var transactionTypeMasterObject = new Txnm();

                var query = string.Format("select * from txnm where tran_id = {0}", tran_id);
                var data = DbAccess.ExecuteQuery(CommandType.Text, query);

                //assign the data object to account master object
                if (data.Tables[0].Rows.Count > 0)
                {
                    transactionTypeMasterObject.tran_desc = data.Tables[0].Rows[0]["tran_desc"] != null ?data.Tables[0].Rows[0]["tran_desc"].ToString() : "";
                    transactionTypeMasterObject.tran_fin_type = data.Tables[0].Rows[0]["tran_fin_type"] != null ?data.Tables[0].Rows[0]["tran_fin_type"].ToString() : "";
                    transactionTypeMasterObject.tran_id = data.Tables[0].Rows[0]["tran_id"].ToString();
                    transactionTypeMasterObject.tran_pvga = Convert.ToInt16(data.Tables[0].Rows[0]["tran_pvga"].ToString());
                    transactionTypeMasterObject.tran_pvgb = Convert.ToInt16(data.Tables[0].Rows[0]["tran_pvgb"].ToString());

                    return transactionTypeMasterObject;
                }

                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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
