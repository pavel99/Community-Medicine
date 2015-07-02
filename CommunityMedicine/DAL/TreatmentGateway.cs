using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using CommunityMedicine.Model;
using CommunityMedicine.UI;

namespace CommunityMedicine.DAL
{
    public class TreatmentGateway
    {
        Doctor aDoctor = new Doctor();
        private string connectionString = ConfigurationManager.ConnectionStrings["CommunityMedicineConDB"].ConnectionString;

        public List<Doctor> PopulateDoctorDropDownList(int centerId)
        {

            List<Doctor> doctorList = new List<Doctor>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("SELECT * FROM Doctor Where CenterId='{0}'", centerId);

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Doctor aDoctor = new Doctor();
                aDoctor.Id = Convert.ToInt32(reader["Id"]);
                aDoctor.DoctorName = reader["DoctorName"].ToString();
                doctorList.Add(aDoctor);

            }
            reader.Close();
            connection.Close();
            return doctorList;
        }

        public List<Dose> PopulateDosedropdownList()
        {
            List<Dose> doseList = new List<Dose>();
            Dose dose1 = new Dose();
            dose1.Id = 1;
            dose1.DoseType = "1+0+0";
            doseList.Add(dose1);


            Dose dose2 = new Dose();
            dose2.Id = 2;
            dose2.DoseType = "0+1+0";
            doseList.Add(dose2);

            Dose dose3 = new Dose();
            dose3.Id = 3;
            dose3.DoseType = "0+0+1";
            doseList.Add(dose3);

            Dose dose4 = new Dose();
            dose4.Id = 4;
            dose4.DoseType = "1+1+0";
            doseList.Add(dose4);

            Dose dose5 = new Dose();
            dose5.Id = 5;
            dose5.DoseType = "1+0+1";
            doseList.Add(dose5);

            Dose dose6 = new Dose();
            dose6.Id = 6;
            dose6.DoseType = "1+1+0";
            doseList.Add(dose6);

            Dose dose7 = new Dose();
            dose6.Id = 7;
            dose6.DoseType = "0+1+1";
            doseList.Add(dose7);

            Dose dose8 = new Dose();
            dose8.Id = 8;
            dose8.DoseType = "1+1+1";
            doseList.Add(dose8);

            return doseList;


        }
        public List<Disease> PopulateDiseaseDropDownList()
        {

            List<Disease> diseaseList = new List<Disease>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("SELECT * FROM Diesease");

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Disease adDisease = new Disease();
                adDisease.Serial = Convert.ToInt32(reader["DiseaseId"]);
                adDisease.DiseaseName = reader["DiseaseName"].ToString();
                diseaseList.Add(adDisease);

            }
            reader.Close();
            connection.Close();
            return diseaseList;
        }
        public List<Medicine> PopulateMedicineDropDownList(int centerId)
        {

            List<Medicine> medicineList = new List<Medicine>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("SELECT Medicine.MedicineId,Medicine.MedicineName FROM DistributeMedicine INNER JOIN Medicine ON Medicine.MedicineId=DistributeMedicine.MedicineId Where CenterId='{0}'", centerId);

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Medicine medicine = new Medicine();
                medicine.Serial = Convert.ToInt32(reader["MedicineId"]);
                medicine.MedicineName = reader["MedicineName"].ToString();
                medicineList.Add(medicine);

            }
            reader.Close();
            connection.Close();
            return medicineList;
        }
        public int SaveTreatMent(Treatment aTreatment)
        {
            string query = string.Format("INSERT INTO Treatment VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", aTreatment.VoterId, aTreatment.Observation, aTreatment.Date, aTreatment.DoctorId, aTreatment.DiseaseId, aTreatment.MedicineId, aTreatment.Dose, aTreatment.Meal, aTreatment.Quantity, aTreatment.Note, aTreatment.CenterId);
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;

        }
        public int SaveService(Services aService)
        {
            string query = string.Format("INSERT INTO Service VALUES('{0}','{1}')", aService.VoterId, aService.ServiceGiven);
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;

        }
        public bool IsPatientAlreadyExists(string voterId)
        {
            bool isPatientExists = false;

            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("Select * From Service where VoterId='{0}'", voterId);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                isPatientExists = true;
                break;
            }
            reader.Close();
            connection.Close();
            return isPatientExists;
        }
        public int UpdateQuantity(int centerId, int medicineId, int value)
        {
            string query = string.Format(@"UPDATE DistributeMedicine SET Quantity=Quantity-'{0}'where CenterId='{1}'" +
                                       " AND MedicineId='{2}'", value, centerId, medicineId);
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public int GetQuantiyOfMedicine(int centerId, int medicineId)
        {
            string query = string.Format("Select Quantity From DistributeMedicine Where CenterId='{0}' AND MedicineId='{1}'", centerId, medicineId);

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int quantity = (int)command.ExecuteScalar();
            connection.Close();
            return quantity;
        }
        public int UpdateServiceGiven(string voterId)
        {
            string query = string.Format(@"UPDATE Service SET ServiceGiven=ServiceGiven+1 where VoterId='{0}'", voterId);
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
        public int GetDiseaseIdByName(string diseaseName)
        {
            string query = string.Format("SELECT DiseaseId FROM Diesease Where DiseaseName='{0}'", diseaseName);
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            Disease disease = new Disease();
            disease.Serial = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return disease.Serial;
        }
        public int GetMedicineIdByName(string medicineName)
        {
            string query = string.Format("SELECT MedicineId FROM Medicine Where MedicineName='{0}'", medicineName);
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            Medicine medicine = new Medicine();
            medicine.Serial = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return medicine.Serial;
        }
        public int GetServiceGivenByVoterId(string voterId)
        {
            string query = string.Format("SELECT ServiceGiven FROM Service Where VoterId='{0}'", voterId);
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            Services services = new Services();
            services.ServiceGiven = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return services.ServiceGiven;
        }

        //public List<Treatment> GetTreatments(string medicineId, string date)
        //{
        //    string query=string.Format("Select ")
        //}
        public List<DiseaseWiseReports> GetDiseaseWiseReport(int diseaseId, string date1, string date2)
        {
            DataTable dt = new DataTable();
            List<DiseaseWiseReports> reports = new List<DiseaseWiseReports>();
            string query = string.Format(@"select District.DistrictName , Count(" +
                                         "distinct(Treatment.VoterId)) as NumberOfPatient,District.Population From Treatment " +
                                         "inner join Center on Treatment.CenterId=Center.CenterId inner join " +
                                         "Thana on Center.ThanaId=Thana.ThanaId inner join District on " +
                                         "Thana.DistrictId=District.DistrictId inner join Diesease on" +
                                         " Treatment.DiseaseId=Diesease.DiseaseId  where Diesease.DiseaseId='{0}'" +
                                         " and Treatment.Date Between '{1}' and '{2}'" +
                                         " GROUP BY District.DistrictName,Diesease.DiseaseName,District.Population",
                diseaseId, date1, date2);
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DiseaseWiseReports report = new DiseaseWiseReports();
                report.DistrictName = reader[0].ToString();
                report.TotalPatient = Convert.ToInt32(reader[1]);
                int poplulation = Convert.ToInt32(reader[2]);
                report.PercentageOverPopulation = ((report.TotalPatient * 100.0) / poplulation);
                reports.Add(report);

            }
            connection.Close();
            return reports;

        }

        public DataTable GetData(string districtName, string fromDate, string toDate)
        {
            DataTable dt = new DataTable();
            string query =
                string.Format(
                    "Select Diesease.DiseaseName,Count(distinct(Treatment.VoterId)) " +
                    "From Treatment inner join Diesease on Diesease.DiseaseId=Treatment.DiseaseId " +
                    "inner join Center on Treatment.CenterId=Center.CenterId inner join Thana on " +
                    "Thana.ThanaId=Center.ThanaId inner join District on Thana.DistrictId=District.DistrictId " +
                    "Where District.DistrictName='{0}' AND Treatment.Date between '{1}' AND '{2}' " +
                    "Group By Diesease.DiseaseName",
                    districtName, fromDate, toDate);
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query);
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                command.CommandType = CommandType.Text;
                command.Connection = connection;
                sda.SelectCommand = command;
                sda.Fill(dt);
            }
            return dt;
        }





    }
}
