namespace PassionProjectfinalIteration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bassguitar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BassGuitars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Color = c.String(nullable: false),
                        NumberOfStrings = c.Int(nullable: false),
                        Model = c.String(nullable: false),
                        Manufacturer = c.String(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        OwnerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Bassists", t => t.OwnerID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.OwnerID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Bassists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        YearsOfExperience = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BassGuitars", "OwnerID", "dbo.Bassists");
            DropForeignKey("dbo.BassGuitars", "CategoryID", "dbo.Categories");
            DropIndex("dbo.BassGuitars", new[] { "OwnerID" });
            DropIndex("dbo.BassGuitars", new[] { "CategoryID" });
            DropTable("dbo.Bassists");
            DropTable("dbo.Categories");
            DropTable("dbo.BassGuitars");
        }
    }
}
