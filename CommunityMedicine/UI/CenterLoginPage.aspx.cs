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
    public partial class CenterLoginPage : System.Web.UI.Page
    {
        CenterManager manager=new CenterManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void loginButton_Click(object sender, EventArgs e)
        {
            if (centerCodeTextBox.Text == "" || passwordTextBox.Text == "")
            {
                msgLabel.Text = "Please enter values";
            }
            else
            {
                string centerCode = centerCodeTextBox.Text;
                string password = passwordTextBox.Text;
                 string key = "pavel";
                byte[] hashKey =manager.GetHashKey(key);
                string encryptedPassword = manager.Encrypt(hashKey, password);
                if (manager.Login(centerCode, encryptedPassword))
                {
                    Center aCenter = manager.GetCenter(centerCode, encryptedPassword);
                    Session["centerName"] = aCenter.CenterName;
                    Session["centerId"] = aCenter.CenterId;
                    Response.Redirect("CenterHomePage.aspx");
                    //Response.Redirect("CenterHome.aspx?centerName="+aCenter.CenterName+"&centerId="+aCenter.CenterId);
                }
                else
                {
                    msgLabel.Text = "Center Code or Password is invalid";
                }
               
            }
        }

        }
    }
