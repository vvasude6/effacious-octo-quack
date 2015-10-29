using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace UI
{
    public partial class MakePayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserId"] == null || Session["Access"] == null)
                    Response.Redirect("UserLogin.aspx");
                if (Session["Access"].ToString() == "5")
                    Response.Redirect("AdminHome.aspx");
                else if (Session["Access"].ToString() == "1")
                    Response.Redirect("Home.aspx");
                else if (Session["Access"].ToString() == "3" || Session["Access"].ToString() == "4")
                    Response.Redirect("EmployeeHome.aspx");

                if (!IsPostBack)
                {
                    if (Global.IsPageAccessible(Page.Title))
                    {
                        if (Session["Access"].ToString() == "2")
                        {
                            LoadCustomers(Session["UserId"].ToString());
                            
                            LoadCurrentUserAccounts();
                        }
                    }
                    else
                    {
                        Response.Redirect("Error.aspx?error=NoAccess");
                    }

                }
            }
            catch { }
        }

        private void LoadCustomers(string internalUserId)
        {
            var xSwitchObject = new Business.XSwitch();

            try
            {
                var output = xSwitchObject.getEmployeeAccessibleCustomerData(Global.ConnectionString, Session["UserId"].ToString());
                if ((output == null) || (output.Tables[0].Rows.Count != 0))
                {
                    CustomerDropDown.DataSource = output.Tables[0];
                    CustomerDropDown.DataTextField = "cs_uname";
                    CustomerDropDown.DataValueField = "cs_no";
                    CustomerDropDown.DataBind();
                    //AccountList.InnerHtml = GetAccountListHtml(output.resultSet);
                    LoadAccounts(CustomerDropDown.SelectedValue, byPass: true);
                }
                else
                {
                    CustomerDropDown.Items.Add(new ListItem { Text = "You have access to no customers", Value = "0" });
                }
            }
            catch { }
        }

        private void LoadAccounts(string externalUserId, bool byPass = false)
        {
            try
            {
                if (Session["Access"].ToString() == "2" || byPass)
                {
                    var output = new Business.XSwitch(Global.ConnectionString, Session["UserId"].ToString(), string.Format("009|{0}", externalUserId));
                    if (output == null)
                        Response.Redirect("Error.aspx");

                    if (output.resultSet.Tables.Count > 0)
                    {
                        if (output.resultSet.Tables[0].Rows.Count != 0)
                        {
                            FromDropdown.Items.Clear();
                            FromDropdown.DataSource = output.resultSet.Tables[0];
                            FromDropdown.DataTextField = "ac_no";
                            FromDropdown.DataValueField = "ac_no";
                            FromDropdown.DataBind();
                            //AccountList.InnerHtml = GetAccountListHtml(output.resultSet);
                        }
                        else
                        {
                            FromDropdown.Items.Add(new ListItem { Text = "No Accounts Found", Value = "0" });
                        }
                    }
                    else
                    {
                        FromDropdown.Items.Clear();
                        FromDropdown.Items.Add(new ListItem { Text = "No Accounts Found", Value = "0" });
                    }

                }
            }
            catch {
                
            }
        }

        private void LoadCurrentUserAccounts()
        {
            try
            {
                if (Session["Access"].ToString() == "2")
                {
                    var output = new Business.XSwitch(Global.ConnectionString, Session["UserId"].ToString(), string.Format("009|{0}", Session["UserId"].ToString()));
                    if (output == null)
                        Response.Redirect("Error.aspx");

                    if (output.resultSet.Tables.Count > 0)
                    {
                        if (output.resultSet.Tables[0].Rows.Count != 0)
                        {
                            ToDropdown.Items.Clear();
                            ToDropdown.DataSource = output.resultSet.Tables[0];
                            ToDropdown.DataTextField = "ac_no";
                            ToDropdown.DataValueField = "ac_no";
                            ToDropdown.DataBind();
                            //AccountList.InnerHtml = GetAccountListHtml(output.resultSet);
                        }
                        else
                        {
                            FromDropdown.Items.Add(new ListItem { Text = "No Accounts Found", Value = "0" });
                        }
                    }
                    else
                    {
                        FromDropdown.Items.Clear();
                        FromDropdown.Items.Add(new ListItem { Text = "No Accounts Found", Value = "0" });
                    }

                }
            }
            catch
            {

            }
        }

        protected void MakePayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["Access"].ToString() == "2")
                {
                    if (FromDropdown.SelectedValue == "0")
                    {
                        MessageBox.Show("Select the Account from which an amount has to be Debited");
                    }

                    if (ToDropdown.SelectedValue == "0")
                    {
                        MessageBox.Show("Select the Account to which the amount has to be Debited");
                    }
                    else if (Amount.Text == "" || !UI.Validate.isAmountValid(Amount.Text))
                    {
                        MessageBox.Show("Amount cannot be empty, and amount accepts only decimal values.");
                    }
                    else
                    {
                        var amount = Convert.ToDecimal(Amount.Text);
                        ProcessTransaction(amount);
                    }
                }

                else
                {
                    var amount = Convert.ToDecimal(Amount.Text);
                    ProcessTransaction(amount);
                }
            }
            catch { }

        }

       
        private void ProcessTransaction(decimal amount)
        {
            try
            {
                //TODO:
                //var output = new Business.XSwitch(Global.ConnectionString, Session["UserId"].ToString(), string.Format("011|{0}| |{1}|{2}| ", FromDropdown.SelectedValue, amount, Session["Access"]));
                //MessageBox.Show(string.Format("The debit was successful. Your current balance is {0}", output.resultP));
            }
            catch { }
        }

        private void ResetPage()
        {
            Amount.Text = string.Empty;
            FromDropdown.SelectedIndex = 0;
        }

        protected void CustomerDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAccounts(CustomerDropDown.SelectedValue, byPass: true);
        }
    }
}