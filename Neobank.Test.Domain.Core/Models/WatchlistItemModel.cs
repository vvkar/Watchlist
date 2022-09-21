namespace Neobank.Test.Domain.Core.Models
{
    public class WatchlistItemModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public double ImDbRating { get; set; }
        public bool IsWatched { get; set; }

        public Guid WatchlistId { get; set; }
        public WatchlistModel Watchlist { get; set; }
    }
}
