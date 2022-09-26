using Watchlist.Infrastructure.Business.DTO.Base;

namespace Watchlist.Infrastructure.Business.DTO
{
    public record PostersResponseDto : BaseResponseDto
    {
        public IEnumerable<PosterDto> Posters { get; init; }
    }
}
