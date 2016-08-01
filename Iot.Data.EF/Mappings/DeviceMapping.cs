using System.Data.Entity.ModelConfiguration;
using Iot.Models;

namespace Iot.Data.EF.Mappings
{
    /// <summary>
    /// Class DeviceMapping.
    /// </summary>
    public class DeviceMapping : EntityTypeConfiguration<Device>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceMapping"/> class.
        /// </summary>
        public DeviceMapping()
        {
            //HasRequired(d => d.SerialNumber);
        }
    }
}