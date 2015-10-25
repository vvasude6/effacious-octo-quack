using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class EmployeeHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
                Response.Redirect("UserLogin.aspx");

            if (Global.IsPageAccessible(Page.Title))
            {
                LoadPendingTransactions();
            }
        }

        private void LoadPendingTransactions()
        {
            var output = new Business.XSwitch(Global.ConnectionString, Session["Username"].ToString(), string.Format("009|{0}", Session["UserId"].ToString()));
            if (output == null)
                Response.Redirect("UserLogin.aspx");

            if (output.resultSet.Tables[0].Rows.Count != 0)
            {
                GetPendingTransactionTableHtml(output.resultSet);
                //PendingTransactionTable.InnerHtml = GetPendingTransactionTableHtml(output.resultSet);
            }
            else
            {
                //PendingTransactionTable.InnerHtml = 
                //GetPendingTransactionTableHtml();
            }
        }

        private void GetPendingTransactionTableHtml(DataSet data)
        {
            PendingTransactionGridView.DataSource = data;
            PendingTransactionGridView.DataBind();
        }
        
        protected void PendingTransactionGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItem != null)
            {
                var mainPanel = new Panel { CssClass= "btn-group" };
                var approveButton = new Button
                {
                    CssClass = "btn btn-default",
                    CommandArgument = e.Row.Cells[0].Text,
                    CommandName = "Approve",
                    Text = "Approve"
                };
                var rejectButton = new Button
                {
                    CssClass = "btn btn-default",
                    CommandArgument = e.Row.Cells[0].Text,
                    CommandName = "Reject",
                    Text = "Reject",
                };
                var lastIndex = e.Row.Cells.Count == 0 ? 0 : e.Row.Cells.Count - 1;
                mainPanel.Controls.Add(approveButton);
                mainPanel.Controls.Add(rejectButton);
                e.Row.Cells[lastIndex].Controls.Add(mainPanel);
                e.Row.Cells[lastIndex].HorizontalAlign = HorizontalAlign.Right;
            }
        }

        protected void PendingTransactionGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var id = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName.ToLower())
            {
                case "approve":
                    //approve request id
                    break;
                case "reject":
                    //reject request id
                    break;
                default:
                    break;
            }
        }
    }
}
