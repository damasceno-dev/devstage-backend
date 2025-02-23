using DevStage.Application.UseCases.Subscriptions.GetTotalSubscriptions;
using DevStage.Application.UseCases.Subscriptions.Register;
using DevStage.Communication.Requests;
using DevStage.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevStage.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        [HttpPost]
        [EndpointDescription("Subscribes to the event")]
        [ProducesResponseType(typeof(ResponseRegisterSubscriptionJson),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Subscriptions([FromBody]RequestRegisterSubscriptionJson request, [FromServices]RegisterSubscriptionUseCase useCase)
        {
            var response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }
        
        [HttpGet]
        [Route("/{subscriberId}/totalSubscriptions")]
        [EndpointDescription("Get total converted invites into subscription for the subscriber")]
        [ProducesResponseType(typeof(ResponseSubscriberTotalSubscriptions), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTotalSubscriptions([FromRoute] Guid subscriberId, [FromServices] GetTotalSubscriptionsUseCase useCase)
        {
            var totalSubscriptions = await useCase.Execute(subscriberId);
            return Ok(totalSubscriptions);
        }
    }
}
