using Neobank.Test.Domain.Core.DTO;

namespace Neobank.Test.Domain.Interfaces.Services
{
    public interface IFilmSearchService
    {
        Task<IEnumerable<FilmDto>> GetFilmByTitleAsync(string name);
    }
}
