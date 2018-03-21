using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace PatientPortal.Models
{
    public class PhysicianViewModel
    {

        public int? PhysicianId { get; set; }

        public string Title { get; set; }

        [DisplayName("Last Name: ")]
        public string LastName { get; set; }

        [DisplayName("First Name: ")]
        public string FirstName { get; set; }

        [DisplayName("Full Name: ")]
        public string FullName => Title + " " + FirstName + " " + LastName;
    }
}

