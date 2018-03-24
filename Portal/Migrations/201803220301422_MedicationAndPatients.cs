namespace Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MedicationAndPatients : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medications",
                c => new
                    {
                        MedicationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.MedicationId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        Prefix = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
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
            DropTable("dbo.Medications");
        }
    }
}
