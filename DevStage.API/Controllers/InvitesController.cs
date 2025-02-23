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
        [Route("/{subscriberId}")]
        [EndpointDescription("Access invite link and redirects user to the event")]
        [ProducesResponseType(typeof(string), StatusCodes.Status302Found)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AccessInviteLink([FromRoute] Guid subscriberId, [FromServices] AccessInviteLinkUseCase useCase)
        {
            var redirectUrl = await useCase.Execute(subscriberId);
            return Redirect(redirectUrl);
        }

        [HttpGet]
        [Route("/{subscriberId}/totalInvites")]
        [EndpointDescription("Get total invites for the subscriber")]
        [ProducesResponseType(typeof(ResponseSusbcriberTotalInvites), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTotalInvites([FromRoute] Guid subscriberId, [FromServices] GetTotalInvitesUseCase useCase)
        {
            var totalInvites = await useCase.Execute(subscriberId);
            return Ok(totalInvites);
        }
    }
}
