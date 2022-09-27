namespace Watchlist.Infrastructure.Business.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage?> GetAsync(this HttpClient client, string method, string apiKey, string request)
        {
            return await client.GetAsync($"{method}/{apiKey}/{request}");
        }
    }
}
