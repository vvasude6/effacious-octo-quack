using Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace UI
{
    public partial class DebitForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserId"] == null || Session["Access"] == null)
                Response.Redirect("UserLogin.aspx");

            if (!IsPostBack)
            {
                if (Global.IsPageAccessible(Page.Title))
                {
                    if (Session["Access"].ToString() == "1" || Session["Access"].ToString() == "2")
                    {
                        FromCustomerDiv.Visible = false;
                        LoadAccounts(Session["UserId"].ToString());
                    }
                    else
                    {
                        FromCustomerDiv.Visible = true;
                        LoadCustomers(Session["UserId"].ToString());
                    }
                }
                else
                {
                    Response.Redirect("Error.aspx?error=NoAccess");
                }
                
            }
        }

        private void LoadCustomers(string internalUserId)
        {
            var xSwitchObject = new Business.XSwitch();

            var output = xSwitchObject.getEmployeeAccessibleCustomerData(Global.ConnectionString, Session["UserId"].ToString());
            if (output.Tables[0].Rows.Count != 0)
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

        private void LoadAccounts(string externalUserId, bool byPass = false)
        {
            if (Session["Access"].ToString() == "1" || Session["Access"].ToString() == "2" || byPass)
            {
                var output = new Business.XSwitch(Global.ConnectionString, Session["Username"].ToString(), string.Format("009|{0}", externalUserId));
                if (output == null)
                    Response.Redirect("Error.aspx");


                if (output.resultSet.Tables[0].Rows.Count != 0)
                {
                    FromDropdown.DataSource = output.resultSet.Tables[0];
                    FromDropdown.DataTextField = "ac_no";
                    FromDropdown.DataValueField = "ac_no";
                    FromDropdown.DataBind();
                    //AccountList.InnerHtml = GetAccountListHtml(output.resultSet);
                }
                else
                {
                    FromDropdown.Items.Add(new ListItem { Text = "No Accounts Found", Value = null });
                }
            }
        }

        protected void DebitButton_Click(object sender, EventArgs e)
        {
            if (Session["Access"].ToString() == "1" || Session["Access"].ToString() == "2")
            {
                if (FromDropdown.SelectedValue == null)
                {
                    MessageBox.Show("Select the Account from which an amount has to be Debited");
                }
                else if (Amount.Text == "" || !UI.Validate.isAmountValid(Amount.Text))
                {
                    MessageBox.Show("Amount cannot be empty, and amount accepts only decimal values.");
                }
                else
                {
                    var amount = Convert.ToDecimal(Amount.Text);

                    if (amount > 1000)
                    {
                        _otpService = new OTPService(Session["UserId"].ToString() + Session["UserName"].ToString());
                        _otpService.GenerateOTP(Session["UserName"].ToString(), email: Session["UserEmail"].ToString());
                        //show otp 
                        DebitButton.Visible = false;
                        OTPDiv.Visible = true;
                    }
                    else
                    {
                        ProcessTransaction(amount);
                    }
                }
            }
        }

        private static OTPService _otpService;
        protected void ResendOTPLink_Click(object sender, EventArgs e)
        {
            _otpService.GenerateOTP(Session["UserName"].ToString(), email: Session["UserEmail"].ToString());
        }

        protected void VerifyButton_Click(object sender, EventArgs e)
        {
            if (_otpService.VerifyOTP(OTPTextBox.Text.Trim()))
            {
                ProcessTransaction(Convert.ToDecimal(Amount.Text));
                ResetPage();
            }

            else
            {
                MessageBox.Show("Could not verify the OTP that you entered.");
            }
        }

        private void ProcessTransaction(decimal amount)
        {
            var output = new Business.XSwitch(Global.ConnectionString, Session["UserId"].ToString(), string.Format("011|{0}| |{1}", FromDropdown.SelectedValue, amount));
            MessageBox.Show(string.Format("The debit was successful. Your current balance is {0}", output.resultP));
        }

        private void ResetPage()
        {
            Amount.Text = string.Empty;
            FromDropdown.SelectedIndex = 0;
            OTPDiv.Visible = false;
            DebitButton.Visible = true;
        }

        protected void CustomerDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAccounts(CustomerDropDown.SelectedValue, byPass: true);
        }
    }
}