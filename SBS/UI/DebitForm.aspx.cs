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

            if (Session["UserId"] == null)
                Response.Redirect("UserLogin.aspx");

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

        private void LoadAccounts()
        {
            var output = new Business.XSwitch(Global.ConnectionString, Session["Username"].ToString(), string.Format("009|{0}", Session["UserId"].ToString()));
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
                FromDropdown.Items.Add("No Accounts Found");
            }
        }

        protected void DebitButton_Click(object sender, EventArgs e)
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

                if(amount > 1000)
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
    }
}