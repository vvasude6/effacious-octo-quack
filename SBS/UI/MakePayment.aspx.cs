using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace UI
{
    public partial class MakePayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   //Loop through the list of all payees and add to the Payeelist dropdown
            // LoadPayee();
            String CustName = (String)Session["Username"];



        }

        protected void Payment_Click(object sender, EventArgs e)
        {//Just send Message if transaction is successful or failed and also reason for failure
            if(PayeeList.SelectedValue==null)
            {
                MessageBox.Show("Select the Payee");
            }
            else if(AmountPay.Text=="")
            {
                MessageBox.Show("Enter the amount to be paid");
            }
            else if(ConfirmPay.Text=="")
            {
                MessageBox.Show("Please enter the confirmation amount");
            }
            else if(ConfirmPay.Text!=AmountPay.Text)
            {
                MessageBox.Show("Enter correct amount in the confirmation Textbox");
            }
            else
            {
                String Payee = PayeeList.SelectedValue;
                String Amount = AmountPay.Text;
                //Result=Paymentfunction
                //MessageBox.Show(Result);
            }
        }
        private void LoadPayee()
        {   //Return list of Payees
           /* List<String> Payees=loadPayeelist
            //foreach(var payee in Payees)
            //{
                PayeeList.Add(payee);
            //}*/
        }
    }
}