using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;


namespace UI
{
    public partial class TransferMoney : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadSenderAccounts();
            LoadRecepientAccounts();
            String CustName = (String)Session["Username"];


        }

        protected void Transfer_Click(object sender, EventArgs e)
        {//Send the Message of successful or failure(reason for failure)
            if(FromDropDown.SelectedValue==null)
            {
                MessageBox.Show("Select the sender Account");
            }
            else if(ToDropDown.SelectedValue==null)
            {
                MessageBox.Show("Select the recepient Account");
            }
            else if(AmountTransfer.Text=="")
            {
                MessageBox.Show("Enter the amount to transfer");
            }
            else if(ConfirmAmount.Text=="")
            {
                MessageBox.Show("Enter the Confirmation Amount");
            }
            else if(ConfirmAmount.Text!=AmountTransfer.Text)
            {
                MessageBox.Show("Enter the correct amount to transfer");
            }
            else{
                String senderacc= FromDropDown.SelectedValue;
                String recipientacc = ToDropDown.SelectedValue;
                String amount = AmountTransfer.Text;
                //Result=Transferfunction
            
            }
        }
        private void LoadSenderAccounts()
        {
            //Return list of SenderAccounts
            /* List<String> SenderAcc=loadaccounts
             //foreach(var acc in SenderAcc)
             //{
                 FromDropDown.Add(acc);
             //}*/
        }
        private void LoadRecepientAccounts()
        {
            //Return list of RecepientAccounts
            /* List<String> RecepientAcc=loadaccounts
             //foreach(var acc in RecepientAcc)
             //{
                 ToDropDown.Add(acc);
             //}*/
        }

        

       
    }
}