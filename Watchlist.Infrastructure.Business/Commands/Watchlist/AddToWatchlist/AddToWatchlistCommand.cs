using MediatR;
using Watchlist.Domain.Core.Models;

namespace Watchlist.Infrastructure.Business.Commands.Watchlist.AddToWatchlist
{
    public record AddToWatchlistCommand : IRequest<WatchlistItemModel>
    {
        public Guid UserId { get; init; }
        public string FilmId { get; init; }
        public AddToWatchlistCommand(Guid userId, string filmId)
        {
            UserId = userId;
            FilmId = filmId;
        }
    }
}
