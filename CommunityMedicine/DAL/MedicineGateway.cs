using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CommunityMedicine.Model;

namespace CommunityMedicine.DAL
{
    public class MedicineGateway
    {
        private string connectionString =
            ConfigurationManager.ConnectionStrings["CommunityMedicineConDB"].ConnectionString;

        public int Save(Medicine aMedicine)
        {
            string query = string.Format("INSERT INTO Medicine VALUES('{0}')", aMedicine.MedicineName);
            SqlConnection connection=new SqlConnection(connectionString);
            SqlCommand command =new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;

        }

        public bool IsMedicineNameExists(Medicine aMedicine)
        {
            bool isMedicineNameExists = false;

            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("Select * From Medicine where MedicineName='{0}'",aMedicine.MedicineName);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                isMedicineNameExists = true;
                break;
            }
            reader.Close();
            connection.Close();
            return isMedicineNameExists;
        }
        public List<Medicine> GetAllMedicine()
        {
            List<Medicine> medicineList = new List<Medicine>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("Select * From Medicine");

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();
            int serial = 1;
            while (reader.Read())
            {
                Medicine aMedicine=new Medicine();
                aMedicine.Serial = serial;
                aMedicine.MedicineName = reader["MedicineName"].ToString();
               
                medicineList.Add(aMedicine);
                serial++;
            }
            reader.Close();
            connection.Close();
            return medicineList;

        }
    }
}