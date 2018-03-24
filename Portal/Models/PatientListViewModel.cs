using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Models
{
    public class PatientListViewModel
    {
        public List<PatientViewModel> Patients { get; set; }
        public int TotalPatients { get; set; }
    }
}