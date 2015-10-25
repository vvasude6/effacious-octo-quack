using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Security;
namespace UI
{
    public partial class OTPControl : System.Web.UI.UserControl
    {
        public string Email { get; set; }
        public string Secret { get; set; }
        public string CustomerFullName { get; set; }
        public bool OTPVerified { get; private set; }

        private OTPService _otpService;
        protected void Page_Load(object sender, EventArgs e)
        {
            _otpService = new OTPService(Secret);
        }

        protected void ResendOTPLink_Click(object sender, EventArgs e)
        {
            _otpService.GenerateOTP(CustomerFullName, email: Email);
        }

        protected void VerifyButton_Click(object sender, EventArgs e)
        {
            OTPVerified = _otpService.VerifyOTP(OTPTextBox.Text.Trim());
        }
    }
}
