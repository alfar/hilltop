using System;
using System.Collections.Generic;

namespace Hilltop.Core.Domain
{
    public interface IBaseEntity
    {
        Guid Id { get; }
        IEnumerable<IDomainEvent> GetEvents();
    }
}