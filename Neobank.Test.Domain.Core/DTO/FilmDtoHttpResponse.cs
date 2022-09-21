namespace Neobank.Test.Domain.Core.DTO
{
    public class FilmDtoHttpResponse
    {
        public string Expression { get; set; }
        public string ErrorMessage { get; set; }
        public IEnumerable<FilmDto> Results { get; set; }
    }
}
