namespace Neobank.Test.Infrastructure.Persistance.Entities
{
    public class FilmEntity
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public bool IsWatched { get; set; }

        public Guid WatchlistId { get; set; }
        public WatchlistEntity Watchlist { get; set; }
    }
}
