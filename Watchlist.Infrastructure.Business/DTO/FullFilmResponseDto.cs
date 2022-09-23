using Watchlist.Infrastructure.Business.DTO.Base;

namespace Watchlist.Infrastructure.Business.DTO
{
    public record FullFilmResponseDto : BaseResponseDto
    {
        public string Id { get; init; }
        public string Title { get; init; }
        public string Type { get; init; }
        public double? ImDbRating { get; init; }
    }
}
