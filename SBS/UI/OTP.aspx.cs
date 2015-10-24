using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace UI
{
    public partial class OTP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Pwd_Click(object sender, EventArgs e)
        {   if(OTpwd.Text=="")
        {
            MessageBox.Show("Enter One time Password");
        }
            String otp = Encryption.MD5Hash(OTpwd.Text);
            String new_pwd = Encryption.MD5Hash(NewPwd.Text);
            String conf_pwd = Encryption.MD5Hash(ConfirmPwd.Text);
        }
    }
}