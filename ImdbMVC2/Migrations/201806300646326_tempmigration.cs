namespace ImdbMVC2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tempmigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "name", c => c.String(nullable: true));
            AlterColumn("dbo.Movies", "plot", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "plot", c => c.String());
            AlterColumn("dbo.Movies", "name", c => c.String());
        }
    }
}
