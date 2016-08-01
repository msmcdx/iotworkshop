namespace Iot.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class AddNameToDevices.
    /// </summary>
    public partial class AddNameToDevices : DbMigration
    {
        /// <summary>
        /// Ups this instance.
        /// </summary>
        public override void Up()
        {
            AddColumn("dbo.Device", "Name", c => c.String());
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            DropColumn("dbo.Device", "Name");
        }
    }
}
