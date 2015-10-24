using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class MerchantDisplay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAccounts();
            LoadTransactions();
           
        }
        private void LoadAccounts()
        {
            //return list of accounts with balance
        }
        private void LoadTransactions()
        {
            //List<String> Transactions=return transactions of the merchant function
            foreach(String tran in Transactions)
            {
                
                Transactiontable.Rows.Add(r);
            }
        }
    }
}