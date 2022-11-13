namespace Microsoft.eShopOnDapr.Services.Basket.API.IntegrationEvents.EventHandling;

public class BasketVerifiedIntegrationEventHandler
    : IIntegrationEventHandler<BasketVerifiedIntegrationEvent>
{
    private readonly IEventBus _eventBus;

    public BasketVerifiedIntegrationEventHandler(
        IEventBus eventBus)
    {
        _eventBus = eventBus;
    }

    public Task HandleAsync(BasketVerifiedIntegrationEvent @event) =>
        _eventBus.PublishAsync(new SendNotificationIntegrationEvent(@event.BasketActorId, "UpdatedBasketState", new {Status = "Validated" }));
}
