namespace Iot.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class AddCategoryAndDownload.
    /// </summary>
    public partial class AddCategoryAndDownload : DbMigration
    {
        /// <summary>
        /// Ups this instance.
        /// </summary>
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);

            CreateTable(
                "dbo.Download",
                c => new
                    {
                        DownloadId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ImageUrl = c.String(),
                        DownloadType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DownloadId);

            //CreateTable(
            //    "dbo.Device",
            //    c => new
            //        {
            //            DeviceId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            SerialNumber = c.String(),
            //            Description = c.String(),
            //            IsOffline = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.DeviceId);

            //CreateTable(
            //    "dbo.Item",
            //    c => new
            //        {
            //            ItemId = c.Int(nullable: false, identity: true),
            //            Type = c.Int(nullable: false),
            //            Value = c.String(),
            //            TimeAdded = c.DateTime(nullable: false),
            //            DeviceId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ItemId)
            //    .ForeignKey("dbo.Device", t => t.DeviceId, cascadeDelete: true)
            //    .Index(t => t.DeviceId);

            CreateTable(
                "dbo.Download2Categories",
                c => new
                    {
                        DownloadId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DownloadId, t.CategoryId })
                .ForeignKey("dbo.Download", t => t.DownloadId, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.DownloadId)
                .Index(t => t.CategoryId);

        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            //DropForeignKey("dbo.Item", "DeviceId", "dbo.Device");
            DropForeignKey("dbo.Download2Categories", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Download2Categories", "DownloadId", "dbo.Download");
            DropIndex("dbo.Download2Categories", new[] { "CategoryId" });
            DropIndex("dbo.Download2Categories", new[] { "DownloadId" });
            //DropIndex("dbo.Item", new[] { "DeviceId" });
            DropTable("dbo.Download2Categories");
            //DropTable("dbo.Item");
            //DropTable("dbo.Device");
            DropTable("dbo.Download");
            DropTable("dbo.Category");
        }
    }
}
