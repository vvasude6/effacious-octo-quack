using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Security;

namespace UI
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        private static OTPService _otpService;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //private static String userId = "1234";

        protected void SendOTPBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string[] arglist = new String[2];

                Business.XSwitch xsw = new Business.XSwitch();
                if (!UI.Validate.isUserNameValid(UserNameTextBox.Text))
                {
                    //MessageBox.Show("Invalid User Name");
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Invalid user name');", true);

                    return;
                }
                var output = xsw.getExternalUserDataFromUserName(Global.ConnectionString, UserNameTextBox.Text);
                if (output == null)
                {
                    //MessageBox.Show("Invalid User Name");
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Invalid user name');", true);

                    return;
                }

                Session["TempUserId"] = output.cs_no;
                String userName = output.cs_fname + " " + output.cs_lname;

                _otpService = new OTPService(output.cs_uid + userName);
                _otpService.GenerateOTP(userName, email: output.cs_email);
            }
            catch { }
        }

        protected void ChangePwdBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_otpService.VerifyOTP(OTPTextBox.Text.Trim()))
                {
                    //MessageBox.Show("Could not verify the OTP that you entered.");
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Could not verify the OTP entered');", true);
                    return;
                }

                if (!UI.Validate.isPasswordValid(pwdTextBox.Text) ||
                    hashPwdHiddenField.Value.Equals("0") ||
                    !hashPwdHiddenField.Value.Equals(hashCpwdHiddenField.Value))
                {
                    //MessageBox.Show("Invalid Password Entered, or passwords do not match.");
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Invalid password entered, or password dont match');", true);

                    pwdTextBox.Text = "";
                    cpwdTextBox.Text = "";
                    return;
                }

                string[] arglist = new String[3];
                int argIndex = 0;

                arglist[argIndex++] = Mnemonics.TxnCodes.TX_FORGET_PASSWORD;
                arglist[argIndex++] = Session["TempUserId"].ToString();
                arglist[argIndex++] = hashPwdHiddenField.Value;

                var output = new Business.XSwitch(Global.ConnectionString, Session["TempUserId"].ToString(), string.Format("{0}|{1}|{2}", arglist));

                //MessageBox.Show("Password changed successfully.");
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Password changed successfully');", true);
                _otpService = null;
            }
            catch { }
            Response.Redirect("UserLogin.aspx");
        }
    }
}