using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PatientPortal.Models
{
    public class PatientPortalContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PatientPortalContext() : base("name=PatientPortalContext")
        {
        }

        public System.Data.Entity.DbSet<PatientConsoleModel.Models.Patient> Patients { get; set; }

        public System.Data.Entity.DbSet<PatientPortal.Models.Medication> Medications { get; set; }
    }
}
