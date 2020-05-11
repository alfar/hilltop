using System;

namespace Hilltop.Core.Domain
{
    public interface IDomainEvent
    {
        DateTime TimeOfEvent {get;}        
    }
}