using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace CommunityMedicine.Model
{
    public class Thana
    {
        public int ThanaId { get; set; }
        public string ThanaName { get; set; }
        public int DistrictId { get; set; }
    }
}