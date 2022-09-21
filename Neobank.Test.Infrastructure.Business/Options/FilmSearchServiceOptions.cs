namespace Neobank.Test.Infrastructure.Business.Options
{
    public class FilmSearchServiceOptions
    {
        public const string Section = "FilmSearchServices";
        public const string IMDB = "IMDB";

        public string BaseUri { get; set; }
        public string ApiKey { get; set; }
    }
}
