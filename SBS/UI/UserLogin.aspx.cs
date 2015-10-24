using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace UI
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            if (Username.Text == "" || Password.Text == "")
            {
                MessageBox.Show("Enter the fields");
            }
            else
            {   Session["Username"]=Username.Text;
                Response.Redirect("MakePayment.aspx");
                Response.Redirect("TransferMoney.aspx");
                Response.Redirect("Home.aspx");
                //Response.Redirect("");
                String user = Username.Text;
                String pwd = Encryption.MD5Hash(user);
            }
        }

        protected void Forgotpassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePwd.aspx");
        }

       

       
    }
}