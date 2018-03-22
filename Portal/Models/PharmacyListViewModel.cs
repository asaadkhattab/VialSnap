using System.Collections.Generic;

namespace Portal.Models
{
    public class PharmacyListViewModel
    {
        public List<PharmacyViewModel> Pharmacies { get; set; }
        public int TotalPharmacies { get; set; }
    }
}