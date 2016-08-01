using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Iot.Interfaces;

namespace Iot.Data.Storage
{
    /// <summary>
    /// Class DataStorageRepository.
    /// </summary>
    /// <typeparam name="T">selected type</typeparam>
    public class DataStorageRepository<T> : IRepository<T> where T : class, new()
    {
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Counts the specified where.
        /// </summary>
        /// <param name="where">The where statment.</param>
        /// <returns>count of elements or -1 othwerwise</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<int> CountAsync(Expression<Func<T, bool>> where = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the specified where.
        /// </summary>
        /// <param name="where">The where statment.</param>
        /// <returns>IEnumerable&lt;T&gt; or empty list.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<List<T>> FindAsync(Expression<Func<T, bool>> @where)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="exp">The exp.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<List<T>> FindAsync(Expression<Func<T, bool>> @where, Expression<Func<T, object>> exp)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the single.
        /// </summary>
        /// <param name="where">The where statment.</param>
        /// <returns>single object or null otherwise</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<T> FindSingleAsync(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the single.
        /// </summary>
        /// <param name="where">The where statment.</param>
        /// <param name="exp">The exp.</param>
        /// <returns>single object or null otherwise</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<T> FindSingleAsync(Expression<Func<T, bool>> where, Expression<Func<T, object>> exp)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="exp">The exp.</param>
        /// <returns>IQueryable&lt;T&gt; or null.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<List<T>> GetAllAsnyc(Expression<Func<T, object>> exp)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>Task&lt;IQueryable&lt;T&gt;&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all with included expression
        /// </summary>
        /// <param name="exp">The exp.</param>
        /// <returns>IQueryable&lt;T&gt; or empty object otherwise</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IQueryable<T> GetAll(Expression<Func<T, object>> exp)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IQueryable&lt;T&gt; or null.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<List<T>> GetAllAsnyc()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="take">The take.</param>
        /// <returns>Task&lt;IQueryable&lt;T&gt;&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<List<T>> GetAsync(int take)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the new.
        /// </summary>
        /// <returns>get new instance of object.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public T GetNew()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}