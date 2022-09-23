using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Watchlist.Domain.Core.Models;
using Watchlist.Domain.Interfaces.Repositories.Write;
using Watchlist.Infrastructure.Persistance;
using Watchlist.Infrastructure.Persistance.Entities;

namespace Watchlist.Infrastructure.Persistance.Repositories.Write
{
    public class WatchlistItemWriteRepository : IWatchlistItemWriteRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public WatchlistItemWriteRepository(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<WatchlistItemModel> CreateAsync(WatchlistItemModel model)
        {
            var entity = _mapper.Map<WatchlistItemEntity>(model);

            _context.WatchlistItems.Add(entity);

            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<WatchlistItemModel> UpdateFullAsync(WatchlistItemModel model)
        {
            var entity = _mapper.Map<WatchlistItemEntity>(model);

            _context.WatchlistItems.Update(entity);

            await _context.SaveChangesAsync();

            return model;
        }
    }
}
