using Watchlist.Domain.Core.Models;

namespace Watchlist.Domain.Interfaces.Services
{
    public interface IFilmSearchService
    {
        Task<IEnumerable<ShortFilmModel>> GetFilmListByTitleAsync(string name);
        Task<FullFilmModel> GetFilmByIdAsync(string filmId);
        Task<PosterModel> GetPosterByIdAsync(string filmId);
        Task<WikiModel> GetWikiByIdAsync(string filmId);
        Task<FilmEmailModel> GetFilmEmailModelByIdAsync(string filmId);
    }
}
