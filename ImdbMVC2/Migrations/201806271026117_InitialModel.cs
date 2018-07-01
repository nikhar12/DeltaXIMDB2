namespace ImdbMVC2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        dob = c.DateTime(nullable: false),
                        bio = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        yor = c.Int(nullable: false),
                        plot = c.String(),
                        poster = c.Binary(),
                        Producer_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Producers", t => t.Producer_id)
                .Index(t => t.Producer_id);
            
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        dob = c.DateTime(nullable: false),
                        bio = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.MoviesActors",
                c => new
                    {
                        Movies_id = c.Int(nullable: false),
                        Actors_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movies_id, t.Actors_id })
                .ForeignKey("dbo.Movies", t => t.Movies_id, cascadeDelete: true)
                .ForeignKey("dbo.Actors", t => t.Actors_id, cascadeDelete: true)
                .Index(t => t.Movies_id)
                .Index(t => t.Actors_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Producer_id", "dbo.Producers");
            DropForeignKey("dbo.MoviesActors", "Actors_id", "dbo.Actors");
            DropForeignKey("dbo.MoviesActors", "Movies_id", "dbo.Movies");
            DropIndex("dbo.MoviesActors", new[] { "Actors_id" });
            DropIndex("dbo.MoviesActors", new[] { "Movies_id" });
            DropIndex("dbo.Movies", new[] { "Producer_id" });
            DropTable("dbo.MoviesActors");
            DropTable("dbo.Producers");
            DropTable("dbo.Movies");
            DropTable("dbo.Actors");
        }
    }
}
