namespace PassionProjectfinalIteration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBassGuitarClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BassGuitars", "BassGuitarHasPic", c => c.Boolean(nullable: false));
            AddColumn("dbo.BassGuitars", "PicExtension", c => c.String());
            DropColumn("dbo.BassGuitars", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BassGuitars", "ImagePath", c => c.String());
            DropColumn("dbo.BassGuitars", "PicExtension");
            DropColumn("dbo.BassGuitars", "BassGuitarHasPic");
        }
    }
}
