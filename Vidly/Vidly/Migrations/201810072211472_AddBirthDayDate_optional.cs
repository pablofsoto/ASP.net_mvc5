namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthDayDate_optional : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "BirthdayDate", c => c.DateTime());
            Sql("UPDATE Customer SET BirthdayDate=null Where Id>1");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "BirthdayDate", c => c.DateTime(nullable: false));
        }
    }
}
