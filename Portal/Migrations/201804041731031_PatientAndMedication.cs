namespace Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PatientAndMedication : DbMigration
    {
        public override void Up()
        {
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
                    })
                .PrimaryKey(t => t.PatientId)
                .ForeignKey("dbo.Medications", t => t.MedicationId, cascadeDelete: true)
                .Index(t => t.MedicationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "MedicationId", "dbo.Medications");
            DropIndex("dbo.Patients", new[] { "MedicationId" });
            DropTable("dbo.Patients");
        }
    }
}
