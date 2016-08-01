using System.Data.Entity.Migrations;
using Iot.Models;

namespace Iot.Data.EF.Migrations
{
    /// <summary>
    /// Class Configuration. This class cannot be inherited.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<IotContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// Seeds the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        protected override void Seed(IotContext context)
        {
            context.Categories.AddOrUpdate(p => p.Name,
                new Category { Name = "IOT", Description = "IOT related stuff" },
                new Category { Name = "Web", Description = "Web related stuff" },
                new Category { Name = "Desktop", Description = "Desktop related stuff" },
                new Category { Name = "Code snippets", Description = "code snippets" },
                new Category { Name = "ZIP", Description = "zip files based on selected criteria" });
        }
    }
}
