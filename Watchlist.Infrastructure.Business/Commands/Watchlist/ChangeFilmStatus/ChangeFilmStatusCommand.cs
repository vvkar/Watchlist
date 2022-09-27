using MediatR;
using Watchlist.Domain.Core.Models;

namespace Watchlist.Infrastructure.Business.Commands.Watchlist.ChangeFilmStatus
{
    public record ChangeFilmStatusCommand : IRequest<WatchlistItemModel>
    {
        public Guid UserId { get; init; }
        public string FilmId { get; init; }
        public bool IsWatched { get; init; }
        public ChangeFilmStatusCommand(Guid userId, string filmId, bool isWatched)
        {
            UserId = userId;
            FilmId = filmId;
            IsWatched = isWatched;
        }
    }
}
