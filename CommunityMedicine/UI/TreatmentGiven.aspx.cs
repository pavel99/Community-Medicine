using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CommunityMedicine.BLL;
using CommunityMedicine.DAL;
using CommunityMedicine.Model;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;


namespace CommunityMedicine.UI
{
    public partial class TreatmentGiven : System.Web.UI.Page
    {
        TreatmentManager manager = new TreatmentManager();
        DataTable dataTable=new DataTable();
        Treatment treatment=new Treatment();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDoctorDropdownList();
                PopulateDiseaseDropdownList();
                PopulateMedicineDropdownList();
                PopulateGridView();
                PopulateDoseDropdownList();
            }

        }

        protected void showDetailsButton_Click(object sender, EventArgs e)
        {
            string voterId = voterIdTextBox.Text;
            WebClient webClient = new WebClient();

            var data = webClient.DownloadString("http://nerdcastlebd.com/web_service/voterdb/index.php/voters/all/format/json");
            JObject jObject = JObject.Parse(data);
            foreach (var person in jObject["voters"])
            {
                VoterModel voterModel = new VoterModel();
                voterModel.ID = person["id"].ToString();
                voterModel.Name = person["name"].ToString();
                voterModel.Address = person["address"].ToString();
                voterModel.DateOfBirth = person["date_of_birth"].ToString();

                int currentyear = DateTime.Now.Year;
                if (voterId == voterModel.ID)
                {
                    voterIdTextBox.Text = voterModel.ID;
                    nameTextBox.Text = voterModel.Name;
                    addressTextBox.Text = voterModel.Address;

                    string[] birthyear = voterModel.DateOfBirth.Split('-');

                    int birthyear1 = int.Parse(birthyear[0]);

                    ageTextBox.Text = (currentyear-birthyear1).ToString();
                }

            }
            string voter = voterIdTextBox.Text;
            if (manager.IsPatientAlreadyExists(voter))
            {

                int serviceGiven = manager.GetServiceGivenByVoterId(voter);
                serviceGivenTextBox.Text = Convert.ToString(serviceGiven);
            }
            else
            {
                serviceGivenTextBox.Text = "0";
            }
        }

        public void PopulateDoctorDropdownList()
        {
            int centerId = Convert.ToInt32(Session["centerId"]);
            doctorDropDownList.DataSource = manager.PopulateDoctorDropDownList(centerId);
            doctorDropDownList.DataTextField = "DoctorName";
            doctorDropDownList.DataValueField = "Id";
            doctorDropDownList.DataBind();

        }
        public void PopulateDiseaseDropdownList()
        {
            diseaseDropDownList.DataSource = manager.PopulateDiseaseDropDownList();
            diseaseDropDownList.DataTextField = "DiseaseName";
            diseaseDropDownList.DataValueField = "Serial";
            diseaseDropDownList.DataBind();

        }
        public void PopulateMedicineDropdownList()
        {
            int centerId = Convert.ToInt32(Session["centerId"]);
            medicineDropDownList.DataSource = manager.PopulateMedicineDropDownList(centerId);
            medicineDropDownList.DataTextField = "MedicineName";
            medicineDropDownList.DataValueField = "Serial";
            medicineDropDownList.DataBind();

        }

        public void PopulateDoseDropdownList()
        {
            doseDropDownList.DataSource = manager.PopulateDosedropdownList();
            doseDropDownList.DataTextField = "DoseType";
            doseDropDownList.DataValueField = "Id";
            doseDropDownList.DataBind();

        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            //dataTable.Clear();
            if (Session["save"] == null)
            {
                //if (ViewState["save"] != null)

                PopulateGridView();
               // dataTable = (DataTable) Session["save"];
            }
            dataTable = (DataTable)Session["save"];
            //  dataTable = (DataTable)ViewState["save"];
            
            // GetDataLoadedInGridView();
            //string name = medicineDropDownList.SelectedItem.Text;
            //int quantity = int.Parse(quantityTextBox.Text);
            string meal;
            string disease = diseaseDropDownList.SelectedItem.Text;
            string medicine = medicineDropDownList.SelectedItem.Text;
            string dose = doseDropDownList.SelectedItem.Text;
            string quantity = quantiyGivenTextBox.Text;
            if (aftermelaRadioButton.Checked)
            {
                meal = aftermelaRadioButton.Text;

            }
            else
            {
                meal = beformealRadioButton.Text;
            }
            string note = noteTextBox.Text;



            DataRow dr = dataTable.NewRow();
            dr["Disease"] = disease;
            dr["Medicine"] = medicine;
            dr["Dose"] = dose;
            dr["Before Meal/After Meal"] = meal;
            dr["Quantity Given"] =quantity;
            dr["Note"] =note ;
            




            dataTable.Rows.Add(dr);

            Session["save"] = dataTable;
            //ViewState["save"] = dataTable;
            treatmentGridView.DataSource = dataTable;
            treatmentGridView.DataBind();
            //ViewState["save"] = null;



        }
        public void PopulateGridView()
        {
            dataTable.Columns.Add("Disease", typeof(string));
            dataTable.Columns.Add("Medicine", typeof(string));
            dataTable.Columns.Add("Dose", typeof(string));
            dataTable.Columns.Add("Before Meal/After Meal", typeof(string));
            dataTable.Columns.Add("Quantity Given", typeof(string));
             dataTable.Columns.Add("Note", typeof(string));

            Session["save"] = dataTable;
            //ViewState["save"] = dataTable;
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            string disease = "";
            string medicine = "";

            if (voterIdTextBox.Text=="")
            {
                
            }
            else
            {
                 foreach (GridViewRow row in treatmentGridView.Rows)
                {
                    TextBox txtBox = (TextBox)row.FindControl("TextBox");

                    treatment.VoterId = voterIdTextBox.Text;
                    treatment.Observation = observationTextBox.Text;
                    
                    treatment.Date =dateTextBox.Text ;
                    treatment.DoctorId = Convert.ToInt32(doctorDropDownList.SelectedValue);
                    treatment.CenterId = Convert.ToInt32(Session["centerId"]);
                    disease = row.Cells[0].Text;
                    medicine = (row.Cells[1].Text);
                    treatment.Dose = (row.Cells[2].Text);
                    treatment.Meal=(row.Cells[3].Text);
                    treatment.Quantity=int.Parse(row.Cells[4].Text);
                    treatment.Note=(row.Cells[5].Text);

                     

                    treatment.DiseaseId = manager.GetDiseaseIdByName(disease);
                    treatment.MedicineId = manager.GetMedicineIdByName(medicine);
                    saveLabel.Text = manager.SaveTreatMent(treatment);
                   // Dopdf();
                   
                    string text = manager.UpdateQuantity(treatment.CenterId, treatment.MedicineId, treatment.Quantity);
                }
                 if (manager.IsPatientAlreadyExists(treatment.VoterId))
                 {
                     updateLabel.Text = manager.UpdateServiceGiven(treatment.VoterId);
                 }
                 else
                 {
                     Services services = new Services();
                     services.VoterId = voterIdTextBox.Text;
                     services.ServiceGiven = 1;
                     string result = manager.SaveService(services);
                 }

                }
           // Dopdf();
            
           
            Session.Clear();
            Session.RemoveAll();
            treatmentGridView.DataSource =string.Empty;
            treatmentGridView.Columns.Clear();
            treatmentGridView.DataBind();
            observationTextBox.Text = "";
            noteTextBox.Text = "";
            // Dopdf();

        }

        //public void Dopdf()
        //{
        //    Response.ContentType = "application/pdf";
        //    Response.AddHeader("content-disposition", "attachment;filename=Export.pdf");
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);
        //    HtmlForm frm = new HtmlForm();
        //    treatmentPanel.Parent.Controls.Add(frm);
        //    //voterIdTextBox.Parent.Controls.Add(frm);
        //    //serviceGivenTextBox.Parent.Controls.Add(frm);
        //    //observationTextBox.Parent.Controls.Add(frm);
        //    //dateTextBox.Parent.Controls.Add(frm);
        //    //doctorDropDownList.Parent.Controls.Add(frm);

        //    frm.Attributes["runat"] = "server";
        //    frm.Controls.Add(treatmentPanel);
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

        protected void pdfButton_Click(object sender, EventArgs e)
        {
            DoPdf();

        }

        public void DoPdf()
        {
            PdfPTable pdfPTable = new PdfPTable(treatmentGridView.HeaderRow.Cells.Count);

            foreach (TableCell headerCell in treatmentGridView.HeaderRow.Cells)
            {
                PdfPCell pdfCell = new PdfPCell(new Phrase(headerCell.Text));
                pdfPTable.AddCell(pdfCell);
            }

            int count = 1;

            foreach (GridViewRow gridViewRow in treatmentGridView.Rows)
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

            Paragraph nationalID = new Paragraph("Voter Id: " + voterIdTextBox.Text);
            Paragraph name = new Paragraph("Patient Name: " + nameTextBox.Text);
           // Paragraph centerName = new Paragraph("Center Name: " + n.Name);
            Paragraph address = new Paragraph("Address: " + addressTextBox.Text);
            Paragraph age = new Paragraph("Date of Birth: " + ageTextBox.Text);
            Paragraph date = new Paragraph("Treatment Date: " + dateTextBox.Text);
            Paragraph doctor = new Paragraph("Doctor Name: " + doctorDropDownList.SelectedItem.Text);
            Paragraph service = new Paragraph("Service Given: " + serviceGivenTextBox.Text);
            Paragraph observation = new Paragraph("Observation: " + observationTextBox.Text);
            Paragraph text = new Paragraph("\n\n");

            document.Open();
            document.Add(nationalID);
            document.Add(name);
            document.Add(address);
            //document.Add(centerName);
            document.Add(date);
            document.Add(doctor);
            document.Add(observation);


            document.Add(age);
            document.Add(service);


            document.Add(text);
            document.Add(pdfPTable);
            document.Close();

            Response.ContentType = "Application";
            Response.AppendHeader("content-disposition", "attachment;filename=Prescription.pdf");
            Response.Write(document);
            Response.Flush();
            Response.End();
            document.Close();
        }

    }
}