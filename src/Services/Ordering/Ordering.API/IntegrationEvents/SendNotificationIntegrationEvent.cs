namespace Microsoft.eShopOnDapr.Services.Ordering.API.IntegrationEvents;

public record SendNotificationIntegrationEvent(string BuyerId, string NotificationType, Object Data) : IntegrationEvent;
