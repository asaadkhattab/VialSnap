using System.Collections.Generic;
using System.ComponentModel;


namespace Portal.Models
{
    public class PharmacyViewModel
    {
        public PharmacyViewModel()
        {
            MedControlledSubstances = new List<MedControlledSubstanceViewModel>();
        }

        public int? PharmacyId { get; set; }

        [DisplayName("Name: ")]
        public string Name { get; set; }


        [DisplayName("City: ")]
        public string City { get; set; }

        [DisplayName("State: ")]
        public string State { get; set; }

        [DisplayName("Pharmacy Info: ")]
        public string PharmacyInfo => Name + " at " + City + "," + " " + State; 

        public List<MedControlledSubstanceViewModel> MedControlledSubstances { get; set; }
    }
}