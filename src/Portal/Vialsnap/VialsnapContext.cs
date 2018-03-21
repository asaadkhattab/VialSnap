namespace Vialsnap
{
    using Vialsnap.Models;
    using System.Data.Entity;

    public class VialsnapContext : DbContext
    {
        public VialsnapContext()
            : base("name=VialsnapContext")
        {
        }

        public virtual DbSet<Patient> People { get; set; }
        public virtual DbSet<Medication> Medications { get; set; }
    }
}