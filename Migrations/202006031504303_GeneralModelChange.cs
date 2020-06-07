namespace TRbooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GeneralModelChange : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MovieGenres", newName: "BookGenres");
            DropForeignKey("dbo.Movies", "MovieGenreId", "dbo.MovieGenres");
            DropIndex("dbo.Movies", new[] { "MovieGenreId" });
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        BookGenreId = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        NumberInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookGenres", t => t.BookGenreId, cascadeDelete: true)
                .Index(t => t.BookGenreId);
            
            DropTable("dbo.Movies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        MovieGenreId = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        NumberInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Books", "BookGenreId", "dbo.BookGenres");
            DropIndex("dbo.Books", new[] { "BookGenreId" });
            DropTable("dbo.Books");
            CreateIndex("dbo.Movies", "MovieGenreId");
            AddForeignKey("dbo.Movies", "MovieGenreId", "dbo.MovieGenres", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.BookGenres", newName: "MovieGenres");
        }
    }
}
