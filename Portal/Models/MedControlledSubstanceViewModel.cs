using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Models
{
    public class MedControlledSubstanceViewModel
    {
        public MedicationViewModel Medication { get; set; }
        public int Schedule { get; set; }
    }
}