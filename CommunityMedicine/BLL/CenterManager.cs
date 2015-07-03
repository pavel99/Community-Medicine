using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using CommunityMedicine.DAL;
using CommunityMedicine.Model;

namespace CommunityMedicine.BLL
{
    public class CenterManager
    {
        private string Salt;
        CenterGateway gateway = new CenterGateway();
        public List<District> PopulateDropDownList()
        {
            return gateway.PopulateDropDownList();

        }

        public List<Thana> PopulateThanaDropDownList(int districtId)
        {
            return gateway.PopulateThanaDropDownList(districtId);
        }

        public string Save(Center aCenter)
        {
            if (gateway.IsCenterNameExists(aCenter))
            {
                return "CenterName Already Exists";
            }
            else
            {
                if (gateway.Save(aCenter) > 0)
                {
                    return "Saved Succesfully";
                }
                else
                {
                    return "Saving failed";
                }
                
            }
            
        }
        public List<Center> PopulateCenterDropDownList(int thanaId)
        {
            return gateway.PopulateCenterDropDownList(thanaId);
        }
        public List<Medicine> PopulateMedicineDropDownList()
        {
            return gateway.PopulateMedicineDropDownList();
        }

        public string SaveDoctor(Doctor aDoctor)
        {
            if (gateway.SaveDoctor(aDoctor)>0)
            {
                return "Saved successfully";
            }
            else
            {
                return "Save failed";
            }
            
        }

        public bool Login(string centerCode,string password)
        {
            return gateway.Login(centerCode,password);
        }

        public Center GetCenter(string centerCode, string password)
        {
            return gateway.GetCenter(centerCode, password);
        }

        public int SaveMedicineQuantity(MedicineQuantity medicineQuantity)
        {
            return gateway.SaveMedicineQuantity(medicineQuantity);
        }

        public int GetMedicineIdByName(string name)
        {
            return gateway.GetMedicineIdByName(name);
        }

        public bool IsMedicineIdAlreadyExists(int medicineId,int centerId)
        {
            return gateway.IsMedicineIdAlreadyExists(medicineId,centerId);
        }

        public int UpdateQuantity(int centerId, int medicineId, int value)
        {
            return gateway.UpdateQuantity(centerId, medicineId, value);
        }

        public List<MedicineStockReport> MedicineStockReport(int centerId)
        {
            return gateway.MedicineStockReport(centerId);
        }
        public byte[] GetHashKey(string hashKey)
        {
            // Initialize
            UTF8Encoding encoder = new UTF8Encoding();
            // Get the salt
            string salt = !string.IsNullOrEmpty(Salt) ? Salt : "I am a nice little salt";
            byte[] saltBytes = encoder.GetBytes(salt);
            // Setup the hasher
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(hashKey, saltBytes);
            // Return the key
            return rfc.GetBytes(16);
        }
        public string Encrypt(byte[] key, string dataToEncrypt)
        {
            // Initialize
            AesManaged encryptor = new AesManaged();
            // Set the key
            encryptor.Key = key;
            encryptor.IV = key;
            // create a memory stream
            using (MemoryStream encryptionStream = new MemoryStream())
            {
                // Create the crypto stream
                using (
                    CryptoStream encrypt = new CryptoStream(encryptionStream, encryptor.CreateEncryptor(),
                        CryptoStreamMode.Write))
                {
                    // Encrypt
                    byte[] utfD1 = UTF8Encoding.UTF8.GetBytes(dataToEncrypt);
                    encrypt.Write(utfD1, 0, utfD1.Length);
                    encrypt.FlushFinalBlock();
                    encrypt.Close();
                    // Return the encrypted data
                    return Convert.ToBase64String(encryptionStream.ToArray());
                }
            }
        }
        public string Decrypt(byte[] key, string encryptedString)
        {
            // Initialize
            AesManaged decryptor = new AesManaged();
            byte[] encryptedData = Convert.FromBase64String(encryptedString);
            // Set the key
            decryptor.Key = key;
            decryptor.IV = key;
            // create a memory stream
            using (MemoryStream decryptionStream = new MemoryStream())
            {
                // Create the crypto stream
                using (
                    CryptoStream decrypt = new CryptoStream(decryptionStream, decryptor.CreateDecryptor(),
                        CryptoStreamMode.Write))
                {
                    // Encrypt
                    decrypt.Write(encryptedData, 0, encryptedData.Length);
                    decrypt.Flush();
                    decrypt.Close();
                    // Return the unencrypted data
                    byte[] decryptedData = decryptionStream.ToArray();
                    return UTF8Encoding.UTF8.GetString(decryptedData, 0, decryptedData.Length);
                }
            }
        }
    }
}