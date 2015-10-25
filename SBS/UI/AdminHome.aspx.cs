using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class AdminHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
                Response.Redirect("UserLogin.aspx");

            if (Global.IsPageAccessible(Page.Title))
            {
                //write code here !
            }
        }
    }
}