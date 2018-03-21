using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vialsnap.Models
{
    public class PatientListViewModel
    {
        public List<PatientViewModel> People { get; set; }
        public int TotalPeople { get; set; }
    }
}