using Neobank.Test.Infrastructure.Business.DTO.Base;

namespace Neobank.Test.Infrastructure.Business.DTO
{
    public record FilmListResponseDto : BaseResponseDto
    {
        public string Expression { get; init; }
        public IEnumerable<ShortFilmDto> Results { get; init; }
    }
}
