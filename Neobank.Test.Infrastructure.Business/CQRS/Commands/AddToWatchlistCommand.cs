using AutoMapper;
using MediatR;
using Neobank.Test.Domain.Core.Exceptions;
using Neobank.Test.Domain.Core.Models;
using Neobank.Test.Domain.Interfaces.Repositories.Read;
using Neobank.Test.Domain.Interfaces.Repositories.Write;
using Neobank.Test.Domain.Interfaces.Services;

namespace Neobank.Test.Infrastructure.Business.CQRS.Commands
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
        private readonly IWatchlistItemReadRepository _readRepo;
        private readonly IWatchlistItemWriteRepository _writeRepo;
        private readonly IFilmSearchService _searchService;
        private readonly IMapper _mapper;

        public AddToWatchlistCommandHandler(
            IWatchlistItemReadRepository readRepo, 
            IWatchlistItemWriteRepository writeRepo,
            IFilmSearchService searchService,
            IMapper mapper)
        {
            _readRepo = readRepo;
            _writeRepo = writeRepo;
            _searchService = searchService;
            _mapper = mapper;
        }

        public async Task<WatchlistItemModel> Handle(AddToWatchlistCommand request, CancellationToken cancellationToken)
        {
            var entity = await _readRepo.GetAsync(request.UserId, request.FilmId);

            if (entity is not null)
                throw new AlreadyAddedException($"Film with id {request.FilmId} already added to watchlist!");

            var film = await _searchService.GetFilmByIdAsync(request.FilmId);

            var model = _mapper.Map<WatchlistItemModel>(film);

            model.UserId = request.UserId;

            return await _writeRepo.CreateAsync(model);
        }
    }
}
