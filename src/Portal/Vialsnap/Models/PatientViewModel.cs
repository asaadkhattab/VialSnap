using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Vialsnap.Models
{
    public class PatientViewModel
    {
        public int? PatientId { get; set; }

        [DisplayName("Prefix:")]
        public string Prefix { get; set; }

        [DisplayName("Last Name:")]
        public string LastName { get; set; }

        [DisplayName("Middle Name:")]
        public string MiddleName { get; set; }

        [DisplayName("First Name:")]
        public string FirstName { get; set; }

        [DisplayName("Suffix:")]
        public string Suffix { get; set; }

        [DisplayName("Date Of Birth: ")]
        public DateTimeOffset DateOfBirth { get; set; }

        [DisplayName("Address Line 1:")]
        public string AddressLine1 { get; set; }

        [DisplayName("Address Line 2:")]
        public string AddressLine2 { get; set; }


        public string State { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }

        [DisplayName("Home Number:")]
        public int HomeNumber { get; set; }

        [DisplayName("Cell Number: ")]
        public int CellNumber { get; set; }
        public int Email { get; set; }


        public decimal AccountBalance { get; set; }


        [DisplayName("Name: ")]
        public string FullName => Prefix + " " + FirstName + " " + MiddleName + " "  + LastName + " " + Suffix;

       // [DisplayName("Address: ")]
       // public string FullAddress => AddressLine1 + "" + AddressLine2 + " " + State + "," + City + " " + Zip;

        public string Name { get; set; }
        public MedicationViewModel Medication { get; set; }
    }
}