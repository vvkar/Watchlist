namespace Neobank.Test.Domain.Core.Models
{
    public class WatchlistModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public IEnumerable<FilmModel> Films { get; set; }
    }
}
