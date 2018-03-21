﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientConsoleModel.Models
{
    //Bridge Entity Class
    public class PatientPhysician
    {
        public int Id { get; set; }
        //Foreign Key Properties
        public int PatientId { get; set; }
        public int PhysicianId { get; set; }
        public int RoleId { get; set; }

        //Navigation Properties
        public virtual Patient Patient { get; set; }
        public virtual Physician Physician { get; set; }
        public virtual Role Role { get; set; }

    }
}
