using System;
using System.Collections.Generic;
using Hilltop.Core.Domain;

namespace Hilltop.Core.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T item);
        T GetByGuid(Guid guid);
        IEnumerable<T> GetAll();        
        void Delete(Guid guid);        
    }
}