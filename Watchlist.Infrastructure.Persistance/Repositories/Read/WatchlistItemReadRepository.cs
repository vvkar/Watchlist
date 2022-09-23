using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Watchlist.Domain.Core.Models;
using Watchlist.Domain.Interfaces.Repositories.Read;
using Watchlist.Infrastructure.Persistance;

namespace Watchlist.Infrastructure.Persistance.Repositories.Read
{
    public class WatchlistItemReadRepository : IWatchlistItemReadRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public WatchlistItemReadRepository(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<WatchlistItemModel>> GetAllAsync()
        {
            var entityList = await _context.WatchlistItems.AsNoTracking().ToListAsync();

            var modelList = _mapper.Map<IEnumerable<WatchlistItemModel>>(entityList);

            return modelList;
        }

        public async Task<WatchlistItemModel> GetAsync(Guid userId, string itemId)
        {
            var entity = await _context.WatchlistItems.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == itemId && e.UserId == userId);

            var model = _mapper.Map<WatchlistItemModel>(entity);

            return model;
        }

        public async Task<IEnumerable<WatchlistItemModel>> GetByUserId(Guid userId)
        {
            var entityList = await _context.WatchlistItems
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .ToListAsync();

            var modelList = _mapper.Map<IEnumerable<WatchlistItemModel>>(entityList);

            return modelList;
        }
    }
}
