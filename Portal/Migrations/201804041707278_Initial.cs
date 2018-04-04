namespace Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "MedicationId", "dbo.Medications");
            DropIndex("dbo.Patients", new[] { "MedicationId" });
            DropTable("dbo.Patients");
        }
        
        public override void Down()
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
                        Insurance = c.String(),
                        AccountBalance = c.Int(nullable: false),
                        MedicationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PatientId);
            
            CreateIndex("dbo.Patients", "MedicationId");
            AddForeignKey("dbo.Patients", "MedicationId", "dbo.Medications", "MedicationId", cascadeDelete: true);
        }
    }
}
