namespace Code_First_Exercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGeneresDatabase : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VALUES ('Horror')");
            Sql("INSERT INTO Genres (Name) VALUES ('Comedy')");
            Sql("INSERT INTO Genres (Name) VALUES ('Action')");

        }

        public override void Down()
        {
            Sql("DELETE FROM Genres");
        }
    }
}
