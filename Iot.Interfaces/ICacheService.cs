using System;

namespace Iot.Interfaces
{
    /// <summary>
    /// Interface ICacheService
    /// </summary>
    /// <remarks>
    ///     based on implementation on http://stackoverflow.com/questions/343899/how-to-cache-data-in-a-mvc-application
    /// </remarks>
    public interface ICacheService
    {
        /// <summary>
        /// Gets the or set.
        /// </summary>
        /// <typeparam name="T">model class</typeparam>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="getItemCallback">The get item callback.</param>
        /// <returns>T or null otherwise</returns>
        T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class;
    }
}