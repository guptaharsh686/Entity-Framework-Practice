namespace Code_First_Exercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVideoTagsRelationship : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TagVideos", newName: "VodeoTags");
            RenameColumn(table: "dbo.VodeoTags", name: "Tag_Id", newName: "TagId");
            RenameColumn(table: "dbo.VodeoTags", name: "Video_Id", newName: "VideoId");
            RenameIndex(table: "dbo.VodeoTags", name: "IX_Video_Id", newName: "IX_VideoId");
            RenameIndex(table: "dbo.VodeoTags", name: "IX_Tag_Id", newName: "IX_TagId");
            DropPrimaryKey("dbo.VodeoTags");
            AddPrimaryKey("dbo.VodeoTags", new[] { "VideoId", "TagId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.VodeoTags");
            AddPrimaryKey("dbo.VodeoTags", new[] { "Tag_Id", "Video_Id" });
            RenameIndex(table: "dbo.VodeoTags", name: "IX_TagId", newName: "IX_Tag_Id");
            RenameIndex(table: "dbo.VodeoTags", name: "IX_VideoId", newName: "IX_Video_Id");
            RenameColumn(table: "dbo.VodeoTags", name: "VideoId", newName: "Video_Id");
            RenameColumn(table: "dbo.VodeoTags", name: "TagId", newName: "Tag_Id");
            RenameTable(name: "dbo.VodeoTags", newName: "TagVideos");
        }
    }
}
