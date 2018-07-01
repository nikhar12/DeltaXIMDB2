namespace ImdbMVC2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingOneProducertoMovie : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Movies", new[] { "Producer_id" });
            CreateIndex("dbo.Movies", "producer_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Movies", new[] { "producer_id" });
            CreateIndex("dbo.Movies", "Producer_id");
        }
    }
}
