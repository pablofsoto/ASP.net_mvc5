namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipType(Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (1,0,0,0)");
            Sql("INSERT INTO MembershipType(Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (2,30,0,10)");
            Sql("INSERT INTO MembershipType(Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (3,90,0,15)");
            Sql("INSERT INTO MembershipType(Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (4,300,0,20)");
        }
        
        public override void Down()
        {
        }
    }
}
