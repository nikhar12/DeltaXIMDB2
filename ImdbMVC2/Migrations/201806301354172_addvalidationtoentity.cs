namespace ImdbMVC2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvalidationtoentity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Actors", "name", c => c.String(nullable: false));
            AlterColumn("dbo.Actors", "sex", c => c.String(nullable: true));
            AlterColumn("dbo.Producers", "pname", c => c.String(nullable: true));
            AlterColumn("dbo.Producers", "sex", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Producers", "sex", c => c.String());
            AlterColumn("dbo.Producers", "pname", c => c.String());
            AlterColumn("dbo.Actors", "sex", c => c.String());
            AlterColumn("dbo.Actors", "name", c => c.String());
        }
    }
}
