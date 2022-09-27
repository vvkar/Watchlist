using MediatR;
using Watchlist.Domain.Core.Exceptions;
using Watchlist.Domain.Core.Models;
using Watchlist.Domain.Interfaces.Services;

namespace Watchlist.Infrastructure.Business.Queries.Search.SearchFilms
{
    public class SearchFilmsQueryHandler : IRequestHandler<SearchFilmsQuery, IEnumerable<ShortFilmModel>>
    {
        private readonly IFilmSearchService _searchService;
        public SearchFilmsQueryHandler(IFilmSearchService filmSearchService)
        {
            _searchService = filmSearchService;
        }
        public async Task<IEnumerable<ShortFilmModel>> Handle(SearchFilmsQuery request, CancellationToken cancellationToken)
        {
            var result = await _searchService.GetFilmListByTitleAsync(request.Title);

            if (!result.Any())
                throw new NotFoundException();

            return result;
        }
    }
}
