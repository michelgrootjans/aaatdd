using System.Collections.Generic;
using Utilities.Domain;

namespace Utilities.Repository
{
    /// <summary>
    /// The base repository interface for all repositories
    /// </summary>
    public interface IRepository
    {
        IEnumerable<T> FindAll<T>();
        Entity Get<Entity>(object id) where Entity : IEntity;
        void Delete<T>(T entity);
        void Save<T>(T entity);
        void Update<T>(T entity);
    }
}