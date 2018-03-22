using System.ComponentModel;

namespace Portal.Models
{
    public class PharmacyViewModel
    {
        public int? PharmacyId { get; set; }

        [DisplayName("Name: ")]
        public string Name { get; set; }


        [DisplayName("City: ")]
        public string City { get; set; }

        [DisplayName("State: ")]
        public string State { get; set; }

        public string PharmacyInfo => Name + " at " + City + "," + " " + State; 
    }
}