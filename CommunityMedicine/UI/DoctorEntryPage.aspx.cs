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
    public partial class DoctorEntryPage : System.Web.UI.Page
    {
        Doctor aDoctor = new Doctor();
        CenterManager manager = new CenterManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void doctorSaveButton_Click(object sender, EventArgs e)
        {
            string centerName = (string)Session["centerName"];
            int centerId = (int)Session["centerId"];
            if (doctorNameTextBox.Text == "" || doctorDegreeTextBox.Text == "" || specializationTextBox.Text == "")
            {
                msgLabel.Text = "Please enter all values";

            }
            else
            {
                aDoctor.DoctorName = doctorNameTextBox.Text;
                aDoctor.Degree = doctorDegreeTextBox.Text;
                aDoctor.Specialization = specializationTextBox.Text;
                aDoctor.CenterId = Convert.ToInt32(centerId);
                msgLabel.Text = manager.SaveDoctor(aDoctor);

            }
            doctorNameTextBox.Text = "";
            doctorDegreeTextBox.Text = "";
            specializationTextBox.Text = "";

        }
    }
}