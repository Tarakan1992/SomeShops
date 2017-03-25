using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SS.Entities
{
    /// <summary>
    /// Base entity class.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    public abstract class EntityBase<T> : IEntity<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }
        object IEntity.Id
        {
            get { return Id; }
            set { Id = (T)Convert.ChangeType(value, typeof(T)); }
        }
    }
}
