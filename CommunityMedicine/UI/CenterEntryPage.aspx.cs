using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicine.BLL;
using CommunityMedicine.Model;

namespace CommunityMedicine.UI
{
    public partial class CenterEntryPage : System.Web.UI.Page
    {
        private Thana athana = new Thana();
        private Center aCenter = new Center();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDropDownList();
            }

        }

        private CenterManager aManager = new CenterManager();
        private District aDistrict = new District();
        private  string Salt;

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
                // string password = CreateRandomPassword();
                string password = CreateRandomPassword();
                string key = "pavel";
                byte[] hashKey = aManager.GetHashKey(key);
                aCenter.CenterPassword = aManager.Encrypt(hashKey, password);
                aCenter.ThanaId = Convert.ToInt32(thanaDropDownList.SelectedValue);
                string test = aManager.Save(aCenter);
                if (test == "Saved Succesfully")
                {

                    string decrptedPassword = aManager.Decrypt(hashKey, aCenter.CenterPassword);
                    Session["centerName"] = aCenter.CenterName;
                    Session["centerCode"] = aCenter.CenterCode;
                    Session["password"] = decrptedPassword;
                    //Response.Redirect("DisplayCenter.aspx?centerName=" + aCenter.CenterName + "&centerCode=" +
                    //                  aCenter.CenterCode + "&password=" + aCenter.CenterPassword);
                    Response.Redirect("DisplayCenterPage.aspx");
                }
                else
                {
                    msgLabel.Text = test;
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
            string thanaCode = thanaName.Substring(0, 3) + random.Next(1, 9) + random.Next(1, 9) + random.Next(1, 9) +
                               random.Next(1, 9) + random.Next(1, 9) + random.Next(1, 9);

            return thanaCode;



        }

        public string CreateRandomPassword()
        {
            int passwordLength = 8;
            string _allowedChars = "@#$%0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ";
            Random randNum = new Random();
            char[] chars = new char[passwordLength];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = _allowedChars[(int) ((_allowedChars.Length)*randNum.NextDouble())];
            }
            return new string(chars);
        }

        private string Encryptdata(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }

        private string Decryptdata(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }

        //public  byte[] GetHashKey(string hashKey)
        //{
        //    // Initialize
        //    UTF8Encoding encoder = new UTF8Encoding();
        //    // Get the salt
        //    string salt = !string.IsNullOrEmpty(Salt) ? Salt : "I am a nice little salt";
        //    byte[] saltBytes = encoder.GetBytes(salt);
        //    // Setup the hasher
        //    Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(hashKey, saltBytes);
        //    // Return the key
        //    return rfc.GetBytes(16);
        //}

        //public  string Encrypt(byte[] key, string dataToEncrypt)
        //{
        //    // Initialize
        //    AesManaged encryptor = new AesManaged();
        //    // Set the key
        //    encryptor.Key = key;
        //    encryptor.IV = key;
        //    // create a memory stream
        //    using (MemoryStream encryptionStream = new MemoryStream())
        //    {
        //        // Create the crypto stream
        //        using (
        //            CryptoStream encrypt = new CryptoStream(encryptionStream, encryptor.CreateEncryptor(),
        //                CryptoStreamMode.Write))
        //        {
        //            // Encrypt
        //            byte[] utfD1 = UTF8Encoding.UTF8.GetBytes(dataToEncrypt);
        //            encrypt.Write(utfD1, 0, utfD1.Length);
        //            encrypt.FlushFinalBlock();
        //            encrypt.Close();
        //            // Return the encrypted data
        //            return Convert.ToBase64String(encryptionStream.ToArray());
        //        }
        //    }
        //}

        //public  string Decrypt(byte[] key, string encryptedString)
        //{
        //    // Initialize
        //    AesManaged decryptor = new AesManaged();
        //    byte[] encryptedData = Convert.FromBase64String(encryptedString);
        //    // Set the key
        //    decryptor.Key = key;
        //    decryptor.IV = key;
        //    // create a memory stream
        //    using (MemoryStream decryptionStream = new MemoryStream())
        //    {
        //        // Create the crypto stream
        //        using (
        //            CryptoStream decrypt = new CryptoStream(decryptionStream, decryptor.CreateDecryptor(),
        //                CryptoStreamMode.Write))
        //        {
        //            // Encrypt
        //            decrypt.Write(encryptedData, 0, encryptedData.Length);
        //            decrypt.Flush();
        //            decrypt.Close();
        //            // Return the unencrypted data
        //            byte[] decryptedData = decryptionStream.ToArray();
        //            return UTF8Encoding.UTF8.GetString(decryptedData, 0, decryptedData.Length);
        //        }
        //    }
        //}
    }
}