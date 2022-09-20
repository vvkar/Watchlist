namespace Neobank.Test.API.Models.Options
{
    public class FilmSearchServiceOptions
    {
        public const string Section = "FilmSearchServices";
        public const string IMDB = "IMDB";

        public string BaseUri { get; set; }
        public string ApiKey { get; set; }
    }
}
