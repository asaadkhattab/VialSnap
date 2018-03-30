namespace Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "InsuranceId", "dbo.Insurances");
            DropForeignKey("dbo.Patients", "PharmacyId", "dbo.Pharmacies");
            DropIndex("dbo.Patients", new[] { "PharmacyId" });
            DropIndex("dbo.Patients", new[] { "InsuranceId" });
            AddColumn("dbo.Patients", "Insurance", c => c.String());
            DropColumn("dbo.Patients", "PharmacyId");
            DropColumn("dbo.Patients", "InsuranceId");
            DropTable("dbo.Insurances");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Insurances",
                c => new
                    {
                        InsuranceId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.InsuranceId);
            
            AddColumn("dbo.Patients", "InsuranceId", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "PharmacyId", c => c.Int(nullable: false));
            DropColumn("dbo.Patients", "Insurance");
            CreateIndex("dbo.Patients", "InsuranceId");
            CreateIndex("dbo.Patients", "PharmacyId");
            AddForeignKey("dbo.Patients", "PharmacyId", "dbo.Pharmacies", "PharmacyId", cascadeDelete: true);
            AddForeignKey("dbo.Patients", "InsuranceId", "dbo.Insurances", "InsuranceId", cascadeDelete: true);
        }
    }
}
