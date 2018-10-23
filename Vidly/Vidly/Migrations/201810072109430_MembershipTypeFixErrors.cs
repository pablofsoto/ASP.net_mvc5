namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MembershipTypeFixErrors : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipType SET DurationInMonths=0 Where Id=1");
            Sql("UPDATE MembershipType SET DurationInMonths=1 Where Id=2");
            Sql("UPDATE MembershipType SET DurationInMonths=3 Where Id=3");
            Sql("UPDATE MembershipType SET DurationInMonths=12 Where Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
