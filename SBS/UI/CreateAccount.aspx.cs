using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace UI
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        String callingURL;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Request.UrlReferrer.ToString();
        }

        protected void AccountCreate_click(object sender, EventArgs e)
        {
            try { 
                string[] arglist = new String[2];
                int argIndex = 0;

                arglist[argIndex++] = Mnemonics.TxnCodes.TX_CREATE_ACCOUNT;
                arglist[argIndex++] = AccountTypeDropDownList.Text;
                
                var output = new Business.XSwitch(Global.ConnectionString, Session["UserId"].ToString(), string.Format("{0}|{1}", arglist));
                MessageBox.Show("Request for account created.  Email will be sent when administrator reviews.");
            }
            catch { }
            Response.Redirect(callingURL);

        }
    }
}