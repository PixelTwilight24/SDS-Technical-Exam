namespace SDS_Technical_Exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecyclableItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecyclableTypeId = c.Int(nullable: false),
                        Weight = c.Double(nullable: false),
                        ComputedRate = c.Double(nullable: false),
                        ItemDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RecyclableTypes", t => t.RecyclableTypeId, cascadeDelete: true)
                .Index(t => t.RecyclableTypeId);
            
            CreateTable(
                "dbo.RecyclableTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Rate = c.Double(nullable: false),
                        MinKg = c.Double(nullable: false),
                        MaxKg = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecyclableItems", "RecyclableTypeId", "dbo.RecyclableTypes");
            DropIndex("dbo.RecyclableItems", new[] { "RecyclableTypeId" });
            DropTable("dbo.RecyclableTypes");
            DropTable("dbo.RecyclableItems");
        }
    }
}
