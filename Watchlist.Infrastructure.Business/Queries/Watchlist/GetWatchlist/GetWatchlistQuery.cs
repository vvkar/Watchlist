using MediatR;
using Watchlist.Domain.Core.Models;

namespace Watchlist.Infrastructure.Business.Queries.Watchlist.GetWatchlist
{
    public record GetWatchlistQuery : IRequest<IEnumerable<WatchlistItemModel>>
    {
        public Guid UserId { get; init; }
        public GetWatchlistQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
