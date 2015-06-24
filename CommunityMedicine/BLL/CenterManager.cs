using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunityMedicine.DAL;
using CommunityMedicine.Model;

namespace CommunityMedicine.BLL
{
    public class CenterManager
    {
        CenterGateway gateway = new CenterGateway();
        public List<District> PopulateDropDownList()
        {
            return gateway.PopulateDropDownList();

        }

        public List<Thana> PopulateThanaDropDownList(int districtId)
        {
            return gateway.PopulateThanaDropDownList(districtId);
        }

        public int Save(Center aCenter)
        {
            return gateway.Save(aCenter);
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
    }
}