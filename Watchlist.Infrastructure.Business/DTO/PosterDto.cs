using Newtonsoft.Json;

namespace Watchlist.Infrastructure.Business.DTO
{
    public record PosterDto
    {
        [JsonProperty("link")]
        public string Uri { get; init; }
    }
}
