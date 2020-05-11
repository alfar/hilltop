using System;
using System.Collections.Generic;

namespace Hilltop.Core.Domain
{
    public class BaseEntity : IBaseEntity
    {
        public BaseEntity(Guid id)
        {
            Id = id;
        }

        private List<IDomainEvent> events = new List<IDomainEvent>();
        public Guid Id { get; private set; }

        protected void AddEvent(IDomainEvent domainEvent) {
            events.Add(domainEvent);
        }

        public IEnumerable<IDomainEvent> GetEvents() => events.AsReadOnly();
    }
}