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
    public partial class CenterEntryPage : System.Web.UI.Page
    {
        Thana athana = new Thana();
        Center aCenter = new Center();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDropDownList();
            }

        }
        CenterManager aManager = new CenterManager();
        District aDistrict = new District();
        protected void centerSaveButton_Click(object sender, EventArgs e)
        {
            if (centerNameTextBox.Text == "" || districtDropDownList.SelectedIndex == -1 ||
                thanaDropDownList.SelectedIndex == -1)
            {
                msgLabel.Text = "Please enter the value";

            }
            else
            {
                aCenter.CenterName = centerNameTextBox.Text;
                aCenter.CenterCode = GenerateCenterCodeCode();
                aCenter.CenterPassword = CreateRandomPassword();
                aCenter.ThanaId = Convert.ToInt32(thanaDropDownList.SelectedValue);
                int test=aManager.Save(aCenter);
                if (test > 0)
                {
                    Session["centerName"] = aCenter.CenterName;
                    Session["centerCode"] = aCenter.CenterCode;
                    Session["password"] = aCenter.CenterPassword;
                    //Response.Redirect("DisplayCenter.aspx?centerName=" + aCenter.CenterName + "&centerCode=" +
                    //                  aCenter.CenterCode + "&password=" + aCenter.CenterPassword);
                    Response.Redirect("DisplayCenterPage.aspx");

                }
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
            athana.DistrictId = Convert.ToInt32(districtDropDownList.SelectedValue);

            thanaDropDownList.DataSource = aManager.PopulateThanaDropDownList(athana.DistrictId);
            thanaDropDownList.DataTextField = "ThanaName";
            thanaDropDownList.DataValueField = "ThanaId";
            thanaDropDownList.DataBind();
        }

        public string GenerateCenterCodeCode()
        {
            string thanaName = thanaDropDownList.SelectedItem.Text;
            Random random = new Random();
            string thanaCode = thanaName.Substring(0, 3) + random.Next(1, 9) + random.Next(1, 9) + random.Next(1, 9);

            return thanaCode;



        }
        public string CreateRandomPassword()
        {
            int passwordLength = 6;
            string _allowedChars = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ";
            Random randNum = new Random();
            char[] chars = new char[passwordLength];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }
    }
}