using MediatR;
using Watchlist.Domain.Core.Exceptions;
using Watchlist.Domain.Core.Models;
using Watchlist.Domain.Interfaces.Repositories;

namespace Watchlist.Infrastructure.Business.Commands.Watchlist.ChangeFilmStatus
{
    public record ChangeFilmStatusCommand : IRequest<WatchlistItemModel>
    {
        public Guid UserId { get; init; }
        public string FilmId { get; init; }
        public ChangeFilmStatusCommand(Guid userId, string filmId)
        {
            UserId = userId;
            FilmId = filmId;
        }
    }
}
