using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace UI
{
    public partial class TransferMoney : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null || Session["Access"] == null)
                Response.Redirect("UserLogin.aspx");
            if (Session["Access"].ToString() == "3" || Session["Access"].ToString() == "4")
                Response.Redirect("EmployeeHome.aspx");
            if (Session["Access"].ToString() == "5")
                Response.Redirect("AdminHome.aspx");

            if (!IsPostBack)
            {
                if (Global.IsPageAccessible(Page.Title))
                {
                    LoadAccounts();
                }
                else
                {
                    Response.Redirect("Error.aspx?error=NoAccess");
                }
            }
        }

        protected void Transfer_Click(object sender, EventArgs e)
        {
            //Send the Message of successful or failure(reason for failure)
            if (FromDropDown.SelectedValue == null || FromDropDown.SelectedValue == "0")
            {
                //MessageBox.Show("Select the sender Account.");
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Select sender account');", true);
            }
            else if (ToTextBox.Text == string.Empty)
            {
                //MessageBox.Show("Enter a valid recepient Account.");
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Enter valid recipient account');", true);
            }
            else if (AmountTransfer.Text == "" || !UI.Validate.isAmountValid(AmountTransfer.Text))
            {
                //MessageBox.Show("Amount cannot be empty, and amount accepts only decimal values.");
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Invalid amount entered');", true);
            }
            else if (ConfirmAmount.Text == "" || !UI.Validate.isAmountValid(ConfirmAmount.Text))
            {
                //MessageBox.Show("Confirmation Amount cannot be empty, and Confirmation Amount accepts only decimal values.");
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Invalid confirmation amount entered');", true);
            }
            else if (ConfirmAmount.Text != AmountTransfer.Text)
            {
                //MessageBox.Show("Amount and Confirmation Amount should be same.");
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Amount confirmation not equal');", true);
            }
            else
            {
                var transferAmount = Convert.ToDecimal(ConfirmAmount.Text);
                var output = new Business.XSwitch(Global.ConnectionString, FromDropDown.SelectedValue, string.Format("021|{0}|{1}|{2}|{3}| ",FromDropDown.SelectedValue, ToTextBox.Text, transferAmount, Session["Access"].ToString()));

                //MessageBox.Show(output.resultP);
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('"+ output.resultP +"');", true);
            }
        }

        private void LoadAccounts()
        {
            var output = new Business.XSwitch(Global.ConnectionString, Session["Username"].ToString(), string.Format("009|{0}", Session["UserId"].ToString()));
            if (output == null)
                Response.Redirect("Error.aspx");


            if (output.resultSet.Tables[0].Rows.Count != 0)
            {
                FromDropDown.DataSource = output.resultSet.Tables[0];
                FromDropDown.DataTextField = "ac_no";
                FromDropDown.DataValueField = "ac_no";
                FromDropDown.DataBind();
                //AccountList.InnerHtml = GetAccountListHtml(output.resultSet);
            }
            else
            {
                FromDropDown.Items.Add("No Accounts Found");
            }
        }

    }
}