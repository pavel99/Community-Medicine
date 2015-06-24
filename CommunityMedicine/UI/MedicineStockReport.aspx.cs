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
    public partial class MedicineStockReport : System.Web.UI.Page
    {
        CenterManager manager=new CenterManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            int centerId = (int)Session["centerId"];
            medicineStockGridView.DataSource = manager.MedicineStockReport(centerId);
            medicineStockGridView.DataBind();

        }
    }
}