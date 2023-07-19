namespace Code_First_Exercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFewChangesasPerItterationExercise : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER  TABLE   dbo.Videos  DROP    CONSTRAINT[DF__Videos__Classifi__48CFD27E]");
            DropForeignKey("dbo.Videos", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Videos", new[] { "Genre_Id" });
            RenameColumn(table: "dbo.Videos", name: "Genre_Id", newName: "GenreId");
            DropPrimaryKey("dbo.Genres");
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagVideos",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Video_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Video_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Videos", t => t.Video_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Video_Id);
            
            AlterColumn("dbo.Genres", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Videos", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Videos", "Classification", c => c.Byte(nullable: false));
            AlterColumn("dbo.Videos", "GenreId", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Genres", "Id");
            CreateIndex("dbo.Videos", "GenreId");
            AddForeignKey("dbo.Videos", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.TagVideos", "Video_Id", "dbo.Videos");
            DropForeignKey("dbo.TagVideos", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.TagVideos", new[] { "Video_Id" });
            DropIndex("dbo.TagVideos", new[] { "Tag_Id" });
            DropIndex("dbo.Videos", new[] { "GenreId" });
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Videos", "GenreId", c => c.Int());
            AlterColumn("dbo.Videos", "Classification", c => c.Int(nullable: false));
            AlterColumn("dbo.Videos", "Name", c => c.String());
            AlterColumn("dbo.Genres", "Name", c => c.String());
            AlterColumn("dbo.Genres", "Id", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.TagVideos");
            DropTable("dbo.Tags");
            AddPrimaryKey("dbo.Genres", "Id");
            RenameColumn(table: "dbo.Videos", name: "GenreId", newName: "Genre_Id");
            CreateIndex("dbo.Videos", "Genre_Id");
            AddForeignKey("dbo.Videos", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
