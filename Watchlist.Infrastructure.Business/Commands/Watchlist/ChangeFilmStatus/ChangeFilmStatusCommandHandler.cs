using MediatR;
using Watchlist.Domain.Core.Exceptions;
using Watchlist.Domain.Core.Models;
using Watchlist.Domain.Interfaces.Repositories;

namespace Watchlist.Infrastructure.Business.Commands.Watchlist.ChangeFilmStatus
{
    public class ChangeFilmStatusCommandHandler
        : IRequestHandler<ChangeFilmStatusCommand, WatchlistItemModel>
    {
        private readonly IWatchlistItemRepository _repo;
        public ChangeFilmStatusCommandHandler(IWatchlistItemRepository repo)
        {
            _repo = repo;
        }

        public async Task<WatchlistItemModel> Handle(ChangeFilmStatusCommand request, CancellationToken cancellationToken)
        {
            var model = await _repo.GetAsync(request.UserId, request.FilmId);

            if (model is null)
                throw new NotFoundException($"User doesn't have in watchlist film with id: {request.FilmId}");

            model.IsWatched = !model.IsWatched;

            var updatedModel = await _repo.UpdateFullAsync(model);

            return updatedModel;
        }
    }
}
