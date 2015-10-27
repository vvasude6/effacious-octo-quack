﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace UI
{
    public partial class CustProfileUpdate : System.Web.UI.Page
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

            String[] argList = new String[2];
            argList[0] = Mnemonics.TxnCodes.TX_FETCH_CUSTOMER;
            argList[1] = Session["UserId"].ToString();

            var output = new Business.XSwitch(Global.ConnectionString, Session["UserId"].ToString(),
                string.Format("{0}|{1}", argList));

            String[] profileList = output.resultGet.Split('|');
            FirstNameTextBox.Text = profileList[2];
            MiddleNameTextBox.Text = profileList[3];
            LastNameTextBox.Text = profileList[4];
            Addrs1TextBox.Text = profileList[5];
            Addrs2TextBox.Text = profileList[6];
            CityTextBox.Text = profileList[7];
            StateTextBox.Text = profileList[8];
            ZipTextBox.Text = profileList[9];
            PhNumTextBox.Text = profileList[11];
            EmailTextBox.Text = profileList[12];
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
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

            if (errorFound)
            {
                MessageBox.Show("Invalid data entered!  Please correct and resubmit.");
                return;
            }

            string[] arglist = new String[12];
            int argIndex = 0;

            arglist[argIndex++] = Mnemonics.TxnCodes.TX_UPDATE_PROFILE;
            arglist[argIndex++] = " ";
            arglist[argIndex++] = " ";
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
            arglist[argIndex++] = " ";
            arglist[argIndex++] = " ";
            arglist[argIndex++] = " ";
            arglist[argIndex++] = " ";
            arglist[argIndex++] = " ";
            arglist[argIndex++] = " ";
            arglist[argIndex++] = " ";
            arglist[argIndex++] = " ";
            arglist[argIndex++] = " ";

            var output = new Business.XSwitch(Global.ConnectionString, Session["UserId"].ToString(), 
                string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{17}|{18}{19}|{20}|{21}|{22}|{23}", arglist));
        }
    }
}