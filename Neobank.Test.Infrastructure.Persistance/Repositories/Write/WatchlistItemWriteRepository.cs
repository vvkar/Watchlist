using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Neobank.Test.Domain.Core.Models;
using Neobank.Test.Domain.Interfaces.Repositories.Write;
using Neobank.Test.Infrastructure.Persistance.Entities;

namespace Neobank.Test.Infrastructure.Persistance.Repositories.Write
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
