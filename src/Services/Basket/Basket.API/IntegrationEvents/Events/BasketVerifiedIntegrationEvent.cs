namespace Microsoft.eShopOnDapr.Services.Basket.API.IntegrationEvents.Events;

public record BasketVerifiedIntegrationEvent(
    string BasketActorId,
    string Description,
    decimal Total,
    string BuyerId)
    : IntegrationEvent;