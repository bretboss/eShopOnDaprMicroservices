namespace Microsoft.eShopOnDapr.BlazorClient.Basket;

public class BasketClient
{
    private readonly HttpClient _httpClient;

    public BasketClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<BasketData> GetBasketAsync()
    {
        var basket = await _httpClient.GetFromJsonAsync<BasketData>(
            "b/api/v1/basket/");

        return basket!;
    }

    public async Task<BasketData> SaveBasketAsync(BasketData basket)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "b/api/v1/basket/",
            basket);

        response.EnsureSuccessStatusCode();

        var basketData = await response.Content.ReadFromJsonAsync<BasketData>();
        return basketData!;
    }

    public async Task CheckoutAsync(BasketCheckout basketCheckout)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "b/api/v1/basket/checkout",
            basketCheckout);

        response.EnsureSuccessStatusCode();
    }
}
