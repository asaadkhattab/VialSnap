using PatientConsoleModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientConsoleModel
{
    public class Context : DbContext
    {
        public Context()
        {
            //When we change the database
            Database.SetInitializer(new DatabaseInitializer());
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Basic> Basics { get; set; }


        //Override
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Patient>()
                .Property(p => p.PatientWeight)
                .HasPrecision(4, 4);

            
        }
    }


}
