using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicine.Model
{
    public class Services
    {
        public int Id { get; set; }
        public string VoterId { get; set; }
        public int ServiceGiven { get; set; }
    }
}