﻿using System;
using System.Collections.Generic;

namespace Portal.Models
{
    public class Pharmacy
    {

        public Pharmacy()
        {
            //Navigation Property
            MedControlledSubstances = new HashSet<MedControlledSubstance>();
        }

        public int PharmacyId { get; set; }

        public string Name { get; set; }

        public string State { get; set; }

        public string City { get; set; }
        
        public virtual ICollection<MedControlledSubstance> MedControlledSubstances { get; set; }
    }
}