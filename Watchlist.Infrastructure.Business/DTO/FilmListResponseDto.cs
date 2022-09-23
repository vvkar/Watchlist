using Watchlist.Infrastructure.Business.DTO.Base;

namespace Watchlist.Infrastructure.Business.DTO
{
    public record FilmListResponseDto : BaseResponseDto
    {
        public string Expression { get; init; }
        public IEnumerable<ShortFilmDto> Results { get; init; }
    }
}
