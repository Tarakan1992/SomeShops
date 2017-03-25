using Microsoft.EntityFrameworkCore;
using SS.Entities;
using SS.Interfaces.Data;
using System;
using System.Linq;

namespace SS.Data.Repositories
{
    public class RepositoryBase<TEntity, TDbContext> : IRepository<TEntity>
       where TEntity : class, IEntity, new()
       where TDbContext : DbContext
    {
        protected readonly TDbContext context;
        protected readonly DbSet<TEntity> dbSet;

        public RepositoryBase(TDbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// Get collection of all elements for current entity.
        /// </summary>
        public IQueryable<TEntity> All
        {
            get { return dbSet; }
        }

        /// <summary>
        /// Delete item by id.
        /// </summary>
        /// <param name="id">Id.</param>
        public void Delete(object id)
        {
            var obj = dbSet.Find(id);
            dbSet.Remove(obj);
        }

        /// <summary>
        /// Find item of collection by Id.
        /// </summary>
        /// <param name="id">Item's Id.</param>
        /// <returns></returns>
        public TEntity Find(object id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        /// Insert new Item.
        /// </summary>
        /// <param name="obj"></param>
        public void Insert(TEntity obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Entity");
            }

            dbSet.Add(obj);
            context.SaveChanges();
        }

        /// <summary>
        /// Update item.
        /// </summary>
        /// <param name="obj">Item.</param>
        public void Update(TEntity obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Entity");
            }

            context.SaveChanges();
        }
    }
}
