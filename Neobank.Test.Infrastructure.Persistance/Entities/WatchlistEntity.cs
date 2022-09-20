namespace Neobank.Test.Infrastructure.Persistance.Entities
{
    public class WatchlistEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public IEnumerable<FilmEntity> Films { get; set; }
    }
}
