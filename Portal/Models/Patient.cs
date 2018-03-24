using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }

        public int AccountBalance { get; set; }

        public int MedicationId { get; set; }
        public virtual Medication Medication { get; set; }
    }
}