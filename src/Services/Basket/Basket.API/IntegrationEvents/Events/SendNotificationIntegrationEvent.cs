namespace Microsoft.eShopOnDapr.Services.Basket.API.IntegrationEvents;

public record SendNotificationIntegrationEvent(string BuyerId, string NotificationType, Object Data) : IntegrationEvent;
