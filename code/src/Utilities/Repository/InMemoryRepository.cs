/*
 * Created by: 
 * Created: zaterdag 6 december 2008
 */

using System.Collections.Generic;

namespace Utilities.Repository
{
    public class InMemoryRepository : IRepository
    {
        public IList<T> FindAll<T>()
        {
            throw new System.NotImplementedException();
        }

        public T Get<T>(object id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete<T>(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Save<T>(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update<T>(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}