using AutoMapper;
using MediatR;
using Neobank.Test.Domain.Core.Exceptions;
using Neobank.Test.Domain.Core.Models;
using Neobank.Test.Domain.Interfaces.Repositories.Read;

namespace Neobank.Test.Infrastructure.Business.CQRS.Queries
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
        private readonly IWatchlistItemReadRepository _readRepo;
        private readonly IMapper _mapper;
        
        public GetWatchlistQueryHandler(IWatchlistItemReadRepository readRepo, IMapper mapper)
        {
            _readRepo = readRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WatchlistItemModel>> Handle(GetWatchlistQuery request, CancellationToken cancellationToken)
        {
            var modelList = await _readRepo.GetByUserId(request.UserId);
            
            if (!modelList.Any())
                throw new NotFoundException($"User doesn't have a watchlist!");

            return modelList;
        }
    }
}
