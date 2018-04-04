using System.ComponentModel.DataAnnotations;

namespace Portal.Models
{
    public class Patient
    {
        public int PatientId { get; set; }

        public string Prefix { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Suffix { get; set; }

        public int AccountBalance { get; set; }

        //Medication
        public int MedicationId { get; set; }
        public virtual Medication Medication { get; set; }

 
    }
}