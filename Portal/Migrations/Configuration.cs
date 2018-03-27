using Portal.Models;
using System.Data.Entity.Migrations;

namespace Portal.Migrations
{
    using Portal.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<PortalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PortalContext context)
        {
            context.Pharmacies.AddOrUpdate(
                p => p.PharmacyId,
                new Pharmacy { PharmacyId = 1, Name = "Mountain Apothecare", City = "Paintsville", State = "KY"},
                new Pharmacy { PharmacyId = 2, Name = "CVS", City = "Los Angeles", State = "CA"},
                new Pharmacy { PharmacyId = 3, Name = "RiteAid", City = "Dayton", State = "OH"}
                );

            context.Medications.AddOrUpdate(
                m => m.MedicationId,
                new Medication { MedicationId = 1, Name = "Tylenol"},
                new Medication { MedicationId = 2, Name = "Adderall"},
                new Medication { MedicationId = 3, Name = "Advil"},
                new Medication { MedicationId = 4, Name = "Nexium"}        
                );

            context.SaveChanges();

            context.MedControlledSubstances.AddOrUpdate(
                mcss => new { mcss.PharmacyId, mcss.MedicationId },
                new MedControlledSubstance { PharmacyId = 1, MedicationId = 1, Schedule = 1 },
                new MedControlledSubstance { PharmacyId = 2, MedicationId = 2, Schedule = 2 },
                new MedControlledSubstance { PharmacyId = 3, MedicationId = 1, Schedule = 2 }
                );

            context.Patients.AddOrUpdate(
                pat => pat.PatientId,
                new Patient { PatientId = 1, Prefix = "Mr", FirstName = "Asaad", MiddleName = "Y", LastName = "Khattab", Suffix = "III", AccountBalance = 99, MedicationId = 4   },
                new Patient { PatientId = 2, Prefix = "Mrs", FirstName = "Emily", MiddleName = "N", LastName = "Green", Suffix = "PhD", AccountBalance = 9, MedicationId = 1},
                new Patient { PatientId = 3, Prefix = "Mr", FirstName = "Sam", MiddleName = "Y", LastName = "Farthing", Suffix = "Sr.", AccountBalance = 134, MedicationId = 3},
                new Patient { PatientId = 4, Prefix = "Mr", FirstName = "Avram", MiddleName = "C", LastName = "Hale", Suffix = "I", AccountBalance = 23, MedicationId = 1}
                );







        }
    }
}
