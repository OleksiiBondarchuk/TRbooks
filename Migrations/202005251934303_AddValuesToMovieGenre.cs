namespace TRbooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValuesToMovieGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Family')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Comedy')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Action')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Horror')");
        }
        
        public override void Down()
        {
        }
    }
}
