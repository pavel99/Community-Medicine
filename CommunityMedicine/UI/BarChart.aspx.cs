using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using CommunityMedicine.BLL;

namespace CommunityMedicine.UI
{
    public partial class BarChart : System.Web.UI.Page
    {
        TreatmentManager manager=new TreatmentManager();
        CenterManager centerManager=new CenterManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDistrictDropDownList();
            }

        }

        public void PopulateDistrictDropDownList()
        {
            districtDropDownList.DataSource = centerManager.PopulateDropDownList();
            districtDropDownList.DataTextField = "DistrictName";
            districtDropDownList.DataValueField = "DistrictId";
            districtDropDownList.DataBind();
        }

        private void LoadChartData(DataTable initialDataSource)
        {
            for (int i = 1; i < initialDataSource.Columns.Count; i++)
            {
                Series series = new Series();
                foreach (DataRow dr in initialDataSource.Rows)
                {
                    int y = (int) dr[i];
                    series.Points.AddXY(dr["DiseaseName"].ToString(), y);
                }
                Chart1.Series.Add(series);
            }
        }

        protected void ShowBarChartButton_Click(object sender, EventArgs e)
        {
            string districtName = districtDropDownList.SelectedItem.Text;
            string fromDate = fromDateTextBox.Text;
            string todate = toDateTextBox.Text;

            DataTable dt = manager.GetData(districtName, fromDate, todate);
            LoadChartData(dt);

        }

    }
}