using PatientPortal.Models;
using System.Data.Entity;

namespace PatientPortal
{
    public class PhysicianPortalContext : DbContext
    {
        public PhysicianPortalContext() : base("name=PhysicianPortalContext") { }
        public virtual DbSet<Physician> Doctor { get; set; }
    }
}