using System;
using System.Collections.Generic;

namespace Hilltop.Web.Experiments.Domain
{
    public class Resource : IResource, IInvitable
    {
        private readonly List<Booking> bookings;
        public Resource(Guid guid, string name)
        {
            Guid = guid;
            Name = name;
            bookings = new List<Booking>();
        }

        public Guid Guid { get; }
        public string Name { get; }

        public bool CanInvite => true;

        public IReadOnlyCollection<Booking> Bookings => bookings.AsReadOnly();
    }
}