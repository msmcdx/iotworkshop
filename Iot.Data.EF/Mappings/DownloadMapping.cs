using System.Data.Entity.ModelConfiguration;
using Iot.Models;

namespace Iot.Data.EF.Mappings
{
    /// <summary>
    /// Class DownloadMapping.
    /// </summary>
    public class DownloadMapping : EntityTypeConfiguration<Download>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadMapping"/> class.
        /// </summary>
        public DownloadMapping()
        {
            HasMany(t => t.Categories)
                .WithMany(t => t.Downloads)
                .Map(m =>
                {
                    m.ToTable("Download2Categories");
                    m.MapLeftKey("DownloadId");
                    m.MapRightKey("CategoryId");
                });
        }
    }
}