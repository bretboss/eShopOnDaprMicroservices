using Microsoft.eShopOnDapr.Services.Notification.API.IntegrationEvents;
using Microsoft.eShopOnDapr.Services.Notification.API.IntegrationEvents.EventHandling;

namespace Microsoft.eShopOnDapr.Services.Ordering.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class IntegrationEventController : ControllerBase
{
    private const string DAPR_PUBSUB_NAME = "pubsub";

    [HttpPost("SendNotification")]
    [Topic(DAPR_PUBSUB_NAME, nameof(SendNotificationIntegrationEvent))]
    public Task HandleAsync(
        SendNotificationIntegrationEvent @event,
        [FromServices] SendNotificationIntegrationEventHandler handler) =>
        handler.HandleAsync(@event);
}
