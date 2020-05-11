using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;

using Hilltop.Core.Domain;

namespace Hilltop.Core.Repository
{
    public class MemoryRepository<T> : IRepository<T> where T : BaseEntity
    {
        private ConcurrentDictionary<Guid, T> store = new ConcurrentDictionary<Guid, T>();
        public void Add(T item)
        {
            if (!store.TryAdd(item.Id, item))
            {
                throw new ApplicationException("Unable to add");
            }
        }

        public T GetByGuid(Guid guid)
        {
            if (store.TryGetValue(guid, out T value))
            {
                return value;
            }

            return null;
        }

        public IEnumerable<T> GetAll()
        {
            return store.Values.ToList();
        }

        public void Delete(Guid guid)
        {
            if (!store.TryRemove(guid, out T removed))
            {
                throw new ApplicationException("Unable to delete");
            }
        }
    }
}