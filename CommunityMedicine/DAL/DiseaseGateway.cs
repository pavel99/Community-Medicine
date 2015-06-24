using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using CommunityMedicine.Model;
using System.Data.SqlClient;

namespace CommunityMedicine.DAL
{
    public class DiseaseGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["CommunityMedicineConDB"].ConnectionString;

        public int Save(Disease aDisease)
        {
            string query = string.Format("INSERT INTO Diesease VALUES('{0}','{1}','{2}')",aDisease.DiseaseName,aDisease.Description,aDisease.TreatmentProcedure);
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;

        }
        public bool IsDiseaseNameExists(Disease aDisease)
        {
            bool isDiseaseNameExists = false;

            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("Select * From Diesease where DiseaseName='{0}'", aDisease.DiseaseName);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                isDiseaseNameExists = true;
                break;
            }
            reader.Close();
            connection.Close();
            return isDiseaseNameExists;
        }
        public List<Disease> GetAlldDiseases()
        {
            List<Disease> diseaseList = new List<Disease>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("Select * From Diesease");

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();
            int serial = 1;
            while (reader.Read())
            {
                Disease aDisease=new Disease();
                aDisease.Serial = serial;
                aDisease.DiseaseName = reader["DiseaseName"].ToString();
                aDisease.Description = reader["Description"].ToString();
                aDisease.TreatmentProcedure = reader["TreatementProcedure"].ToString();

                diseaseList.Add(aDisease);
                serial++;
            }
            reader.Close();
            connection.Close();
            return diseaseList;

        }
    }
}