namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthDayDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "BirthdayDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "BirthdayDate");
        }
    }
}
