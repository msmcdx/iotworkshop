using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Iot.Interfaces;

namespace Iot.Data.EF
{
    /// <summary>
    /// Class DataRepository for working with data and MS SQL with Entity Framework
    /// </summary>
    /// <typeparam name="T">object type</typeparam>
    public class DataRepository<T> : IRepository<T> where T : class, new()
    {
        /// <summary>
        /// Gets or sets the database context.
        /// </summary>
        /// <value>The database context.</value>
        protected DbContext DbContext { get; set; }

        /// <summary>
        /// Gets or sets the database set.
        /// </summary>
        /// <value>The database set.</value>
        protected DbSet<T> DbSet { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataRepository{T}" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="System.ArgumentNullException">dbContext</exception>
        public DataRepository(DbContext context)
        {
            DbContext = context;
            DbSet = DbContext.Set<T>();
            //disable lazy loading
            //context.Configuration.LazyLoadingEnabled = false;
            //context.Configuration.ProxyCreationEnabled = false;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        public IQueryable<T> GetAll()
        {
            return DbSet;
        }
        
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="exp">The exp.</param>
        /// <returns>Task&lt;IQueryable&lt;T&gt;&gt;.</returns>
        public IQueryable<T> GetAll(Expression<Func<T, object>> exp)
        {
            var dbset = DbSet.Include(exp);
            return dbset;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IQueryable&lt;T&gt; or null.</returns>
        public async Task<List<T>> GetAllAsnyc()
        {
            return await DbSet.ToListAsync();
        }

        /// <summary>
        /// Finds the single.
        /// </summary>
        /// <param name="where">The where statment.</param>
        /// <param name="exp">The exp.</param>
        /// <returns>single object or null otherwise</returns>
        public async Task<T> FindSingleAsync(Expression<Func<T, bool>> @where, Expression<Func<T, object>> exp)
        {
            var dbset = DbSet.Include(exp);
            return await dbset.SingleOrDefaultAsync(@where);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="exp">The exp.</param>
        /// <returns>IQueryable&lt;T&gt; or null.</returns>
        public async Task<List<T>> GetAllAsnyc(Expression<Func<T, object>> exp)
        {
            var dbset = DbSet.Include(exp);
            return await dbset.ToListAsync();
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="take">The take.</param>
        /// <returns>Task&lt;IQueryable&lt;T&gt;&gt;.</returns>
        public async Task<List<T>> GetAsync(int take)
        {
            return await DbSet.Take(take).ToListAsync();
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
                dbEntityEntry.State = EntityState.Added;
            else
                DbSet.Add(entity);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
                DbSet.Attach(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        /// <summary>
        /// Gets the new.
        /// </summary>
        /// <returns>get new instance of object.</returns>
        public T GetNew()
        {
            return new T();
        }

        /// <summary>
        /// count as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where statment.</param>
        /// <returns>count of elements or -1 othwerwise</returns>
        public async Task<int> CountAsync(Expression<Func<T, bool>> @where = null)
        {
            return (where == null)
                ? await DbSet.CountAsync()
                : await DbSet.Where(where).CountAsync();
        }

        /// <summary>
        /// Finds the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public Task<List<T>> FindAsync(Expression<Func<T, bool>> @where)
        {
            return DbSet.Where(where).ToListAsync();
        }

        /// <summary>
        /// Finds the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="exp">The exp.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public Task<List<T>> FindAsync(Expression<Func<T, bool>> @where, Expression<Func<T, object>> exp)
        {
            var dbset = DbSet.Include(exp);
            return dbset.Where(where).ToListAsync();
        }

        /// <summary>
        /// find single as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where statment.</param>
        /// <returns>single object or null otherwise</returns>
        public async Task<T> FindSingleAsync(Expression<Func<T, bool>> @where)
        {
            return await DbSet.FirstAsync(@where);
        }
    }
}