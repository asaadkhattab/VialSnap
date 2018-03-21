using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.Models
{
    public class PhysicianList
    {
        public List<PhysicianViewModel> Doctor { get; set; }
        public int TotalPhysician { get; set; }
    }
}