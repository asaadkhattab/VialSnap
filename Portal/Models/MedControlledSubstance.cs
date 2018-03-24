using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Models
{
    public class MedControlledSubstance
    {
        [Key]
        [Column(Order = 1)]
        public int PharmacyId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int MedicationId { get; set; }
        public int Schedule { get; set; }
        public virtual Pharmacy Pharmacy { get; set; }
        public virtual Medication Medication { get; set; }
    }
}