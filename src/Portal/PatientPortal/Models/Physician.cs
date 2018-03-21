using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.Models
{
    public class Physician
    {
        public int PhysicianId { get; set; }
        public string Title { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}