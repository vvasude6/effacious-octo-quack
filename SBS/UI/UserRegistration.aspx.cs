using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace UI
{
    public partial class UserRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FirstNameTextBox.ForeColor = System.Drawing.Color.Black;
            MiddleNameTextBox.ForeColor = System.Drawing.Color.Black;
            LastNameTextBox.ForeColor = System.Drawing.Color.Black;
            Addrs1TextBox.ForeColor = System.Drawing.Color.Black;
            Addrs2TextBox.ForeColor = System.Drawing.Color.Black;
            CityTextBox.ForeColor = System.Drawing.Color.Black;
            StateTextBox.ForeColor = System.Drawing.Color.Black;
            ZipTextBox.ForeColor = System.Drawing.Color.Black;
            PhNumTextBox.ForeColor = System.Drawing.Color.Black;
            EmailTextBox.ForeColor = System.Drawing.Color.Black;
            pwdTextBox.ForeColor = System.Drawing.Color.Black;
            cpwdTextBox.ForeColor = System.Drawing.Color.Black;
        }

        protected void CustCreate_Click(object sender, EventArgs e)
        {
            bool errorFound = false;

            if (!(UI.Validate.isUserNameValid(FirstNameTextBox.Text)))
            {
                errorFound = true;
                FirstNameTextBox.ForeColor = System.Drawing.Color.Red;
            }
            else FirstNameTextBox.ForeColor = System.Drawing.Color.Black;
            if (!(UI.Validate.isUserNameValid(MiddleNameTextBox.Text)))
            {
                errorFound = true;
                MiddleNameTextBox.ForeColor = System.Drawing.Color.Red;
            }
            else MiddleNameTextBox.ForeColor = System.Drawing.Color.Black;
            if (!(UI.Validate.isUserNameValid(LastNameTextBox.Text)))
            {
                errorFound = true;
                LastNameTextBox.ForeColor = System.Drawing.Color.Red;
            }
            else LastNameTextBox.ForeColor = System.Drawing.Color.Black;
            if (!(UI.Validate.isAddressValid(Addrs1TextBox.Text)))
            {
                errorFound = true;
                Addrs1TextBox.ForeColor = System.Drawing.Color.Red;
            }
            else Addrs1TextBox.ForeColor = System.Drawing.Color.Black;
            if (!(UI.Validate.isAddressValid(Addrs2TextBox.Text)))
            {
                errorFound = true;
                Addrs2TextBox.ForeColor = System.Drawing.Color.Red;
            }
            else Addrs2TextBox.ForeColor = System.Drawing.Color.Black;
            if (!(UI.Validate.isCityValid(CityTextBox.Text)))
            {
                errorFound = true;
                CityTextBox.ForeColor = System.Drawing.Color.Red;
            }
            else CityTextBox.ForeColor = System.Drawing.Color.Black;
            if (!(UI.Validate.isStateValid(StateTextBox.Text)))
            {
                errorFound = true;
                StateTextBox.ForeColor = System.Drawing.Color.Red;
            }
            else StateTextBox.ForeColor = System.Drawing.Color.Black;
            if (!(UI.Validate.isZipCodeValid(ZipTextBox.Text)))
            {
                errorFound = true;
                ZipTextBox.ForeColor = System.Drawing.Color.Red;
            }
            else ZipTextBox.ForeColor = System.Drawing.Color.Black;
            if (!(UI.Validate.isPhoneNumberValid(PhNumTextBox.Text)))
            {
                errorFound = true;
                PhNumTextBox.ForeColor = System.Drawing.Color.Red;
            }
            else PhNumTextBox.ForeColor = System.Drawing.Color.Black;
            if (!(UI.Validate.isEmailAddressValid(EmailTextBox.Text)))
            {
                errorFound = true;
                EmailTextBox.ForeColor = System.Drawing.Color.Red;
            }
            else EmailTextBox.ForeColor = System.Drawing.Color.Black;

            if (!UI.Validate.isPasswordValid(pwdTextBox.Text) || 
                hashPwdHiddenField.Value.Equals("0") || 
                !hashPwdHiddenField.Value.Equals(hashCpwdHiddenField.Value))
            {
                errorFound = true;
                pwdTextBox.ForeColor = System.Drawing.Color.Red;
                cpwdTextBox.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                pwdTextBox.ForeColor = System.Drawing.Color.Black;
                cpwdTextBox.ForeColor = System.Drawing.Color.Black;
            }

            if (!UI.Validate.isSecurityQuestionValid(Question1TextBox.Text))
            {
                errorFound = true;
                Question1TextBox.ForeColor = System.Drawing.Color.Red;
            }
            else Question1TextBox.ForeColor = System.Drawing.Color.Black;
            if (!UI.Validate.isSecurityAnswerValid(Answer1TextBox.Text))
            {
                errorFound = true;
                Answer1TextBox.ForeColor = System.Drawing.Color.Red;
            }
            else Answer1TextBox.ForeColor = System.Drawing.Color.Black;

            if (!UI.Validate.isSecurityQuestionValid(Question2TextBox.Text))
            {
                errorFound = true;
                Question2TextBox.ForeColor = System.Drawing.Color.Red;
            }
            else Question2TextBox.ForeColor = System.Drawing.Color.Black;
            if (!UI.Validate.isSecurityAnswerValid(Answer2TextBox.Text))
            {
                errorFound = true;
                Answer2TextBox.ForeColor = System.Drawing.Color.Red;
            }
            else Answer2TextBox.ForeColor = System.Drawing.Color.Black;

            if (!UI.Validate.isSecurityQuestionValid(Question3TextBox.Text))
            {
                errorFound = true;
                Question3TextBox.ForeColor = System.Drawing.Color.Red;
            }
            else Question3TextBox.ForeColor = System.Drawing.Color.Black;
            if (!UI.Validate.isSecurityAnswerValid(Answer3TextBox.Text))
            {
                errorFound = true;
                Answer3TextBox.ForeColor = System.Drawing.Color.Red;
            }
            else Answer3TextBox.ForeColor = System.Drawing.Color.Black;

            if (errorFound)
            {
                MessageBox.Show("Invalid data entered!  Please correct and resubmit.");
                return;
            }

            string[] arglist = new String[23];
            int argIndex = 0;

            arglist[argIndex++] = Mnemonics.TxnCodes.TX_REGISTER_USER;
            arglist[argIndex++] = " ";
            arglist[argIndex++] = MerchantCheckBox.Checked ? "2" : "1";
            arglist[argIndex++] = FirstNameTextBox.Text;
            arglist[argIndex++] = MiddleNameTextBox.Text;
            arglist[argIndex++] = LastNameTextBox.Text;
            arglist[argIndex++] = Addrs1TextBox.Text;
            arglist[argIndex++] = Addrs2TextBox.Text;
            arglist[argIndex++] = ZipTextBox.Text;
            arglist[argIndex++] = CityTextBox.Text;
            arglist[argIndex++] = StateTextBox.Text;
            arglist[argIndex++] = PhNumTextBox.Text;
            arglist[argIndex++] = EmailTextBox.Text;
            arglist[argIndex++] = " ";
            arglist[argIndex++] = " ";
            arglist[argIndex++] = Question1TextBox.Text;
            arglist[argIndex++] = Answer1TextBox.Text;
            arglist[argIndex++] = Question2TextBox.Text;
            arglist[argIndex++] = Answer2TextBox.Text;
            arglist[argIndex++] = Question3TextBox.Text;
            arglist[argIndex++] = Answer3TextBox.Text;
            arglist[argIndex++] = " ";
            arglist[argIndex++] = " ";
            arglist[argIndex++] = pwdTextBox.Text;

            var output = new Business.XSwitch(Global.ConnectionString, "", string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{17}|{18}{19}|{20}|{21}|{22}|{23}", arglist));
        }
    }
}