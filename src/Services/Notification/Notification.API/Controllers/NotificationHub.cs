using Microsoft.eShopOnDapr.Services.Notification.API.Infrastructure.Services;

namespace Microsoft.eShopOnDapr.Services.Ordering.API.Controllers;

[Authorize]
public class NotificationsHub : Hub
{
    private readonly ILogger<NotificationsHub> _logger;

    public NotificationsHub(ILogger<NotificationsHub> logger, IIdentityService identityService)
    {
        _logger = logger;
    }

    public override async Task OnConnectedAsync()
    {
        var buyerId = GetBuyerId();
        await Groups.AddToGroupAsync(Context.ConnectionId, buyerId);
        await base.OnConnectedAsync();

        _logger.LogInformation("Added {BuyerId} to Notifications.", buyerId);
    }

    public override async Task OnDisconnectedAsync(Exception? ex)
    {
        var buyerId = GetBuyerId();
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, buyerId);
        await base.OnDisconnectedAsync(ex);

        _logger.LogInformation("Removed {BuyerId} from Notifications.", buyerId);
    }

    // This context is not an HttpContext, so it is not the same as using IIdentityService.GetUserIdentity()
    private string GetBuyerId() => Context.User!.Claims.First(c => c.Type == "sub").Value;
}
