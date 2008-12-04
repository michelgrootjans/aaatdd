using System.Collections.Generic;

namespace Utilities.Repository
{
    /// <summary>
    /// The base repository interface for all repositories
    /// </summary>
    public interface IRepository
    {
        IList<T> FindAll<T>();
        T Get<T>(object id);
        void Delete<T>(T entity);
        void Save<T>(T entity);
        void Update<T>(T entity);
    }
}