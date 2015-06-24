using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicine.Model
{
    public class Disease
    {
        public int  Serial { get; set; }
        public string DiseaseName { get; set; }
        public string Description { set; get; }
        public string TreatmentProcedure { get; set; }
    }
}