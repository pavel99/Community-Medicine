using System;
using System.Collections.Generic;
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

        public bool IsPatientAlreadyExists(Services aService)
        {
            return gateway.IsPatientAlreadyExists(aService);
        }

        public string UpdateQuantity(int centerId, int medicineId,int value)
        {
            if ((gateway.GetQuantiyOfMedicine(centerId, medicineId) - treatment.Quantity) > 0)
            {
                if (gateway.UpdateQuantity(centerId, medicineId, value) > 0)
                {
                    return "Updated Succesfully"
                }
                else
                {
                    return "Upadating failed"
                }
            }
            else
            {
                return "There is not enough medicine, the quantity of the medicine is  now " +
                       gateway.GetQuantiyOfMedicine(centerId, medicineId);
            }
        }
    }
}