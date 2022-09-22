namespace Neobank.Test.API.Models.Requests
{
    public class ChangeFilmStatusRequest
    {
        public Guid UserId { get; set; }
        public string FilmId { get; set; }
    }
}
