using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicine.BLL;
using CommunityMedicine.Model;

namespace CommunityMedicine.UI
{
    public partial class DiseaseEntryPage : System.Web.UI.Page
    {
        DiseaseManager manager = new DiseaseManager();
        Disease aDisease = new Disease();
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateGridView();
        }

        protected void diseaseSaveButton_Click(object sender, EventArgs e)
        {
            if (diseaseNameTextBox.Text == "" || descriptionTextBox.Text == "" || procedureTextBox.Text == "")
            {
                msgLabel.Text = "Please enter values";
            }
            else
            {
                aDisease.DiseaseName = diseaseNameTextBox.Text;
                aDisease.Description = descriptionTextBox.Text;
                aDisease.TreatmentProcedure = procedureTextBox.Text;
                msgLabel.Text = manager.Save(aDisease);
                PopulateGridView();
            }
            diseaseNameTextBox.Text = "";
            descriptionTextBox.Text = "";
            procedureTextBox.Text = "";
        }
        public void PopulateGridView()
        {
            diseaseGridView.DataSource = manager.GetAlldDiseases();
            diseaseGridView.DataBind();
        }

        protected void diseaseGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void diseaseGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            diseaseGridView.PageIndex = e.NewPageIndex;
            PopulateGridView();

        }
    }
}