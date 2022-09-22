using Neobank.Test.Domain.Core.Models;

namespace Neobank.Test.Domain.Interfaces.Services
{
    public interface IFilmSearchService
    {
        Task<IEnumerable<ShortFilmModel>> GetFilmListByTitleAsync(string name);
        Task<FullFilmModel> GetFilmByIdAsync(string filmId);
    }
}
