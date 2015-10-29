using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Security;

namespace UI
{
    public partial class PII : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserId"] == null || Session["Access"] == null)
                    Response.Redirect("UserLogin.aspx");
                if (Session["Access"].ToString() == "5")
                    Response.Redirect("AdminHome.aspx");

                if (!IsPostBack)
                {
                    if (Global.IsPageAccessible(Page.Title))
                    {

                        LoadCustomers(Session["UserId"].ToString());

                    }
                    else
                    {
                        Response.Redirect("Error.aspx?error=NoAccess");
                    }

                }
            }
            catch { }
        }
        private string generatedotp;
        protected void Userlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            _otpService = new OTPService(Session["UserId"].ToString() + Session["UserName"].ToString());
            generatedotp = _otpService.GenerateOTP(Session["UserName"].ToString(), email: Session["UserEmail"].ToString());
            OTPDiv.Visible = true;
            

        }
        private static OTPService _otpService;
        protected void ResendOTPLink_Click(object sender, EventArgs e)
        {
            try
            {
                _otpService.GenerateOTP(Session["UserName"].ToString(), email: Session["UserEmail"].ToString());
            }
            catch { }
        }

        protected void VerifyButton_Click(object sender, EventArgs e)
        {
            if (OTPTextBox.Text == generatedotp)
            {
                OTPUtility.SendMail("Group 2", "group2csefall2015@gmail.com", "Government", "sbsgovernment@gmail.com", "PII Information", "body");
                UserDetails.Visible = true;
                try
                {
                    if (IsPostBack)
                        return;

                    FirstNamebox.ForeColor = System.Drawing.Color.Black;
                    MiddleNamebox.ForeColor = System.Drawing.Color.Black;
                    LastNamebox.ForeColor = System.Drawing.Color.Black;
                    Address1box.ForeColor = System.Drawing.Color.Black;
                    Address2box.ForeColor = System.Drawing.Color.Black;
                    Citybox.ForeColor = System.Drawing.Color.Black;
                    Statebox.ForeColor = System.Drawing.Color.Black;
                    Zipbox.ForeColor = System.Drawing.Color.Black;
                    Phnobox.ForeColor = System.Drawing.Color.Black;
                    Mailidbox.ForeColor = System.Drawing.Color.Black;

                    String[] argList = new String[2];
                    argList[0] = Mnemonics.TxnCodes.TX_FETCH_CUSTOMER;
                    argList[1] = Session["UserId"].ToString();

                    var output = new Business.XSwitch(Global.ConnectionString, Session["UserId"].ToString(),
                        string.Format("{0}|{1}", argList));
                    if (output == null)
                        return;

                    String[] profileList = output.resultGet.Split('|');
                    FirstNamebox.Text = profileList[2];
                    MiddleNamebox.Text = profileList[3];
                    LastNamebox.Text = profileList[4];
                    Address1box.Text = profileList[5];
                    Address2box.Text = profileList[6];
                    Citybox.Text = profileList[7];
                    Statebox.Text = profileList[8];
                    Zipbox.Text = profileList[9];
                    Phnobox.Text = profileList[11];
                    Mailidbox.Text = profileList[12];
                }
                catch { }

            }
        }
        private void LoadCustomers(string internalUserId)
        {
            var xSwitchObject = new Business.XSwitch();

            try
            {
                var output = xSwitchObject.getEmployeeAccessibleCustomerData(Global.ConnectionString, Session["UserId"].ToString());
                if ((output == null) || (output.Tables[0].Rows.Count != 0))
                {
                    Userlist.DataSource = output.Tables[0];
                    Userlist.DataTextField = "cs_uname";
                    Userlist.DataValueField = "cs_no";
                    Userlist.DataBind();
                    //AccountList.InnerHtml = GetAccountListHtml(output.resultSet);

                }
                else
                {
                    Userlist.Items.Add(new ListItem { Text = "You have access to no customers", Value = "0" });
                }
            }
            catch { }
        }


    }

}
