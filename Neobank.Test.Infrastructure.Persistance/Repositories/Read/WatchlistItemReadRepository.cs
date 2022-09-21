using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Neobank.Test.Domain.Core.Models;
using Neobank.Test.Domain.Interfaces.Repositories.Read;
using Neobank.Test.Infrastructure.Persistance.Entities;
using Neobank.Test.Infrastructure.Persistance.Repositories.Base;

namespace Neobank.Test.Infrastructure.Persistance.Repositories.Read
{
    public class WatchlistItemReadRepository 
        : BaseReadRepository<WatchlistItemModel, WatchlistItemEntity>, IWatchlistItemReadRepository
    {
        public WatchlistItemReadRepository(IMapper mapper, AppDbContext context)
            : base(mapper, context)
        {
        }

        public async Task<WatchlistItemModel> GetAsync(Guid watchlistId, string itemId)
        {
            var entity = await _dbSet.AsNoTracking()
                            .Include(e => e.Watchlist).FirstOrDefaultAsync(e => e.Id == itemId && e.WatchlistId == watchlistId);

            var model = _mapper.Map<WatchlistItemModel>(entity);

            return model;
        }
    }
}
