using MediatR;
using Watchlist.Domain.Core.Exceptions;
using Watchlist.Domain.Core.Models;
using Watchlist.Domain.Interfaces.Repositories;

namespace Watchlist.Infrastructure.Business.CQRS.Queries
{
    public record GetWatchlistQuery : IRequest<IEnumerable<WatchlistItemModel>>
    {
        public Guid UserId { get; init; }
        public GetWatchlistQuery(Guid userId)
        {
            UserId = userId;
        }
    }

    public class GetWatchlistQueryHandler
        : IRequestHandler<GetWatchlistQuery, IEnumerable<WatchlistItemModel>>
    {
        private readonly IWatchlistItemRepository _repo;

        public GetWatchlistQueryHandler(IWatchlistItemRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<WatchlistItemModel>> Handle(GetWatchlistQuery request, CancellationToken cancellationToken)
        {
            var modelList = await _repo.GetByUserId(request.UserId);

            if (!modelList.Any())
                throw new NotFoundException($"User doesn't have a watchlist!");

            return modelList;
        }
    }
}
