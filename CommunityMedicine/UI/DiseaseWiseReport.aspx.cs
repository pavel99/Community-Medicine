using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CommunityMedicine.BLL;
using CommunityMedicine.Model;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace CommunityMedicine.UI
{
    public partial class DiseaseWiseReport : System.Web.UI.Page
    {
        TreatmentManager manger=new TreatmentManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDiseaseDropDownList();
            }
           

        }

        public void PopulateDiseaseDropDownList()
        {
            diseaseDropDownList.DataSource = manger.PopulateDiseaseDropDownList();
            diseaseDropDownList.DataTextField = "DiseaseName";
            diseaseDropDownList.DataValueField = "Serial";
            diseaseDropDownList.DataBind();
        }

        public void PopulateDiseaWiseGridView()
        {
            int diseaseId = Convert.ToInt32(diseaseDropDownList.SelectedValue);
            string date1 = firstDateTextBox.Text;
            string date2 = lastDateTextBox.Text;
            diseaseWiseGridView.DataSource = manger.GetDiseaseWiseReport(diseaseId, date1, date2);
            diseaseWiseGridView.DataBind();
        }


        protected void diseaseWiseGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            

        }


        protected void showDieseaseButton_Click(object sender, EventArgs e)
        {
            PopulateDiseaWiseGridView();

        }

        protected void diseaseWiseGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            diseaseWiseGridView.PageIndex = e.NewPageIndex;
            PopulateDiseaWiseGridView();
        }
        //public void Dopdf()
        //{
        //    Response.ContentType = "application/pdf";
        //    Response.AddHeader("content-disposition", "attachment;filename=Export.pdf");
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);
        //    HtmlForm frm = new HtmlForm();
        //    reportPanel.Parent.Controls.Add(frm);
            

        //    frm.Attributes["runat"] = "server";
        //    frm.Controls.Add(reportPanel);
        //    frm.RenderControl(hw);
        //    StringReader sr = new StringReader(sw.ToString());
        //    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        //    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //    pdfDoc.Open();
        //    htmlparser.Parse(sr);
        //    pdfDoc.Close();
        //    Response.Write(pdfDoc);
        //    Response.End();
        //}
        public void DoPdf()
        {
             
        
            PdfPTable pdfPTable = new PdfPTable(diseaseWiseGridView.HeaderRow.Cells.Count);

            foreach (TableCell headerCell in diseaseWiseGridView.HeaderRow.Cells)
            {
                PdfPCell pdfCell = new PdfPCell(new Phrase(headerCell.Text));
                pdfPTable.AddCell(pdfCell);
            }

            int count = 1;

            foreach (GridViewRow gridViewRow in diseaseWiseGridView.Rows)
            {
                if (count != 0)
                    foreach (TableCell tableCell in gridViewRow.Cells)
                    {
                        PdfPCell pdfCell = new PdfPCell(new Phrase(tableCell.Text));
                        pdfPTable.AddCell(pdfCell);
                    }
                count++;

            }
            Document document = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter.GetInstance(document, Response.OutputStream);
            //PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("test.pdf", FileMode.Create));

            Paragraph diseaseName= new Paragraph("Disease Name: " + diseaseDropDownList.SelectedItem.Text);
            Paragraph   from= new Paragraph("From: " + firstDateTextBox.Text);
           // Paragraph centerName = new Paragraph("Center Name: " + n.Name);
            Paragraph to = new Paragraph("To: " + lastDateTextBox.Text);
            

            document.Open();
            document.Add(diseaseName);
            document.Add(from);
            document.Add(to);
            
            document.Add(pdfPTable);
            document.Close();

            Response.ContentType = "Application";
            Response.AppendHeader("content-disposition", "attachment;filename=Disease-WiseReport.pdf");
            Response.Write(document);
            Response.Flush();
            Response.End();
            document.Close();
        }
        

        protected void doPDF_Click(object sender, EventArgs e)
        {
            DoPdf();
        }
    }
}