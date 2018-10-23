namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIsSubscribedtoNewsLetter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "IsSubscribedtoNewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "IsSubscribedtoNewsLetter");
        }
    }
}
