using System.Collections;
using System.Collections.Generic;
using Utilities.Domain;

namespace Utilities.Repository
{
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
            var entity = (IEntity) t;

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