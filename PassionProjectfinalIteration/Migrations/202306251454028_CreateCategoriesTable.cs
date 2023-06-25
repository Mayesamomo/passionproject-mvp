namespace PassionProjectfinalIteration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCategoriesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BassGuitars", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BassGuitars", "ImagePath");
        }
    }
}
