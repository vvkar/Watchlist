using Newtonsoft.Json;

namespace Watchlist.Infrastructure.Business.DTO
{
    public record WikiDto
    {
        [JsonProperty("plainText")]
        public string TextDescription { get; init; }

        [JsonProperty("html")]
        public string HtmlDescription { get; init; }
    }
}
