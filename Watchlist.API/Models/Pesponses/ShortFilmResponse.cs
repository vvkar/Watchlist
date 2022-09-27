namespace Watchlist.API.Models.Pesponses
{
    public record ShortFilmResponse
    {
        public string Id { get; init; }
        public string Title { get; init; }
        public string? Description { get; init; }
    }
}
