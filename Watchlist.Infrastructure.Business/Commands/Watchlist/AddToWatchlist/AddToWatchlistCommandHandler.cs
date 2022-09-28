using AutoMapper;
using MediatR;
using Watchlist.Domain.Core.Exceptions;
using Watchlist.Domain.Core.Models;
using Watchlist.Domain.Interfaces.Repositories;
using Watchlist.Domain.Interfaces.Services;

namespace Watchlist.Infrastructure.Business.Commands.Watchlist.AddToWatchlist
{
    public class AddToWatchlistCommandHandler : IRequestHandler<AddToWatchlistCommand, WatchlistItemModel>
    {
        private readonly IWatchlistItemRepository _repo;
        private readonly IFilmSearchService _searchService;
        private readonly IMapper _mapper;

        public AddToWatchlistCommandHandler(IWatchlistItemRepository repo,
                                            IFilmSearchService searchService,
                                            IMapper mapper)
        {
            _repo = repo;
            _searchService = searchService;
            _mapper = mapper;
        }

        public async Task<WatchlistItemModel> Handle(AddToWatchlistCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repo.GetAsync(request.UserId, request.FilmId);

            if (entity is not null)
                throw new AlreadyAddedException($"Film with id {request.FilmId} already added to watchlist!");

            var film = await _searchService.GetFilmByIdAsync(request.FilmId);

            var model = _mapper.Map<WatchlistItemModel>(film);
            model.UserId = request.UserId;
            model.IsWatched = false;
            //TODO: consider setting creation date as promotion date

            return await _repo.CreateAsync(model);
        }
    }
}