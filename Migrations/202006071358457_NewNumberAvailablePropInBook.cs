namespace TRbooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Model;

    public partial class NewNumberAvailablePropInBook : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Rentals", new[] { "book_Id" });
            AddColumn("dbo.Books", "NumberAvailable", c => c.Int(nullable: false));
            CreateIndex("dbo.Rentals", "Book_Id");

            Sql("UPDATE Books SET NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Rentals", new[] { "Book_Id" });
            DropColumn("dbo.Books", "NumberAvailable");
            CreateIndex("dbo.Rentals", "book_Id");
        }
    }
}
