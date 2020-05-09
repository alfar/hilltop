using Hilltop.Web.Experiments.Controllers.DataTransfer;
using Hilltop.Web.Experiments.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Hilltop.Web.Experiments.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvitationController : ControllerBase
    {
        [HttpPost]
        public IActionResult Invite([FromBody] InviteRequest inviteRequest)
        {
            var invitation = new Invitation(inviteRequest.Invitee, inviteRequest.EventDate, inviteRequest.Subject);

            return Created("/invitations/1", invitation);
        }
    }
}