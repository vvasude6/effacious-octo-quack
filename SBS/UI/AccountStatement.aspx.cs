using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class AccountStatement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null || Session["Access"] == null)
                Response.Redirect("UserLogin.aspx");
            if (Session["Access"].ToString() == "3" || Session["Access"].ToString() == "4")
                Response.Redirect("EmployeeHome.aspx");
            if (Session["Access"].ToString() == "5")
                Response.Redirect("AdminHome.aspx");

            if (Global.IsPageAccessible(Page.Title))
            {
                LoadFinancialAccountStatement();
                //LoadNonFinancialAccountStatement();
            }
        }

        private void LoadFinancialAccountStatement()
        {
            var xSwitch = new Business.XSwitch();
            FinHistoryGridView.DataSource= xSwitch.getFinHistory(Global.ConnectionString, Session["UserId"].ToString());
            FinHistoryGridView.DataBind();
        }

        //private void LoadNonFinancialAccountStatement()
        //{
        //    var xSwitch = new Business.XSwitch();
        //    NonFinHistoryGridView.DataSource = xSwitch.getNonFinHistory(Global.ConnectionString, Session["UserId"].ToString());
        //    NonFinHistoryGridView.DataBind();
        //}
    }
}