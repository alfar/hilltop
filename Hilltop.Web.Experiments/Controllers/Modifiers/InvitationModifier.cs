using Hilltop.Core.Web.Controllers.Interfaces;
using Hilltop.Core.Web.Controllers.Helpers;
using Hilltop.Web.Experiments.Domain;

namespace Hilltop.Web.Experiments.Controllers.Modifiers
{
    public class InvitationModifier : IModifier
    {
        private readonly IInvitable invitee;
        public InvitationModifier(IInvitable invitee)
        {
            this.invitee = invitee;
        }

        public void Modify(IModifiable modifiable)
        {
            if (invitee.CanInvite)
            {
                modifiable.AddValue("actions", new Action("invite", "/invitations/invite/"));
            }
            if (invitee.CanUninvite)
            {
                modifiable.AddValue("actions", new Action("uninvite", "/invitations/uninvite/"));
            }
        }
    }
}