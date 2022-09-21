namespace Neobank.Test.API.Models.Pesponses
{
    public record FilmResponse
    {
        public string Id { get; init; }
        public string Title { get; init; }
        public string ResultType { get; init; }
        public string Description { get; init; }
    }
}
