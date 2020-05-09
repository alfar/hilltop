using System;

namespace Hilltop.Web.Experiments.Domain
{
    public class Invitation
    {
        public Invitation(string invitee, DateTime eventDate, string subject)
        {
            Invitee = invitee;
            EventDate = eventDate;
            Subject = subject;
        }
        
        public string Invitee { get; private set; }
        public DateTime EventDate { get; private set; }
        public string Subject { get; private set; }
    }
}