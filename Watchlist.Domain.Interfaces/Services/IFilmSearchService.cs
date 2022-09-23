using Watchlist.Domain.Core.Models;

namespace Watchlist.Domain.Interfaces.Services
{
    public interface IFilmSearchService
    {
        Task<IEnumerable<ShortFilmModel>> GetFilmListByTitleAsync(string name);
        Task<FullFilmModel> GetFilmByIdAsync(string filmId);
    }
}
