namespace Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredFieldPharmacy : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pharmacies", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Pharmacies", "State", c => c.String(nullable: false));
            AlterColumn("dbo.Pharmacies", "City", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pharmacies", "City", c => c.String());
            AlterColumn("dbo.Pharmacies", "State", c => c.String());
            AlterColumn("dbo.Pharmacies", "Name", c => c.String());
        }
    }
}
