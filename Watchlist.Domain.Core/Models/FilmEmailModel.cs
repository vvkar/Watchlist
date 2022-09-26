namespace Watchlist.Domain.Core.Models
{
    public class FilmEmailModel
    {
        public FullFilmModel Film { get; set; }
        public PosterModel Poster { get; set; }
        public WikiModel Wiki { get; set; }
    }
}
