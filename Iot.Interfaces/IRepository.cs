using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Iot.Interfaces
{
    /// <summary>
    /// base repository interface
    /// </summary>
    /// <typeparam name="T">model, which will be used</typeparam>
    public interface IRepository<T> where T : class, new()
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>Task&lt;IQueryable&lt;T&gt;&gt;.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Gets all with included expression
        /// </summary>
        /// <param name="exp">The exp.</param>
        /// <returns>IQueryable&lt;T&gt; or empty object otherwise</returns>
        IQueryable<T> GetAll(Expression<Func<T, object>> exp);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IQueryable&lt;T&gt; or null.</returns>
        Task<List<T>> GetAllAsnyc();
        
        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="take">The take.</param>
        /// <returns>Task&lt;IQueryable&lt;T&gt;&gt;.</returns>
        Task<List<T>> GetAsync(int take);
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(T entity);
        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);
        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);
        /// <summary>
        /// Gets the new.
        /// </summary>
        /// <returns>get new instance of object.</returns>
        T GetNew();
        /// <summary>
        /// Counts the specified where.
        /// </summary>
        /// <param name="where">The where statment.</param>
        /// <returns>count of elements or -1 othwerwise</returns>
        Task<int> CountAsync(Expression<Func<T, bool>> where = null);
        /// <summary>
        /// Finds the specified where.
        /// </summary>
        /// <param name="where">The where statment.</param>
        /// <returns>IEnumerable&lt;T&gt; or empty list.</returns>
        Task<List<T>> FindAsync(Expression<Func<T, bool>> where);

        /// <summary>
        /// Finds the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="exp">The exp.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        Task<List<T>> FindAsync(Expression<Func<T, bool>> @where, Expression<Func<T, object>> exp);
        /// <summary>
        /// Finds the single.
        /// </summary>
        /// <param name="where">The where statment.</param>
        /// <returns>single object or null otherwise</returns>
        Task<T> FindSingleAsync(Expression<Func<T, bool>> where);

        /// <summary>
        /// Finds the single.
        /// </summary>
        /// <param name="where">The where statment.</param>
        /// <param name="exp">The exp.</param>
        /// <returns>single object or null otherwise</returns>
        Task<T> FindSingleAsync(Expression<Func<T, bool>> where, Expression<Func<T, object>> exp);

        /// <summary>
        /// Gets all included asnyc.
        /// </summary>
        /// <param name="exp">The exp.</param>
        /// <returns>Task&lt;List&lt;T&gt;&gt;.</returns>
        Task<List<T>> GetAllAsnyc(Expression<Func<T, object>> exp);
    }
}