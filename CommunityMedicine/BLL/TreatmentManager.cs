using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CommunityMedicine.DAL;
using CommunityMedicine.Model;

namespace CommunityMedicine.BLL
{
    public class TreatmentManager
    {
        TreatmentGateway  gateway=new TreatmentGateway();
        Treatment treatment=new Treatment();

        public List<Doctor> PopulateDoctorDropDownList(int centerId)
        {
            return gateway.PopulateDoctorDropDownList(centerId);
        }

        public List<Disease> PopulateDiseaseDropDownList()
        {
           return gateway.PopulateDiseaseDropDownList();
        }

        public List<Medicine> PopulateMedicineDropDownList(int centerId)
        {
            return gateway.PopulateMedicineDropDownList(centerId);
        }

        public string SaveTreatMent(Treatment aTreatment)
        {
            if (gateway.SaveTreatMent(aTreatment) > 0)
            {
                return "Saved Succesfully";
            }
            else
            {
                return "Saving failed";
            }
            
        }

        public List<Dose> PopulateDosedropdownList()
        {
            return gateway.PopulateDosedropdownList();
        }

        public bool IsPatientAlreadyExists(string voterId)
        {
            return gateway.IsPatientAlreadyExists(voterId);
        }

        public string UpdateQuantity(int centerId, int medicineId,int value)
        {
            if ((gateway.GetQuantiyOfMedicine(centerId, medicineId) - treatment.Quantity) > 0)
            {
                if (gateway.UpdateQuantity(centerId, medicineId, value) > 0)
                {
                    return "Updated Succesfully";
                }
                else
                {
                    return "Upadating failed";
                }
            }
            else
            {
                return "There is not enough medicine, the quantity of the medicine is  now " +
                       gateway.GetQuantiyOfMedicine(centerId, medicineId);
            }
        }

        public string UpdateServiceGiven(string voterId)
        {
            if (gateway.UpdateServiceGiven(voterId) > 0)
            {
                return "Updated Succesfully";
            }
            else
            {

                return "Updating failed";
            }
        }

        public string SaveService(Services aService)
        {
            if (gateway.SaveService(aService)>0)
            {
                return "Saved Succesfully";
            }
            else
            {
                return "Saving Failed";
            }
        }

        public int GetDiseaseIdByName(string diseaseName)
        {
            return gateway.GetDiseaseIdByName(diseaseName);
        }

        public int GetMedicineIdByName(string medicineName)
        {
            return gateway.GetMedicineIdByName(medicineName);
        }

        public int GetServiceGivenByVoterId(string voterId)
        {
            return gateway.GetServiceGivenByVoterId(voterId);
        }

        public List<DiseaseWiseReports> GetDiseaseWiseReport(int diseaseId, string date1, string date2)
        {
            return gateway.GetDiseaseWiseReport(diseaseId, date1, date2);
        }

        public DataTable GetData(string districtName, string fromDate, string toDate)
        {
            return gateway.GetData(districtName, fromDate, toDate);
        }
    }
}