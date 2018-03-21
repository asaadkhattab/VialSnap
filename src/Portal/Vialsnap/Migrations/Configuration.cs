using Vialsnap.Models;
using System.Data.Entity.Migrations;

namespace Vialsnap.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<Vialsnap.VialsnapContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Vialsnap.VialsnapContext context)
        {


            context.Medications.AddOrUpdate(
                m => m.MedicationId,
                new Medication { MedicationId = 1, Name = "Tylenol" },
                new Medication { MedicationId = 2, Name = "Crestor"},
                new Medication { MedicationId = 3, Name = "Prozac"},
                new Medication { MedicationId = 4, Name = "Advil"},
                new Medication { MedicationId = 5, Name = "Aspirin"},
                new Medication { MedicationId = 6, Name = "Ibuprofen"}
                );
            context.SaveChanges();

            context.People.AddOrUpdate(
                p => p.PatientId,
                new Patient { PatientId = 1, Prefix = "Mr", FirstName = "Andrew", MiddleName = "Andy", LastName = "Peters", Suffix = "PhD", MedicationId = 1 },
                new Patient { PatientId = 2, Prefix = "Mrs.", FirstName = "Emily", MiddleName = "La", LastName = "Brown", Suffix = "Sr.", MedicationId = 2 }
            );
        }
    }
}
