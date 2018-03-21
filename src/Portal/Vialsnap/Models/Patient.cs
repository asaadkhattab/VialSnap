using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vialsnap.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Prefix { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FirstName { get; set; }
        public string Suffix { get; set; }

        public DateTimeOffset DateOfBirth { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }

        public int HomeNumber { get; set; }
        public int CellNumber { get; set; }
        public int Email { get; set; }


        public decimal AccountBalance { get; set; }

        public int? MedicationId { get; set; }
        public virtual Medication Medication { get; set; }

    }
}

 