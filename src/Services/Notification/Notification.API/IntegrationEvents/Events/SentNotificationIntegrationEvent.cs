namespace Microsoft.eShopOnDapr.Services.Notification.API.IntegrationEvents;

public record SentNotificationIntegrationEvent(string BuyerId, string NotificationType, object Data) : IntegrationEvent;
