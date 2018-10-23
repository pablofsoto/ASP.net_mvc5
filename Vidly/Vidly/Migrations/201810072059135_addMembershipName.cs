namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMembershipName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipType", "Name", c => c.String(nullable: true, maxLength: 255));
            Sql("UPDATE MembershipType SET Name='Pay As You Go' Where Id=1");
            Sql("UPDATE MembershipType SET Name='Monthly' Where Id=2");
            Sql("UPDATE MembershipType SET Name='Quarterly' Where Id=3");
            Sql("UPDATE MembershipType SET Name='Annual' Where Id=4");

        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipType", "Name");
        }
    }
}
