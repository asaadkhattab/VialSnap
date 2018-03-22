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
        }
    }
}
