using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "The name of the pharmacy is required.")]
        public string Name { get; set; }


        [DisplayName("City: ")]
        [Required(ErrorMessage = "The city of the pharmacy is required.")]
        public string City { get; set; }

        [DisplayName("State: ")]
        [Required(ErrorMessage = "The state of the pharmacy is required.")]
        public string State { get; set; }
 
        public string PharmacyInfo => Name + " at " + City + "," + " " + State; 

        public List<MedControlledSubstanceViewModel> MedControlledSubstances { get; set; }
    }
}