using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace UI
{
    public partial class CreditForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAccounts();
        }
        private void LoadAccounts()
        {
            //Return list of Accounts
            /* List<String> Acc=loadaccounts
             //foreach(var acc in SenderAcc)
             //{
                 FromDropDown.Add(acc);
             //}*/
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ToDropdown.SelectedValue == null)
            {
                MessageBox.Show("Select the Account to which Amount has to be Credited ");
            }
            else if (Amount.Text == "")
            {
                MessageBox.Show("Enter the Amount");
            }
            else
            {
                String Amt = Amount.Text;
                //CAll Credit Function
            }

        }
    }
}