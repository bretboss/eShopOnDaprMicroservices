using System.Text.Json;

namespace Microsoft.eShopOnDapr.Services.Notification.API.IntegrationEvents.EventHandling;

public class SendNotificationIntegrationEventHandler : IIntegrationEventHandler<SendNotificationIntegrationEvent>
{
    private readonly IEventBus _eventBus;
    private readonly IHubContext<NotificationsHub> _hubContext;
    private readonly ILogger<SendNotificationIntegrationEventHandler> _logger;

    public SendNotificationIntegrationEventHandler(IEventBus eventBus, IHubContext<NotificationsHub> hubContext,
        ILogger<SendNotificationIntegrationEventHandler> logger)
    {
        _eventBus = eventBus;
        _hubContext = hubContext;
        _logger = logger;
    }

    public async Task HandleAsync(SendNotificationIntegrationEvent @event)
    {
        await _hubContext.Clients
            .Group(@event.BuyerId)
            .SendAsync(@event.NotificationType, @event.Data);

        _logger.LogInformation("Sent {NotificationType} to {BuyerId} with {Data}", @event.NotificationType, @event.BuyerId, JsonSerializer.Serialize(@event.Data));

        await _eventBus.PublishAsync(new SentNotificationIntegrationEvent(@event.BuyerId, @event.NotificationType, @event.Data));
    }
}
