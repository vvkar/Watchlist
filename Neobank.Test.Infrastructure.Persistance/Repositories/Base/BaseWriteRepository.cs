using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Neobank.Test.Domain.Interfaces.Repositories.Base;

namespace Neobank.Test.Infrastructure.Persistance.Repositories.Base
{
    public abstract class BaseWriteRepository<TModel, TEntity> 
        : IBaseWriteRepository<TModel, TEntity> where TEntity: class
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        private readonly ILogger _logger;
        public BaseWriteRepository(IMapper mapper, AppDbContext context, ILogger logger)
        {
            _mapper = mapper;
            _context = context;
            _dbSet = _context.Set<TEntity>();
            _logger = logger;
        }

        public async Task<TModel> CreateAsync(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            _logger.LogInformation($"Adding entity to DB. Entity: {entity.GetType().Name}");
            var result = await _dbSet.AddAsync(entity);

            return _mapper.Map<TModel>(result.Entity);
        }

        //TODO: update async
    }
}
