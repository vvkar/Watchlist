using MediatR;
using Watchlist.Domain.Core.Models;

namespace Watchlist.Infrastructure.Business.Queries.Search.SearchFilms
{
    public record SearchFilmsQuery : IRequest<IEnumerable<ShortFilmModel>>
    {
        public string Title { get; init; }
        public SearchFilmsQuery(string title)
        {
            Title = title;
        }
    }
}
