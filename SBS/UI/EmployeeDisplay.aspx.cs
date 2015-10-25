using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class EmployeeDisplay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTransactions();
        }
        private void LoadTransactions()
        {
            TableRow tr = new TableRow();
            TableCell tc1 = new TableCell();
            tc1.Text = "Transaction ID, Transaction Name, Transaction Details";
            TableCell tc2 = new TableCell();
            Button Approve = new Button();
            Approve.Text = "Approve";
            tc2.Controls.Add(Approve);
            TableCell tc3 = new TableCell();
            Button Reject = new Button();
            Reject.Text = "Reject";
            tc3.Controls.Add(Reject);
            tr.Cells.Add(tc1);
            tr.Cells.Add(tc2);
            tr.Cells.Add(tc3);
            EmpTranslist.Rows.Add(tr);
        }
    }
}