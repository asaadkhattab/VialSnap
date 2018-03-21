namespace PatientPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medications",
                c => new
                    {
                        MedicationId = c.Int(nullable: false, identity: true),
                        MedName = c.String(),
                    })
                .PrimaryKey(t => t.MedicationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Medications");
        }
    }
}
