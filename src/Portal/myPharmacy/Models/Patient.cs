using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myPharmacy.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Reason { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public string Medication { get; set; }
    }
}