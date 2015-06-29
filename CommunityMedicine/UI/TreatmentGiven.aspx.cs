using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicine.BLL;
using CommunityMedicine.DAL;
using CommunityMedicine.Model;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;


namespace CommunityMedicine.UI
{
    public partial class TreatmentGiven : System.Web.UI.Page
    {
        TreatmentManager manager = new TreatmentManager();
        DataTable dataTable=new DataTable();
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

                if (voterId == voterModel.ID)
                {
                    voterIdTextBox.Text = voterModel.ID;
                    nameTextBox.Text = voterModel.Name;
                    addressTextBox.Text = voterModel.Address;
                    ageTextBox.Text = voterModel.DateOfBirth;
                }

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

    }
}