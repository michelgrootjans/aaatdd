/*
 * Created by: 
 * Created: zaterdag 6 december 2008
 */

using System;
using System.Collections;
using System.Collections.Generic;
using Utilities.Domain;

namespace Utilities.Repository
{
    public class InMemoryRepository : IRepository
    {
        private readonly Dictionary<Type, object> database;

        public InMemoryRepository()
        {
            database = new Dictionary<Type, object>();
        }

        public IEnumerable<T> FindAll<T>()
        {
            return GetListOf<T>();
        }

        public T Get<T>(object id) where T : IEntity
        {
            var table = GetListOf<T>();
            return table.Get(id);
        }

        public void Delete<T>(T entity)
        {
            var table = GetListOf<T>();
            table.Delete(entity);
        }

        public void Save<T>(T entity)
        {
            var table = GetListOf<T>();
            table.Save(entity);
        }

        public void Update<T>(T entity)
        {
            var table = GetListOf<T>();
            table.Update(entity);
        }

        private InMemoryTable<T> GetListOf<T>()
        {
            if (! database.ContainsKey(typeof (T)))
                database.Add(typeof (T), new InMemoryTable<T>());

            return database[typeof (T)] as InMemoryTable<T>;
        }

        internal class InMemoryTable<T> : IEnumerable<T>
        {
            private readonly Dictionary<object, T> records;

            public InMemoryTable()
            {
                records = new Dictionary<object, T>();
            }

            public IEnumerator<T> GetEnumerator()
            {
                return records.Values.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public void Save(T t)
            {
                var entity = (IEntity) t;
                if (records.ContainsKey(entity.Id))
                    records[entity.Id] = t;
                else
                    records.Add(entity.Id, t);
            }

            public void Delete(T t)
            {
                var entity = (IEntity)t;

                if (!records.ContainsKey(entity.Id)) return;
                
                records.Remove(entity.Id);
            }

            public T Get(object id)
            {
                if (records.ContainsKey(id))
                    return records[id];

                return default(T);
            }

            public void Update(T t)
            {
                Save(t);
            }
        }
    }
}