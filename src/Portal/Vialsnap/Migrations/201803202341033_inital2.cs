namespace Vialsnap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inital2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "MedicationId", "dbo.Medications");
            DropIndex("dbo.Patients", new[] { "MedicationId" });
            AlterColumn("dbo.Patients", "MedicationId", c => c.Int());
            CreateIndex("dbo.Patients", "MedicationId");
            AddForeignKey("dbo.Patients", "MedicationId", "dbo.Medications", "MedicationId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "MedicationId", "dbo.Medications");
            DropIndex("dbo.Patients", new[] { "MedicationId" });
            AlterColumn("dbo.Patients", "MedicationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Patients", "MedicationId");
            AddForeignKey("dbo.Patients", "MedicationId", "dbo.Medications", "MedicationId", cascadeDelete: true);
        }
    }
}
