namespace Neobank.Test.Infrastructure.Persistance.Entities
{
    public class WatchlistItemEntity
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public double? ImDbRating { get; set; }
        
        //TODO: consider using enum
        public bool IsWatched { get; set; }
        public Guid UserId { get; set; }
        public DateTime? PromotionDate { get; set; }
    }
}
