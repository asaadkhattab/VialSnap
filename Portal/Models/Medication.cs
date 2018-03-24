using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Models
{
    public class Medication
    {
        public Medication()
        {
            MedControlledSubstances = new HashSet<MedControlledSubstance>();
        }

        public int MedicationId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<MedControlledSubstance> MedControlledSubstances { get; set; }
    }
}