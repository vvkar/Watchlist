namespace Neobank.Test.Infrastructure.Persistance.Entities
{
    public class WatchlistItemEntity
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public double ImDbRating { get; set; }
        public bool IsWatched { get; set; }

        public Guid WatchlistId { get; set; }
        public WatchlistEntity Watchlist { get; set; }
    }
}
