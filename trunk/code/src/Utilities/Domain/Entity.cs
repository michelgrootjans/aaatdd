/*
 * Created by: 
 * Created: zaterdag 6 december 2008
 */

namespace Utilities.Domain
{
    public class Entity<T> : IEntity
    {
        object IEntity.Id { get { return Id; } }

        public T Id { get; set; }
    }
}