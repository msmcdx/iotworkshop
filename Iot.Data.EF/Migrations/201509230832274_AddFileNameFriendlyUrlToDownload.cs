namespace Iot.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class AddFileNameFriendlyUrlToDownload.
    /// </summary>
    public partial class AddFileNameFriendlyUrlToDownload : DbMigration
    {
        /// <summary>
        /// Ups this instance.
        /// </summary>
        public override void Up()
        {
            AddColumn("dbo.Download", "FriendlyName", c => c.String());
            AddColumn("dbo.Download", "FileName", c => c.String());
            AddColumn("dbo.Download", "Count", c => c.Int(nullable: false));
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            DropColumn("dbo.Download", "Count");
            DropColumn("dbo.Download", "FileName");
            DropColumn("dbo.Download", "FriendlyName");
        }
    }
}
