namespace TRbooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplicationUserStudentTicket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "StudentTicket", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "StudentTicket");
        }
    }
}
