using System;

namespace Hilltop.Web.Experiments.Domain
{
    public class Booking
    {
        public Booking(DateTime bookingDate, string booker)
        {
            BookingDate = bookingDate;
            Booker = booker;
        }

        public DateTime BookingDate { get; set; }
        public string Booker { get; set; }
    }
}