using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Iot.Data.EF.Mappings;
using Iot.Models;

namespace Iot.Data.EF
{
    /// <summary>
    /// Class IotContext, which implements bridge to the database
    /// </summary>
    public class IotContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IotContext" /> class.
        /// </summary>
        public IotContext()
            : base(nameOrConnectionString: "DefaultConnection")
        {
        }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.</remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Use singular table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //default settings for anything
            modelBuilder.Configurations.Add(new DeviceMapping());
            modelBuilder.Configurations.Add(new ItemMapping());
            modelBuilder.Configurations.Add(new DownloadMapping());
            modelBuilder.Configurations.Add(new CategoryMapping());
        }

        /// <summary>
        /// Gets or sets the devices.
        /// </summary>
        /// <value>The devices.</value>
        public DbSet<Device> Devices { get; set; }
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        public DbSet<Item> Items { get; set; }
        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>The categories.</value>
        public DbSet<Category> Categories { get; set; }
        /// <summary>
        /// Gets or sets the downloads.
        /// </summary>
        /// <value>The downloads.</value>
        public DbSet<Download> Downloads { get; set; }
    }
}