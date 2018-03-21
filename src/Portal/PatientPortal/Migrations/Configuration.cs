using PatientPortal.Models;

using System.Data.Entity.Migrations;

namespace PatientPortal.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<PatientPortalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PatientPortal.Models.PatientPortalContext";
        }

        protected override void Seed(PatientPortalContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );

            context.Physician.AddOrUpdate(
                p => p.PhysicianId,
                    new Physician { PhysicianId = 1, Title = "Dr.", LastName = "William", FirstName = "Conner" },
                    new Physician { PhysicianId = 2, Title = "Dr.", LastName = "Samantha", FirstName = "Greene" },
                    new Physician { PhysicianId = 3, Title = "Dr.", LastName = "Serena", FirstName = "Patrick" },
                    new Physician { PhysicianId = 4, Title = "Dr.", LastName = "James", FirstName = "Begley" }
                );
        }
    }
}
