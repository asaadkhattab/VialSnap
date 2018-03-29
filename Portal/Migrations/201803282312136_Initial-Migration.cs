namespace Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Insurances",
                c => new
                    {
                        InsuranceId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.InsuranceId);
            
            CreateTable(
                "dbo.MedControlledSubstances",
                c => new
                    {
                        PharmacyId = c.Int(nullable: false),
                        MedicationId = c.Int(nullable: false),
                        Schedule = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PharmacyId, t.MedicationId })
                .ForeignKey("dbo.Medications", t => t.MedicationId, cascadeDelete: true)
                .ForeignKey("dbo.Pharmacies", t => t.PharmacyId, cascadeDelete: true)
                .Index(t => t.PharmacyId)
                .Index(t => t.MedicationId);
            
            CreateTable(
                "dbo.Medications",
                c => new
                    {
                        MedicationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.MedicationId);
            
            CreateTable(
                "dbo.Pharmacies",
                c => new
                    {
                        PharmacyId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PharmacyId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        Prefix = c.String(),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false),
                        Suffix = c.String(),
                        AccountBalance = c.Int(nullable: false),
                        MedicationId = c.Int(nullable: false),
                        PharmacyId = c.Int(nullable: false),
                        InsuranceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PatientId)
                .ForeignKey("dbo.Insurances", t => t.InsuranceId, cascadeDelete: true)
                .ForeignKey("dbo.Medications", t => t.MedicationId, cascadeDelete: true)
                .ForeignKey("dbo.Pharmacies", t => t.PharmacyId, cascadeDelete: true)
                .Index(t => t.MedicationId)
                .Index(t => t.PharmacyId)
                .Index(t => t.InsuranceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "PharmacyId", "dbo.Pharmacies");
            DropForeignKey("dbo.Patients", "MedicationId", "dbo.Medications");
            DropForeignKey("dbo.Patients", "InsuranceId", "dbo.Insurances");
            DropForeignKey("dbo.MedControlledSubstances", "PharmacyId", "dbo.Pharmacies");
            DropForeignKey("dbo.MedControlledSubstances", "MedicationId", "dbo.Medications");
            DropIndex("dbo.Patients", new[] { "InsuranceId" });
            DropIndex("dbo.Patients", new[] { "PharmacyId" });
            DropIndex("dbo.Patients", new[] { "MedicationId" });
            DropIndex("dbo.MedControlledSubstances", new[] { "MedicationId" });
            DropIndex("dbo.MedControlledSubstances", new[] { "PharmacyId" });
            DropTable("dbo.Patients");
            DropTable("dbo.Pharmacies");
            DropTable("dbo.Medications");
            DropTable("dbo.MedControlledSubstances");
            DropTable("dbo.Insurances");
        }
    }
}
