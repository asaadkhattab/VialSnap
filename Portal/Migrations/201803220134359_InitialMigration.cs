namespace Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pharmacies",
                c => new
                    {
                        PharmacyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        State = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.PharmacyId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pharmacies");
        }
    }
}
