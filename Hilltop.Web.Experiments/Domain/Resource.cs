using System;
using System.Collections.Generic;
using System.Linq;

using Hilltop.Core.Domain;

namespace Hilltop.Web.Experiments.Domain
{
    public class Resource : BaseEntity, IResource
    {
        private readonly List<Booking> bookings;
        public Resource(Guid id, string name) : base(id)
        {
            Name = name;
            bookings = new List<Booking>();
        }

        public string Name { get; }

        public IReadOnlyCollection<Booking> Bookings => bookings.AsReadOnly();

        public void AddBooking(DateTime bookingDate, string booker)
        {
            if (bookings.Any(b => b.BookingDate == bookingDate))
            {
                throw new ApplicationException("The resource is already booked at that time");
            }
            bookings.Add(new Booking(bookingDate, booker));
        }
    }
}