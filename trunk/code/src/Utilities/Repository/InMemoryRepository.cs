/*
 * Created by: 
 * Created: zaterdag 6 december 2008
 */

using System;
using System.Collections.Generic;
using Utilities.Domain;

namespace Utilities.Repository
{
    public class InMemoryRepository : IRepository
    {
        public IEnumerable<T> FindAll<T>()
        {
            return Table<T>();
        }

        public T Get<T>(object id) where T : IEntity
        {
            return Table<T>().Get(id);
        }

        public void Delete<T>(T entity)
        {
            Table<T>().Delete(entity);
        }

        public void Save<T>(T entity)
        {
            Table<T>().Save(entity);
        }

        public void Update<T>(T entity)
        {
            Table<T>().Update(entity);
        }

        private readonly Dictionary<Type, object> database = new Dictionary<Type, object>();
        internal InMemoryTable<T> Table<T>()
        {
            if (! database.ContainsKey(typeof (T)))
                database.Add(typeof (T), new InMemoryTable<T>());

            return database[typeof (T)] as InMemoryTable<T>;
        }
    }
}