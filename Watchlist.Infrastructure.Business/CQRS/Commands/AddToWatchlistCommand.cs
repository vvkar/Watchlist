using AutoMapper;
using MediatR;
using Watchlist.Domain.Core.Exceptions;
using Watchlist.Domain.Core.Models;
using Watchlist.Domain.Interfaces.Repositories;
using Watchlist.Domain.Interfaces.Services;

namespace Watchlist.Infrastructure.Business.CQRS.Commands
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

            return await _repo.CreateAsync(model);
        }
    }
}
