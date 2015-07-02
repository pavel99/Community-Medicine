using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicine.Model
{
    public class Treatment
    {
        public int  Id{ get; set; }
        public string VoterId { get; set; }
        public string Observation { set; get; }
        public string Date{ get; set; }
        public int  DoctorId { get; set; }
        public int DiseaseId { get; set; }
        public int MedicineId { set; get; }
        public string Dose { get; set; }

        public string Meal { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
        public int CenterId { get; set; }

        
        

        
    }
}