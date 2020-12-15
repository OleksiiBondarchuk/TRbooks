namespace TRbooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddValuesToMovieGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Adventure')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Classics')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Graphic Novel')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Horror')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Mystery')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Fantasy')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Romance')");

        }

        public override void Down()
        {
        }
    }
}
