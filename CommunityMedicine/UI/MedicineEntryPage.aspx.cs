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
    public partial class MedicineEntryPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateGridView();


        }
        MedicineManager aManager = new MedicineManager();
        Medicine aMedicine = new Medicine();
        protected void medicineSaveButton_Click(object sender, EventArgs e)
        {
            if (medicineTextBox.Text == "")
            {

                msgLabel.Text = "Please Enter the  Medicine Name";
            }
            else
            {
                aMedicine.MedicineName = medicineTextBox.Text;
                msgLabel.Text = aManager.Save(aMedicine);
                medicineTextBox.Text = string.Empty;
                PopulateGridView();
            }
            medicineTextBox.Text = "";

        }

        public void PopulateGridView()
        {
            medicineGridView.DataSource = aManager.GetAllMedicine();
            medicineGridView.DataBind();
        }

        protected void medicineGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            medicineGridView.PageIndex = e.NewPageIndex;
            PopulateGridView();
        }
    }
}