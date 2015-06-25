using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace CommunityMedicine.UI
{
    public partial class DisplayCenterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string centerName = (string)Session["centerName"];
            string centerCode = (string)Session["centerCode"];
            string centerPassword = (string)Session["password"];
            //string centerName = Request["centerName"];
            //string centerCode = Request["centerCode"];
            //string centerPassword = Request["password"];

            lblcenterName.Text = centerName;
            lblcenterCode.Text = centerCode;
            lblpassword.Text = centerPassword;

        }

        protected void doPdfButton_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Export.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            HtmlForm frm = new HtmlForm();
            panel1.Parent.Controls.Add(frm);
            frm.Attributes["runat"] = "server";
            frm.Controls.Add(panel1);
            frm.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End(); 

        }
    }
}