using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class ActmD
    {
        public static Actm Read(string connectionString, string acc_no, Dber dberr)
        {
            try
            {
                var accountMasterObject = new Actm();

                var query = string.Format("select * from actm where ac_no = {0}", acc_no);
                var data = DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);

                //assign the data object to account master object
                if (data.Tables[0].Rows.Count > 0)
                {
                    accountMasterObject.ac_bal = Convert.ToDecimal(data.Tables[0].Rows[0]["ac_bal"]);
                    accountMasterObject.ac_cr_flag = data.Tables[0].Rows[0]["ac_cr_flag"].ToString();
                    accountMasterObject.ac_dr_flag = data.Tables[0].Rows[0]["ac_dr_flag"].ToString();
                    accountMasterObject.ac_hold = Convert.ToDecimal(data.Tables[0].Rows[0]["ac_hold"]);
                    accountMasterObject.ac_no = data.Tables[0].Rows[0]["ac_no"].ToString();
                    accountMasterObject.ac_open_dt = data.Tables[0].Rows[0]["ac_open_dt"].ToString();
                    accountMasterObject.ac_pvg = Convert.ToInt32(data.Tables[0].Rows[0]["ac_pvg"]);
                    accountMasterObject.ac_type = data.Tables[0].Rows[0]["ac_type"].ToString();
                    accountMasterObject.cs_no1 = data.Tables[0].Rows[0]["cs_no1"].ToString();
                    accountMasterObject.cs_no2 = data.Tables[0].Rows[0]["cs_no2"].ToString();

                    return accountMasterObject;
                }
                else
                {
                    dberr.setError(Mnemonics.DbErrorCodes.DBERR_ACTM_NOFIND);
                    return null; 
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet ReadAll(Dber dberr)
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

        public static int Create(Actm actmObject, Dber dberr)
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
        
        public static bool Delete (string acc_no, Dber dber)
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

        public static bool Update(Actm actmObject, Dber dberr)
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
