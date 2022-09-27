namespace Watchlist.API.Models.Requests
{
    public record AddToWatchlistRequest
    {
        public Guid UserId { get; init; }
        public string FilmId { get; init; }
    }
}
