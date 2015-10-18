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
        public static Actm Read(string acc_no)
        {
            var accountMasterObject = new Actm();
            
            var query = string.Format("select * from actm where ac_no = {0}", acc_no);
            var data = DbAccess.ExecuteQuery(CommandType.Text, query);
            
            //assign the data object to account master object
            if (data.Tables[0].Rows.Count > 0)
            {
                accountMasterObject.ac_bal = Convert.ToDecimal(data.Tables[0].Rows[0].ItemArray[4]);
                accountMasterObject.ac_cr_flag = data.Tables[0].Rows[0].ItemArray[8].ToString();
                accountMasterObject.ac_dr_flag = data.Tables[0].Rows[0].ItemArray[7].ToString();
                accountMasterObject.ac_hold = Convert.ToDecimal(data.Tables[0].Rows[0].ItemArray[5].ToString());
                accountMasterObject.ac_no = data.Tables[0].Rows[0].ItemArray[0].ToString();
                accountMasterObject.ac_open_dt = data.Tables[0].Rows[0].ItemArray[9].ToString();
                accountMasterObject.ac_pvg = Convert.ToInt32(data.Tables[0].Rows[0].ItemArray[6].ToString());
                accountMasterObject.ac_type = data.Tables[0].Rows[0].ItemArray[3].ToString();
                accountMasterObject.cs_no1 = data.Tables[0].Rows[0].ItemArray[1].ToString();
                accountMasterObject.cs_no2 = data.Tables[0].Rows[0].ItemArray[2].ToString();

                return accountMasterObject;
            }

            else
                return null;

        }
    }
}
