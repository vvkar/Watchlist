namespace Neobank.Test.Domain.Core.Models
{
    public class FilmModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public bool IsWatched { get; set; }

        public Guid WatchlistId { get; set; }
        public WatchlistModel Watchlist { get; set; }
    }
}
