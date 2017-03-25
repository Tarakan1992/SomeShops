using System.Linq;

namespace SS.Interfaces.Data
{
    /// <summary>
    /// Interface of Generic repository.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity>
    {
        /// <summary>
        /// Get all items from collection.
        /// </summary>
        IQueryable<TEntity> All { get; }

        /// <summary>
        /// Find item by Id.
        /// </summary>
        /// <param name="id">Item Id.</param>
        /// <returns></returns>
        TEntity Find(object id);

        /// <summary>
        /// Insert new item into collection.
        /// </summary>
        /// <param name="obj">Item.</param>
        void Insert(TEntity obj);

        /// <summary>
        /// Update item in collection.
        /// </summary>
        /// <param name="obj">Item.</param>
        void Update(TEntity obj);

        /// <summary>
        /// Delete item from collection by Id.
        /// </summary>
        /// <param name="id">Item Id.</param>
        void Delete(object id);
    };
}
