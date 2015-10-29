using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class AccountStatement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null || Session["Access"] == null)
                Response.Redirect("UserLogin.aspx");
            if (Session["Access"].ToString() == "3" || Session["Access"].ToString() == "4")
                Response.Redirect("EmployeeHome.aspx");
            if (Session["Access"].ToString() == "5")
                Response.Redirect("AdminHome.aspx");

            if (Global.IsPageAccessible(Page.Title))
            {
                LoadFinancialAccountStatement();
                //LoadNonFinancialAccountStatement();
            }
        }

        private void LoadFinancialAccountStatement()
        {
            var xSwitch = new Business.XSwitch();
            FinHistoryGridView.DataSource= xSwitch.getFinHistory(Global.ConnectionString, Session["UserId"].ToString());
            FinHistoryGridView.DataBind();
        }

        //private void LoadNonFinancialAccountStatement()
        //{
        //    var xSwitch = new Business.XSwitch();
        //    NonFinHistoryGridView.DataSource = xSwitch.getNonFinHistory(Global.ConnectionString, Session["UserId"].ToString());
        //    NonFinHistoryGridView.DataBind();
        //}

        public void ExportToPdf(DataTable dt)
        {
            try { Document document = new Document();
                var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path + "\\AccountStatement.pdf", FileMode.Create));
                document.Open();
                iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 5);

                PdfPTable table = new PdfPTable(dt.Columns.Count);
                PdfPRow row = null;
                float[] widths = new float[] { 4f, 4f, 4f, 4f, 4f };

                table.SetWidths(widths);

                table.WidthPercentage = 100;
                int iCol = 0;
                string colname = "";
                PdfPCell cell = new PdfPCell(new Phrase("Products"));

                cell.Colspan = dt.Columns.Count;

                foreach (DataColumn c in dt.Columns)
                {

                    table.AddCell(new Phrase(c.ColumnName, font5));
                }

                foreach (DataRow r in dt.Rows)
                {
                    if (dt.Rows.Count > 0)
                    {
                        table.AddCell(new Phrase(r[0].ToString(), font5));
                        table.AddCell(new Phrase(r[1].ToString(), font5));
                        table.AddCell(new Phrase(r[2].ToString(), font5));
                        table.AddCell(new Phrase(r[3].ToString(), font5));
                        table.AddCell(new Phrase(r[4].ToString(), font5));
                    }
                }
                document.Add(table);
                document.Close();
            }
            catch(Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('" + ex.Message + "');", true);
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void CreatePdfButton_Click(object sender, EventArgs e)
        {
            var xSwitch = new Business.XSwitch();
            var table = xSwitch.getFinHistory(Global.ConnectionString, Session["UserId"].ToString()).Tables[0];
            ExportToPdf(table);
        }
    }
}