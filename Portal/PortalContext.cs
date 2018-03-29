namespace Portal
{
    using Portal.Models;
    using System.Data.Entity;

    public class PortalContext : DbContext
    {

        public PortalContext()
            : base("name=PortalContext")
        {
        }
        public virtual DbSet<Pharmacy> Pharmacies { get; set; }

        public virtual DbSet<MedControlledSubstance> MedControlledSubstances { get; set; }

        public virtual DbSet<Medication> Medications { get; set; }

        public virtual DbSet<Patient> Patients { get; set; }
 
    }
}