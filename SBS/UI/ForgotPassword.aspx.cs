using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

using Security;

namespace UI
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        private static OTPService _otpService;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private String userId = "1234";

        protected void SendOTPBtn_Click(object sender, EventArgs e)
        {
            string[] arglist = new String[2];

            Business.XSwitch xsw = new Business.XSwitch();
            if (!UI.Validate.isUserNameValid(UserNameTextBox.Text))
             {
                MessageBox.Show("Invalid User Name");
                return;
            }
            var output = xsw.getExternalUserDataFromUserName(Global.ConnectionString, UserNameTextBox.Text);
            if (output == null)
            {
                MessageBox.Show("Invalid User Name");
                return;
            }

            
            userId = output.cs_uid;
            String userName = output.cs_fname + " " + output.cs_lname;

            _otpService = new OTPService(userId + userName);
            _otpService.GenerateOTP(userName, email: output.cs_email);
        }

        protected void ChangePwdBtn_Click(object sender, EventArgs e)
        {
            if (!_otpService.VerifyOTP(OTPTextBox.Text.Trim()))
            {
                MessageBox.Show("Could not verify the OTP that you entered.");
                return;
            }

            if (!UI.Validate.isPasswordValid(pwdTextBox.Text) ||
                hashPwdHiddenField.Value.Equals("0") ||
                !hashPwdHiddenField.Value.Equals(hashCpwdHiddenField.Value))
            {
                MessageBox.Show("Invalid Password Entered, or passwords do not match.");
                pwdTextBox.Text = "";
                cpwdTextBox.Text = "";
                return;
            }

            string[] arglist = new String[3];
            int argIndex = 0;

            arglist[argIndex++] = Mnemonics.TxnCodes.TX_FORGET_PASSWORD;
            arglist[argIndex++] = userId;
            arglist[argIndex++] = hashPwdHiddenField.Value;

            var output = new Business.XSwitch(Global.ConnectionString, userId, string.Format("{0}|{1}|{2}", arglist));

            MessageBox.Show("Password changed successfully.");
            _otpService = null;
            Response.Redirect("UserLogin.aspx");
        }
    }
}