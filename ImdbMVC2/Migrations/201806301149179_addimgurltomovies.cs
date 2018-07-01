namespace ImdbMVC2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addimgurltomovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "imgurl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "imgurl");
        }
    }
}
