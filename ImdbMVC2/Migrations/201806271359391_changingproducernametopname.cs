namespace ImdbMVC2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingproducernametopname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Producers", "pname", c => c.String());
            DropColumn("dbo.Producers", "name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Producers", "name", c => c.String());
            DropColumn("dbo.Producers", "pname");
        }
    }
}
