using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }
                
        protected void Forgotpassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserNameTextBox.Text == string.Empty || hashPasswordHiddenField.Value == string.Empty)
                {
                    //MessageBox.Show("Looks like you have not entered the username and/or the password. They are required for sign in.");
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Looks like you have not entered the username and/or the password. They are required for sign in.');", true);
                }
                else
                {
                    var userName = UserNameTextBox.Text.ToString();
                    var password = hashPasswordHiddenField.Value;
                    if (UI.Validate.isUserNameValid(userName))
                    {
                        var xSwitch = new Business.XSwitch();
                        //var encryptedConnectionString = Security.PKIService.EncryptData(Global.ConnectionString, xSwitch.getBankPublicKey(Global.ConnectionString));
                        var encryptedUserName = Security.PKIService.EncryptData(userName, xSwitch.getBankPublicKey(Global.ConnectionString));
                        var encryptedData = Security.PKIService.EncryptData(string.Format("{0}|{1}", userName, password), xSwitch.getBankPublicKey(Global.ConnectionString));

                        Session["Username"] = userName.Trim();
                        //var xSwitchObject = new Business.XSwitch(Global.ConnectionString, userName, string.Format("001|{0}|{1}", userName, password));
                        var xSwitchObject = new Business.XSwitch(Global.ConnectionString, encryptedUserName, "001|" + encryptedData);
                        
                        var encrytedOutput = xSwitchObject.resultP;
                        var output = (string)Security.PKIService.DecryptData(encrytedOutput, xSwitchObject.getCustomerPrivateKey(Global.ConnectionString, userName.ToString()));
                        if (output.Contains("|"))
                        {
                            var dataRecieved = output.Split('|');
                            Session["UserId"] = dataRecieved[0];
                            Session["UserName"] = dataRecieved[1].Trim() + " " + dataRecieved[2].Trim();
                            Session["Access"] = dataRecieved[3];
                            Session["UserEmail"] = dataRecieved[4];
                            switch (dataRecieved[3])
                            {
                                case "1":
                                    Response.Redirect("Home.aspx");
                                    break;
                                case "2":
                                    Response.Redirect("MerchantHome.aspx");
                                    break;
                                case "3":
                                case "4":
                                    Response.Redirect("EmployeeHome.aspx");
                                    break;
                                case "5":
                                    Response.Redirect("AdminHome.aspx");
                                    break;
                                default:
                                    //MessageBox.Show("Looks like we could not log you in. Please check the details you have entered.");
                                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Login failed, check userid and password');", true);
                                    break;
                            }
                        }
                        else
                        {
                            //MessageBox.Show(output);
                            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Login failed, check userid and password');", true);
                        }
                    }
                    else
                    {
                        //MessageBox.Show("Looks like we could not log you in. Please check the details you have entered.");
                        //var message = "Looks like we could not log you in. Please check the details you have entered.";
                        ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Login failed, check userid and password');", true);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void ForgotPasswordLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx");
        }
    }
}