using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicine.BLL;
using CommunityMedicine.Model;

namespace CommunityMedicine.UI
{
    public partial class SendMedicinePage : System.Web.UI.Page
    {
        CenterManager aManager = new CenterManager();
        Thana aThana = new Thana();
        Center aCenter = new Center();
        DataTable dataTable = new DataTable();
        MedicineQuantity medicineQuantity = new MedicineQuantity();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridView();
                PopulateDropDownList();
                PopulateMedicineDropDownList();
                medicineQuantityGridView.DataSource = dataTable;
                medicineQuantityGridView.DataBind();

            }

        }
        public void PopulateDropDownList()
        {
            districtDropDownList.DataSource = aManager.PopulateDropDownList();
            districtDropDownList.DataTextField = "DistrictName";
            districtDropDownList.DataValueField = "DistrictId";
            districtDropDownList.DataBind();

        }

        protected void districtDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

            aThana.DistrictId = Convert.ToInt32(districtDropDownList.SelectedValue);

            thanaDropDownList.DataSource = aManager.PopulateThanaDropDownList(aThana.DistrictId);
            thanaDropDownList.DataTextField = "ThanaName";
            thanaDropDownList.DataValueField = "ThanaId";
            thanaDropDownList.DataBind();
        }

        protected void thanaDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            aCenter.ThanaId = Convert.ToInt32(thanaDropDownList.SelectedValue);

            centerDropDownList.DataSource = aManager.PopulateCenterDropDownList(aCenter.ThanaId);
            centerDropDownList.DataTextField = "CenterName";
            centerDropDownList.DataValueField = "CenterId";
            centerDropDownList.DataBind();

        }
        public void PopulateMedicineDropDownList()
        {
            medicineDropDownList.DataSource = aManager.PopulateMedicineDropDownList();
            medicineDropDownList.DataTextField = "MedicineName";
            medicineDropDownList.DataValueField = "Serial";
            medicineDropDownList.DataBind();

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
            string name = medicineDropDownList.SelectedItem.Text;
            int quantity = int.Parse(quantityTextBox.Text);



            DataRow dr = dataTable.NewRow();
            dr["Name"] = name;
            dr["Quantity"] = quantity.ToString();


            dataTable.Rows.Add(dr);

            Session["save"] = dataTable;
            //ViewState["save"] = dataTable;
            medicineQuantityGridView.DataSource = dataTable;
            medicineQuantityGridView.DataBind();
            //ViewState["save"] = null;



        }

        public void PopulateGridView()
        {
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Quantity", typeof(string));

            Session["save"] = dataTable;
            //ViewState["save"] = dataTable;
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            string name = "";
            int quantity = 0;
            int value = 0;

            if (quantityTextBox.Text == "" || districtDropDownList.SelectedIndex == -1 ||
                thanaDropDownList.SelectedIndex == -1)
            {
                msgLabel.Text = "Please enter all values";
            }
            else
            {



                foreach (GridViewRow row in medicineQuantityGridView.Rows)
                {
                    TextBox txtBox = (TextBox)row.FindControl("TextBox");

                    name = row.Cells[0].Text;
                    quantity = int.Parse(row.Cells[1].Text);

                    medicineQuantity.MedicineId = aManager.GetMedicineIdByName(name);
                    medicineQuantity.Quantity = quantity;
                    medicineQuantity.CenterId = int.Parse(centerDropDownList.SelectedValue);
                    if (aManager.IsMedicineIdAlreadyExists(medicineQuantity.MedicineId, medicineQuantity.CenterId))
                    {
                        int test = aManager.UpdateQuantity(medicineQuantity.CenterId, medicineQuantity.MedicineId,
                            quantity);
                        if (test > 0)
                        {
                            msgLabel.Text = "Updated Succesfully";
                            Session.RemoveAll();
                        }
                        else
                        {
                            msgLabel.Text = "Updatingfailed";
                        }
                    }
                    else
                    {
                        value = aManager.SaveMedicineQuantity(medicineQuantity);
                    }



                }
                if (value > 0)
                {
                    msgLabel.Text = "Medicine is sent Succesfully";
                 
                }

                medicineQuantityGridView.DataSource = string.Empty;
                //ViewState["save"] = string.Empty;
                //Session["save"] = null;
                medicineQuantityGridView.DataBind();
                medicineQuantityGridView.Columns.Clear();
                dataTable.Clear();
                quantityTextBox.Text = "";
                Session.Clear();

            }




        }
        

    }
}