namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [Genre]([Name])VALUES('Action')");
            Sql("INSERT INTO [Genre]([Name])VALUES('Comedy')");
            Sql("INSERT INTO [Genre]([Name])VALUES('Family')");
            Sql("INSERT INTO [Genre]([Name])VALUES('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
