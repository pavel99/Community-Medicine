using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicine.Model
{
    public class MedicineQuantity
    {
        public int Id { get; set; }

        public int MedicineId { get; set; }

        public int Quantity { get; set; }

        public int CenterId { get; set; }
    }
}