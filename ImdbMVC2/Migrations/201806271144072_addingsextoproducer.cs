namespace ImdbMVC2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingsextoproducer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Producers", "sex", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Producers", "sex");
        }
    }
}
