namespace Microsoft.eShopOnDapr.Services.Notification.API.IntegrationEvents;

public record SendNotificationIntegrationEvent(string BuyerId, string NotificationType, Object Data) : IntegrationEvent;
