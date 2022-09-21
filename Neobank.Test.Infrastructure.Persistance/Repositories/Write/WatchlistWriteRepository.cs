using AutoMapper;
using Microsoft.Extensions.Logging;
using Neobank.Test.Domain.Core.Models;
using Neobank.Test.Domain.Interfaces.Repositories.Write;
using Neobank.Test.Infrastructure.Persistance.Entities;
using Neobank.Test.Infrastructure.Persistance.Repositories.Base;

namespace Neobank.Test.Infrastructure.Persistance.Repositories.Write
{
    public class WatchlistWriteRepository
        : BaseWriteRepository<WatchlistModel, WatchlistEntity>, IWatchlistWriteRepository
    {
        public WatchlistWriteRepository(IMapper mapper, AppDbContext context, ILogger logger) 
            : base(mapper, context, logger)
        {
        }
    }
}
