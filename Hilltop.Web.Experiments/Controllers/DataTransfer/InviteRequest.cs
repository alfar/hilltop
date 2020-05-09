using System;

namespace Hilltop.Web.Experiments.Controllers.DataTransfer
{
    public class InviteRequest
    {
        public string Invitee { get; set; }
        public DateTime EventDate {get;set;}
        public string Subject {get;set;}
    }
}