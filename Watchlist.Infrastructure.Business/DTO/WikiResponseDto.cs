using Newtonsoft.Json;
using Watchlist.Infrastructure.Business.DTO.Base;

namespace Watchlist.Infrastructure.Business.DTO
{
    public record WikiResponseDto : BaseResponseDto
    {
        [JsonProperty("plotShort")]
        public WikiDto Result { get; set; }
    }
}
