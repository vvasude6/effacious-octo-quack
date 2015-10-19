using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace Data
{
    public static class FinhistD
    {
        public static Finhist Read(string connectionString, string ref_no, Dber dberr)
        {
            try
            {
                var FinHistMasterObject = new Finhist();

                var query = string.Format("select * from FinHist where ref_no = {0}", ref_no);
                var data = DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);

                //assign the data object to ErrorHistry master object
                if (data.Tables[0].Rows.Count > 0)
                {
                    FinHistMasterObject.ref_no = data.Tables[0].Rows[0]["ref_no"].ToString();
                    FinHistMasterObject.init_empid = data.Tables[0].Rows[0]["init_empid"].ToString();
                    FinHistMasterObject.tran_date = data.Tables[0].Rows[0]["tran_date"].ToString();
                    FinHistMasterObject.tran_desc = data.Tables[0].Rows[0]["tran_desc"].ToString();
                    FinHistMasterObject.tran_timestamp = data.Tables[0].Rows[0]["tran_timestamp"].ToString();
                    FinHistMasterObject.rem_bal = data.Tables[0].Rows[0]["rem_bal"].ToString();
                    FinHistMasterObject.cr_amt = Convert.ToDecimal(data.Tables[0].Rows[0]["cr_amt"]);
                    FinHistMasterObject.dr_amt = Convert.ToDecimal(data.Tables[0].Rows[0]["dr_amt"]);
                    FinHistMasterObject.ac_no = data.Tables[0].Rows[0]["ac_no"].ToString();
                    FinHistMasterObject.apprv_empid = data.Tables[0].Rows[0]["apprv_empid"].ToString();


                    return FinHistMasterObject;
                }

                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataSet ReadAll(string connectionString, Dber dberr)
        {
            var query = string.Format("select * from FinHist");
           return DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);

        }
        public static int Create(string connectionString, Finhist dataObject, Dber dberr)
        {
            throw new NotImplementedException();
        }
        public static bool Update(string connectionString, Finhist dataObject, Dber dberr)
        {
            throw new NotImplementedException();
        }

        public static bool Delete(string connectionString, string id, Dber dberr)
        {
            throw new NotImplementedException();
        }
    }
}
