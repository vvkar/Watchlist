namespace Neobank.Test.API.Models.Pesponses
{
    public record ValidationErrorResponse
    {
        public string Field { get; init; }
        public string? Details { get; init; }
    }
}
