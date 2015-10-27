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
    public partial class OTP : System.Web.UI.Page
    {
        private static OTPService _otpService;

        protected void Page_Load(object sender, EventArgs e)
        {
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

            // TODO: Save password
            MessageBox.Show("Password changed successfully.");
            _otpService = null;
            Response.Redirect("UserLogin.aspx");
        }

        protected void SendOTPBtn_Click(object sender, EventArgs e)
        {
            String userId = "1234";
            String userName = "Jon Lammers";
            String userEmail = "jlammer@asu.edu";

            // TODO: Get user Info

            _otpService = new OTPService(userId + userName);
            _otpService.GenerateOTP(userName, email: userEmail);
        }
    }
}