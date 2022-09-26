using MediatR;
using Watchlist.Domain.Core.Models;
using Watchlist.Domain.Interfaces.Services;

namespace Watchlist.Infrastructure.Business.CQRS.Queries
{
    public record GetFilmQuery : IRequest<IEnumerable<ShortFilmModel>>
    {
        public string Title { get; init; }
        public GetFilmQuery(string title)
        {
            Title = title;
        }
    }

    public class GetFilmQueryHandler : IRequestHandler<GetFilmQuery, IEnumerable<ShortFilmModel>>
    {
        private readonly IFilmSearchService _searchService;
        public GetFilmQueryHandler(IFilmSearchService filmSearchService)
        {
            _searchService = filmSearchService;
        }
        public async Task<IEnumerable<ShortFilmModel>> Handle(GetFilmQuery request, CancellationToken cancellationToken)
        {
            var result = await _searchService.GetFilmListByTitleAsync(request.Title);

            if (!result.Any())
                throw new Exception("no content");

            return result;
        }
    }
}
