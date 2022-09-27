using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Watchlist.Domain.Core.Models;
using Watchlist.Domain.Interfaces.Repositories;
using Watchlist.Infrastructure.Persistance.Entities;

namespace Watchlist.Infrastructure.Persistance.Repositories
{
    public class WatchlistItemRepository : IWatchlistItemRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public WatchlistItemRepository(IMapper mapper, AppDbContext context)
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
            var entityList = await _context.WatchlistItems.AsNoTracking()
                                .Where(x => x.UserId == userId).ToListAsync();

            var modelList = _mapper.Map<IEnumerable<WatchlistItemModel>>(entityList);

            return modelList;
        }

        public async Task<IEnumerable<Guid>> GetUsersAsync()
        {
            var userIdList = await _context.WatchlistItems
                                .Select(x => x.UserId).Distinct().ToListAsync();

            return userIdList;
        }

        public async Task<WatchlistItemModel> UpdateFullAsync(WatchlistItemModel model)
        {
            var entity = _mapper.Map<WatchlistItemEntity>(model);

            _context.WatchlistItems.Update(entity);

            await _context.SaveChangesAsync();

            return model;
        }
        public async Task<WatchlistItemModel> CreateAsync(WatchlistItemModel model)
        {
            var entity = _mapper.Map<WatchlistItemEntity>(model);

            _context.WatchlistItems.Add(entity);

            await _context.SaveChangesAsync();

            return model;
        }

        //TODO: consider expression predicate
        public async Task<IEnumerable<WatchlistItemModel>> GetUnwatchedListByUserId(Guid userId)
        {
            var entityList = await _context.WatchlistItems.AsNoTracking()
                .Where(x => x.UserId == userId).OrderByDescending(x => x.ImDbRating).ToListAsync();

            var modelList = _mapper.Map<IEnumerable<WatchlistItemModel>>(entityList);
            return modelList;
        }
       
    }
}
