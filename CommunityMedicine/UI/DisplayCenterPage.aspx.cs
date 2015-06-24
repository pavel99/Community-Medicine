using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
    }
}