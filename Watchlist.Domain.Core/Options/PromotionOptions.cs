namespace Watchlist.Domain.Core.Options
{
    public class PromotionOptions
    {
        public const string Promotion = "Promotion";

        public DayOfWeek DayOfWeek { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int MinimumFilmsLimit { get; set; }
        public int MinimumDaysAfterPromotion { get; set; }
    }
}
