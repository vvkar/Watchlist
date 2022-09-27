namespace Watchlist.API.Models.Requests
{
    public class ChangeFilmStatusRequest
    {
        public Guid UserId { get; set; }
        public string FilmId { get; set; }
        public bool IsWatched { get; set; }
    }
}
