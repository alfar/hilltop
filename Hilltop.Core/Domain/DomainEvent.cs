using System;

namespace Hilltop.Core.Domain
{
    public class DomainEvent : IDomainEvent
    {
        public DomainEvent(DateTime timeOfEvent) {
            TimeOfEvent = timeOfEvent;
        }

        public DateTime TimeOfEvent { get; }
    }
}