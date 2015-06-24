using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunityMedicine.DAL;
using CommunityMedicine.Model;

namespace CommunityMedicine.BLL
{
    public class DiseaseManager
    {
        DiseaseGateway aGateway=new DiseaseGateway();

        public string Save(Disease aDisease)
        {
            if (aGateway.IsDiseaseNameExists(aDisease))
            {
                return "Disease Already Exists";
            }
            else 
            {
                if (aGateway.Save(aDisease) > 0)
                {
                    return "Saved Succesfully";
                }
                else
                {
                    return "Saving Failed";
                }
                 
            }
            
        }
        public List<Disease> GetAlldDiseases()
        {
            return aGateway.GetAlldDiseases();
        }
    }
}