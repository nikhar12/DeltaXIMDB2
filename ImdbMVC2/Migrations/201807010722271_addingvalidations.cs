namespace ImdbMVC2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingvalidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "poster", c => c.Binary(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "poster", c => c.Binary());
        }
    }
}
