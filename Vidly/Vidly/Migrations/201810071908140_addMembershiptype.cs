namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMembershiptype : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipType",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customer", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customer", "MembershipTypeId");
            AddForeignKey("dbo.Customer", "MembershipTypeId", "dbo.MembershipType", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "MembershipTypeId", "dbo.MembershipType");
            DropIndex("dbo.Customer", new[] { "MembershipTypeId" });
            DropColumn("dbo.Customer", "MembershipTypeId");
            DropTable("dbo.MembershipType");
        }
    }
}
