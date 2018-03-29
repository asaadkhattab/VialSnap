using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Portal.Models
{
    public class Pharmacy
    {

        public Pharmacy()
        {
            //Navigation Property
            MedControlledSubstances = new HashSet<MedControlledSubstance>();
        }

        public int PharmacyId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        public virtual ICollection<MedControlledSubstance> MedControlledSubstances { get; set; }
 
    }
}