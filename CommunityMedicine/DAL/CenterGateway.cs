using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CommunityMedicine.Model;

namespace CommunityMedicine.DAL
{
    public class CenterGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["CommunityMedicineConDB"].ConnectionString;

        public List<District> PopulateDropDownList()
        {
            
            List<District> districtList = new List<District>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("SELECT * FROM District");
           
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
           
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
               District aDistrict=new District();
                aDistrict.DistrictId = Convert.ToInt32(reader["DistrictId"]);
                aDistrict.DistrictName = reader["DistrictName"].ToString();
                districtList.Add(aDistrict);

            }
            reader.Close();
            connection.Close();
            return districtList;
        }
        public List<Thana> PopulateThanaDropDownList(int districtId)
        {

            List<Thana> thanaList = new List<Thana>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("SELECT * FROM Thana Where DistrictId='{0}'",districtId);

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
               Thana aThana = new Thana();
                aThana.ThanaId = Convert.ToInt32(reader["ThanaId"]);
                aThana.ThanaName = reader["ThanaName"].ToString();
                thanaList.Add(aThana);

            }
            reader.Close();
            connection.Close();
            return thanaList;
        }
        public List<Center> PopulateCenterDropDownList(int thanaId)
        {

            List<Center> centerList = new List<Center>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("SELECT * FROM Center Where ThanaId='{0}'", thanaId);

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Center aCenter = new Center();
                aCenter.CenterId = Convert.ToInt32(reader["CenterId"]);
                aCenter.CenterName = reader["CenterName"].ToString();
                centerList.Add(aCenter);

            }
            reader.Close();
            connection.Close();
            return centerList;
        }
        public List<Medicine> PopulateMedicineDropDownList()
        {

            List<Medicine> medicineList = new List<Medicine>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("SELECT * FROM Medicine");

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Medicine aMedicine = new Medicine();
                aMedicine.Serial = Convert.ToInt32(reader["MedicineId"]);
                aMedicine.MedicineName= reader["MedicineName"].ToString();
                medicineList.Add(aMedicine);

            }
            reader.Close();
            connection.Close();
            return medicineList;
        }
        public int Save(Center aCenter)
        {
            string query = string.Format("INSERT INTO Center VALUES('{0}','{1}','{2}','{3}')", aCenter.CenterName, aCenter.CenterCode,aCenter.CenterPassword,aCenter.ThanaId);
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;

        }
        public int SaveDoctor(Doctor aDoctor)
        {
            string query = string.Format("INSERT INTO Doctor VALUES('{0}','{1}','{2}','{3}')", aDoctor.DoctorName, aDoctor.Degree, aDoctor.Specialization,aDoctor.CenterId);
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;

        }
        public bool Login(string centerCode,string password)
        {
            bool isUserExists=false;
           
            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("SELECT * FROM Center Where CenterCode='{0}' AND CenterPassword='{1}'",centerCode,password);

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                isUserExists = true;



            }
            reader.Close();
            connection.Close();
            return isUserExists;

        }
        public Center GetCenter(string centerCode, string password)
        {
            Center aCenter = new Center();
            
            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("SELECT * FROM Center Where CenterCode='{0}' AND CenterPassword='{1}'", centerCode, password);

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                
                aCenter.CenterId = Convert.ToInt32(reader["CenterId"]);
                aCenter.CenterName = reader["CenterName"].ToString();
                aCenter.CenterCode = reader["CenterCode"].ToString();
                aCenter.CenterPassword = reader["CenterPassword"].ToString();
                aCenter.ThanaId = Convert.ToInt32(reader["ThanaId"]);
                

            }
            reader.Close();
            connection.Close();
            return aCenter;
        }
        public int SaveMedicineQuantity(MedicineQuantity medicineQuantity)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT INTO DistributeMedicine VALUES('" + medicineQuantity.CenterId + "','" + medicineQuantity.MedicineId + "','" + medicineQuantity.Quantity + "')";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowsAffected;
        }

        public int GetMedicineIdByName(string name)
        {
            string query = string.Format("SELECT MedicineId FROM Medicine Where MedicineName='{0}'", name);
            SqlConnection connection=new SqlConnection(connectionString);
            SqlCommand command=new SqlCommand(query,connection);
            connection.Open();
            Medicine aMedicine=new Medicine();
              aMedicine.Serial= Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return aMedicine.Serial;
        }

        public bool IsMedicineIdAlreadyExists(int medicineId,int centerId)
        {
            bool IsMedicineIdAlreadyExists = false;
            string query = string.Format("SELECT * FROM DistributeMedicine  Where MedicineId='{0}' AND CenterId='{1}'", medicineId,centerId);
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                IsMedicineIdAlreadyExists = true;


            }
            reader.Close();
            connection.Close();
            return IsMedicineIdAlreadyExists;



        }

        public int UpdateQuantity(int centerId, int medicineId, int value)
        {
            string query=string.Format(@"UPDATE DistributeMedicine SET Quantity=Quantity+'{0}'where CenterId='{1}'" +
                                       " AND MedicineId='{2}'",value,centerId,medicineId);
            SqlConnection connection=new SqlConnection(connectionString);
            SqlCommand command=new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<MedicineStockReport> MedicineStockReport(int centerId)
        {
            List<MedicineStockReport> quantityList=new List<MedicineStockReport>();
            string query =
                string.Format(@"select Medicine.MedicineName as MedicineName,DistributeMedicine.Quantity From DistributeMedicine join Medicine" +
                " ON Medicine.MedicineId=DistributeMedicine.MedicineId inner join Center ON " +
                "DistributeMedicine.CenterId =Center.CenterId where DistributeMedicine.CenterId='{0}' " +
                "Group By MedicineName,DistributeMedicine.Quantity ",centerId);
            SqlConnection connection=new SqlConnection(connectionString);
            SqlCommand command=new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                MedicineStockReport stockReport=new MedicineStockReport();
                stockReport.MedicineName = reader["MedicineName"].ToString();
                stockReport.Quantity = Convert.ToInt32(reader["Quantity"]);
                quantityList.Add(stockReport);

            }
            reader.Close();
            connection.Close();
            return quantityList;

        }
        public bool IsCenterNameExists(Center aCenter)
        {
            bool isCenterNameExists = false;

            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("Select * From Center where CenterName='{0}' and ThanaId='{1}'", aCenter.CenterName,aCenter.ThanaId);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                isCenterNameExists = true;
                break;
            }
            reader.Close();
            connection.Close();
            return isCenterNameExists;
        }
    }
}