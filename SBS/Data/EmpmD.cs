using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace Data
{
    public static class EmpmD
    {
        public static Empm Read(string connectionString, string emp_id)
        {
            try
            {
                var EmployeeMasterObject = new Empm();

                var query = string.Format("select * from actm where emp_id = {0}", emp_id);
                var data = DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);

                //assign the data object to employee master object
                if (data.Tables[0].Rows.Count > 0)
                {
                    EmployeeMasterObject.emp_no = data.Tables[0].Rows[0]["emp_no"].ToString();
                    EmployeeMasterObject.emp_fname = data.Tables[0].Rows[0]["emp_fname"].ToString();
                    EmployeeMasterObject.emp_mname = data.Tables[0].Rows[0]["emp_mname"].ToString();
                    EmployeeMasterObject.emp_lname = data.Tables[0].Rows[0]["emp_lname"].ToString();
                    EmployeeMasterObject.emp_phn = data.Tables[0].Rows[0]["emp_phn"].ToString();
                    EmployeeMasterObject.emp_addr1 = data.Tables[0].Rows[0]["emp_addr1"].ToString();
                    EmployeeMasterObject.emp_addr2 = data.Tables[0].Rows[0]["emp_addr2"].ToString();
                    EmployeeMasterObject.emp_city = data.Tables[0].Rows[0]["emp_city"].ToString();
                    EmployeeMasterObject.emp_state = data.Tables[0].Rows[0]["emp_state"].ToString();
                    EmployeeMasterObject.emp_zip = data.Tables[0].Rows[0]["emp_zip"].ToString();
                    EmployeeMasterObject.emp_usr = data.Tables[0].Rows[0]["emp_usr"].ToString();
                    EmployeeMasterObject.emp_pw = data.Tables[0].Rows[0]["emp_pw"].ToString();
                    EmployeeMasterObject.emp_pvg = Convert.ToInt32(data.Tables[0].Rows[0]["emp_pvg"]);
                    EmployeeMasterObject.emp_mngr = data.Tables[0].Rows[0]["emp_mngr"].ToString();
                    EmployeeMasterObject.emp_brnch = data.Tables[0].Rows[0]["emp_brnch"].ToString();
                    EmployeeMasterObject.emp_secq1 = data.Tables[0].Rows[0]["emp_secq1"].ToString();
                    EmployeeMasterObject.emp_ans1 = data.Tables[0].Rows[0]["emp_ans1"].ToString();
                    EmployeeMasterObject.emp_secq2 = data.Tables[0].Rows[0]["emp_secq2"].ToString();
                    EmployeeMasterObject.emp_ans2 = data.Tables[0].Rows[0]["emp_ans2"].ToString();
                    EmployeeMasterObject.emp_ans2 = data.Tables[0].Rows[0]["emp_ans2"].ToString();
                    EmployeeMasterObject.emp_ans3 = data.Tables[0].Rows[0]["emp_ans3"].ToString();
                    EmployeeMasterObject.emp_email = data.Tables[0].Rows[0]["emp_email"].ToString();
                   

                   

                    return EmployeeMasterObject;
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
            var query = string.Format("select * from Empm");
            return DbAccess.ExecuteQuery(connectionString, CommandType.Text, query);

        }
        public static int Create(string connectionString, Empm dataObject)
        {
            throw new NotImplementedException();
        }
        public static bool Update(string connectionString, Empm dataObject)
        {
            throw new NotImplementedException();
        }

        public static bool Delete(string connectionString, string id)
        {
            throw new NotImplementedException();
        }
    }
}
