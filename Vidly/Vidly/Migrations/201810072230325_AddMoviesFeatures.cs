namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoviesFeatures : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movie", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movie", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movie", "NumberInStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movie", "NumberInStock");
            DropColumn("dbo.Movie", "DateAdded");
            DropColumn("dbo.Movie", "ReleaseDate");
        }
    }
}
