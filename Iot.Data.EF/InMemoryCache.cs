using System;
using System.Runtime.Caching;
using Iot.Interfaces;

namespace Iot.Data.EF
{
    /// <summary>
    /// Class InMemoryCache.
    /// </summary>
    public class InMemoryCache : ICacheService
    {
        /// <summary>
        /// Gets the or set.
        /// </summary>
        /// <typeparam name="T">model class</typeparam>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="getItemCallback">The get item callback.</param>
        /// <returns>T or null otherwise</returns>
        /// <remarks>
        ///     it is cached for 10 minutes
        /// </remarks>
        public T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class
        {
            T item = MemoryCache.Default.Get(cacheKey) as T;
            if (item == null)
            {
                item = getItemCallback();
                MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(10));
            }
            return item;
        }
    }
}