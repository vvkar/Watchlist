namespace Neobank.Test.Infrastructure.Business.DTO
{
    public record ShortFilmDto
    {
        public string Id { get; init; }
        public string Title { get; init; }
        public string ResultType { get; init; }
        public string? Description { get; init; }
    }
}
