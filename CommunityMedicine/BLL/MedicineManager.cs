using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunityMedicine.DAL;
using CommunityMedicine.Model;

namespace CommunityMedicine.BLL
{
    public class MedicineManager
    {
        MedicineGateway aGateway=new MedicineGateway();

        public string Save(Medicine aMedicine)
        {
            if (aGateway.IsMedicineNameExists(aMedicine))
            {
                return "Medicine Already Exist.";
            }
            else if (aGateway.Save(aMedicine) > 0)
            {
                return "Successfully Saved.";

            }
            else
            {
                return "Saving Failed.";
            }
        }

        public List<Medicine> GetAllMedicine()
        {
            return aGateway.GetAllMedicine();
        }
    }
}