using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Neobank.Test.Domain.Interfaces.Repositories.Base;

namespace Neobank.Test.Infrastructure.Persistance.Repositories.Base
{
    public abstract class BaseReadRepository<TModel, TEntity>
        : IBaseReadRepository<TModel, TEntity> where TEntity : class
    {
        protected readonly IMapper _mapper;
        protected readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseReadRepository(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            var entityList = await _dbSet.AsNoTracking().ToListAsync();

            var modelList = _mapper.Map<IEnumerable<TModel>>(entityList);

            return modelList;
        }
    }
}
