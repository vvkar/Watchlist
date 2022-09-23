namespace Watchlist.Infrastructure.Business.DTO.Base
{
    public abstract record BaseResponseDto
    {
        public string? ErrorMessage { get; set; }
    }
}
