namespace SS.Entities
{
    /// <summary>
    /// Interface of Entity.
    /// </summary>
    public interface IEntity
    {
        object Id { get; set; }
    }

    /// <summary>
    /// Generic interface of Entity.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntity<T> : IEntity
    {
        new T Id { get; set; }
    }
}
