using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Neobank.Test.Domain.Core.Models;
using Neobank.Test.Domain.Interfaces.Repositories.Read;
using Neobank.Test.Infrastructure.Persistance.Entities;
using Neobank.Test.Infrastructure.Persistance.Repositories.Base;

namespace Neobank.Test.Infrastructure.Persistance.Repositories.Read
{
    public class WatchlistReadRepository 
        : BaseReadRepository<WatchlistModel, WatchlistEntity>, IWatchlistReadRepository
    {
        public WatchlistReadRepository(IMapper mapper, AppDbContext context)
            : base(mapper, context)
        {
        }

        public async Task<WatchlistModel> GetAsync(Guid id)
        {
            var entity = await _dbSet.AsNoTracking()
                .Include(e => e.Films).FirstOrDefaultAsync(e => e.Id == id);

            var model = _mapper.Map<WatchlistModel>(entity);

            return model;
        }
    }
}
