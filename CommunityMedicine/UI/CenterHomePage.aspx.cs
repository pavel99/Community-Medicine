using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CommunityMedicine.UI
{
    public partial class CenterHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string centerName = (string)Session["centerName"];
            int centerId = (int)Session["centerId"];
            centerNameLabel.Text = centerName;

        }

        protected void addDoctorButton_Click(object sender, EventArgs e)
        {
            string centerName = (string)Session["centerName"];
            int centerId = (int)Session["centerId"];

            //Response.Redirect("DoctorEntryPage.aspx?centerName="+centerName+"&centerId="+centerId+"");
            Response.Redirect("DoctorEntryPage.aspx");

        }
    }
}