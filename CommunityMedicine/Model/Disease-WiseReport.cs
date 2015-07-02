using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicine.Model
{
    public class DiseaseWiseReports
    {
        public string DistrictName { get; set; }
        public int TotalPatient { get; set; }
        public double  PercentageOverPopulation { get; set; }
    }
}