namespace Code_First.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        FullPrice = c.Single(nullable: false),
                        Level = c.Int(nullable: false),
                        Author_Id = c.Int(),
                        Tags_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.Author_Id)
                .ForeignKey("dbo.Tags", t => t.Tags_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Tags_Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Tags_Id", "dbo.Tags");
            DropForeignKey("dbo.Courses", "Author_Id", "dbo.Authors");
            DropIndex("dbo.Courses", new[] { "Tags_Id" });
            DropIndex("dbo.Courses", new[] { "Author_Id" });
            DropTable("dbo.Tags");
            DropTable("dbo.Courses");
            DropTable("dbo.Authors");
        }
    }
}
