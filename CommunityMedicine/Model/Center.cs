using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicine.Model
{
    public class Center
    {
        public int CenterId { get; set; }
        public string CenterName { get; set; }

        public string CenterCode { get; set; }

        public string CenterPassword { get; set; }

        public int ThanaId { get; set; }
    }
}