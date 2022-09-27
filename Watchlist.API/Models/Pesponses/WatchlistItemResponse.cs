namespace Watchlist.API.Models.Pesponses
{
    public class WatchlistItemResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public double? ImDbRating { get; set; }
        public bool IsWatched { get; set; }
    }
}