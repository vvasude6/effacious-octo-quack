using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAccounts();
        }

        private void LoadAccounts()
        {
            AccountList.InnerHtml = GetAccountListHtml();
        }

        private string GetAccountListHtml()
        {
            //get list of accounts for logged in user from business !
            //then loop through all accounts and build a html in the following format
            //<li class='list-group-item'> <span class='badge'>$14</span> Sample format </li>

            var sb = new StringBuilder();

            sb.Append(string.Format("<li class='list-group-item'> <span class='custombadge badge'>{1}</span> {0} </li>", "Savings Account", "$450.00"));
            sb.Append(string.Format("<li class='list-group-item'> <span class='custombadge badge'>{1}</span> {0} </li>", "Checkings Account", "$50.00"));

            return sb.ToString();
        }
    }
}