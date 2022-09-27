namespace Watchlist.Infrastructure.Business.DTO
{
    public record ShortFilmDto
    {
        public string Id { get; init; }
        public string Title { get; init; }
        public string? Description { get; init; }
    }
}
