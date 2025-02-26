using DevStage.Application.UseCases.Invites.AccessInvite;
using DevStage.Application.UseCases.Invites.GetTotalInvites;
using DevStage.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DevStage.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvitesController : ControllerBase
    {
        [HttpGet]
        [Route("/{subscriberId}/invite")]
        [EndpointDescription("Access invite link and redirects user to the event")]
        [ProducesResponseType(typeof(string), StatusCodes.Status302Found)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AccessInviteLink([FromRoute] Guid subscriberId, [FromServices] AccessInviteLinkUseCase useCase)
        {
            var redirectUrl = await useCase.Execute(subscriberId);
            return Redirect(redirectUrl);
        }

        [HttpGet]
        [Route("/{subscriberId}/totalInvitesClicks")]
        [EndpointDescription("Get total invites clicks for the subscriber")]
        [ProducesResponseType(typeof(ResponseSubscriberTotalInvitesJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTotalInvitesClicks([FromRoute] Guid subscriberId, [FromServices] GetTotalInvitesClicksUseCase useCase)
        {
            var totalInvitesClicks = await useCase.Execute(subscriberId);
            return Ok(totalInvitesClicks);
        }
    }
}
