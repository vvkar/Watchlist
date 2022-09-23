﻿using MediatR;
using Watchlist.Domain.Core.Exceptions;
using Watchlist.Domain.Core.Models;
using Watchlist.Domain.Interfaces.Repositories.Read;
using Watchlist.Domain.Interfaces.Repositories.Write;

namespace Watchlist.Infrastructure.Business.CQRS.Commands
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

    public class ChangeFilmStatusCommandHandler
        : IRequestHandler<ChangeFilmStatusCommand, WatchlistItemModel>
    {
        private readonly IWatchlistItemReadRepository _readRepo;
        private readonly IWatchlistItemWriteRepository _writeRepo;
        public ChangeFilmStatusCommandHandler(
            IWatchlistItemReadRepository readRepo,
            IWatchlistItemWriteRepository writeRepo)
        {
            _readRepo = readRepo;
            _writeRepo = writeRepo;
        }

        public async Task<WatchlistItemModel> Handle(ChangeFilmStatusCommand request, CancellationToken cancellationToken)
        {
            var model = await _readRepo.GetAsync(request.UserId, request.FilmId);

            if (model is null)
                throw new NotFoundException($"User doesn't have in watchlist film with id: {request.FilmId}");

            model.IsWatched = !model.IsWatched;

            var updatedModel = await _writeRepo.UpdateFullAsync(model);

            return updatedModel;
        }
    }
}