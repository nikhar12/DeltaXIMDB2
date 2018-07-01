namespace ImdbMVC2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removevalidationfromposter : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "poster", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "poster", c => c.Binary(nullable: false));
        }
    }
}
