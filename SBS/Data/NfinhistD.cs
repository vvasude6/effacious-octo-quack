using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace Data
{
    public static class NfinhistD
    {
        public static Nfinhist Read(string connectionString, string ref_no)
        {
            try
            {
                var NfinhistObject = new Nfinhist();

                var query = string.Format("select * from Nfinhist where ref_no = {0}", ref_no);
                var data = DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);

                //assign the data object to Error master object
                if (data.Tables[0].Rows.Count > 0)
                {
                    NfinhistObject.ac_no = data.Tables[0].Rows[0]["ac_no"].ToString();
                    NfinhistObject.apprv_empid = data.Tables[0].Rows[0]["apprv_empid"].ToString();
                    NfinhistObject.init_empid = data.Tables[0].Rows[0]["init_empid"].ToString();
                    NfinhistObject.ref_no = data.Tables[0].Rows[0]["ref_no"].ToString();
                    NfinhistObject.tran_date = data.Tables[0].Rows[0]["tran_date"].ToString();
                    NfinhistObject.tran_desc = data.Tables[0].Rows[0]["tran_desc"].ToString();
                    NfinhistObject.tran_timestamp = data.Tables[0].Rows[0]["tran_timestamp"].ToString();
                    // NfinhistObject.apprv_empid = data.Tables[0].Rows[0]["ref_no"].ToString();

                    return NfinhistObject;

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
            var query = string.Format("select * from Nfinhist);
           return  DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);
        }
        public static int Create(string connectionString, Nfinhist dataObject)
        {
            throw new NotImplementedException();
        }

        public static bool Update(string connectionString, Nfinhist dataObject)
        {
            throw new NotImplementedException();
        }
        public static bool Delete(string connectionString, string id)
        {
            throw new NotImplementedException();
        }
    }
}
