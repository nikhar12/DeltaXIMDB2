namespace ImdbMVC2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstringsextoactor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "sex", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actors", "sex");
        }
    }
}
